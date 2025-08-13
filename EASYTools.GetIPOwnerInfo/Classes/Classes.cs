namespace EASYTools.GetIPOwnerInfoTool.Classes {

    internal class IPList {
        public string ip { get; set; }
    }

    internal class Config {
        public string checkOwnerIpUrl { get; set; } = "http://ip-api.com/json/";
    }
}