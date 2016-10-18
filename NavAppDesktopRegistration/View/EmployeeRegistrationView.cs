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

        void loadAllCombo(ComboBox combobox,Type enumType)
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
                //MessageBox.Show("path is " + finger_pictureBox.ImageLocation);
            }
        }

        private void close_employee_register_btn_Click(object sender, EventArgs e)
        {
            formClose();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            string employeeName = text_name.Text;
            string nationalID = nationalId_box.Text;
            string rank = rankCombo.SelectedText;
            string dept = dept_combo.SelectedText;
            string branch = branch_combo.SelectedText;
            DateTime dob = dob_dateTimePicker.Value;
            //string dob = "'20161025'";
            //DateTime dob = dob_dateTimePicker.Value.Date
            string height = height_box.Text;
            string blood_Group = bloodGrpCombo.SelectedText;
            string identification = identificationMark_box.Text;
            DateTime doj = doj_datetimepicker.Value;
            //string doj = "'20161025'"; 
            string employer_catagory = EmployeesCatagory_box.Text;
            string marital_status = maritalStatus_combo.SelectedText;
            string present_address = presentAddress_box.Text;
            string permanent_address = permanentAddress_box.Text;
            string email = email_box.Text;
            string contact = contact_box.Text;
            string police_station = policeStation_box.Text;
            string police_stationContact = pscontact_box.Text;
            string family_person_name = f_memberName_box.Text;
            string family_NID = f_memberNID_box.Text;
            string family_contact = f_memberContact_box.Text;
            string family_PS = f_memberPS_box.Text;
            int office_Id = 0;
            int rfid = Int32.Parse(RFID_box.Text);
            string previousOfficeID = "0";

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
            string connectionString = @"Data Source=DESKTOP-7FART4C\SQLEXPRESS;Initial Catalog=FInal_navy;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("emp_register", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter prmName = 
            cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
            cmd.Parameters.AddWithValue("@NationalID", nationalID);
            cmd.Parameters.AddWithValue("@RankID", rank);
            cmd.Parameters.AddWithValue("@DepartmentID", dept);
            cmd.Parameters.AddWithValue("@BranchID", branch);
            cmd.Parameters.AddWithValue("@IssuedCardID", issuedcardID);
            cmd.Parameters.AddWithValue("@DateOfBirth", dob);
            cmd.Parameters.AddWithValue("@Height", height);
            cmd.Parameters.AddWithValue("@BloodGroup", blood_Group);
            cmd.Parameters.AddWithValue("@IdentificationMark", identification);
            cmd.Parameters.AddWithValue("@EmployeeSignatureFilePath", signature_box.Text);
            cmd.Parameters.AddWithValue("@AuthoritySignatureFilePath", signature_box.Text);
            cmd.Parameters.AddWithValue("@AuthorizedBy", issuedcardID);
            cmd.Parameters.AddWithValue("@AuthorizedDate", doj);
            cmd.Parameters.AddWithValue("@DateOfIssue", doj);
            cmd.Parameters.AddWithValue("@EmployersCategory", employer_catagory);
            cmd.Parameters.AddWithValue("@DateOfRetirement", doj);
            cmd.Parameters.AddWithValue("@DateOfJoining", doj);
            cmd.Parameters.AddWithValue("@MaritalStatus", marital_status);
            cmd.Parameters.AddWithValue("@PresentAddress", present_address);
            cmd.Parameters.AddWithValue("@PermanentAddress", permanent_address);
            cmd.Parameters.AddWithValue("@EmailAddress", email);
            cmd.Parameters.AddWithValue("@ContactNumber", contact);
            cmd.Parameters.AddWithValue("@PoliceStation", police_station);
            cmd.Parameters.AddWithValue("@PoliceStationContactNumber", police_stationContact);
            cmd.Parameters.AddWithValue("@FamilyPersonName", family_person_name);
            cmd.Parameters.AddWithValue("@FamilyPersonNID", family_NID);
            cmd.Parameters.AddWithValue("@FamilyPersonContactNumber", family_contact);
            cmd.Parameters.AddWithValue("@FamilyPersonPoliceStation", family_PS);
            cmd.Parameters.AddWithValue("@OfficeID", office_Id);
            cmd.Parameters.AddWithValue("@CardID", rfid);
            cmd.Parameters.AddWithValue("@PreviousOfficeIds", previousOfficeID);
            cmd.Parameters.AddWithValue("@CreatedBy", office_Id);
            cmd.Parameters.AddWithValue("@CreatedDate", datetime);
            cmd.Parameters.AddWithValue("@ModifiedBy", office_Id);
            cmd.Parameters.AddWithValue("@ModifiedDate", datetime);

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
        
    }
}
