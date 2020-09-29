using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCut.src.model
{
    class CmdManager
    {
        public static void addCmdToRightMenu()
        {
            RegistryKey reg = Registry.ClassesRoot;
            reg.CreateSubKey(@"Directory\Background\shell\OpenCmdHere");
            reg.CreateSubKey(@"Directory\Background\shell\OpenCmdHere\command");

            RegistryKey sw1 = reg.OpenSubKey(@"Directory\Background\shell\OpenCmdHere", true);
            //string GetValue1 = sw.GetValue("Start").ToString();
            sw1.SetValue("", @"命令行");
            sw1.SetValue("Icon", @"C:\\Windows\\System32\\cmd.exe");

            RegistryKey sw2 = reg.OpenSubKey(@"Directory\Background\shell\OpenCmdHere\command", true);
            sw2.SetValue("", @"cmd.exe -noexit -command Set-Location -literalPath %V");

        }

        public static void removeSCmdToRightMenu()
        {
            RegistryKey reg = Registry.ClassesRoot;
            reg.DeleteSubKeyTree(@"Directory\Background\shell\OpenCmdHere");
        }

        public static bool isAdded()
        {

            RegistryKey reg = Registry.ClassesRoot;
            RegistryKey sw = reg.OpenSubKey(@"Directory\Background\shell\OpenCmdHere");
            return sw != null;
        }
    }
}
