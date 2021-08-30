using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 无边框拖动效果
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Start_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

        }
        int a = 1;
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            //a = a + 1;
            //if (a % 2 == 0 )
            //{

                //this.Left = 0.0;
               // this.Top = 0.0;
               //this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                //this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                //double w = SystemParameters.PrimaryScreenWidth;
                // double h = System.Windows.SystemParameters.PrimaryScreenHeight;
                // for (double i = this.Width; i < w; i++)
                //{
                // Thread.Sleep(1 % 10);//每次累加都延时30毫秒，100次为3000毫秒
                // this.Width
                // ++;



                // }


                // for (double i = this.Height; i < h; i++)
                //{
                // double t = 0.001;
                //Thread.Sleep(1% 10);//每次累加都延时30毫秒，100次为3000毫秒
                // this.Height
                // ++;
                //  }
               //L.Width = System.Windows.SystemParameters.PrimaryScreenWidth/10;
                //L.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            //}
            //else
            //{

               
               // this.Width = 640.281;
               // this.Height = 391;
           // }
           
            
        }
        private void Move_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)

        {

            if (e.LeftButton == MouseButtonState.Pressed)

            {

                this.DragMove();

            }

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            button7.Margin =
               new Thickness(-17, 10, 0, 0);
            R.Margin =
               new Thickness(142, 18, 0, 0);
            R2.Margin =
              new Thickness(142, 372, 0, -354);
            R3.Margin =
              new Thickness(142, 730, 0, -712);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            button7.Margin =
                new Thickness(-17, 44, 0, 0);
            R.Margin =
               new Thickness(142, 372, 0, -354);
            R2.Margin =
              new Thickness(142, 18, 0, 0);
            R3.Margin =
             new Thickness(142, 730, 0, -712);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            button7.Margin =
               new Thickness(-17, 78, 0, 0);
            R3.Margin =
              new Thickness(142, 18, 0, 0);
            R2.Margin =
              new Thickness(142, 372, 0, -354);
            R.Margin =
              new Thickness(142, 730, 0, -712);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("Java路径不能为空", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                if (System.Windows.MessageBox.Show("java路径为“" + TextBox1.Text + " ”是否正确", "确认信息", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
                {
                    button4.IsEnabled = false;
                    String EnvironmentPath = System.Environment
                .GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine);


                    Environment.SetEnvironmentVariable("path", EnvironmentPath + @"%JAVA_HOME%\bin;%JAVA_HOME%\jre\bin;", EnvironmentVariableTarget.Machine);
                    Environment.SetEnvironmentVariable("Classpath", @".;%JAVA_HOME%\lib\dt.jar;%JAVA_HOME%\lib\tools.jar;", EnvironmentVariableTarget.Machine);


                    Environment.SetEnvironmentVariable("JAVA_HOME", TextBox1.Text, EnvironmentVariableTarget.Machine);
                    button4.IsEnabled = true;
                   
                   
                    if (System.Windows.MessageBox.Show("配置完成需要重启以生效，是否现在重启", "确认信息", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
                    {
                        Process myProcess = new Process();
                        myProcess.StartInfo.FileName = "cmd.exe";
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.RedirectStandardInput = true;
                        myProcess.StartInfo.RedirectStandardOutput = true;
                        myProcess.StartInfo.RedirectStandardError = true;
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.Start();
                        myProcess.StandardInput.WriteLine("shutdown -r -t 1");
                    }
                }
                else
                {
                    MessageBox.Show("操作已取消", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox2.Text == "")
            {
                MessageBox.Show("请选择Java版本", "提醒");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择系统版本", "提醒");
            }
            else
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = comboBox1.Text + comboBox2.Text;
                myProcess.Start();
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择java安装目录";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show("文件夹路径不能为空", "提示");
                    return;
                }
                TextBox1.Text = dialog.SelectedPath;
            }
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
