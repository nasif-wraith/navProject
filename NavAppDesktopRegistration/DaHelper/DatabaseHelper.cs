using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace NavAppDesktopRegistration
{
    public class DatabaseHelper
    {

        MainDatabaseHelper MDBHelper;

        #region for insert update delete in Branch
        public int InsertInBranch(BranchModel branchModel, UserModel currentUser)
        {
            MDBHelper = new MainDatabaseHelper();

            SqlCommand cmd = new SqlCommand("InsertBranch");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchName", branchModel.BranchName);
            cmd.Parameters.AddWithValue("@Address", branchModel.Address);
            cmd.Parameters.AddWithValue("@Contact", branchModel.Contact);
            //cmd.Parameters.AddWithValue("@DepartmentID", branchModel.DepartmentID);
            cmd.Parameters.AddWithValue("@CreatedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            cmd.Parameters.Add("@BranchID", SqlDbType.Int).Direction = ParameterDirection.Output;
            int BranchID = MDBHelper.RunQuerryInBranch(cmd);
            //int BranchID = int.Parse(cmd.Parameters["@BranchID"].Value.ToString());
            return BranchID;
        }

        public   BranchModel SelectAllFromBranch(BranchModel branchModel, UserModel currentUser)
        {
            MDBHelper = new MainDatabaseHelper();
            BranchModel branch = new BranchModel();
            SqlCommand cmd = new SqlCommand("Select  * from Branches where BranchID = " + branchModel.BranchID);
            //SqlCommand cmd = new SqlCommand("GetBranchInfo");
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@branchID", branchModel.BranchID);
            //cmd.Parameters.Add("@BranchName",SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //cmd.Parameters.Add("@Address", SqlDbType.VarChar,100).Direction = ParameterDirection.Output;
            //cmd.Parameters.Add("@Contact", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            branch = MDBHelper.GetDataFromBranch(cmd, branch);
            return branch;
        }

        public void UpdateInBranch(BranchModel branchModel, UserModel currentUser)
        {
            MDBHelper = new MainDatabaseHelper();

            SqlCommand cmd = new SqlCommand("UpdateBranch");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BranchID", branchModel.BranchID);
            cmd.Parameters.AddWithValue("@BranchName", branchModel.BranchName);
            cmd.Parameters.AddWithValue("@Address", branchModel.Address);
            cmd.Parameters.AddWithValue("@Contact", branchModel.Contact);
            //cmd.Parameters.AddWithValue("@DepartmentID", branchModel.DepartmentID);
            cmd.Parameters.AddWithValue("@CreatedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            //cmd.Parameters.Add("@BranchID", SqlDbType.Int).Direction = ParameterDirection.Output;
            //int BranchID = 
                MDBHelper.RunUpdateInBranch(cmd);
            //int BranchID = int.Parse(cmd.Parameters["@BranchID"].Value.ToString());
            //return BranchID;
        }
        
        public void DeleteFromBranch(BranchModel branchModel)
        {
            MDBHelper = new MainDatabaseHelper();
            BranchModel branch = new BranchModel();
            SqlCommand cmd = new SqlCommand("Delete  from Branches where BranchID = " + branchModel.BranchID);
            //SqlCommand cmd = new SqlCommand("GetBranchInfo");
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.Text;
            MDBHelper.Delete(cmd, branch);
        }
        #endregion

        #region Insert Update Delete in Employee
        public int InsertInEmployee(EmployeeModel _employee, UserModel _currentUser)
        {

            DateTime rngMin = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            //DateTime.MinValue = rngMin;
            
            MDBHelper = new MainDatabaseHelper();
            DateTime datetimeNow = DateTime.Now;
            //MessageBox.Show(""  + datetimeNow);
            SqlCommand cmd = new SqlCommand("InsertEmployee");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeName", _employee.EmployeeName);
            cmd.Parameters.AddWithValue("@RankID", _employee.RankID);
            cmd.Parameters.AddWithValue("@DepartmentID", _employee.DepartmentID);
            cmd.Parameters.AddWithValue("@BranchID", _employee.BranchID);
            cmd.Parameters.AddWithValue("@IssuedCardID", _employee.IssuedCardID);
            cmd.Parameters.AddWithValue("@Height", _employee.Height);
            cmd.Parameters.AddWithValue("@BloodGroup", _employee.BloodGroup);
            cmd.Parameters.AddWithValue("@IdentificationMark", _employee.IdentificationMark);
            cmd.Parameters.AddWithValue("@EmployeeSignatureFilePath", _employee.EmployeeSignatureFilePath);
            //cmd.Parameters.AddWithValue("@AuthoritySignatureFilePath", _employee.AuthoritySignatureFilePath);
            cmd.Parameters.AddWithValue("@AuthorizedBy", _currentUser.UserID);
            cmd.Parameters.Add("@AuthorizedDate", SqlDbType.DateTime).Value = _employee.AuthorizedDate;
            cmd.Parameters.Add("@DateOfIssue", SqlDbType.DateTime).Value = _employee.DateOfIssue;
            cmd.Parameters.AddWithValue("@EmployersCategory", _employee.EmployersCatagory);
            cmd.Parameters.AddWithValue("@DateOfRetirement", _employee.DateOfRetirement);
            cmd.Parameters.AddWithValue("@DateOfJoining", _employee.DateOfJoining);
            cmd.Parameters.AddWithValue("@MaritalStatus", _employee.MaritalStatus);
            cmd.Parameters.AddWithValue("@PresentAddress", _employee.PresentAdress);
            cmd.Parameters.AddWithValue("@PermanentAddress", _employee.PermanentAddress);
            cmd.Parameters.AddWithValue("@EmailAddress", _employee.EmailAddress);
            cmd.Parameters.AddWithValue("@ContactNumber", _employee.ContactNumber);
            cmd.Parameters.AddWithValue("@PoliceStation", _employee.PoliceStation);
            cmd.Parameters.AddWithValue("@PoliceStationContactNumber", _employee.PoliceStationContactNumber);
            cmd.Parameters.AddWithValue("@FamilyPersonName", _employee.FamilyPersonName);
            cmd.Parameters.AddWithValue("@FamilyPersonNID", _employee.FamilyPersonNID);
            cmd.Parameters.AddWithValue("@FamilyPersonContactNumber", _employee.FamilyPersonContactNumber);
            cmd.Parameters.AddWithValue("@FamilyPersonPoliceStation", _employee.FamilyPersonPoliceStation);
            cmd.Parameters.AddWithValue("@OfficeID", _employee.OfficeID);
            cmd.Parameters.AddWithValue("@PreviousOfficeIds", _employee.PreviousOfficeID);
            cmd.Parameters.AddWithValue("@CreatedBy", _currentUser.UserID);
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = _employee.CreatedDate;
            cmd.Parameters.AddWithValue("@ModifiedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@PersonalNo", _employee.PersonalNo);
            cmd.Parameters.AddWithValue("@DateOfBirth", _employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@imagePath", _employee.EmployeeImagePath);
            cmd.Parameters.AddWithValue("@CardID", _employee.Rfid);
            cmd.Parameters.AddWithValue("@NationalID", _employee.NationalID);
            cmd.Parameters.AddWithValue("@FingerPrintPath", _employee.FingerPrintPath);
            cmd.Parameters.AddWithValue("@RfID", _employee.Rfid);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            int EmployeeID = MDBHelper.RunQuerryInEmployee(cmd);
            return _employee.EmployeeID;





            //cmd.Parameters["@AuthorizedDate"].Value = datetimeNow;
            //cmd.Parameters["@DateOfIssue"].Value = datetimeNow;





            //cmd.Parameters["@CreatedDate"].Value = datetimeNow;
            // cmd.Parameters.AddWithValue("@CreatedDate", datetimeNow);


        }
        #endregion

        #region Insert Update Delete in Department
        public int InsertIntoDepartment(DepartmentModel dept, UserModel currentUser)
        {
            MDBHelper = new MainDatabaseHelper();
            SqlCommand cmd = new SqlCommand("InsertDepartment");
            cmd.Parameters.AddWithValue("@DepartmentName", dept.DepartmentName);
            cmd.Parameters.AddWithValue("@CreatedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@Modifiedate", DateTime.Now);
            cmd.Parameters.AddWithValue("@DeptBranch",dept.DeptBranch);
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Direction = ParameterDirection.Output;
            int departmentID = MDBHelper.RunQueryInDepartment(cmd);
            return departmentID;
        }
        #endregion

        #region insert update delete in User
        public int InsertIntoUser(UserModel user, UserModel currentUser)
        {
            MDBHelper = new MainDatabaseHelper();
            SqlCommand cmd = new SqlCommand("InsertUsers");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", user.EmployeeID);
            cmd.Parameters.AddWithValue("@IsSuperAdmin", user.IsSuperAdmin);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@PreviousPasswords", user.PreviousPassword);
            cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
            cmd.Parameters.AddWithValue("@CreatedBy", currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", currentUser.UserID); //needs to be discussed
            cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now); //needs to know what to implement
            cmd.Parameters.AddWithValue("@IsAdmin", user.IsActive);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Direction = ParameterDirection.Output;
            int ID = MDBHelper.RunQueryInUser(cmd);
            return ID;
        }
        #endregion
    }
}
