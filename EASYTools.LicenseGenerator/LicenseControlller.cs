using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Xml;


namespace EASYTools.LicenseGenerator {

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
        internal static string? publicKey = null;
        internal static string? privateKey = null;

        public static bool VerifyLicense(out LicenseData lic_model, bool isServerCheck) {
            lic_model = new LicenseData();
            try {
                XmlDocument xmlDoc = new();
                xmlDoc.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data","license.lic"));

                string pubKey = isServerCheck ? xmlDoc.SelectSingleNode("//License/PublicKey").InnerXml : publicKey;
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

        public static MemoryStream GenerateLicense(LicenseData lic_model) {
            var rsaWrite = new RSACryptoServiceProvider();
            publicKey = rsaWrite.ToXmlString(true);
            privateKey = rsaWrite.ToXmlString(true);

            lic_model.Key = GenerateLicenseKey(lic_model, privateKey);

            XmlDocument xmlDoc = new();
            XmlNode rootNode = xmlDoc.CreateElement("License");
            xmlDoc.AppendChild(rootNode);

            XmlNode childNode = xmlDoc.CreateElement("Product");
            childNode.InnerText = lic_model.Product;
            rootNode.AppendChild(childNode);

            childNode = xmlDoc.CreateElement("Version");
            childNode.InnerText = lic_model.Version;
            rootNode.AppendChild(childNode);

            childNode = xmlDoc.CreateElement("Organization");
            childNode.InnerText = "GroupWare-Solution.Eu";
            rootNode.AppendChild(childNode);

            childNode = xmlDoc.CreateElement("LicenseOwner");
            childNode.InnerText = lic_model.LicenseOwner;
            rootNode.AppendChild(childNode);

            childNode = xmlDoc.CreateElement("PublicKey");
            childNode.InnerText = publicKey;
            rootNode.AppendChild(childNode);

            childNode = xmlDoc.CreateElement("Key");
            childNode.InnerText = lic_model.Key ?? "";
            rootNode.AppendChild(childNode);

            if (lic_model.ExpireDate != null) {
                childNode = xmlDoc.CreateElement("ExpireDate");
                childNode.InnerText = lic_model.ExpireDate?.ToString("yyyy/MM/dd");
                rootNode.AppendChild(childNode);
            }

            MemoryStream stream = new MemoryStream();
            xmlDoc.Save(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private static string? GenerateLicenseKey(LicenseData lic_model, string rsaPrivateKey) {
            try {
                string message = lic_model.LicenseOwner + (lic_model.ExpireDate != null ? "#" + lic_model.ExpireDate?.ToString("dd.MM.yyyy") : "");

                var converter = new ASCIIEncoding();
                byte[] plainText = converter.GetBytes(message);
                var rsaWrite = new RSACryptoServiceProvider();
                rsaWrite.FromXmlString(rsaPrivateKey);
                byte[] signature = rsaWrite.SignData(plainText, new SHA1CryptoServiceProvider());
                return Convert.ToBase64String(signature);
            } catch { return null; }
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