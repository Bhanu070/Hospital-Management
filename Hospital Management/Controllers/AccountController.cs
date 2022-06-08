using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Hospital_Management.Models;
using System.Data.SqlClient;
using System.Configuration;
using BusinessManager;
using Hospital_Management.AppCode;
using System.Net;
using System.IO;
using BusinessObject;
using System.Data;
using System.Web.Helpers;
using System.Text;

namespace UKWB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        SqlConnection con = new SqlConnection(connection);

        public ActionResult Login()
        {
            MainModel itemnew = new MainModel();

            if (Request.Cookies["hospital@#123"] != null)
            {
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Id = AllArray[0];
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";
                return View("~/Views/Admin/Index.cshtml", itemnew);
            }
            else
            {

                return View("~/Views/Account/Login.cshtml");
            }

        }
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        public ActionResult UserLogin(FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            string Name = coll["mobile"];
            if (Name != null)
            {
                string Password = encryptpass(coll["password"]);
                // string Password = coll["password"];
                Login obj = LoginManager.Login(Name, Password);
                if (obj != null)
                {
                    HttpCookie GateCookies = new HttpCookie("hospital@#123");
                    GateCookies.Value = obj.Id.ToString() + "," + obj.UserName + "," + obj.Role + "," + obj.UserPic + "," + obj.Country + "," + obj.State + "," + obj.Email;
                    GateCookies.Expires = DateTime.Now.AddMonths(2);
                    Response.Cookies.Add(GateCookies);
                    ViewBag.Email = obj.Email;
                    return RedirectToAction("DashBoard");
                }
                else
                    return View("~/Views/Account/Login.cshtml");
            }
            return View("~/Views/Account/Login_msg.cshtml");
        }

        public ActionResult DashBoard()
        {
            MainModel itemnew = new MainModel();

            if (Request.Cookies["hospital@#123"] != null)
            {
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Id = AllArray[0];
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.courseId = AllArray[4];
                ViewBag.StreamId = AllArray[5];
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
              
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                itemnew.LoginList = LoginManager.GetAll().ToList();

               

              

                if (AllArray[2] == "Admin")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else if (AllArray[2] == "Customer")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else if (AllArray[2] == "Teacher")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else if (AllArray[2] == "Student")
                    return View("~/Views/Admin/Stu_Dashboard.cshtml", new MainModel { LoginList = itemnew.LoginList, PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else if (AllArray[2] == "Reviewer")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else if (AllArray[2] == "Typist")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
                else
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login=itemnew.Login });
            }
            else
                return View("~/Views/Account/Login_msg.cshtml");
        }

        private static string auto()
        {
            int count = 0;
            SqlConnection con = new SqlConnection(connection);
            SqlCommand com = new SqlCommand("select Max(code)as code from [Login]", con);
            con.Open();
            var icount = com.ExecuteScalar();
            if (icount != DBNull.Value && icount != null)
                count = Convert.ToInt32(icount) + 1;
            else
                count = 1;

            con.Close();

            string chars = "MM00" + count.ToString();
            return chars;
        }
        private static string CreateRandomPassword(int length = 4)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public string apicall(string url)
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                return results;
            }
            catch
            {
                return "0";
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string myid = Request.Form["Idd"];

            Guid Id = Guid.Empty;
            Guid.TryParse(myid, out Id);
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                SqlCommand cmdc = new SqlCommand("Select Pic from [Login] where Id='" + Id + "'", con);
                cmdc.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmdc);
                DataTable dt = new DataTable();
                da.Fill(dt);

                SqlCommand cmd = new SqlCommand("Update [Login] set Pic=@Pic where Id='" + Id + "'", con);

                var pic = System.Web.HttpContext.Current.Request.Files["UserImg"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);
                    string proimage = "../UserImg/" + fileName;
                    cmd.Parameters.AddWithValue("@Pic", proimage);


                    //_imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("/UserImg/") + fileName;
                    _imgname = "UserImg/" + fileName;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize

                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }


        //Logout 
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Response.Cookies["hospital@#123"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Login");
        }

      
        public ActionResult SubmitOTPFamily(FormCollection coll)
        {
            if (Session["OTP"] != null)
            {
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.Id = AllArray[0];
                ViewBag.Name = AllArray[1];
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);

                string otpvalue1 = coll["v1"];
                string otpvalue2 = coll["v2"];
                string otpvalue3 = coll["v3"];
                string otpvalue4 = coll["v4"];
                string UserId = coll["UserId"];
                Guid UId = Guid.Empty;
                Guid.TryParse(UserId, out UId);

                string OTPMatchValue = otpvalue1 + otpvalue2 + otpvalue3 + otpvalue4;

                if (Session["OTP"].ToString() == OTPMatchValue)
                {
                    MainModel itemnew = new MainModel();

                    itemnew.Login = LoginManager.GetById(RefId);

                    Login obj = LoginManager.Login(itemnew.Login.MobileNo, itemnew.Login.Password);
                    if (obj != null)
                    {
                        ViewBag.MsgL = "You have enter correct OTP.";
                        Session["OTP"] = null;

                        return RedirectToAction("MemberLogin");
                    }
                    else
                        return View("~/Views/Account/Login.cshtml");
                }
                else
                {
                    ViewBag.MsgL = "Pleae enter correct OTP.";
                    return PartialView("~/Views/Account/OTP.cshtml");
                }
            }
            else
                return PartialView("~/Views/Account/OTP.cshtml");
        }


        public ActionResult ForgetPassword()
        {

            MainModel itemnew = new MainModel();

            itemnew.LoginList = LoginManager.GetAll();

            //ViewBag.UserType = new SelectList(Constant.UserType, "Text", "Value");


            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Account/ForgetPassword.cshtml", itemnew);


        }
        public ActionResult SaveForgetPassword(FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            string mob = coll["mobile"];
            List<Login> obj = LoginManager.GetAll().Where(x => x.MobileNo == mob).ToList();
            if (obj[0].MobileNo != "")
            {
                #region Send SMS API

                string mobile = obj[0].MobileNo;
                string message = "Your Password  is - " + obj[0].Password;
                //itemnew.SMSList = SMSManager.GetAll().Take(1).ToList();
                //string result = apicall("http://" + itemnew.SMSList[0].DName + "//sendsms.jsp?user=" + itemnew.SMSList[0].UId + "&password=" + itemnew.SMSList[0].Pin + "&mobiles=" + mobile + "&sms=" + message + "&senderid=" + itemnew.SMSList[0].SenderId);

                #endregion
                return RedirectToAction("Login");
            }
            return View("~/Views/Account/Login.cshtml");
        }

        [HttpGet]
        public FileResult GetDownloadFile(Guid Id)
        {
            MainModel itemnew = new MainModel();

            //Download obj = DownloadManager.GetById(Id);
            var CurrentFileName = "";// obj.Document;
            string contentType = string.Empty;
            if (CurrentFileName.Contains(".txt"))
            {
                contentType = "application/txt";
            }
            else if (CurrentFileName.Contains(".docx"))
            {
                contentType = "application/docx";
            }
            else if (CurrentFileName.Contains(".xlsx"))
            {
                contentType = "application/xlsx";
            }
            else if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }
            return File(CurrentFileName, contentType, CurrentFileName);

        }
    }
}