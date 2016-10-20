using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavAppDesktopRegistration
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string NationalID { get; set; }
        public int RankID { get; set; }
        public int  DepartmentID { get; set; }
        public int BranchID { get; set; }
        public int IssuedCardID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Height { get; set; }
        public string BloodGroup { get; set; }
        public string IdentificationMark { get; set; }
        public string EmployeeSignatureFilePath { get; set; }
        public string AuthoritySignatureFilePath { get; set; }
        public int AuthorizedBy { get; set; }
        public DateTime AuthorizedDate { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string EmployersCatagory { get; set; }
        public DateTime DateOfRetirement { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int MaritalStatus { get; set; }
        public string PresentAdress { get; set; }
        public string PermanentAddress { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string PoliceStation { get; set; }
        public string PoliceStationContactNumber { get; set; }
        public string FamilyPersonName { get; set; }
        public string FamilyPersonNID { get; set; }
        public string FamilyPersonContactNumber { get; set; }
        public string FamilyPersonPoliceStation { get; set; }
        public string EmployeeImagePath { get; set; }
        public string FingerPrintPath { get; set; }
        public int OfficeID { get; set; }
        public string PreviousOfficeID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Rfid { get; set; }

        //add more Properties see Database Table
    }
}
