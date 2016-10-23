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
using VBTablet;

namespace NavAppDesktopRegistration
{
    
    public partial class EmployeeRegistrationView : Form
    {
        
        #region private fields
        private UserModel _currentUser;
        private EmployeeModel _employee;
        private string _signaturePath;
        private string _picturePath;
        private string _fingerprintPath;
        private Form _previousForm;
        private signaturePadView _signature;
       
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
            _signature = new signaturePadView();
            
        }
        #endregion

        #region public methods



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
            _signature.Show();
            //OpenFileDialog pic = new OpenFileDialog();
            //if (pic.ShowDialog() == DialogResult.OK)
            //{
            //    // pictureBox1.Image = Image.FromFile(pic.FileName);
            //    signature_pictureBox.Load(pic.FileName);
            //    signature_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //    //textBox1.Text = pic.FileName;
            //    signature_box.Text = pic.FileName;
            //    _signaturePath = pic.FileName;
            //}

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
                _picturePath = pic.FileName;
               
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
                _fingerprintPath = pic.FileName;
                
            }
        }

        private void close_employee_register_btn_Click(object sender, EventArgs e)
        {
            formClose();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            _employee = new EmployeeModel();
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
            _employee.Rfid = Int32.Parse(RFID_box.Text);
            _employee.PreviousOfficeID = "0";
            _employee.EmployeeSignatureFilePath = _signaturePath;
            _employee.FingerPrintPath = _fingerprintPath;
            _employee.EmployeeImagePath = _picturePath;
            _employee.PersonnelNo = Int32.Parse(tbPersonnelNo.Text);
            _employee.CreatedDate = DateTime.Now;
            _employee.ModifiedDate = DateTime.Now;
            _employee.AuthorizedDate = DateTime.Now;
            _employee.DateOfIssue = DateTime.Now;
            //dummy var
            _employee.IssuedCardID = 1;
                       
            DatabaseHelper DBhelp = new DatabaseHelper();
            int ID = DBhelp.InsertInEmployee(_employee, _currentUser);
            MessageBox.Show("everything is uploaded. \nEmployee ID is : "+ID, "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void rankCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        #region signature pad codes
       
        #endregion





    }
}
