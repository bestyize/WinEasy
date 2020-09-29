using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCut.src.model
{
    class WindowsDenfenderManager
    {
        public static bool openWindowsDefenderManager() {
            bool succ=true;
            //关闭安全健康服务
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService", true);
            software1.SetValue("Start", 2);
            string GetValue1 = software1.GetValue("Start").ToString();
            if (GetValue1 == "2")
            {
                //MessageBox.Show("开启安全健康服务成功！重启生效");
            }
            else
            {
                succ= false;
            }

            //关闭window Defender安全中心服务
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc", true);
            software2.SetValue("Start", 2);
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "2")
            {
                //MessageBox.Show("关闭成功！重启生效");
            }
            else
            {
                succ= false;
            }

            return succ;
        }

        public static bool closeWindowsDefenderManager()
        {
            bool succ = true;
            //关闭安全健康服务
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService", true);
            software1.SetValue("Start", 4);
            string GetValue1 = software1.GetValue("Start").ToString();
            if (GetValue1 == "4")
            {
                //MessageBox.Show("关闭安全健康服务成功！重启生效");
            }
            else
            {
                succ= false;
            }

            //关闭window Defender安全中心服务
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc", true);
            software2.SetValue("Start", 4);
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "4")
            {
                //MessageBox.Show("关闭成功！重启生效");
            }
            else
            {
                succ= false;
            }

            return succ;
        }

        public static bool isOpen() {
            bool isOpen = true;
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService", true);
            string GetValue1 = software1.GetValue("Start").ToString();
            if (GetValue1 == "2")
            {
                
            }
            else
            {
                isOpen = false;
            }

            //关闭window Defender安全中心服务
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc", true);
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "2")
            {
               
            }
            else
            {
                isOpen = false;
            }

            return isOpen;
        }
    }
}
