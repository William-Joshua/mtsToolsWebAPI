using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace mtsToolsWebAPI.Common
{
    public class PassWordHelper
    {
        private string _password;

        public PassWordHelper(string password)
        {
            _password = GetMixSaltPassWord(password);
        }

        /// <summary>
        /// Add Salt to PassWord
        /// </summary>
        private string GetMixSaltPassWord(string password)
        {
            string saltPassWord = string.Empty;
            /// 盐因子可动态变更，考虑到只在场内使用故不作此操作
            string saltItem = WebConfigurationManager.AppSettings["MtsToolsSalt"];
            saltPassWord = saltItem + password;
            return saltPassWord;
        }

        public string CrtPassWord()
        {
            string ciphertext = EasyEncryption.SHA.ComputeSHA256Hash(_password).ToUpper();
            return ciphertext;
        }
    }
}
