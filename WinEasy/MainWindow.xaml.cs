using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System;
using Microsoft.Win32;
using ScreenCut.src.model;

namespace ScreenCut
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        int startUp = 0;
        public MainWindow()
        {
            InitializeComponent();
            initView();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MoveMainWindow(object sender, MouseButtonEventArgs e) {
            base.DragMove();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            //this.notifyIcon1.Visible = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process snippingToolProcess = new Process();
            snippingToolProcess.EnableRaisingEvents = true;
            if (!Environment.Is64BitProcess)
            {
                snippingToolProcess.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
                snippingToolProcess.Start();
            }
            else
            {
                snippingToolProcess.StartInfo.FileName = "C:\\Windows\\system32\\SnippingTool.exe";
                snippingToolProcess.Start();
            }

        }

        private void cbWindowsDefenderChecked(object sender, RoutedEventArgs e)
        {
            if (startUp == 1) {
                startUp = 2;
                return;
            }
            
            if (cbWindowsDefender.IsChecked == true)
            {
                bool success = WindowsDenfenderManager.closeWindowsDefenderManager();
                if (success)
                {
                    MessageBox.Show("关闭Windows Defender成功！重启生效");
                }
                else
                {
                    MessageBox.Show("失败，请以管理员权限运行");
                    return;
                }
            }
            else 
            {
                bool success = WindowsDenfenderManager.openWindowsDefenderManager();
                if (success)
                {
                    MessageBox.Show("开启Windows Defender成功！重启生效");
                }
                else
                {
                    MessageBox.Show("失败，请以管理员权限运行");
                    return;
                }
            }
        }

        private void initView() {
            bool isOpen = WindowsDenfenderManager.isOpen();
            if (isOpen) {
                startUp = 2;
            }
            else {
                startUp = 1;
                cbWindowsDefender.IsChecked = true;
            }
            bool isScreenToolAdded = ScreenShotManager.isAdded();
            if (isScreenToolAdded) {
                cbScreenShot.IsChecked = true;
            }

            if (CmdManager.isAdded() == true) {
                cbCmd.IsChecked = true;
            }
            
        }

        private void cbScreenShot_Checked(object sender, RoutedEventArgs e)
        {
            if (cbScreenShot.IsChecked == true)
            {
                ScreenShotManager.addScreenShotToRightMenu();
            }
            else {
                ScreenShotManager.removeScreenShotToRightMenu();
            }
            
        }

        private void cbCmd_Checked(object sender, RoutedEventArgs e) {
            if (cbCmd.IsChecked == true)
            {
                CmdManager.addCmdToRightMenu();
            }
            else
            {
                CmdManager.removeSCmdToRightMenu();
            }
        }

        private void btnOpenGitHub_Clicked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/bestyize/WinEasy");
        }
    }
}
