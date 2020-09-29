using ScreenCut.src.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScreenCut.src.model
{
    class UpdateCheck
    {
        public static UpdateInfo checkUpdate() {
            UpdateInfo update = null;
            try
            {
                string response = HttpHelper.downloadWebSiteUseGet("http://freedraw.xyz/wineasy/update.json");
                JObject jo = (JObject)JsonConvert.DeserializeObject(response);
                string version = jo["version"].ToString();
                string desc = jo["desc"].ToString();
                string downloadLink = jo["downloadLink"].ToString();
                update = new UpdateInfo(version, desc, downloadLink);
            }
            catch { 

            }
            
            return update;
        }
    }
}
