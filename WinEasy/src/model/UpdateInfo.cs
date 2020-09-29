using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCut.src.model
{
    public class UpdateInfo
    {
        public static string currVersion = "1.0.1";
        public string version;
        public string desc;
        public string downloadLink;

        public UpdateInfo(string version, string desc, string downloadLink) {
            this.version = version;
            this.desc = desc;
            this.downloadLink = downloadLink;
        }

        
    }
}
