using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.UI;
using System.DirectoryServices;
using APL.BL.SFTS.Models.SystemCommon;
using APL.BL.SFTS.Models;
using APL.BL.SFTS.DataBridgeZone;
using APL.BL.SFTS.ProcessZone;
using System.Security.Cryptography;
using APL.BL.SFTS.Models.ApiMobile;
using Newtonsoft.Json;
using System.Net.Http;

namespace APL.BL.SFTS.Web.Controllers
{
    public class AccountController : Controller
    {
		// GET: Account/Login
		// GET: Account/Login
		// GET: Account/Login
		// GET: Account/Login
		public ActionResult Login()
        {
			

			if (Session["CurUserName"] != null)
            {
                return RedirectToAction("Index", "Home", new { area = "SFTS" });
            }
            else
            {
                return View();
            }
        }

        // GET: Account/Logout
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Logout()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string userName = Convert.ToString(Session["CurUserName"]);
                    string token = Convert.ToString(Session["UserToken"]);
                    decimal IsTokenExpired = TokenExpiration(userName, token);
                    Session["CurUserName"] = null;
                    Session["UserToken"] = null;

                    return Json(new { status = 1 });
                }
                catch (Exception e)
                {
                    Session["CurUserName"] = null;
                    Session["UserToken"] = null;
                    return Json(new { status = 1, errors = e.ToString() });
                }
            }
            return Json(new
            {
                status = 1,
            });
        }



        //for ApiToken
        public string GenerateToken(string userid, string password)
        {
            string Id = Guid.NewGuid().ToString("N");
            string userAgent = "User-Agent";
            string message = string.Join(":", new string[] { userid, Id, userAgent });
            string key = password ?? "";

            var encoding = new System.Text.ASCIIEncoding();

            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        //for ApiToken
        public decimal InsertToken(string userName, string token)
        {
            decimal result = 0;
            decimal appId = 1122;
            string version = "2.4.0";
			decimal LANGU = 1;
			string deviceID = "";
			result = new GenerateTokenPZ().InsertToken(userName, token, appId, version, deviceID, LANGU);
            return result;
        }

        //for ApiToken
        public decimal TokenExpiration(string userName, string token)
        {
            decimal result = 0;
            result = new GenerateTokenPZ().WebTokenExpiration(userName, token);

            return result;
        }


        // GET: Account/Login
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(vmLoginUser model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = 0; //vmAuthenticatedUser objAuthMember = null;
                    result = AuthenticateUser(model);
                    //if (result == 1)
                    //{
                    //    Session["UserID"] = objAuthMember.UserID;
                    //    Session["ClientIP"] = HostService.GetIP();
                    //}

                    return Json(new { status = result /*,token = Token*/});
                }
                catch (Exception e)
                {
                    return Json(new { status = false, errors = e.ToString() });
                }
            }
            return Json(new
            {
                status = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }

        private int AuthenticateUser(vmLoginUser model)
        {
            //string tracing = string.Empty;
            int resullt = 0;
            try
            {
                string Token = "";
                decimal appId = 1122;
                model.Version = "2.4.0";
				string deviceid = "";
				bool isPasswordValid = true;
                string encryptPassword= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password.Trim(), "MD5");
                List<SP_GET_USER_AUTHENTICATION> userInfo = new UserInfoPZ().GetLogInAuthentication(model.UserLogin.Trim(), encryptPassword, appId, deviceid);
                if (userInfo[0].IS_DOMAIN_USER == 1)
                {
					//isPasswordValid = CheckUserPasswordInActiveDirectory(model);

					if (isPasswordValid) {
                        if (userInfo != null && userInfo.Count > 0)
                        {
                            Token = GenerateToken(model.UserLogin, model.Password);
                            decimal TokenSaveResult = InsertToken(model.UserLogin, Token);
                            if (TokenSaveResult > 0)
                            {
                                if (userInfo[0].STATUS == 1)
                                {
                                    Session["CurUserID"] = userInfo[0].USER_ID.ToString();
                                    Session["CurUserFullName"] = userInfo[0].USER_NAME.ToString();
                                    Session["CurUserName"] = model.UserLogin.Trim();
                                    Session["UserToken"] = Token;
                                    resullt = 1;
                                }
                            }
                        }
                    };
                }
                else {
                    if (userInfo != null && userInfo.Count > 0)
                    {
                        Token = GenerateToken(model.UserLogin, model.Password);
                        decimal TokenSaveResult = InsertToken(model.UserLogin, Token);
                        if (TokenSaveResult > 0)
                        {
                            if (userInfo[0].STATUS == 1)
                            {
                                Session["CurUserID"] = userInfo[0].USER_ID.ToString();
                                Session["CurUserFullName"] = userInfo[0].USER_NAME.ToString();
                                Session["CurUserName"] = model.UserLogin.Trim();
                                Session["UserToken"] = Token;
                                resullt = 1;
                            }
                        }
                    }
                    else
                    {
                        resullt = 0;
                    }
                }

            }
            catch (Exception ex)
            {            
                string msg = ex.Message;
                resullt = 0;
            }
            return resullt;
        }


        public string GetAdDomainName()
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["ADDomainName"].ToString();
        }

        private bool CheckUserPasswordInActiveDirectory(vmLoginUser model) //(ref string trace)
        {
            string strLoginName = model.UserLogin.Replace("'", "#").Trim();
            string strADDomanName = GetAdDomainName(); //"banglalinkgsm.com";
            bool result = false;
            //using (DirectoryEntry de = new DirectoryEntry("LDAP://Banglalink", strLoginName, PasswordTextBox.Text.Trim()))
            ////test
            //trace = "Domin Name :" +strADDomanName+ ", InputUserName :" + txtUserName.Text + ", Replace User Name :" + strLoginName + ", InputPassword :" + txtPassword.Text;
            using (DirectoryEntry de = new DirectoryEntry(String.Format("LDAP://{0}", strADDomanName), strLoginName, model.Password.Trim()))
            {
                using (DirectorySearcher adSearch = new DirectorySearcher(de))
                {

                    adSearch.Filter = "(sAMAccountName=" + strLoginName + ")";
                    try
                    {
                        SearchResult adSearchResult = adSearch.FindOne();
                        DirectoryEntry adUser = adSearchResult.GetDirectoryEntry();
                        ////test
                        //trace += "DirectoryEntry-> Name :" + adUser.Name + "DirectoryEntry-> Username :" + adUser.Username;
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        //lblMsg.Text = "User does not exist!";
                        ////test
                        //trace += ex.Message;
                        string s = ex.ToString();
                        result = false;
                    }
                    //string UserEmailAddress = adUser.Properties["mail"].Value.ToString();
                }
            }
            return result;
        }

    }
}