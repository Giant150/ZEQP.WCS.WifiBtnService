using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WiFiBtnClient
{
    public partial class Form1 : Form
    {
        public TcpClient Client { get; set; }
        public NetworkStream Stream { get; set; }
        private byte[] DeviceNo { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.Client = new TcpClient();
            this.DeviceNo = new byte[4];
        }

        private async void btnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var ip = txtIP.Text;
                var port = int.Parse(txtPort.Text);
                await this.Client.ConnectAsync(ip, port);
                btnConnection.Enabled = !this.Client.Connected;
                btnConnectionClose.Enabled = this.Client.Connected;
                if (this.Client.Connected)
                {
                    this.Stream = this.Client.GetStream();
                    MessageBox.Show("���ӳɹ�");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnectionClose_Click(object sender, EventArgs e)
        {
            if (this.Client.Connected)
                this.Client.Close();
        }

        #region Address
        private async void btnReadAddr_Click(object sender, EventArgs e)
        {
            var cmdBytes = new byte[] { 0x3A, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x41, 0x00, 0x01, 0x00, 0x77 };
            cmdBytes = UpdateCheckSum(cmdBytes);
            WriteLog($"�������ӻ����豸��ַ��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
            await this.Stream.WriteAsync(cmdBytes);
            var buffer = new byte[1024];
            int received = await this.Stream.ReadAsync(buffer);
            WriteLog($"�������ӻ����豸��ַ�󣬴ӻ����أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            this.DeviceNo = buffer.Skip(10).Take(4).ToArray();
            txtAddr.Text = GetCmdString(this.DeviceNo);
        }
        
        private async void btnWriteAddr_Click(object sender, EventArgs e)
        {
            var deviceNo = GetByteCommand(txtAddr.Text);
            if (deviceNo.Length != 4)
            {
                MessageBox.Show("�豸��ַ����ȷ");
                return;
            }
            var cmdBytes = new byte[] { 0x3A, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x61, 0x00, 0x05, 0x00, 0x00, 0x02, 0x00, 0x01, 0x9E };
            deviceNo.CopyTo(cmdBytes, 10);
            cmdBytes = UpdateCheckSum(cmdBytes);
            WriteLog($"����д�ӻ����豸��ַ��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
            await this.Stream.WriteAsync(cmdBytes);
            var buffer = new byte[1024];
            int received = await this.Stream.ReadAsync(buffer);
            WriteLog($"����д�ӻ����豸��ַ�󣬴ӻ����أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            this.DeviceNo = deviceNo;
            txtAddr.Text = GetCmdString(this.DeviceNo);
        }
        #endregion

        #region ��ť���
        private async void btnWrite1Status0_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x01, 0x00, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite2Status0_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x02, 0x00, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite3Status0_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x03, 0x00, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite4Status0_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x04, 0x00, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ��ť����
        private async void btnWrite1Status1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x01, 0x01, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite2Status1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x02, 0x01, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite3Status1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x03, 0x01, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite4Status1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x83, 0x00, 0x02, 0x04, 0x01, 0xC9 };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·�״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ��ť����
        private async void btnWrite1Light1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x01, 0x01, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite2Light1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x02, 0x01, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite3Light1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x03, 0x01, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite4Light1_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x04, 0x01, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ��ť����
        private async void btnWrite1Light3_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x01, 0x03, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite2Light3_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x02, 0x03, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite3Light3_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x03, 0x03, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnWrite4Light3_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(1000);
                cts.Token.Register(() => Console.WriteLine($"������ȡ��!"));
                var cmdBytes = new byte[] { 0x3A, 0x00, 0x01, 0x00, 0x02, 0x05, 0x93, 0x00, 0x06, 0x04, 0x03, 0x00, 0x00, 0x00, 0x01, 0xDE };
                this.GetReverseDeviceNo().CopyTo(cmdBytes, 1);
                cmdBytes = UpdateCheckSum(cmdBytes);
                WriteLog($"����·�����״̬��{Environment.NewLine}{GetCmdString(cmdBytes)}{Environment.NewLine}");
                await this.Stream.WriteAsync(cmdBytes, cts.Token);
                var buffer = new byte[1024];
                int received = await this.Stream.ReadAsync(buffer, cts.Token);
                WriteLog($"����·���״̬�󣬰�ť�з��أ�{Environment.NewLine}{GetCmdString(buffer.Take(received).ToArray())}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region helper
        private string GetCmdString(byte[] bytes)
        {
            var hexResult = bytes.Select(s => Convert.ToHexString(new byte[] { s })).ToArray();
            return string.Join(" ", hexResult);
        }

        private byte[] GetByteCommand(string cmd)
        {
            var charArray = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return charArray.Select(s => Convert.ToByte(s, 16)).ToArray();
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
        /// �豸��ַȡ��
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
        private void WriteLog(string msg)
        {
            txtLog.Text += msg;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
        #endregion
    }
}