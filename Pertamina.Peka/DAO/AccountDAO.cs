using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pertamina.Peka.Models;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.DirectoryServices;

namespace Pertamina.Peka.DAO
{
    public class AccountDAO
    {
        public string dominName;
        public string adPath;
        string strError = string.Empty;
        DataTable dtUser = new DataTable();
        DataSet dsUser = new DataSet();
        DataTable dtPekerja = new DataTable();
        DataSet dsPekerja = new DataSet();
        //bool loginSukses = false;
        string displayname = "";
        string roles = string.Empty;
        Account accounts = new Account();
        private Pekerja pekerjas = new Pekerja();
        private PekerjaDAO pekerjasDAO = new PekerjaDAO();

        protected SqlParameter @function = new SqlParameter("@function", SqlDbType.Int);
        protected SqlParameter @db = new SqlParameter("@db", SqlDbType.VarChar, 100);

        protected SqlParameter @idRole = new SqlParameter("@idRole", SqlDbType.Int);
        protected SqlParameter @username = new SqlParameter("@username", SqlDbType.VarChar, 50);
        protected SqlParameter @RoleName = new SqlParameter("@RoleName", SqlDbType.VarChar, 50);
        protected SqlParameter @section = new SqlParameter("@section", SqlDbType.VarChar, 100);

        protected SqlParameter @CreatedBy = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @CreatedOn = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        protected SqlParameter @ModifiedBy = new SqlParameter("@ModifiedBy", SqlDbType.VarChar, 50);
        protected SqlParameter @ModifiedOn = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        protected SqlParameter @isActive = new SqlParameter("@isActive", SqlDbType.Bit);
        protected SqlParameter @isBanned = new SqlParameter("@isBanned", SqlDbType.Bit);
        protected SqlParameter @requested = new SqlParameter("@requested", SqlDbType.Bit);

        public bool coba(Account acc)
        {
            if (!string.IsNullOrEmpty(acc.Email)&&!string.IsNullOrEmpty(acc.Password))
            {
                System.Web.HttpContext.Current.Session["role"] = "Administrator";
                System.Web.HttpContext.Current.Session["idrole"] = 2;
                System.Web.HttpContext.Current.Session["aplikasi"] = "IACT";
                System.Web.HttpContext.Current.Session["nama"] = "Rudi Hermawan Catur Putra";
                //System.Web.HttpContext.Current.Session["nopek"] = "750279";
                //System.Web.HttpContext.Current.Session["nopek"] = null;
                System.Web.HttpContext.Current.Session["NoLevel"] = "5";
                System.Web.HttpContext.Current.Session["NoBagian"] = "58";
                System.Web.HttpContext.Current.Session["NoFungsi"] = "16";

                System.Web.HttpContext.Current.Session["aplikasi"] = "PEKA";
                //System.Web.HttpContext.Current.Session["nama"] = displayname;
                //System.Web.HttpContext.Current.Session["dept"] = department;
                roles = System.Web.HttpContext.Current.Session["role"].ToString();
                System.Web.HttpContext.Current.Session["username"] = acc.Email;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LDAP(Account acc)
        {
            var loginSukses = false;
            #region LDAP
            try
            {
                System.Web.HttpContext.Current.Session["db"] = "PEKA";
                foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
                {
                    dominName = key.Contains("DirectoryDomain") ? System.Configuration.ConfigurationManager.AppSettings[key] : dominName;
                    adPath = key.Contains("DirectoryPath") ? System.Configuration.ConfigurationManager.AppSettings[key] : adPath;
                    if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
                    {     
                        if (true == AuthenticateUser(dominName, acc.Email, acc.Password, adPath, out strError))
                        {
                            dtUser.Clear();
                            dsUser.Clear();
                            //accounts.Email = acc;
                            dsUser = SearchUser(accounts);
                            dtUser = dsUser.Tables[0];
                            if (dtUser.Rows.Count > 0)
                            {
                                bool requested = (from DataRow dr in dtUser.Rows
                                                  select (bool)dr["requested"]).FirstOrDefault();

                                bool isbanned = (from DataRow dr in dtUser.Rows
                                                 select (bool)dr["isbanned"]).FirstOrDefault();
                                if (!requested && !isbanned)
                                {
                                    accounts.Email = acc.Email;
                                    System.Web.HttpContext.Current.Session["username"] = acc.Email;
                                    System.Web.HttpContext.Current.Session["role"] = (from DataRow dr in dtUser.Rows
                                                       select (string)dr["Rolename"]).FirstOrDefault();
                                    System.Web.HttpContext.Current.Session["idrole"] = (from DataRow dr in dtUser.Rows
                                                         select (int)dr["idrole"]).FirstOrDefault();
                                    System.Web.HttpContext.Current.Session["section"] = (from DataRow dr in dtUser.Rows
                                                          select (string)dr["section"]).FirstOrDefault();

                                    //ambilDataPekerja(acc.Email);

                                    System.Web.HttpContext.Current.Session["aplikasi"] = "PEKA";
                                    System.Web.HttpContext.Current.Session["nama"] = displayname;
                                    //System.Web.HttpContext.Current.Session["dept"] = department;
                                    roles = System.Web.HttpContext.Current.Session["role"].ToString();
                                    System.Web.HttpContext.Current.Session["username"] = acc.Email;

                                    //Production
                                    //System.Web.HttpContext.Current.Session["role"] = "Administrator";
                                    //System.Web.HttpContext.Current.Session["idrole"] = 1;
                                    //System.Web.HttpContext.Current.Session["aplikasi"] = "IACT";
                                    //System.Web.HttpContext.Current.Session["nama"] = "Rudi Hermawan Catur Putra";
                                    //System.Web.HttpContext.Current.Session["nopek"] = "750279";
                                    //System.Web.HttpContext.Current.Session["NoLevel"] = "5";
                                    //System.Web.HttpContext.Current.Session["NoBagian"] = "58";
                                    //System.Web.HttpContext.Current.Session["NoFungsi"] = "16";
                                    //aktLog.createLog(Session["aplikasi"].ToString(), "Log In", "Login", "Login sebagai user yg sudah terdaftar", Session["username"].ToString(), DateTime.Now);
                                    loginSukses = true;

                                }

                                else if (requested)
                                {
                                    accounts.errorMessage = "Your Account must be approved first, please contact IT admin";
                                }

                                else if (isbanned)
                                {
                                    accounts.errorMessage = "Your Account was inactive, please contact IT admin";
                                }
                            }
                            else
                            {
                                //userDomain.WrongLogin = 0;
                                accounts.Email = acc.Email;
                                accounts.CreatedBy = "System";
                                accounts.CreatedOn = DateTime.Now;
                                accounts.requested = false;
                                accounts.idRole = 2;
                                AddUser(accounts);

                                System.Web.HttpContext.Current.Session["username"] = acc.Email;
                                System.Web.HttpContext.Current.Session["role"] = "Conceptor";
                                System.Web.HttpContext.Current.Session["idrole"] = 2;
                                ambilDataPekerja(acc.Email);


                                //logs.aktifitas = "Login";
                                //logs.deskripsi = "Login sebagai user baru";
                                //logs.CreatedBy = System.Web.HttpContext.Current.Session["username"].ToString();
                                //logs.menu = "Login";
                                //logsDAO.AddLog(logs);

                                loginSukses = true;
                            }
                        }
                        else
                        {

                            //OFLINE MODE (PRODUCTION MODE)
                            //Session["username"] = userName;
                            //Session["role"] = "Administrator";
                            //Session["idrole"] = 1;
                            //Session["aplikasi"] = "IACT";
                            //Session["nama"] = "Rudi Hermawan Catur Putra";
                            //Session["nopek"] = "750279";
                            //Session["NoLevel"] = "5";
                            //Session["NoBagian"] = "58";
                            //Session["NoFungsi"] = "16";
                            //loginSukses = true;

                            //Session["username"] = "rosnamora";
                            //Session["nama"] = "Rosnamora Harahap";
                            //Session["nopek"] = "682355";
                            //Session["role"] = "Employee";
                            //Session["NoLevel"] = "4";
                            //Session["NoBagian"] = "59";
                            //Session["NoFungsi"] = "16";

                            ////PUBLISH MODE
                            accounts.errorMessage = "Invalid username or Password! ";
                            dominName = string.Empty;
                            adPath = string.Empty;
                            if (String.IsNullOrEmpty(strError)) break;

                        }
                    }


                }
                if (!string.IsNullOrEmpty(strError))
                {
                    accounts.errorMessage = strError;
                }

                if (loginSukses)
                {
                    //logs.aktifitas = "Login";
                    //logs.deskripsi = "Login Sebagai " + Session["role"].ToString();
                    //logs.CreatedBy = Session["username"].ToString();
                    //logs.menu = "Login";
                    //logsDAO.AddLog(logs);

                    //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txUsername.Value, DateTime.Now, DateTime.Now.AddMinutes(50), true, roles, FormsAuthentication.FormsCookiePath);
                    //string hash = FormsAuthentication.Encrypt(ticket);
                    //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    //if (ticket.IsPersistent)
                    //{
                    //    cookie.Expires = ticket.Expiration;
                    //}
                    //Response.Cookies.Add(cookie);
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(txUsername.Value, false), false);
                    //FormsAuthentication.SetAuthCookie(txUsername.Value, true);

                    //Response.Redirect("~/Traser.aspx?menu=Home", false);
                  loginSukses = true;
                }
                return loginSukses;
            }
            catch (Exception ex)
            {
                accounts.errorMessage = ex.Message;
                return loginSukses;
            }
            finally
            {

            }
            #endregion
        }

        public void ambilDataPekerja(string usn)
        {
            //pekerjas.email = usn + "@pertamina.com";
            pekerjas.email = usn;
            dsPekerja = pekerjasDAO.SearchPekerja(pekerjas);
            dtPekerja = dsPekerja.Tables[0];
            if (dtPekerja.Rows.Count > 0)
            {
                System.Web.HttpContext.Current.Session["nopek"] = (from DataRow dr in dtPekerja.Rows
                                    select (string)dr["nopek"]).FirstOrDefault();
                System.Web.HttpContext.Current.Session["NoLevel"] = (from DataRow dr in dtPekerja.Rows
                                      select (Int32)dr["NoLevel"]).FirstOrDefault();
                System.Web.HttpContext.Current.Session["NoBagian"] = (from DataRow dr in dtPekerja.Rows
                                       select (Int32)dr["NoBagian"]).FirstOrDefault();
                System.Web.HttpContext.Current.Session["NoFungsi"] = (from DataRow dr in dtPekerja.Rows
                                       select (Int32)dr["NoFungsi"]).FirstOrDefault();
            }
            else
            {
                //System.Web.HttpContext.Current.Session["nopek"] = "0";
                //System.Web.HttpContext.Current.Session["NoLevel"] = "5";
                //System.Web.HttpContext.Current.Session["NoBagian"] = "0";
                //System.Web.HttpContext.Current.Session["NoFungsi"] = "0";
            }
        }

        public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = "";
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("displayname");
                search.PropertiesToLoad.Add("title");
                search.PropertiesToLoad.Add("department");
                //search.PropertiesToLoad.Add("EmployeeID");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
                // Update the new path to the user in the directory
                LdapPath = result.Path;
                string _filterAttribute = (String)result.Properties["cn"][0];
                string mail = (String)result.Properties["mail"][0];
                ambilDataPekerja(mail);
                displayname = (String)result.Properties["displayname"][0];

                //bool x = result.Properties.Contains("EmployeeID");
                //if (x)
                //{
                //    if ((String)result.Properties["EmployeeID"][0] != null && (String)result.Properties["EmployeeID"][0] != "0" && (String)result.Properties["EmployeeID"][0] != "-" && (String)result.Properties["EmployeeID"][0] != "")
                //    {
                //        System.Web.HttpContext.Current.Session["nopek"] = (String)result.Properties["EmployeeID"][0];
                //    }
                //}
                return true;
                //}
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                return false;
                throw new Exception("Error authenticating user.");
            }
        }

        public DataSet SearchUser(Account acocounts)
        {
            @function.Value = 8;
            @db.Value = System.Web.HttpContext.Current.Session["db"] as string;
            if (accounts.Email != null)
            {
                @username.Value = acocounts.Email;
            }
            else
            {
                @username.Value = DBNull.Value;
            }
            //if (accounts.Password != null)
            //{
            //    @RoleName.Value = accounts.Email;
            //}
            //else
            //{
            //    @RoleName.Value = DBNull.Value;
            //}
            return SqlHelper.ExecuteDataset(General.connString, CommandType.StoredProcedure, "SP_UserManajemen", @function, @RoleName, @username, @db);
        }

        public bool AddUser(Account acocounts)
        {
            try
            {
                @function.Value = 9;
                @db.Value = System.Web.HttpContext.Current.Session["db"] as string;
                @username.Value = acocounts.Email;
                @idRole.Value = acocounts.idRole;
                @requested.Value = acocounts.requested;
                @section.Value = acocounts.section;

                @CreatedBy.Value = acocounts.CreatedBy;
                @CreatedOn.Value = DateTime.Now;
                int result = SqlHelper.ExecuteNonQuery(General.connString, CommandType.StoredProcedure, "SP_UserManajemen", @function,
                @username, @idRole, @requested, @section, @CreatedBy, @CreatedOn, @db);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}