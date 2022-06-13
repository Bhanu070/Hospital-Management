using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Hospital_Management.Models
{
    public class MainModel
    {
        [Required(ErrorMessage = "Mobile No. must  be 10 digit")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNo { get; set; }
        public int ClickCount { get; set; }
        public MainModel()
        {
            this.Login = new Login();
            this.LoginList = new List<Login>();

            this.Permission = new Permission();
            this.PermissionList = new List<Permission>();


            this.MenuCategory = new MenuCategory();
            this.MenuCategoryList = new List<MenuCategory>();

            this.MenuMaster = new MenuMaster();
            this.MenuMasterList = new List<MenuMaster>();


            this.Doctor_Master = new Doctor_Master();
            this.Doctor_MasterList = new List<Doctor_Master>();

            this.Patient_Master = new Patient_Master();
            this.Patient_MasterList = new List<Patient_Master>();

            this.Service_type_Master = new Service_type_Master();
            this.Service_type_MasterList = new List<Service_type_Master>();

            this.Pathology_OPD_Main_Details = new Pathology_OPD_Main_Details();
            this.Pathology_OPD_Main_DetailsList = new List<Pathology_OPD_Main_Details>();

            this.Service_type_SubDetails = new Service_type_SubDetails();
            this.Service_type_SubDetailsList = new List<Service_type_SubDetails>();

            this.IPD_Admission_Slip = new IPD_Admission_Slip();
            this.IPD_Admission_SlipList = new List<IPD_Admission_Slip>();

            this.IPD_Main_Details = new IPD_Main_Details();
            this.IPD_Main_DetailsList = new List<IPD_Main_Details>();
            
        }


        public MenuMaster MenuMaster { get; set; }
        public List<MenuMaster> MenuMasterList { get; set; }

        public MenuCategory MenuCategory { get; set; }
        public List<MenuCategory> MenuCategoryList { get; set; }

        public Login Login { get; set; }
        public List<Login> LoginList { get; set; }


        public Permission Permission { get; set; }
        public List<Permission> PermissionList { get; set; }


        public Service_type_SubDetails Service_type_SubDetails { get; set; }
        public List<Service_type_SubDetails> Service_type_SubDetailsList { get; set; }


        public Doctor_Master Doctor_Master { get; set; }
        public List<Doctor_Master> Doctor_MasterList { get; set; }

        public Patient_Master Patient_Master { get; set; }
        public List<Patient_Master> Patient_MasterList { get; set; }

        public Service_type_Master Service_type_Master { get; set; }
        public List<Service_type_Master> Service_type_MasterList { get; set; }

        public Pathology_OPD_Main_Details Pathology_OPD_Main_Details { get; set; }
        public List<Pathology_OPD_Main_Details> Pathology_OPD_Main_DetailsList { get; set; }

        public IPD_Admission_Slip IPD_Admission_Slip { get; set; }
        public List<IPD_Admission_Slip> IPD_Admission_SlipList { get; set; }

        public IPD_Main_Details IPD_Main_Details { get; set; }
        public List<IPD_Main_Details> IPD_Main_DetailsList { get; set; }

        
    }
}