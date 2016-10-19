using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace NavAppDesktopRegistration
{
    
    public partial class EmployeeRegistrationView : Form
    {
        
        #region private fields
        private UserModel _currentUser;
        private EmployeeModel _employee;
        private string signaturetext;
        private string picturetext;
        private string fingerprinttext;
        private Form _previousForm;
        //private static EmployeeRegistrationView instance = null;
        //private static readonly object padlock = new object();
        #endregion

        #region ctor
        public EmployeeRegistrationView()
        {
            InitializeComponent();
        }
        public EmployeeRegistrationView(UserModel currentUser, Form prevForm)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _previousForm = prevForm;
            loadAllCombo(rankCombo, typeof(RanksEnum));
            loadAllCombo(bloodGrpCombo, typeof(BloodGroupEnum));
            loadAllCombo(maritalStatus_combo, typeof(MarriedEnum));
            
        }
        #endregion

        #region public methods

        //public static EmployeeRegistrationView Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new EmployeeRegistrationView();
        //            }
        //            return instance;
        //        }
        //    }
        //}

        #endregion


        #region Private Method

        void loadAllCombo(ComboBox combobox,Type enumType)   ///akta helper class a rakhte hobe.
        {
            combobox.DataSource = Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            }).OrderBy(item => item.value).ToList();
            combobox.DisplayMember = "Description";
            combobox.ValueMember = "value";

        }
        void formClose()
        {
            //this.Hide();
            //_previousForm.Show();
            this.Close();
        }
       
        #endregion

        #region private events or callback
        private void signature_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                // pictureBox1.Image = Image.FromFile(pic.FileName);
                signature_pictureBox.Load(pic.FileName);
                signature_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.Text = pic.FileName;
                signature_box.Text = pic.FileName;
                _employee.EmployeeSignatureFilePath = pic.FileName;
                //MessageBox.Show("path is " + signature_pictureBox.ImageLocation);
            }
        }

        private void picture_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                // pictureBox1.Image = Image.FromFile(pic.FileName);
                picture_pictureBox.Load(pic.FileName);
                picture_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.Text = pic.FileName;
                picture_box.Text = pic.FileName;
                _employee.EmployeeImagePath = pic.FileName;
                // MessageBox.Show("path is " + picture_pictureBox.ImageLocation);
            }
        }

        private void finger_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                // pictureBox1.Image = Image.FromFile(pic.FileName);
                finger_pictureBox.Load(pic.FileName);
                finger_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //textBox1.Text = pic.FileName;
                fingerprint_box.Text = pic.FileName;
                _employee.FingerPrintPath = pic.FileName;
                //MessageBox.Show("path is " + finger_pictureBox.ImageLocation);
            }
        }

        private void close_employee_register_btn_Click(object sender, EventArgs e)
        {
            formClose();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            _employee.EmployeeName = text_name.Text;
            _employee.NationalID = nationalId_box.Text;
            //string rank = rankCombo.SelectedText;
            _employee.RankID = 1;
            _employee.DepartmentID = 1; //dept_combo.SelectedText;
            _employee.BranchID = 1; // branch_combo.SelectedText;
            _employee.DateOfBirth = dob_dateTimePicker.Value;
            _employee.Height = height_box.Text;
            _employee.BloodGroup = bloodGrpCombo.SelectedText;
            _employee.IdentificationMark = identificationMark_box.Text;
            _employee.DateOfJoining = doj_datetimepicker.Value;
            _employee.EmployersCatagory = EmployeesCatagory_box.Text;
            _employee.MaritalStatus = 1; // maritalStatus_combo.SelectedText;
            _employee.PresentAdress = presentAddress_box.Text;
            _employee.PermanentAddress = permanentAddress_box.Text;
            _employee.EmailAddress = email_box.Text;
            _employee.ContactNumber = contact_box.Text;
            _employee.PoliceStation = policeStation_box.Text;
            _employee.PoliceStationContactNumber = pscontact_box.Text;
            _employee.FamilyPersonName = f_memberName_box.Text;
            _employee.FamilyPersonNID = f_memberNID_box.Text;
            _employee.FamilyPersonContactNumber = f_memberContact_box.Text;
            _employee.FamilyPersonPoliceStation = f_memberPS_box.Text;
            _employee.OfficeID = 0;
            int rfid = Int32.Parse(RFID_box.Text);
            _employee.PreviousOfficeID = "0";

            //int r=1;

            //string rank = rankCombo.SelectedItem.ToString();
            //if(rank=="leading seaman")
            //{r=1;}
            //else if (rank=="petty office")
            //{r=2;}
            //else if (rank=="chief petty office")
            //{r=3;}
            //else if (rank=="master chief petty officer")
            //{r=4;}
            //else if (rank=="mid ship man")
            //{r=5;}
            //else if (rank=="sub lieutenant")
            //{r=6;}
            //else if (rank=="lieutenant")
            //{r=7;}
            //else if (rank=="lieutenant commander")
            //{r=8;}
            //else if (rank=="captain")
            //{r=9;}
            //else if (rank=="comodor")
            //{r=10;}
            //else if (rank=="rear admiral")
            //{r=11;}
            //else if (rank=="vice admiral")
            //{r=12;}
            //else if (rank=="admiral")
            //{r=13;}
            //else if(rank=="admiral of the fleet")
            //{ r = 14;}


            //dummy var
            int issuedcardID = 1;

            DateTime datetime = DateTime.Now;
            //string datetime = "'20161025'";
            //string connectionString = @"Data Source=DESKTOP-7FART4C\SQLEXPRESS;Initial Catalog=FInal_navy;Integrated Security=True";
            //string connectionString = @"Data Source=DESKTOP-AG0F2UT\NASIF;Initial Catalog=FInal_navy;Integrated Security=True";
           //try catch block create korte hobe
            //DB helper class implement korte hobe
            string connectionString = @"Data Source=192.168.0.107,49170;Initial Catalog=FInal_navy ;User ID=sa;Password=sa;";

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("emp_register", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter prmName = 
            cmd.Parameters.AddWithValue("@EmployeeName", _employee.EmployeeName);
            cmd.Parameters.AddWithValue("@NationalID", _employee.NationalID);
            cmd.Parameters.AddWithValue("@RankID", _employee.RankID);
            cmd.Parameters.AddWithValue("@DepartmentID", _employee.DepartmentID);
            cmd.Parameters.AddWithValue("@BranchID", _employee.BranchID);
            cmd.Parameters.AddWithValue("@IssuedCardID", issuedcardID);
            cmd.Parameters.AddWithValue("@DateOfBirth", _employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@Height", _employee.Height);
            cmd.Parameters.AddWithValue("@BloodGroup", _employee.BloodGroup);
            cmd.Parameters.AddWithValue("@IdentificationMark", _employee.IdentificationMark);
            cmd.Parameters.AddWithValue("@EmployeeSignatureFilePath", signature_box.Text);
            cmd.Parameters.AddWithValue("@AuthoritySignatureFilePath", signature_box.Text);
            cmd.Parameters.AddWithValue("@AuthorizedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@AuthorizedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateOfIssue", DateTime.Now);
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
            cmd.Parameters.AddWithValue("@CardID", rfid);
            cmd.Parameters.AddWithValue("@PreviousOfficeIds", _employee.PreviousOfficeID);
            cmd.Parameters.AddWithValue("@CreatedBy", _currentUser.UserID);
            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", null);
            cmd.Parameters.AddWithValue("@ModifiedDate", null);

            SqlParameter prmID = new SqlParameter()
            {
                ParameterName = "@EmployeeID",
                Value = -1,
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(prmID);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("everything is uploaded", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void rankCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
