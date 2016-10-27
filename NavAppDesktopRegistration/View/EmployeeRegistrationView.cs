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
using System.Diagnostics;
using System.Drawing.Imaging;

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
        private Bitmap _bmp;
        private int i = 0;
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
            //_bmp = new Bitmap(signature_pictureBox.Image);

        }
        #endregion

        #region public methods
        public void GetBmp( Bitmap bmp)
        {
            _bmp = bmp;
        }


        #endregion


        #region Private Method
        private static Image ResizeImage(int newSize, Image originalImage)
        {
            if (originalImage.Width <= newSize)
                newSize = originalImage.Width;

            var newHeight = originalImage.Height * newSize / originalImage.Width;

            if(newHeight > newSize)
            {
                newSize = originalImage.Width * newSize / originalImage.Height;
                newHeight = newSize;
            }
            return originalImage.GetThumbnailImage(newSize, newHeight, null, IntPtr.Zero);
        }
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
        private void getImageToPictureBox(object sender , FormClosedEventArgs e)
        {
            signature_pictureBox.Load("asdf.bmp");
            signature_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            signature_box.Text = signature_pictureBox.ImageLocation;
            _signaturePath = signature_box.Text;
            Image im = Image.FromFile(signature_pictureBox.ImageLocation);
            int size = 300;
            Image newImage = ResizeImage(size, im);
            //MessageBox.Show("path is  " + signature_box.ImageLocation)
            using (Bitmap bitmap = (Bitmap)newImage)
            {
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    newBitmap.Save("" + i + ".jpg", ImageFormat.Jpeg);
                    i++;
                }
            }
        }
        #region private events or callback
        private void signature_btn_Click(object sender, EventArgs e)
        {
            _signature = new signaturePadView();
            _signature.Show();
            _signature.FormClosed += getImageToPictureBox;
           // signature_pictureBox.Image = _bmp;
            //signature_pictureBox.Load("asdf.bmp");
            //OpenFileDialog pic = new OpenFileDialog();
           // if (pic.ShowDialog() == DialogResult.OK)
           // {
                // pictureBox1.Image = Image.FromFile(pic.FileName);
              //  signature_pictureBox.Load(pic.FileName);
           //  signature_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //textBox1.Text = pic.FileName;
            //signature_box.Text =picture_box
            //_bmp.Save("img" );
           // _signaturePath = signature_pictureBox.ImageLocation;
          //  }

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
            
            Process.Start(@"D:\C# Fingerprint\bin\Debug\zkfinger_demo");
        }

        private void close_employee_register_btn_Click(object sender, EventArgs e)
        {
            formClose();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            _employee = new EmployeeModel();
            _employee.EmployeeName = text_name.Text;
            //string rank = rankCombo.SelectedText;
            _employee.RankID = 1;
            _employee.DepartmentID = 1; //dept_combo.SelectedText;
            _employee.BranchID = 1; // branch_combo.SelectedText;
            _employee.IssuedCardID = 1;
            _employee.Height = height_box.Text;
            _employee.BloodGroup = bloodGrpCombo.SelectedText;
            _employee.IdentificationMark = identificationMark_box.Text;
            _employee.EmployeeSignatureFilePath = _signaturePath;
            _employee.AuthorizedBy = _currentUser.UserID;
            _employee.AuthorizedDate = DateTime.Now;
            _employee.DateOfIssue = DateTime.Now;
            _employee.EmployersCatagory = EmployeesCatagory_box.Text;
            _employee.DateOfRetirement = DateTime.Now;   //it will be changed
            _employee.DateOfJoining = doj_datetimepicker.Value;
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
            _employee.PreviousOfficeID = "0"; //this will be changed.
            _employee.CreatedBy = _currentUser.CreatedBy;
            _employee.CreatedDate = DateTime.Now;
            _employee.ModifiedBy = _currentUser.UserID; //changed korte hobe
            _employee.ModifiedDate = DateTime.Now;
            _employee.PersonalNo = Int32.Parse(tbPersonnelNo.Text);
            _employee.DateOfBirth = dob_dateTimePicker.Value;
            _employee.EmployeeImagePath = _picturePath;
            _employee.CardID = "1";
            _employee.NationalID = nationalId_box.Text;
            _employee.FingerPrintPath = _fingerprintPath;
            _employee.Rfid = Int32.Parse(RFID_box.Text);        
            //dummy var
            

                       
            DatabaseHelper DBhelp = new DatabaseHelper();
            int ID = DBhelp.InsertInEmployee(_employee, _currentUser);
            MessageBox.Show("everything is uploaded.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void rankCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }







        #region signature pad codes

        #endregion
       
        private void Pickbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if(pic.ShowDialog() == DialogResult.OK)
            {
                signature_pictureBox.Load(pic.FileName);
                //signature_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //signature_box.Text = pic.FileName;
                //_signaturePath = signature_box.Text;
                //Image im = Image.FromFile(pic.FileName);
                //int size = 300;
                //Image newImage = ResizeImage(size, im);
                ////MessageBox.Show("path is  " + signature_box.ImageLocation)
                //using (Bitmap bitmap = (Bitmap)newImage)
                //{
                //    using (Bitmap newBitmap = new Bitmap(bitmap))
                //    {
                //        newBitmap.Save("" +i + ".jpg", ImageFormat.Jpeg);
                //        i++;
                //    }
                //}
                    } 
        }

        private void pickFingerPrint_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog() == DialogResult.OK)
            {
                // picturebox1.image = image.fromfile(pic.filename);
                finger_pictureBox.Load(pic.FileName);
                finger_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //textbox1.text = pic.filename;
                fingerprint_box.Text = pic.FileName;
                _fingerprintPath = pic.FileName;

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
