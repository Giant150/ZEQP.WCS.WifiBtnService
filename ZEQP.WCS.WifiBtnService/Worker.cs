using System;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

namespace ZEQP.WCS.WifiBtnService
{
    public class Worker : BackgroundService
    {
        public ILogger<Worker> Logger { get; set; }
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        public DeviceConfig Config { get; set; }
        public byte[] DeviceNo { get; set; }
        public Worker(IConfiguration config, ILogger<Worker> logger)
        {
            this.Logger = logger;
            this.Config = config.GetSection(nameof(DeviceConfig)).Get<DeviceConfig>();
            this.DeviceNo = BitConverter.GetBytes(this.Config.DeviceNo);
            this.Client = new TcpClient();
        }
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            this.Logger.LogInformation($"开始连接到设备:{this.Config.IP}:{this.Config.Port}");
            await this.Client.ConnectAsync(this.Config.IP, this.Config.Port, cancellationToken);
            this.Stream = this.Client.GetStream();
            await Init(cancellationToken);
            await base.StartAsync(cancellationToken);
        }
        /// <summary>
        /// 初始化设备
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Init(CancellationToken cancellationToken)
        {
            this.Logger.LogInformation("开始初始化设备");
            await Init41(cancellationToken);

            await Init93(0x01, 0x03, cancellationToken);
            await Init93(0x02, 0x03, cancellationToken);
            await Init93(0x03, 0x03, cancellationToken);
            await Init93(0x04, 0x03, cancellationToken);

            await Init83(0x01, 0x00, cancellationToken);
            await Init83(0x02, 0x00, cancellationToken);
            await Init83(0x03, 0x00, cancellationToken);
            await Init83(0x04, 0x00, cancellationToken);

            this.Logger.LogInformation("初始化设备完成");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.Logger.LogInformation($"等待按钮盒主动上传按键状态");
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, stoppingToken);
                this.Logger.LogInformation($"按钮盒主动上传按键状态：{GetCmdString(buffer.Take(received).ToArray())}");
                if (buffer[6] == 0x73)
                {
                    var index = buffer[9];//按钮1~4
                    var status = buffer[10];
                    this.Logger.LogInformation($"按钮盒主动上传({index.ToString("X")})按键({(status == 0x00 ? "完成" : "呼叫")})状态");
                    var cmdBytes = new byte[] { 0x2A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x73, 0x00, 0x01, 0x01, 0xA7 };
                    this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                    cmdBytes[9] = index;
                    cmdBytes = UpdateCheckSum(cmdBytes);
                    this.Logger.LogInformation($"按钮盒主动上传按键状态后，软件返回：{GetCmdString(cmdBytes)}");
                    await this.Stream.WriteAsync(cmdBytes, stoppingToken);
                    if (status == 0x01)//呼叫
                    {
                        await Init93(index, 0x01, stoppingToken);//把对应按钮灯点亮
                        await Task.Delay(3000, stoppingToken);
                        await Init93(index, 0x03, stoppingToken);//把对应按钮灯点灭
                        await Init83(index, 0x00, stoppingToken);//把对应按钮的状态修改为完成
                    }
                }
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            this.Stream.Close();
            if (this.Client.Connected)
                this.Client.Close();
            return base.StopAsync(cancellationToken);
        }

        #region Helper
        /// <summary>
        /// 初始化设备地址
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task Init41(CancellationToken cancellationToken)
        {

            var cmdBytes = new byte[] { 0x3A, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x41, 0x00, 0x01, 0x00, 0x77 };
            cmdBytes = UpdateCheckSum(cmdBytes);
            this.Logger.LogInformation($"主机读从机的设备地址：{GetCmdString(cmdBytes)}");
            await this.Stream.WriteAsync(cmdBytes, cancellationToken);
            var buffer = new byte[1024];
            int received = await this.Stream.ReadAsync(buffer, cancellationToken);
            this.Logger.LogInformation($"主机读从机的设备地址后，从机返回：{GetCmdString(buffer.Take(received).ToArray())}");
            //2A FF FF FF FF FF 41 00 05 00 00 02 00 01 6E
            if (BitConverter.ToInt32(buffer, 10) != this.Config.DeviceNo)
            {
                cmdBytes = new byte[] { 0x3A, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x61, 0x00, 0x05, 0x00, 0x00, 0x02, 0x00, 0x01, 0x9E };
                this.DeviceNo.CopyTo(cmdBytes, 10);
                cmdBytes = UpdateCheckSum(cmdBytes);
                this.Logger.LogInformation($"主机写从机的设备地址：{GetCmdString(cmdBytes)}");
                await this.Stream.WriteAsync(cmdBytes, cancellationToken);
                received = await this.Stream.ReadAsync(buffer, cancellationToken);
                this.Logger.LogInformation($"主机写从机的设备地址后，从机返回：{GetCmdString(buffer.Take(received).ToArray())}");
            }
        }

        /// <summary>
        /// 初始化按键状态
        /// </summary>
        /// <param name="index">按钮索引0x01,0x02,0x03,0x04</param>
        /// <param name="status">按键状态0x00完成,0x01呼叫</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task Init83(byte index, byte status, CancellationToken cancellationToken)
        {
            var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x01, 0x00, 0xC9 };
            this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
            cmdBytes[9] = index;
            cmdBytes[10] = status;
            cmdBytes = UpdateCheckSum(cmdBytes);
            this.Logger.LogInformation($"软件下发({index})按键({(status==0x00?"完成":"呼叫")})状态：{GetCmdString(cmdBytes)}");
            await this.Stream.WriteAsync(cmdBytes, cancellationToken);
            var buffer = new byte[1024];
            var received = await this.Stream.ReadAsync(buffer, cancellationToken);
            this.Logger.LogInformation($"软件下发完成状态后，按钮盒返回：{GetCmdString(buffer.Take(received).ToArray())}");
        }

        /// <summary>
        /// 初始化灯状态
        /// </summary>
        /// <param name="index">按钮索引0x01,0x02,0x03,0x04</param>
        /// <param name="status">按键状态0x01亮,0x02闪,0x03灭,0x04亮多长时间,0x05闪多长时间</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task Init93(byte index, byte status, CancellationToken cancellationToken)
        {
            var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x01, 0x01, 0x00, 0x00, 0x00, 0x01, 0xDE };
            this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
            cmdBytes[9] = index;
            cmdBytes[10] = status;
            cmdBytes = UpdateCheckSum(cmdBytes);
            this.Logger.LogInformation($"软件下发({index})灯({status})状态：{GetCmdString(cmdBytes)}");
            await this.Stream.WriteAsync(cmdBytes, cancellationToken);
            var buffer = new byte[1024];
            var received = await this.Stream.ReadAsync(buffer, cancellationToken);
            this.Logger.LogInformation($"软件下发灯状态后，按钮盒返回：{GetCmdString(buffer.Take(received).ToArray())}");
        }
        private byte[] UpdateCheckSum(byte[] bytes)
        {
            int num = 0;
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                num += bytes[i];
            }
            num = num & 0xff;
            var str = num.ToString("X");
            var checkSum = Convert.ToByte(str, 16);
            bytes[bytes.Length - 1] = checkSum;
            return bytes;
        }
        /// <summary>
        /// 设备地址取反
        /// </summary>
        /// <returns></returns>
        private byte[] GetReverseDeviceNo()
        {
            var deviceBytes = new byte[4];
            deviceBytes[0] = this.DeviceNo[2];
            deviceBytes[1] = this.DeviceNo[3];
            deviceBytes[2] = this.DeviceNo[0];
            deviceBytes[3] = this.DeviceNo[1];
            return deviceBytes;
        }
        private string GetCmdString(byte[] bytes)
        {
            var hexResult = bytes.Select(s => Convert.ToHexString(new byte[] { s })).ToArray();
            return string.Join(" ", hexResult);
        }
        #endregion
    }
}