using BusinessManager;
using BusinessObject;
//using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Hospital_Management.AppCode;
using Hospital_Management.Models;

namespace Hospital_Management.Controllers
{
    public class HospitalController : Controller
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        SqlConnection con = new SqlConnection(connection);
        // Main Code 
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
                ViewBag.courseId = AllArray[4];
                ViewBag.StreamId = AllArray[5];
                ViewBag.Email = AllArray[6];
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                //itemnew.Login = LoginManager.GetById(RefId);
                ViewBag.Mobile = AllArray[7];
                ViewBag.Address = AllArray[8];

                Guid Cd = Guid.Empty;
                Guid.TryParse(itemnew.Login.Country, out Cd);


                ViewBag.Country = "N/A";

                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                Guid CourseId = Guid.Empty;
                Guid.TryParse(ViewBag.courseId, out CourseId);



                if (AllArray[2] == "Admin")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                else if (AllArray[2] == "User")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
                else
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
            }
            else
                return RedirectToAction("LogIn", "Hospital");

        }
        public ActionResult Login()
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();

                return View();
            }
            else
                return RedirectToAction("LogIn", "Home");
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


                if (AllArray[2] == "Admin")
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
                else if (AllArray[2] == "Customer")
                    return View("~/Views/Admin/Customer.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });

                else if (AllArray[2] == "Student")
                    return View("~/Views/Admin/Student.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
                else if (AllArray[2] == "Reviewer")
                    return View("~/Views/Admin/Reviewer.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
                else if (AllArray[2] == "Typist")
                    return View("~/Views/Admin/Typist.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, });
                else if (AllArray[2] == "Teacher")
                {
                    // MainModel itemnew = new MainModel();
                    string query = "select count(*) as totques from ParentQues where UserId='" + RefId + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string totqus = dt.Rows[0]["totques"].ToString();
                        ViewBag.TQues = totqus;
                    }
                    con.Close();




                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
                }
                else
                    return View("~/Views/Admin/Index.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public JsonResult IncreseSession()
        {
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.Id = AllArray[0];
            Guid LId = Guid.Empty;
            Guid.TryParse(AllArray[0], out LId);
            Login obj = LoginManager.GetById(LId);
            if (obj != null)
            {
                HttpCookie RPCookies = new HttpCookie("hospital@#123");
                RPCookies.Value = obj.Id.ToString() + "," + obj.UserName + "," + obj.Role + "," + obj.UserPic + "," + obj.Country + "," + obj.State + "," + obj.Email;
                RPCookies.Expires = DateTime.Now.AddMinutes(5);
                Response.Cookies.Add(RPCookies);

            }

            var result = "1";
            return (Json(result, JsonRequestBehavior.AllowGet));
        }



        public ActionResult ChangePassword(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();

                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.UserId = AllArray[0];

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

                itemnew.Login = LoginManager.GetById(Id);

                ViewBag.OldPassword = Decryptdata(itemnew.Login.Password);
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);

                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);
                // ViewBag.Msg = "";
                return View("~/Views/AllForms/ChangePassword.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login });
            }
            else
                return RedirectToAction("LogIn");
        }
        public ActionResult UpdatePassword(FormCollection coll)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                Guid Id = Guid.Empty;
                Guid.TryParse(coll["Id"], out Id);

                Login obj = LoginManager.GetById(Id);
                if (obj != null)
                {
                    SqlCommand cmd = new SqlCommand("Update Login set Password=@Password where Id=@Id", con);
                    if (obj.Extra1 == "Approve")
                    {
                        string strpass = encryptpass(coll["password"]);
                        cmd.Parameters.AddWithValue("@Password", strpass);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Password", obj.Password);
                    }

                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    TempData[Constant.INFO_MESSAGE] = "Password Updated Successfully";

                }
                return Redirect("../Hospital/ChangePassword?Id=" + obj.Id);
            }
            else
                return RedirectToAction("LogIn");

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



        public ActionResult Doctor(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();

                //Guid UserId = new Guid();
                itemnew.Doctor_MasterList = Doctor_MasterManager.GetAll().ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

                List<Doctor_Master> genderList = Doctor_MasterManager.GetAll();
                if (Id != Guid.Empty)
                {
                    itemnew.Doctor_Master = Doctor_MasterManager.GetById(Id);
                    ViewBag.buttontitle = "Update";
                }
                else
                {
                    //ViewBag.Relation = new SelectList(RelationList, "Relation_Code", "Relation_Type");
                    ViewBag.date = DateTime.Now;
                    ViewBag.buttontitle = "Submit";
                }

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/Doctor_Master.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Doctor_MasterList = itemnew.Doctor_MasterList, Doctor_Master = itemnew.Doctor_Master });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult SaveDoctor(FormCollection coll)
        {

            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Doctor_Master obj = new Doctor_Master();

            if (Id != Guid.Empty)
            {
                Doctor_Master oldobj = Doctor_MasterManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }
            obj.Doc_Name = coll["Doc_Name"];
            obj.Qualification = coll["Qualification"];

            if (Id != Guid.Empty)
            {
                obj.UpdatedBy = ViewBag.UserName;
                obj.UpdatedOn = DateTime.Now;
                Doctor_MasterManager.Update(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Doc_Id = Guid.NewGuid();
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                Doctor_MasterManager.Add(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return Redirect("Doctor?Id=00000000-0000-0000-0000-000000000000");
        }
        public ActionResult DeleteDoctor(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                int Lcount = 0;
                SqlCommand cmd = new SqlCommand("Doctor_Master_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Doc_Id", Id);
                con.Open();
                Lcount = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();

                if (Lcount == 1)
                { TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully."; }
                else if (Lcount == 547)
                { TempData[Constant.INFO_MESSAGE] = "Cannot Delete this data as it is inherited in another Forms."; }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
                }
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }
            return Redirect("Doctor?Id=00000000-0000-0000-0000-000000000000");
        }

        public ActionResult Patient(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();

                //Guid UserId = new Guid();
                itemnew.Patient_MasterList = Patient_MasterManager.GetAll().ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];

                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

                List<Patient_Master> genderList = Patient_MasterManager.GetAll();
                if (Id != Guid.Empty)
                {
                    itemnew.Patient_Master = Patient_MasterManager.GetById(Id);
                    ViewBag.sex = new SelectList(Constant.GenderList, "Value", "Text", itemnew.Patient_Master.Sex);
                    ViewBag.buttontitle = "Update";

                }
                else
                {
                    ViewBag.sex = new SelectList(Constant.GenderList, "Value", "Text");
                    ViewBag.date = DateTime.Now;
                    ViewBag.buttontitle = "Submit";
                }

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/Patient_Master.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Patient_MasterList = itemnew.Patient_MasterList, Patient_Master = itemnew.Patient_Master });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult SavePatient(FormCollection coll)
        {
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Patient_Master obj = new Patient_Master();

            if (Id != Guid.Empty)
            {
                Patient_Master oldobj = Patient_MasterManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.Patient_Name = coll["Patient_Name"];
            obj.Patient_UID = coll["Patient_UID"];
            obj.Age = Convert.ToInt32(coll["Age"]);
            obj.Sex = coll["drpsex"];
            obj.MobileNo = coll["MobileNo"];
            obj.Address = coll["Address"];

            if (Id != Guid.Empty)
            {
                obj.UpdatedBy = ViewBag.UserName;
                obj.UpdatedOn = DateTime.Now;
                Patient_MasterManager.Update(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.Patient_Id = Guid.NewGuid();
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                Patient_MasterManager.Add(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return Redirect("Patient?Id=00000000-0000-0000-0000-000000000000");
        }
        public ActionResult DeletePatient(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                int Lcount = 0;
                SqlCommand cmd = new SqlCommand("Patient_Master_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Patient_Id", Id);
                con.Open();
                Lcount = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();

                if (Lcount == 1)
                { TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully."; }
                else if (Lcount == 547)
                { TempData[Constant.INFO_MESSAGE] = "Cannot Delete this data as it is inherited in another Forms."; }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
                }
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }
            return Redirect("Patient?Id=00000000-0000-0000-0000-000000000000");
        }

        public ActionResult ServiceType(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.Msg = "";
                ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
                TempData[Constant.INFO_MESSAGE] = "";
                ViewBag.TypeCss = "success";
                ViewBag.MsgTitle = "Success!";

                string styp = ViewBag.service;
                string stype = ViewBag.servicetype;

                if (stype == "" || stype == null)
                {
                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_All().ToList();
                }
                else
                {
                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_All().Where(s => s.ServiceType == stype).OrderBy(s => s.ServiceName).ToList();
                }





                List<Service_type_Master> genderList = Service_type_MasterManager.GetAll_All();
                if (Id != Guid.Empty)
                {
                    itemnew.Service_type_Master = Service_type_MasterManager.GetById(Id);
                    ViewBag.servicetype = new SelectList(Constant.Hospital_ServiceType, "Value", "Text", itemnew.Service_type_Master.ServiceType);
                    ViewBag.buttontitle = "Update";
                }
                else
                {
                    ViewBag.servicetype = new SelectList(Constant.Hospital_ServiceType, "Value", "Text");
                    ViewBag.date = DateTime.Now;
                    ViewBag.buttontitle = "Submit";
                }

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/ServiceType_Master.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Service_type_MasterList = itemnew.Service_type_MasterList, Service_type_Master = itemnew.Service_type_Master });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult SaveService(FormCollection coll)
        {
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];
            MainModel itemnew = new MainModel();

            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Service_type_Master obj = new Service_type_Master();

            if (Id != Guid.Empty)
            {
                Service_type_Master oldobj = Service_type_MasterManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.ServiceType = coll["drpservice"];
            obj.ServiceName = coll["ServiceName"];
            obj.Price = decimal.Parse(coll["Price"]);
            obj.Discount = Convert.ToDecimal(coll["Discount"]);
            obj.Status = "";

            if (Id != Guid.Empty)
            {
                obj.UpdatedBy = ViewBag.UserName;
                obj.UpdatedOn = DateTime.Now;
                Service_type_MasterManager.Update(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.ServiceId = Guid.NewGuid();
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;
                Service_type_MasterManager.Add(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return Redirect("ServiceType?Id=00000000-0000-0000-0000-000000000000");
        }
        public ActionResult DeleteService(Guid Id)
        {
            MainModel itemnew = new MainModel();

            if (Id != Guid.Empty)
            {
                int Lcount = 0;
                SqlCommand cmd = new SqlCommand("Service_type_Master_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceId", Id);
                con.Open();
                Lcount = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();

                if (Lcount == 1)
                { TempData[Constant.INFO_MESSAGE] = "Record Deleted Successfully."; }
                else if (Lcount == 547)
                { TempData[Constant.INFO_MESSAGE] = "Cannot Delete this data as it is inherited in another Forms."; }
                else
                {
                    TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
                }
            }
            else
            {
                TempData[Constant.INFO_MESSAGE] = "Record Not Deleted.";
            }

            return Redirect("ServiceType?Id=00000000-0000-0000-0000-000000000000");
        }

        public ActionResult GetAllService(string Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                itemnew.Service_type_MasterList = Service_type_MasterManager.GetByServiceType(Id).ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');

                ViewBag.service = "type";
                ViewBag.servicetype = Id;

                ViewBag.servicetype = new SelectList(Constant.Hospital_ServiceType, "Value", "Text");

                //return Redirect("ServiceType?Id=00000000-0000-0000-0000-000000000000");
                return View("~/Views/Hospital/ServiceType_Master.cshtml", new MainModel { Service_type_MasterList = itemnew.Service_type_MasterList });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }

        public ActionResult GetServices(string service)
        {
            MainModel itemnew = new MainModel();
            itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_All().Where(a => a.ServiceType == service).OrderBy(a => a.ServiceName).ToList();
            return PartialView("~/Views/HospitalPartial/_ServiceType.cshtml", new MainModel { Service_type_MasterList = itemnew.Service_type_MasterList });
        }




        public ActionResult OPD()
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                //Guid UserId = new Guid();
                itemnew.Pathology_OPD_Main_DetailsList = Pathology_OPD_Main_DetailsManager.GetAll().ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.Msg = "";
                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();
                ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name");

                List<Doctor_Master> DoctorList = Doctor_MasterManager.GetAll();
                ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name");
                ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text");

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/OPD_Main.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Pathology_OPD_Main_DetailsList = itemnew.Pathology_OPD_Main_DetailsList, Pathology_OPD_Main_Details = itemnew.Pathology_OPD_Main_Details });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult AddOPD(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                //Guid UserId = new Guid();

                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];

                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();


                List<Doctor_Master> DoctorList = Doctor_MasterManager.GetAll();




                if (Id != Guid.Empty)
                {

                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_Service_GetById("OPD", Id);
                    itemnew.Pathology_OPD_Main_Details = Pathology_OPD_Main_DetailsManager.GetById(Id);

                    ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name", itemnew.Pathology_OPD_Main_Details.Doc_Id);
                    ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text", itemnew.Pathology_OPD_Main_Details.Payment_Mode);
                    ViewBag.paymentstatus = new SelectList(Constant.paymentstatus, "Value", "Text", itemnew.Pathology_OPD_Main_Details.Status);

                    ViewBag.TotaalAmount = itemnew.Pathology_OPD_Main_Details.Total_amount;
                    ViewBag.TotaalDiscount = itemnew.Pathology_OPD_Main_Details.Total_deduction;
                    ViewBag.NetAmouunt = itemnew.Pathology_OPD_Main_Details.Gross_total_amount;
                    ViewBag.NetFinalAmount = itemnew.Pathology_OPD_Main_Details.Net_total_amount;
                    ViewBag.TotaalNetPaid = itemnew.Pathology_OPD_Main_Details.PaidAmount;

                    ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name", itemnew.Pathology_OPD_Main_Details.Patient_Id);
                    List<Patient_Master> SubDistrictList = Patient_MasterManager.GetAll().Where(a => a.Patient_Id == itemnew.Pathology_OPD_Main_Details.Patient_Id).OrderBy(a => a.Patient_Name).ToList();

                    ViewBag.buttontitle = "Update";
                    ViewBag.Age = SubDistrictList[0].Age;
                    ViewBag.Sex = SubDistrictList[0].Sex;
                    ViewBag.Address = SubDistrictList[0].Address;
                    ViewBag.PaidAmount = itemnew.Pathology_OPD_Main_Details.PaidAmount;
                }
                else
                {
                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_Service("OPD");

                    ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name");
                    ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text");
                    ViewBag.paymentstatus = new SelectList(Constant.paymentstatus, "Value", "Text");

                    ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name");
                    ViewBag.date = DateTime.Now;
                    ViewBag.buttontitle = "Submit";
                    ViewBag.Age = null;
                    ViewBag.Sex = null;
                    ViewBag.Address = null;
                    ViewBag.PaidAmount = 0.00;
                    ViewBag.TotaalAmount = 0.00;
                    ViewBag.TotaalDiscount = 0.00;
                    ViewBag.NetAmouunt = 0.00;
                    ViewBag.NetFinalAmount = 0.00;
                    ViewBag.TotaalNetPaid = 0.00;
                }

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/AllForms/AddOPD.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Pathology_OPD_Main_Details = itemnew.Pathology_OPD_Main_Details, Service_type_MasterList = itemnew.Service_type_MasterList });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public JsonResult GetPatientDetail(Guid Id)
        {
            List<Patient_Master> SubDistrictList = Patient_MasterManager.GetAll().Where(a => a.Patient_Id == Id).OrderBy(a => a.Patient_Name).ToList();
            var resultsub = new { SubDistrictList = SubDistrictList };
            return (Json(resultsub, JsonRequestBehavior.AllowGet));
        }
        public ActionResult SaveOPD(FormCollection coll)
        {

            MainModel itemnew = new MainModel();
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];

            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";
            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);
            Pathology_OPD_Main_Details obj = new Pathology_OPD_Main_Details();
            if (Id != Guid.Empty)
            {
                Pathology_OPD_Main_Details oldobj = Pathology_OPD_Main_DetailsManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.MainId = Guid.NewGuid();


            //itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_All().Where(a => a.ServiceType == "OPD").OrderBy(a => a.ServiceName).ToList(); ;
            itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_Service("OPD");

            //itemnew.Service_type_Master = Service_type_MasterManager.GetById(ViewBag.sid);
            //obj.Service_type = itemnew.Service_type_Master.ServiceType;
            obj.Service_type = "OPD";
            obj.Patient_Id = Guid.Parse(coll["drpplist"]);
            obj.Doc_Id = Guid.Parse(coll["drpdlist"]);
            obj.Payment_Mode = coll["drppayment"];
            obj.Reciept_Date = DateTime.Now;

            obj.Total_amount = decimal.Parse(coll["Total_amount"]);
            obj.Total_deduction = decimal.Parse(coll["Total_deduction"]);
            obj.Gross_total_amount = decimal.Parse(coll["Gross_total_amount"]);
            obj.Additonal_discount = decimal.Parse(coll["Additonal_discount"]);
            obj.Net_total_amount = decimal.Parse(coll["Net_total_amount"]);
            obj.Remarks = coll["Remarks"];
            obj.Status = coll["drppstatus"];
            obj.extra = "extra";
            obj.extra1 = "extra1";
            obj.extra2 = "extra2";

            if (Id != Guid.Empty)
            {
                obj.MainId = Id;
                obj.UpdatedBy = ViewBag.UserName;
                obj.UpdatedOn = DateTime.Now;
                Pathology_OPD_Main_DetailsManager.Update(obj);

                foreach (var item in itemnew.Service_type_MasterList)
                {
                    string abc = coll["chkapprove_" + item.ServiceId];
                    ViewBag.nid = Guid.NewGuid();
                    int unt = int.Parse(coll["unit_" + item.ServiceId]);

                    Service_type_SubDetails obj1 = new Service_type_SubDetails();
                    if (Id != Guid.Empty)
                    {
                        Service_type_SubDetails oldobj = Service_type_SubDetailsManager.GetById(item.ServiceId);
                        if (oldobj != null)
                            obj1 = oldobj;
                    }

                    if (unt != 0)
                    {

                        decimal pamt = decimal.Parse(coll["amt_" + item.ServiceId]);

                        Service_type_Master objjj = Service_type_MasterManager.GetById(item.ServiceId);

                        if (objjj != null)
                        {
                            Service_type_SubDetails objj = new Service_type_SubDetails();
                            ViewBag.sid = item.ServiceId;
                            objj.ServiceId = ViewBag.sid;
                            objj.Price = objjj.Price;
                            objj.Discount = objjj.Discount;
                            objj.Unit = unt;
                            objj.PaidAmount = pamt;

                            objj.CreatedBy = objj.UpdatedBy = ViewBag.UserName;
                            objj.CreatedOn = objj.UpdatedOn = DateTime.Now;
                            objj.Status = "status";

                            if (Id != Guid.Empty)
                            {
                                objj.MainId = Id;
                                Service_type_SubDetailsManager.Add_temp(objj);
                            }

                        }
                    }
                }

                Service_type_SubDetailsManager.FinalUpdate(Id);
                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.MainId = obj.MainId;
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;
                Pathology_OPD_Main_DetailsManager.Add(obj);
                foreach (var item in itemnew.Service_type_MasterList)
                {
                    string abc = coll["chkapprove_" + item.ServiceId];
                    ViewBag.nid = Guid.NewGuid();
                    int unt = int.Parse(coll["unit_" + item.ServiceId]);
                    //if (coll["chkapprove_" + item.ServiceId] == "on")

                    if (unt != 0)
                    {

                        decimal pamt = decimal.Parse(coll["amt_" + item.ServiceId]);

                        Service_type_Master objjj = Service_type_MasterManager.GetById(item.ServiceId);

                        if (objjj != null)
                        {

                            Service_type_SubDetails objj = new Service_type_SubDetails();
                            ViewBag.sid = item.ServiceId;// objj.ServiceId;
                            objj.ServiceId = ViewBag.sid;
                            objj.MainId = obj.MainId;
                            objj.Price = objjj.Price;
                            objj.Discount = objjj.Discount;
                            objj.Unit = unt;
                            objj.PaidAmount = pamt;

                            objj.CreatedBy = objj.UpdatedBy = ViewBag.UserName;
                            objj.CreatedOn = objj.UpdatedOn = DateTime.Now;
                            objj.Status = "status";

                            Service_type_SubDetailsManager.Add(objj);


                        }
                    }
                }
                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return Redirect("OPD?Id=00000000-0000-0000-0000-000000000000");
        }

        public ActionResult OPD_Pending()
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                //Guid UserId = new Guid();
                itemnew.Pathology_OPD_Main_DetailsList = Pathology_OPD_Main_DetailsManager.GetAll_Pending("Pending").ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.Msg = "";
                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();
                ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name");

                List<Doctor_Master> DoctorList = Doctor_MasterManager.GetAll();
                ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name");
                ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text");

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                ViewBag.status = "pending";
                return View("~/Views/Hospital/OPD_Main.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Pathology_OPD_Main_DetailsList = itemnew.Pathology_OPD_Main_DetailsList, Pathology_OPD_Main_Details = itemnew.Pathology_OPD_Main_Details });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }


        //25-5-22 pathology
        public ActionResult Pathology()
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                //Guid UserId = new Guid();
                itemnew.Pathology_OPD_Main_DetailsList = Pathology_OPD_Main_DetailsManager.GetAll().ToList();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.Msg = "";
                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();
                ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name");

                List<Doctor_Master> DoctorList = Doctor_MasterManager.GetAll();
                ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name");
                ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text");

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/Pathology.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Pathology_OPD_Main_DetailsList = itemnew.Pathology_OPD_Main_DetailsList, Pathology_OPD_Main_Details = itemnew.Pathology_OPD_Main_Details });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult AddPathology(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                //Guid UserId = new Guid();

                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();
                List<Doctor_Master> DoctorList = Doctor_MasterManager.GetAll();
                if (Id != Guid.Empty)
                {
                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_Service_GetById("Pathology", Id);
                    itemnew.Pathology_OPD_Main_Details = Pathology_OPD_Main_DetailsManager.GetById(Id);

                    ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name", itemnew.Pathology_OPD_Main_Details.Doc_Id);
                    ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text", itemnew.Pathology_OPD_Main_Details.Payment_Mode);
                    ViewBag.paymentstatus = new SelectList(Constant.paymentstatus, "Value", "Text", itemnew.Pathology_OPD_Main_Details.Status);

                    ViewBag.TotaalAmount = itemnew.Pathology_OPD_Main_Details.Total_amount;
                    ViewBag.TotaalDiscount = itemnew.Pathology_OPD_Main_Details.Total_deduction;
                    ViewBag.NetAmouunt = itemnew.Pathology_OPD_Main_Details.Gross_total_amount;
                    ViewBag.NetFinalAmount = itemnew.Pathology_OPD_Main_Details.Net_total_amount;
                    ViewBag.TotaalNetPaid = itemnew.Pathology_OPD_Main_Details.PaidAmount;

                    ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name", itemnew.Pathology_OPD_Main_Details.Patient_Id);
                    List<Patient_Master> SubDistrictList = Patient_MasterManager.GetAll().Where(a => a.Patient_Id == itemnew.Pathology_OPD_Main_Details.Patient_Id).OrderBy(a => a.Patient_Name).ToList();

                    ViewBag.buttontitle = "Update";
                    ViewBag.Age = SubDistrictList[0].Age;
                    ViewBag.Sex = SubDistrictList[0].Sex;
                    ViewBag.Address = SubDistrictList[0].Address;
                    ViewBag.PaidAmount = itemnew.Pathology_OPD_Main_Details.PaidAmount;
                }
                else
                {
                    itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_Service("Pathology");
                    ViewBag.dlist = new SelectList(DoctorList, "Doc_Id", "Doc_Name");
                    ViewBag.paymentmode = new SelectList(Constant.paymentmodehospital, "Value", "Text");
                    ViewBag.paymentstatus = new SelectList(Constant.paymentstatus, "Value", "Text");

                    ViewBag.plist = new SelectList(PatientList, "Patient_Id", "Patient_Name");
                    ViewBag.date = DateTime.Now;
                    ViewBag.buttontitle = "Submit";
                    ViewBag.Age = null;
                    ViewBag.Sex = null;
                    ViewBag.Address = null;
                    ViewBag.PaidAmount = 0.00;
                    ViewBag.TotaalAmount = 0.00;
                    ViewBag.TotaalDiscount = 0.00;
                    ViewBag.NetAmouunt = 0.00;
                    ViewBag.NetFinalAmount = 0.00;
                    ViewBag.TotaalNetPaid = 0.00;
                }

                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/AllForms/AddPathology.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, Pathology_OPD_Main_Details = itemnew.Pathology_OPD_Main_Details, Service_type_MasterList = itemnew.Service_type_MasterList });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult SavePathology(FormCollection coll)
        {
            MainModel itemnew = new MainModel();
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];

            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";
            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);

            Pathology_OPD_Main_Details obj = new Pathology_OPD_Main_Details();
            if (Id != Guid.Empty)
            {
                Pathology_OPD_Main_Details oldobj = Pathology_OPD_Main_DetailsManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            obj.MainId = Guid.NewGuid();


            itemnew.Service_type_MasterList = Service_type_MasterManager.GetAll_All().Where(a => a.ServiceType == "Pathology").OrderBy(a => a.ServiceName).ToList();



            obj.Service_type = "Pathology";
            obj.Patient_Id = Guid.Parse(coll["drpplist"]);
            obj.Doc_Id = Guid.Parse(coll["drpdlist"]);
            obj.Payment_Mode = coll["drppayment"];
            obj.Reciept_Date = DateTime.Now;

            obj.Total_amount = decimal.Parse(coll["Total_amount"]);
            obj.Total_deduction = decimal.Parse(coll["Total_deduction"]);
            obj.Gross_total_amount = decimal.Parse(coll["Gross_total_amount"]);
            obj.Additonal_discount = decimal.Parse(coll["Additonal_discount"]);
            obj.Net_total_amount = decimal.Parse(coll["Net_total_amount"]);
            obj.Remarks = coll["Remarks"];
            obj.Status = coll["drppstatus"];
            obj.extra = "extra";
            obj.extra1 = "extra1";
            obj.extra2 = "extra2";

            if (Id != Guid.Empty)
            {
                obj.MainId = Id;
                obj.UpdatedBy = ViewBag.UserName;
                Pathology_OPD_Main_DetailsManager.Update(obj);


                foreach (var item in itemnew.Service_type_MasterList)
                {
                    string abc = coll["chkapprove_" + item.ServiceId];
                    ViewBag.nid = Guid.NewGuid();
                    int unt = int.Parse(coll["unit_" + item.ServiceId]);

                    Service_type_SubDetails obj1 = new Service_type_SubDetails();
                    if (Id != Guid.Empty)
                    {
                        Service_type_SubDetails oldobj = Service_type_SubDetailsManager.GetById(item.ServiceId);
                        if (oldobj != null)
                            obj1 = oldobj;
                    }

                    if (unt != 0)
                    {

                        decimal pamt = decimal.Parse(coll["amt_" + item.ServiceId]);

                        Service_type_Master objjj = Service_type_MasterManager.GetById(item.ServiceId);

                        if (objjj != null)
                        {
                            Service_type_SubDetails objj = new Service_type_SubDetails();
                            ViewBag.sid = item.ServiceId;
                            objj.ServiceId = ViewBag.sid;
                            objj.Price = objjj.Price;
                            objj.Discount = objjj.Discount;
                            objj.Unit = unt;
                            objj.PaidAmount = pamt;

                            objj.CreatedBy = objj.UpdatedBy = ViewBag.UserName;
                            objj.CreatedOn = objj.UpdatedOn = DateTime.Now;
                            objj.Status = "status";

                            if (Id != Guid.Empty)
                            {
                                objj.MainId = Id;
                                Service_type_SubDetailsManager.Add_temp(objj);
                            }

                        }
                    }
                }

                Service_type_SubDetailsManager.FinalUpdate(Id);

                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.MainId = obj.MainId;
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                obj.CreatedOn = obj.UpdatedOn = DateTime.Now;
                Pathology_OPD_Main_DetailsManager.Add(obj);

                foreach (var item in itemnew.Service_type_MasterList)
                {
                    string abc = coll["chkapprove_" + item.ServiceId];
                    ViewBag.nid = Guid.NewGuid();
                    int unt = int.Parse(coll["unit_" + item.ServiceId]);

                    Service_type_SubDetails obj1 = new Service_type_SubDetails();
                    if (Id != Guid.Empty)
                    {
                        Service_type_SubDetails oldobj = Service_type_SubDetailsManager.GetById(item.ServiceId);
                        if (oldobj != null)
                            obj1 = oldobj;
                    }

                    if (unt != 0)
                    {

                        decimal pamt = decimal.Parse(coll["amt_" + item.ServiceId]);

                        Service_type_Master objjj = Service_type_MasterManager.GetById(item.ServiceId);

                        if (objjj != null)
                        {
                            Service_type_SubDetails objj = new Service_type_SubDetails();
                            ViewBag.sid = item.ServiceId;
                            objj.ServiceId = ViewBag.sid;
                            objj.Price = objjj.Price;
                            objj.Discount = objjj.Discount;
                            objj.Unit = unt;
                            objj.PaidAmount = pamt;

                            objj.CreatedBy = objj.UpdatedBy = ViewBag.UserName;
                            objj.CreatedOn = objj.UpdatedOn = DateTime.Now;
                            objj.Status = "status";


                            objj.MainId = obj.MainId;
                            Service_type_SubDetailsManager.Add(objj);


                        }
                    }
                }

                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return Redirect("Pathology?Id=00000000-0000-0000-0000-000000000000");
        }

        #region Admission Slip
        public ActionResult Admission_Slip()
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                ViewBag.Msg = "";
                itemnew.IPD_Admission_SlipList = IPD_Admission_SlipManager.GetAll().ToList();
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);
                return View("~/Views/Hospital/IPD_Admission_Slip.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, IPD_Admission_SlipList = itemnew.IPD_Admission_SlipList });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }
        public ActionResult AddAdmission_Slip(Guid Id)
        {
            if (Request.Cookies["hospital@#123"] != null)
            {
                MainModel itemnew = new MainModel();
                string sid = Request.Cookies["hospital@#123"].Value;
                string[] AllArray = sid.Split(',');
                ViewBag.UserName = AllArray[1];
                ViewBag.Role = AllArray[2];
                ViewBag.Pic = AllArray[3];
                List<Patient_Master> PatientList = Patient_MasterManager.GetAll();
                List<Pathology_OPD_Main_Details> OPDList = Pathology_OPD_Main_DetailsManager.GetAll();
                if (Id != Guid.Empty)
                {
                    itemnew.IPD_Admission_Slip = IPD_Admission_SlipManager.GetById(Id);
                    ViewBag.RegType = new SelectList(Constant.RegistrationType, "Value", "Text", itemnew.IPD_Admission_Slip.Registration_Type);
                    ViewBag.OPDNo = new SelectList(OPDList, "MainId", "OP_No", itemnew.IPD_Admission_Slip.OPD_RegistrationId);
                    ViewBag.WardType = new SelectList(Constant.WardType, "Value", "Text", itemnew.IPD_Admission_Slip.WardName);
                    ViewBag.BedNoType = new SelectList(Constant.BedNumber, "Value", "Text", itemnew.IPD_Admission_Slip.BedNo);
                    ViewBag.BedType = new SelectList(Constant.BedType, "Value", "Text", itemnew.IPD_Admission_Slip.AC_Normal);
                    ViewBag.RegDate = itemnew.IPD_Admission_Slip.Ipd_Reg_Date.ToString("yyyy-MM-dd");
                    ViewBag.buttontitle = "Update";
                    ViewBag.PatientType = new SelectList(PatientList, "Patient_Id", "Patient_Name", itemnew.IPD_Admission_Slip.Patient_id);
                    itemnew.Patient_Master = Patient_MasterManager.GetById(itemnew.IPD_Admission_Slip.Patient_id);
                }
                else
                {
                    ViewBag.RegType = new SelectList(Constant.RegistrationType, "Value", "Text");
                    ViewBag.WardType = new SelectList(Constant.WardType, "Value", "Text");
                    ViewBag.BedNoType = new SelectList(Constant.BedNumber, "Value", "Text");
                    ViewBag.BedType = new SelectList(Constant.BedType, "Value", "Text");
                    ViewBag.OPDNo = new SelectList(OPDList, "MainId", "OP_No");
                    ViewBag.PatientType = new SelectList(PatientList, "Patient_Id", "Patient_Name");
                    ViewBag.RegDate = DateTime.Now.ToString("yyyy-MM-dd");

                }
                itemnew.IPD_Admission_SlipList = IPD_Admission_SlipManager.GetAll().ToList();
                Guid RefId = Guid.Empty;
                Guid.TryParse(AllArray[0], out RefId);
                itemnew.Login = LoginManager.GetById(RefId);
                itemnew.PermissionList = PermissionManager.GetByUserId(RefId);

                return View("~/Views/Hospital/AllForms/AddIPD_Admission_Slip.cshtml", new MainModel { PermissionList = itemnew.PermissionList, Login = itemnew.Login, IPD_Admission_SlipList = itemnew.IPD_Admission_SlipList, IPD_Admission_Slip = itemnew.IPD_Admission_Slip, Patient_Master= itemnew.Patient_Master });
            }
            else
                return RedirectToAction("LogIn", "Hospital");
        }

        public ActionResult SaveIPD_Admission_Slip(FormCollection coll)
        {

            MainModel itemnew = new MainModel();
            string sid = Request.Cookies["hospital@#123"].Value;
            string[] AllArray = sid.Split(',');
            ViewBag.UserName = AllArray[1];
            ViewBag.Role = AllArray[2];
            ViewBag.Pic = AllArray[3];

            ViewBag.Msg = (TempData[Constant.INFO_MESSAGE] != null ? TempData[Constant.INFO_MESSAGE] : string.Empty).ToString();
            TempData[Constant.INFO_MESSAGE] = "";
            ViewBag.TypeCss = "success";
            ViewBag.MsgTitle = "Success!";
            Guid Id = Guid.Empty;
            Guid.TryParse(coll["Id"], out Id);
            IPD_Admission_Slip obj = new IPD_Admission_Slip();
            if (Id != Guid.Empty)
            {
                IPD_Admission_Slip oldobj = IPD_Admission_SlipManager.GetById(Id);
                if (oldobj != null)
                    obj = oldobj;
            }

            Guid OPDId = Guid.Empty;
            Guid.TryParse(coll["drpopd"], out OPDId);

            if(coll["drpregtype"]== "Direct IPD Admission")
            {
                obj.Patient_id = Guid.Parse(coll["drPatient"]);
            }
            else if (coll["drpregtype"] == "Referred from OPD")
            {
                itemnew.Pathology_OPD_Main_Details = Pathology_OPD_Main_DetailsManager.GetById(OPDId);
                obj.Patient_id = itemnew.Pathology_OPD_Main_Details.Patient_Id;

            }
            obj.Registration_Type = coll["drpregtype"];
            obj.OPD_RegistrationId = OPDId;
            obj.Consultant_Name = coll["ConsName"];
            obj.ReferredBy = coll["RefBy"];
            obj.WardName = coll["drpWardType"];
            obj.RoomName = coll["Room"];
            obj.BedNo = Convert.ToInt32(coll["drpBedNo"]);
            obj.AC_Normal =coll["drpBedType"];
            obj.Status = "Complete";
            obj.Ipd_Reg_Date = Convert.ToDateTime(coll["RegDate"]);
            obj.extra = "";
            obj.extra1 = "";
            obj.extra2 = "";

            if (Id != Guid.Empty)
            {
                obj.AdmissionId = Id;
                obj.UpdatedBy = ViewBag.UserName;
                obj.UpdatedOn = DateTime.Now;
                IPD_Admission_SlipManager.Update(obj);
                TempData[Constant.INFO_MESSAGE] = "Record Updated Successfully";
            }
            else
            {
                obj.AdmissionId = Guid.NewGuid();
                obj.CreatedBy = obj.UpdatedBy = ViewBag.UserName;
                obj.CreatedOn = obj.UpdatedOn=  DateTime.Now;
                IPD_Admission_SlipManager.Add(obj);

                TempData[Constant.INFO_MESSAGE] = "Record Added Successfully.";
            }
            return RedirectToAction("Admission_Slip");
        }
        public JsonResult GetPatientDetail_OPD(Guid Id)
        {
            MainModel itemnew = new MainModel();
            itemnew.Pathology_OPD_Main_Details = Pathology_OPD_Main_DetailsManager.GetById(Id);
            List<Patient_Master> SubDistrictList = Patient_MasterManager.GetAll().Where(a => a.Patient_Id == itemnew.Pathology_OPD_Main_Details.Patient_Id).OrderBy(a => a.Patient_Name).ToList();
            var resultsub = new { SubDistrictList = SubDistrictList };
            return (Json(resultsub, JsonRequestBehavior.AllowGet));
        }
        public JsonResult GetPatientDetail_IPD(Guid Id)
        {
            MainModel itemnew = new MainModel();
            List<Patient_Master> SubDistrictList = Patient_MasterManager.GetAll().Where(a => a.Patient_Id == Id).OrderBy(a => a.Patient_Name).ToList();
            var resultsub = new { SubDistrictList = SubDistrictList };
            return (Json(resultsub, JsonRequestBehavior.AllowGet));
        }
        
        #endregion







    }
}