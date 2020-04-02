/***********************************************************************
 * <copyright file="Crypto.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, June 16, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TSD.Option
{
    public class Crypto
    {
        /// <remarks>
        /// Supported .Net intrinsic SymmetricAlgorithm classes.
        /// </remarks>
        public enum SymmProvEnum
        {
            DES, RC2, Rijndael
        }

        private readonly SymmetricAlgorithm mobjCryptoService;

        /// <remarks>
        /// Constructor for using an intrinsic .Net SymmetricAlgorithm class.
        /// </remarks>
        public Crypto(SymmProvEnum NetSelected)
        {
            switch (NetSelected)
            {
                case SymmProvEnum.DES:
                    mobjCryptoService = new DESCryptoServiceProvider();
                    break;
                case SymmProvEnum.RC2:
                    mobjCryptoService = new RC2CryptoServiceProvider();
                    break;
                case SymmProvEnum.Rijndael:
                    mobjCryptoService = new RijndaelManaged();
                    break;
            }
        }
   
        /// <remarks>
        /// Constructor for using a customized SymmetricAlgorithm class.
        /// </remarks>
        public Crypto(SymmetricAlgorithm ServiceProvider)
        {
            mobjCryptoService = ServiceProvider;
        }

        /// <remarks>
        /// Depending on the legal key size limitations of a specific CryptoService provider
        /// and length of the private key provided, padding the secret key with space character
        /// to meet the legal size of the algorithm.
        /// </remarks>
        private byte[] GetLegalKey(string Key)
        {
            string sTemp;
            if (mobjCryptoService.LegalKeySizes.Length > 0)
            {
                var moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;

                // key sizes are in bits
                while (Key.Length * 8 > moreSize)
                {
                    moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;
                }
                sTemp = Key.PadRight(moreSize / 8, ' ');
            }
            else
                sTemp = Key;

            // convert the secret key to byte array
            return Encoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// Encryptings the specified source.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Key">The key.</param>
        /// <returns></returns>
        public string Encrypting(string Source, string Key)
        {
            var bytIn = Encoding.UTF8.GetBytes(Source);

            // create a MemoryStream so that the process can be done without I/O files
            var ms = new MemoryStream();
            var bytKey = GetLegalKey(Key);

            // set the private key
            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            // create an Encryptor from the Provider Service instance
            var encrypto = mobjCryptoService.CreateEncryptor();

            // create Crypto Stream that transforms a stream using the encryption
            var cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

            // write out encrypted content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            // get the output and trim the '\0' bytes
            var bytOut = ms.GetBuffer();
            int i;
            for (i = 0; i < bytOut.Length; i++)
                if (bytOut[i] == 0)
                    break;

            // convert into Base64 so that the result can be used in xml
            return Convert.ToBase64String(bytOut, 0, i);
        }

        /// <summary>
        /// Decryptings the specified source.
        /// </summary>
        /// <param name="Source">The source.</param>
        /// <param name="Key">The key.</param>
        /// <returns></returns>
        public string Decrypting(string Source, string Key)
        {
            // convert from Base64 to binary
            var bytIn = Convert.FromBase64String(Source);

            // create a MemoryStream with the input
            var ms = new MemoryStream(bytIn, 0, bytIn.Length);
            var bytKey = GetLegalKey(Key);

            // set the private key
            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            // create a Decryptor from the Provider Service instance
            var encrypto = mobjCryptoService.CreateDecryptor();

            // create Crypto Stream that transforms a stream using the decryption
            var cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

            // read out the result from the Crypto Stream
            var sr = new StreamReader(cs);
            return sr.ReadToEnd();

        }
        /// <summary>
        /// Checks the license.
        /// </summary>
        /// <returns></returns>
        public bool CheckLicense(string license, bool isSchema, ref string[] info)
        {
            const string key = "abigtimezxcvbnm";
            string elemParentCompanyName = "", elemCompanyName = "", elemCompanyAddress = "", elemSignature = "", elemDirectoryName = "", elemLicenseNumber ="";
            var bFlag = false;
            try
            {
                var XMLFilePath = license;
                if (string.IsNullOrEmpty(XMLFilePath))
                {
                    XMLFilePath = "License.lic";
                }
                var ds = new DataSet();
                if (!isSchema)
                {
                    ds.ReadXml(XMLFilePath);
                }
                else
                {
                    var strReader = new StringReader(license);
                    ds.ReadXml(strReader);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    elemParentCompanyName = dr["CustomerParent"].ToString();
                    elemCompanyName = dr["CustomerName"].ToString();
                    elemCompanyAddress = dr["CustomerAddress"].ToString();
                    elemDirectoryName = dr["DirectoryName"].ToString();
                    elemSignature = dr["Signature"].ToString();
                    elemLicenseNumber = dr["LicenseNumber"].ToString();
                }

                var oCrypto = new Crypto(SymmProvEnum.Rijndael);
                var sEncryptCheck = elemCompanyName.Trim() + "@" + elemCompanyAddress.Trim() + "@" + elemParentCompanyName.Trim() + "@" + elemDirectoryName.Trim() + "@" + elemLicenseNumber;
                var sEnr = oCrypto.Encrypting(sEncryptCheck, key);
                if (sEnr == elemSignature)
                {
                    bFlag = true;
                    info[0] = elemParentCompanyName.Trim();
                    info[1] = elemCompanyName.Trim();
                    info[2] = elemCompanyAddress.Trim();
                    info[3] = elemDirectoryName.Trim();
                    info[4] = elemLicenseNumber.Trim();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                info.Initialize();
                MessageBox.Show("Error while fetching the record" + ex.Message);
            }
            return bFlag;
        }
    }
}
