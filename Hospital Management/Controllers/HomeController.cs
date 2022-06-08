using BusinessManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.AppCode;
using Hospital_Management.Models;
using BusinessObject;
using System.Text;
using System.Data;
using CaptchaMvc.HtmlHelpers;
using System.IO;
using System.Drawing;


namespace Hospital_Management.Controllers
{
    public class HomeController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        SqlConnection con = new SqlConnection(connection);
        static String decryptedpwd;
        public ActionResult Index()
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
                // return View("~/Views/Account/Login.cshtml");
                return RedirectToAction("Logout");
            }
            else
            {
                ViewBag.Msg = "";
                return View("~/Views/Account/Login.cshtml");
                //return View("~/Views/Account/Index.cshtml");
            }

        }

        public ActionResult About()
        {
            ViewBag.MsgL = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.MsgL = "Your contact page.";

            return View();
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


                itemnew.Login = LoginManager.GetById(RefId);
                ViewBag.Mobile = itemnew.Login.MobileNo;
                ViewBag.Address = itemnew.Login.Address;

                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                itemnew.LoginList = LoginManager.GetAll().Where(t => t.Role == "Teacher").ToList();

                Guid CourseId = Guid.Empty;
                Guid.TryParse(ViewBag.courseId, out CourseId);


                if (AllArray[2] == "Admin")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "Customer")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "Employee")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "Student")
                    return View("~/Views/Admin/Stu_Dashboard.cshtml", new MainModel { LoginList = itemnew.LoginList, PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "Reviewer")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "Typist")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
            }
            else
                return View("~/Views/Account/Login_msg.cshtml");
        }

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

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);
                return View("~/Views/Admin/Index.cshtml", itemnew);
            }
            else
            {
                ViewBag.Msg = "your session is expired Please Login again";
                ViewBag.Msg = (TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] != null ? TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

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

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }


        public ActionResult UserLogin(FormCollection coll)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
                MainModel itemnew = new MainModel();
                string Name = coll["mobile"];
                if (Name != null)
                {
                    string Password = encryptpass(coll["password"]);
                    Login obj = LoginManager.Login(Name, Password);
                    if (obj != null)
                    {
                        if (obj.Extra1 == "Approve")
                        {

                            HttpCookie RPCookies = new HttpCookie("hospital@#123");
                            RPCookies.Value = obj.Id.ToString() + "," + obj.UserName + "," + obj.Role + "," + obj.UserPic + "," + obj.Country + "," + obj.State + "," + obj.Email + "," + obj.MobileNo + "," + obj.Address;
                            RPCookies.Expires = DateTime.Now.AddMonths(1);
                            Response.Cookies.Add(RPCookies);
                            ViewBag.Email = obj.Email;
                            itemnew.PermissionList = PermissionManager.GetByUserId(obj.Id);

                            //SqlCommand cmd = new SqlCommand("Update Login set CreatedOn=@CreatedOn where Id=@Id", con);
                            //cmd.Parameters.AddWithValue("@Id", obj.Id);
                            //cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                            //con.Open();
                            //cmd.ExecuteNonQuery();
                            //con.Close();

                            return RedirectToAction("Index", "Hospital");


                        }
                        else
                        {
                            TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "this Account is not Approve by SRO.";
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {
                        Session["Message"] = "danger";
                        TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "Please Check Your Registred Email Id & Password.";
                        return RedirectToAction("Login");
                    }


                }
                return View("~/Views/Account/Login_msg.cshtml");

            //}
            //TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "Error: captcha is not valid.";
            //return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Response.Cookies["hospital@#123"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index");
        }

        // Teacher Registration  

        public ActionResult Signup()
        {
            MainModel itemnew = new MainModel();


            //ViewBag.Course = new SelectList(CourseList, "Id", "ClassName");
            //ViewBag.Stream = new SelectList(StreamList, "Id", "BoardName");


            ViewBag.MsgL = "";


            return View("~/Views/Account/RegisterTeacher.cshtml", itemnew);
        }

        public JsonResult GetEmail(string Email)
        {
            int Lcount = 0;
            SqlCommand cmd = new SqlCommand("select * from [Login] where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                Lcount++;

            var result = new { Lcount = Lcount };
            return (Json(result, JsonRequestBehavior.AllowGet));
        }
        public JsonResult CheckMobile(string MobileNo)
        {
            int Lcount = 0;
            SqlCommand cmd = new SqlCommand("select * from [Login] where MobileNo=@MobileNo", con);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                Lcount++;

            var result = new { Lcount = Lcount };
            return (Json(result, JsonRequestBehavior.AllowGet));

        }

        public ActionResult Password()
        {
            MainModel itemnew = new MainModel();

            itemnew.LoginList = LoginManager.GetAll().ToList();

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] != null ? TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/Account/ForgetPassword.cshtml", itemnew);
        }
        //public ActionResult Forget_Password(FormCollection coll)
        //{
        //    string EmailId = coll["email"];

        //    if (EmailId != string.Empty)
        //    {
        //        List<Login> obj = LoginManager.GetAll().Where(t => t.Email == EmailId).ToList();
        //        if (obj.Count > 0)
        //        {
        //            #region Emaid Send Studen Details
        //            TemplateEngineManager templateEngine = new TemplateEngineManager("UserActive.htm");

        //            if (!string.IsNullOrEmpty(obj[0].UserName))
        //                templateEngine.Variables.Add("FirstName", obj[0].UserName);
        //            else
        //                templateEngine.Variables.Add("FirstName", string.Empty);


        //            if (!string.IsNullOrEmpty(obj[0].Email))
        //                templateEngine.Variables.Add("Email", obj[0].Email);
        //            else
        //                templateEngine.Variables.Add("Email", string.Empty);

        //            string Passwordstr = Decryptdata(obj[0].Password);

        //            if (!string.IsNullOrEmpty(obj[0].Password))
        //                templateEngine.Variables.Add("Password", Passwordstr);
        //            else
        //                templateEngine.Variables.Add("Password", string.Empty);

        //            string CustomerTo = coll["email"];                        // Sender Mail Id 
        //            string subject = "no-reply";

        //            string from = ConfigurationManager.AppSettings["fromEmail"]; // Recive Mail Id
        //            ConstantEmail.SendMail(CustomerTo, from, subject, templateEngine.GetFileContent());


        //            ViewBag.Msg = "";
        //            ViewBag.Msg = (TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] != null ? TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] : string.Empty).ToString();
        //            TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "";
        //            ViewBag.TypeCss = "success";
        //            ViewBag.MsgTitle = "Success!";

        //            #endregion

        //            #region Send SMS API
        //            //string mobile = MobileNo;
        //            //string message = "Your Password is " + " " + GetPass[0].Password + " " + "through Online of AISTRT. .";
        //            ////string uid = "bnbnpr";
        //            //string pin = "ZTcyZTlmOGM5ZWV";
        //            //string sender_id = "AISTRT";
        //            //// string domian = "sms.in";
        //            //string route = "2";
        //            //string type = "1";

        //            //string result = apicall("http://roundsms.com/api/sendhttp.php?authkey=" + pin + "&mobiles=" + mobile + "&message=" + message + "&sender=" + sender_id + "&type=" + 1 + "&route=" + 2);


        //            #endregion
        //            Session["Message"] = "success";
        //            TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "Password Send Your Registred Email Id.";
        //        }
        //        else
        //        {
        //            Session["Message"] = "danger";
        //            TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "Please Check Your Registred Email Id.";
        //        }


        //    }

        //    return RedirectToAction("Password");
        //}


        const string sessionVariableName = "num";
        public ActionResult ClickCounter()
        {
            if (Session[sessionVariableName] == null)
            {
                Session[sessionVariableName] = 0;
            }
            return View();
        }


        // Waqf User Registration 
        int RCount = 0;
        const string clickCountSessionKey = "clickCount";


        //public ActionResult SaveUser(FormCollection coll, HttpPostedFileBase fileupload)
        //{
        //    MainModel itemnew = new MainModel();

        //    Guid Id = Guid.Empty;
        //    Guid.TryParse(coll["Id"], out Id);

        //    Login obj = new Login();

        //    if (Id != Guid.Empty)
        //    {
        //        Login oldobj = LoginManager.GetById(Id);
        //        if (oldobj != null)
        //            obj = oldobj;
        //    }

        //    obj.UserName = coll["name"] + "-" + coll["middlename"] + "-" + coll["lastname"];

        //    obj.State = Guid.Empty.ToString(); //coll["drpState"];

        //    obj.Address = coll["address"];
        //    obj.City = coll["pincode"];
        //    obj.Email = coll["email"];
        //    obj.MobileNo = coll["mobile"];
        //    obj.Role = "User";//coll["role"];
        //    obj.Extra3 = "A";
        //    obj.UserLanguage = coll["address2"]; ;
        //    obj.Extra1 = "Pending";  // status
        //    if (Id != Guid.Empty)
        //    {
        //        if (fileupload != null)
        //        {
        //            if (fileupload.ContentLength > 0)
        //            {
        //                string _FileName = Path.GetFileName(fileupload.FileName);
        //                string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
        //                fileupload.SaveAs(_path);

        //                obj.UserPic = "../UserImage/" + _FileName;
        //            }
        //            else
        //                obj.UserPic = obj.UserPic;
        //        }
        //        else
        //            obj.UserPic = obj.UserPic;


        //        obj.DOB = coll["drptitlew"];
        //        obj.Country = coll["drpcountryw"];
        //        obj.LastLogin = coll["drpdistrictw"];
        //        obj.IPAddress = coll["drpSubdistrictw"];
        //        obj.Email = obj.Email;
        //        obj.MobileNo = obj.MobileNo;
        //        obj.UserName = obj.UserName;
        //        obj.Role = obj.Role;
        //        obj.Extra2 = DateTime.Now.ToString("dd-MM-yyyy"); // approve date
        //        obj.Password = obj.Password;
        //        obj.Extra3 = obj.Extra3;
        //        obj.IPAddress = obj.IPAddress;
        //        obj.LastLogin = obj.LastLogin;
        //        obj.UpdatedBy = "Admin";
        //        obj.UpdatedOn = DateTime.Now;
        //        LoginManager.Update(obj);

        //        TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
        //    }
        //    else
        //    {
        //        obj.Id = Guid.NewGuid();
        //        if (fileupload != null)
        //        {
        //            if (fileupload.ContentLength > 0)
        //            {
        //                string _FileName = Path.GetFileName(fileupload.FileName);
        //                //string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
        //                string NewPath = "/UserImage/";

        //                using (var image = Image.FromStream(fileupload.InputStream))
        //                {
        //                    var newWidth = (int)(132); // 3.5 cm
        //                    var newHeight = (int)(170); // 4.5 cm

        //                    var thumbnailImg = new Bitmap(newWidth, newHeight);
        //                    var thumbGraph = Graphics.FromImage(thumbnailImg);
        //                    thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //                    thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //                    thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
        //                    thumbGraph.DrawImage(image, imageRectangle);
        //                    string targetPath1 = Server.MapPath(NewPath + _FileName);
        //                    thumbnailImg.Save(targetPath1, image.RawFormat);
        //                }

        //                obj.UserPic = "../UserImage/" + _FileName;
        //            }
        //            else
        //                obj.UserPic = "../UserImage/Noimage.png";
        //        }
        //        else
        //            obj.UserPic = "../UserImage/Noimage.png";

        //        obj.DOB = coll["drptitle"];
        //        obj.Country = coll["drpcountry"];
        //        obj.LastLogin = coll["drpdistrict"];
        //        obj.IPAddress = coll["drpSubdistrict"];
        //        obj.Extra2 = DateTime.Now.ToString("dd-MM-yyyy"); // approve date
        //        string strpass = encryptpass(coll["password"]);
        //        obj.Password = strpass;
        //        obj.CreatedBy = obj.UpdatedBy = "Admin";
        //        obj.CreatedOn = obj.UpdatedOn = DateTime.Now;
        //        LoginManager.Add(obj);

        //        WaqfUserMenuPermission(obj.Id);

        //        #region Emaid Send Studen Details
        //        TemplateEngineManager templateEngine = new TemplateEngineManager("UserActive.htm");

        //        if (!string.IsNullOrEmpty(obj.UserName))
        //            templateEngine.Variables.Add("FirstName", obj.UserName);
        //        else
        //            templateEngine.Variables.Add("FirstName", string.Empty);


        //        if (!string.IsNullOrEmpty(obj.Email))
        //            templateEngine.Variables.Add("Email", obj.Email);
        //        else
        //            templateEngine.Variables.Add("Email", string.Empty);

        //        string Passwordstr = Decryptdata(obj.Password);

        //        if (!string.IsNullOrEmpty(obj.Password))
        //            templateEngine.Variables.Add("Password", Passwordstr);
        //        else
        //            templateEngine.Variables.Add("Password", string.Empty);

        //        var activateURL = "/Home/ApproveUser/" + obj.Id;
        //        var activateLinK = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, activateURL);

        //        //string site = Request.Url + "/Home/ApproveUser/"; // "http://app.easystudyplanner.com/Home/ChangePassword/";http://localhost:5944
        //        string url = "<a style='color:green;' href='" + activateLinK + "'>Click Here Activate account</a>";

        //        if (!string.IsNullOrEmpty(url))
        //            templateEngine.Variables.Add("message", url);
        //        else
        //            templateEngine.Variables.Add("message", string.Empty);

        //        string CustomerTo = coll["email"];                        // Sender Mail Id 
        //        string subject = "no-reply";

        //        string from = ConfigurationManager.AppSettings["fromEmail"]; // Recive Mail Id
        //        ConstantEmail.SendMail(CustomerTo, from, subject, templateEngine.GetFileContent());


        //        ViewBag.Msg = "";
        //        ViewBag.Msg = (TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] != null ? TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] : string.Empty).ToString();
        //        TempData[Hospital_Management.AppCode.Constant.INFO_MESSAGE] = "";
        //        ViewBag.TypeCss = "success";
        //        ViewBag.MsgTitle = "Success!";

        //        #endregion



        //        TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";

        //        //return Redirect("/Home/Add_Waqf_User?Id=" + obj.Id);
        //        return Redirect("/Home/Add_Waqf_User?Id=" + Guid.Empty);

        //    }

        //    return Redirect("/Home/Add_Waqf_User?Id=" + obj.Id);
        //}



        public ActionResult UpdateUser(FormCollection coll, HttpPostedFileBase fileupload)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            var exist = LoginManager.GetAll().Where(model => model.Id == Id && model.Extra1 == "Approve").FirstOrDefault();
            if (exist.Id != null)
            {
                Login obj = new Login();

                if (Id != Guid.Empty)
                {
                    Login oldobj = LoginManager.GetById(Id);
                    if (oldobj != null)
                        obj = oldobj;
                }
                obj.DOB = coll["drptitle"];
                obj.UserName = coll["name"] + "-" + coll["middlename"] + "-" + coll["lastname"];
                obj.Country = coll["drpcountry"];
                obj.State = Guid.Empty.ToString(); //coll["drpState"];
                obj.LastLogin = coll["drpdistrict"];
                obj.IPAddress = coll["drpSubdistrict"];
                obj.Address = coll["address"];
                obj.City = coll["pincode"];
                obj.Email = coll["email"];
                obj.MobileNo = coll["mobile"];
                obj.Role = "WaqfUser";//coll["role"];
                obj.Extra3 = "A";
                obj.UserLanguage = coll["address2"]; ;
                obj.Extra1 = "Pending";  // status
                if (Id != Guid.Empty)
                {
                    if (fileupload != null)
                    {
                        if (fileupload.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(fileupload.FileName);
                            string _path = Path.Combine(Server.MapPath("../UserImage/"), _FileName);
                            fileupload.SaveAs(_path);

                            obj.UserPic = "../UserImage/" + _FileName;
                        }
                        else
                            obj.UserPic = obj.UserPic;
                    }
                    else
                        obj.UserPic = obj.UserPic;

                    obj.Email = obj.Email;
                    obj.MobileNo = obj.MobileNo;
                    obj.UserName = obj.UserName;
                    obj.Role = obj.Role;
                    obj.Extra2 = DateTime.Now.ToString("dd-MM-yyyy"); // approve date
                    obj.Password = obj.Password;
                    obj.Extra3 = obj.Extra3;
                    obj.IPAddress = obj.IPAddress;
                    obj.LastLogin = obj.LastLogin;
                    obj.UpdatedBy = "Admin";
                    obj.UpdatedOn = DateTime.Now;
                    LoginManager.Update(obj);

                    TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
                }
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "You will not update Complete Profile.";
                return Redirect("/Home/Add_Waqf_User?Id=" + Id);

            }


            return Redirect("/Home/Add_Waqf_User?Id=" + Id);
        }
        public void WaqfUserMenuPermission(Guid Id)
        {
            MainModel itemnew = new MainModel();

            Permission obj = new Permission();

            obj.UserId = Id;
            obj.MenuName = "Waqf Registration";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);

            obj.UserId = Id;
            obj.MenuName = "Waqf Registration Details";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);

            obj.UserId = Id;
            obj.MenuName = "Report";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);
        }

        // ManagementCommittee user registration
        public ActionResult Add_Management_User(Guid Id)
        {
            MainModel itemnew = new MainModel();

            List<Login> AllList = new List<Login>();

            if (Id != Guid.Empty)
            {
                itemnew.Login = LoginManager.GetById(Id);
                ViewBag.UserRole = new SelectList(Constant.UserRole, "Text", "Value", itemnew.Login.Role);
                ViewBag.UserStatus = new SelectList(Constant.UserStatus, "Text", "Value", itemnew.Login.Extra1);
            }
            else
            {
                ViewBag.UserRole = new SelectList(Constant.UserRole, "Text", "Value");
                ViewBag.UserStatus = new SelectList(Constant.UserStatus, "Text", "Value");

            }



            Guid RefId = Guid.Empty;

            ViewBag.Msg = "";
            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";

            return View("~/Views/AllForms/AddUserManagementCommittee.cshtml", itemnew);
        }
        public ActionResult MSaveUser(FormCollection coll)
        {
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Login obj = new Login();

            if (Id != Guid.Empty)
            {
                Login oldobj = LoginManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.Email = coll["email"];
            obj.MobileNo = coll["mobile"];
            obj.Role = "MUser";//coll["role"];
            obj.UserName = coll["name"];


            //if (coll["chkactive"] == "on")
            //    obj.Extra1 = "Approve";
            //else

            obj.Extra3 = "A";
            obj.Address = "";
            obj.City = "";
            obj.Country = "";
            obj.DOB = "";


            obj.State = "";
            obj.UserLanguage = "";

            if (Id != Guid.Empty)
            {

                obj.Email = obj.Email;
                obj.MobileNo = obj.MobileNo;
                obj.UserName = obj.UserName;
                obj.Role = obj.Role;
                obj.Extra1 = "Approve";  // status
                obj.Extra2 = DateTime.Now.ToString("dd-MM-yyyy"); // approve date
                obj.Password = obj.Password;
                obj.Extra3 = obj.Extra3;
                obj.IPAddress = obj.IPAddress;
                obj.LastLogin = obj.LastLogin;
                obj.UpdatedBy = "Admin";
                obj.UpdatedOn = DateTime.Now;

                LoginManager.Update(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {

                obj.Extra1 = "Approve"; // status
                obj.Extra2 = DateTime.Now.ToString("dd-MM-yyyy"); // approve date
                obj.Id = Guid.NewGuid();
                obj.LastLogin = "";
                obj.IPAddress = "";
                string strpass = encryptpass(coll["password"]);
                obj.Password = strpass;

                obj.CreatedBy = obj.UpdatedBy = "Admin";
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

                LoginManager.Add(obj);



                MUserMenuPermission(obj.Id);

                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";

                return Redirect("/Home/Add_Management_User?Id=" + obj.Id);


            }

            return Redirect("/Home/v?Id=" + obj.Id);
        }

        public void MUserMenuPermission(Guid Id)
        {
            MainModel itemnew = new MainModel();

            Permission obj = new Permission();

            obj.UserId = Id;
            obj.MenuName = "Receipts";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);

            obj.UserId = Id;
            obj.MenuName = "Managment Committee";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);

            obj.UserId = Id;
            obj.MenuName = "Report";
            obj.AddRecord = "on";
            obj.UpdateRecord = "on";
            obj.DeleteRecord = "off";
            obj.ExtraColumn = "on";
            obj.Status = "";
            obj.Id = Guid.NewGuid();

            obj.CreatedBy = obj.UpdatedBy = "Admin";
            obj.CreatedOn = obj.UpdatedOn = DateTime.Now;

            PermissionManager.Add(obj);
        }

        public ActionResult ApproveUser(Guid Id)
        {
            var exist = LoginManager.GetAll().Where(model => model.Id == Id && model.Extra1 == "Pending").FirstOrDefault();
            // Login obj = LoginManager.GetById(Id);
            if (exist != null)
            {
                SqlCommand cmd = new SqlCommand("Update Login set Extra1=@Extra1 ,Extra2=@Extra2 where Id=@Id", con);
                if (exist.Extra1 == "Approve")
                {
                    cmd.Parameters.AddWithValue("@Extra1", "Pending"); //cmd.Parameters.AddWithValue("@Extra1", "false");
                    cmd.Parameters.AddWithValue("@Extra2", DateTime.Now.ToString("dd-MM-yyyy")); // as Approve Date
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Extra1", "Approve");
                    cmd.Parameters.AddWithValue("@Extra2", DateTime.Now.ToString("dd-MM-yyyy"));
                }

                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ViewBag.Success = "Your Email Account Is Activated . please Cleck here To Login " + " " + exist.Email;

            }
            else
            {
                ViewBag.error = "Invalid Request";
                //return View("~/Views/Admin/Error404.cshtml");

            }

            return View("~/Views/Admin/Error404.cshtml");

        }
    }
}