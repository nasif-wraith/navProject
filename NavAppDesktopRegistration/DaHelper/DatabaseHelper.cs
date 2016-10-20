using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace NavAppDesktopRegistration
{
    public class DatabaseHelper
    {
        MainDatabaseHelper MDBHelper = new MainDatabaseHelper();
        public int InsertInBranch(BranchModel branchModel, UserModel currentUser)
        {
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

        public int InsertInEmployee(EmployeeModel _employee, UserModel _currentUser)
        {
            SqlCommand cmd = new SqlCommand("InsertBranch");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeName", _employee.EmployeeName);
            cmd.Parameters.AddWithValue("@NationalID", _employee.NationalID);
            cmd.Parameters.AddWithValue("@RankID", _employee.RankID);
            cmd.Parameters.AddWithValue("@DepartmentID", _employee.DepartmentID);
            cmd.Parameters.AddWithValue("@BranchID", _employee.BranchID);
            cmd.Parameters.AddWithValue("@IssuedCardID", _employee.IssuedCardID);
            cmd.Parameters.AddWithValue("@DateOfBirth", _employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@Height", _employee.Height);
            cmd.Parameters.AddWithValue("@BloodGroup", _employee.BloodGroup);
            cmd.Parameters.AddWithValue("@IdentificationMark", _employee.IdentificationMark);
            cmd.Parameters.AddWithValue("@EmployeeSignatureFilePath", _employee.EmployeeSignatureFilePath);
            //cmd.Parameters.AddWithValue("@AuthoritySignatureFilePath", _employee.AuthoritySignatureFilePath);
            cmd.Parameters.AddWithValue("@AuthorizedBy", _currentUser.UserID);
            cmd.Parameters.Add("@AuthorizedDate", SqlDbType.DateTime);
            cmd.Parameters.Add("@DateOfIssue", SqlDbType.DateTime);
            cmd.Parameters["@AuthorizedDate"].Value =  DateTime.Now;
            cmd.Parameters["@DateOfIssue"].Value =  DateTime.Now;

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
            cmd.Parameters.AddWithValue("@CardID", _employee.Rfid);
            cmd.Parameters.AddWithValue("@PreviousOfficeIds", _employee.PreviousOfficeID);
            cmd.Parameters.AddWithValue("@CreatedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@ModifiedBy", null);
            cmd.Parameters.AddWithValue("@ModifiedDate", null);
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
            int EmployeeID = MDBHelper.RunQuerryInEmployee(cmd);
            return _employee.EmployeeID;
        }
    }
}
