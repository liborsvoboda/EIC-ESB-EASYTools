using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Xml;


namespace EASYTools.LicenseVerify {

    public class LicenseData {
        public string? Status { get; set; }
        public string? PublicKey { get; set; }
        public string? Key { get; set; }
        public DateTime? ExpireDate { get; set; } = null;
        public string? Product { get; set; }
        public string? Version { get; set; }
        public string? LicenseOwner { get; set; }
    }

    public class LicenseControlller {
        public static bool VerifyLicense(out LicenseData lic_model, bool isServerCheck) {
            lic_model = new LicenseData();
            try {
                XmlDocument xmlDoc = new();
                xmlDoc.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data","license.lic"));

                string pubKey = xmlDoc.SelectSingleNode("//License/PublicKey").InnerXml;
                xmlDoc.SelectSingleNode("//License/PublicKey").RemoveAll();

                lic_model.Product = xmlDoc.SelectSingleNode("//License/Product").InnerText;
                lic_model.LicenseOwner = xmlDoc.SelectSingleNode("//License/LicenseOwner").InnerText;
                lic_model.Key = xmlDoc.SelectSingleNode("//License/Key").InnerText;
                XmlNode userNodes = xmlDoc.SelectSingleNode("//License/ExpireDate");

                lic_model.ExpireDate = (userNodes == null) ? null : DateTime.Parse(userNodes.InnerText);
                if (lic_model.ExpireDate == null) {
                    lic_model.Status = "Newer Expired";
                }
                else if (lic_model.ExpireDate != null && (((DateTime)lic_model.ExpireDate).Date - DateTime.Now.Date).TotalDays <= 0) {
                    lic_model.Status = "Expired";
                }
                else { lic_model.Status = "Active"; }

                if (lic_model.Status == "Expired") return false;
                return VerifyLicenseKey(lic_model.Key, lic_model, pubKey);
            } catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        private static bool VerifyLicenseKey(string license, LicenseData lic_model, string publickey) {
            try {
                string message = lic_model.LicenseOwner + (lic_model.ExpireDate != null ? "#" + lic_model.ExpireDate?.ToString("dd.MM.yyyy") : "");
                var converter = new ASCIIEncoding();
                byte[] plainText = converter.GetBytes(message);
                var rsaRead = new RSACryptoServiceProvider();
                rsaRead.FromXmlString(System.Web.HttpUtility.HtmlDecode(publickey));

                return rsaRead.VerifyData(plainText, new SHA1CryptoServiceProvider(), Convert.FromBase64String(license));
            } catch { return false; }
        }
    }
}