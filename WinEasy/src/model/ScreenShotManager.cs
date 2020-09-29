using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCut.src.model
{
    class ScreenShotManager
    {
        public static void addScreenShotToRightMenu()
        {
            RegistryKey reg = Registry.ClassesRoot;
            reg.CreateSubKey(@"Directory\Background\shell\SnippingTool");
            reg.CreateSubKey(@"Directory\Background\shell\SnippingTool\command");

            RegistryKey sw1 = reg.OpenSubKey(@"Directory\Background\shell\SnippingTool", true);
            //string GetValue1 = sw.GetValue("Start").ToString();
            sw1.SetValue("",@"截图");
            sw1.SetValue("Icon", @"C:\\Windows\\System32\\SnippingTool.exe");

            RegistryKey sw2 = reg.OpenSubKey(@"Directory\Background\shell\SnippingTool\command", true);
            sw2.SetValue("",@"C:\\Windows\\System32\\SnippingTool.exe");

        }

        public static void removeScreenShotToRightMenu() {
            RegistryKey reg = Registry.ClassesRoot;
            reg.DeleteSubKeyTree(@"Directory\Background\shell\SnippingTool");
        }

        public static bool isAdded() {
            
            RegistryKey reg = Registry.ClassesRoot;
            RegistryKey sw = reg.OpenSubKey(@"Directory\Background\shell\SnippingTool");
            return sw!=null;
        }
    }
}
