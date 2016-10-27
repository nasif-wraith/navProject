using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VBTablet;

namespace NavAppDesktopRegistration
{
    public partial class signaturePadView : Form
    {

        public Tablet Digitizer;
        int tmpl;
        string tmps;
        int Xold, Yold, RectWidth;
        Bitmap bmp ;

        public signaturePadView()
        {
            InitializeComponent();
            //bmp = new Bitmap(picDraw.Width, picDraw.Height);
            
        }

        private void signaturePadView_Load(object sender, EventArgs e)
        {
            try
            {

                //// On Error GoTo errorload
                Digitizer = new Tablet(); //Actually create the tablet object
                //sldGranularity.Value = 2; //Set packet granularity value
                ////that uses a tablet attribute. Remember not everyone has _your_ tablet.
                Digitizer.UnavailableIsError = false;

                //Tablet.hWnd = frmMain.DefInstance.Handle
                //prgX.Maximum = Digitizer.Context.OutputExtentX - Digitizer.Context.OutputOriginX;
                //prgY.Maximum = Digitizer.Context.OutputExtentY - Digitizer.Context.OutputOriginY;
                //prgZ.Maximum = 255;

                //prgPressure.Maximum = (int)Digitizer.Device.NormalPressure.get_Max(true);
                //prgTangentPressure.Maximum = (int)Digitizer.Device.TangentPressure.get_Max(true);


                //Digitizer.ContextClosed += new VBTablet.Tablet.ContextClosedEventHandler(ContextClosed);
                //Digitizer.ContextOpened += new VBTablet.Tablet.ContextOpenedEventHandler(ContextOpened);
                //Digitizer.ContextRepositioned += new Tablet.ContextRepositionedEventHandler(ContextRepositioned);
                //Digitizer.ContextUpdated += new Tablet.ContextUpdatedEventHandler(ContextUpdated);
                //Digitizer.CursorChange += new Tablet.CursorChangeEventHandler(CursorChange);
                //Digitizer.InfoChange += new Tablet.InfoChangeEventHandler(InfoChange);
                //Digitizer.ProximityChange += new Tablet.ProximityChangeEventHandler(ProximityChange);
                Digitizer.PacketArrival += new Tablet.PacketArrivalEventHandler(PacketArrival);
               // bmp = new Bitmap(picDraw.Image);
                
                //initiation of the device and all others
                connectToDevice();
                enableDevice();
                enableDigitizeMode();
                noidea();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ". Please Connect the Digitizer Device First !!");


            }

        }
        private void noidea()
        {
            bmp = new Bitmap(picDraw.Image);
        }

        private void MainFrm_Activated(object Sender, EventArgs e)
        {
            bool temp, res;

            if (!Digitizer.Context.hCtx.Equals(IntPtr.Zero))
            {
                temp = true;
                res = Digitizer.Context.Reposition(ref temp);
            }


        }

        private void MainFrm_Deactivated(object Sender, EventArgs e)
        {
            bool temp, res;


            if (!Digitizer.Context.hCtx.Equals(IntPtr.Zero))
            {

                temp = false;
                res = Digitizer.Context.Reposition(ref temp);
            }


        }

        #region private region
        private void connectToDevice()
        {
            IntPtr Hwnd;
            bool IsDigitizingContext = false;
            string ContextID = "FirstContext";
           // Connect.Enabled = false;
            //Disconnect.Enabled = true;
           // Enable.Enabled = true;
            //Disable.Enabled = false;
            //chkDigitise.Enabled = true;//Enable Digitize Mode
            Hwnd = this.Handle;
            Digitizer.hWnd = Hwnd;
            Digitizer.AddContext(ContextID, ref IsDigitizingContext);
            Digitizer.SelectContext(ref ContextID);
            Digitizer.Connected = true;
            Digitizer.Context.QueueSize = 32;//Set queue size to a reasonable value
        }

        private void enableDevice()
        {
            //Disable.Enabled = true;
            //Enable.Enabled = false;
           /// InContext();//Call Incontext
                        //Check Following Code

            Digitizer.Context.TrackingMode = true;
            Digitizer.Context.Enabled = true;
            return;
        }

        private void enableDigitizeMode()
        {
            long xextent;
            long yextent;

            ////if (chkDigitise.Checked == false)
            //if (true)
            //{
            //    Digitizer.Context.Options.IsSystemCtx = true;
            //    xextent = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //    yextent = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //    Digitizer.Context.OutputExtentX = (int)xextent;
            //    Digitizer.Context.OutputExtentY = (int)yextent;
            //    Digitizer.Context.Update();
            //    prgX.Maximum = Digitizer.Context.OutputExtentX - Digitizer.Context.OutputOriginX;
            //    prgY.Maximum = Digitizer.Context.OutputExtentY - Digitizer.Context.OutputOriginY;

            //}
            //else
            //{
                xextent = picDraw.Width;// picbox.Width;
                yextent = picDraw.Height;// picbox.Height;
                Digitizer.Context.Options.IsSystemCtx = false;
                Digitizer.Context.OutputExtentX = (int)xextent;
                Digitizer.Context.OutputExtentY = (int)yextent;
                Digitizer.Context.Update();
                //prgX.Maximum = picDraw.Width;
                //prgY.Maximum = picDraw.Height;
           // }
        }
        #endregion

        //private void cmdConnect_Click(object sender, EventArgs e)
        //{
            

        //    //Deviceinfo();
        //}

        //private void Deviceinfo()
        //{
        //    lblDeviceMaxPktRate.Text = "Maximal Update Packet Rate (Packets/sec): " + Digitizer.Device.MaxPktRate.ToString();
        //    lblDeviceMargins.Text = "Device Context Margins (x, y, z): " + Digitizer.Device.Margins.X.ToString() + ", " + Digitizer.Device.Margins.Y.ToString() + ", " + Digitizer.Device.Margins.Z.ToString(); ;
        //    lblDeviceNormalPressure.Text = "Normal Pressure (Min, Max, Resolution, Units): " + Digitizer.Device.NormalPressure.get_Min(true).ToString() + ", " + Digitizer.Device.NormalPressure.get_Max(true).ToString() + " , " + Digitizer.Device.NormalPressure.Resolution.ToString() + " , " + Digitizer.Device.NormalPressure.Units;
        //    lblDevicePnPID.Text = "Plug-and-Play device ID: " + Digitizer.Device.PnPID.ToString();
        //    lblDeviceX.Text = "X capabilities (Min, Max, Resolution, Units): " + Digitizer.Device.X.get_Min(true).ToString() + ", " + Digitizer.Device.X.get_Max(true).ToString() + " ," + Digitizer.Device.X.Resolution.ToString() + " ," + Digitizer.Device.X.Units;
        //    lblDeviceY.Text = "Y capabilities (Min, Max, Resolution, Units): " + Digitizer.Device.Y.get_Min(true).ToString() + ", " + Digitizer.Device.Y.get_Max(true).ToString() + " ," + Digitizer.Device.Y.Resolution.ToString() + " ," + Digitizer.Device.Y.Units;
        //    lblDeviceZ.Text = "Z capabilities (Min, Max, Resolution, Units): " + Digitizer.Device.Z.get_Min(true).ToString() + ", " + Digitizer.Device.Z.get_Max(true).ToString() + " ," + Digitizer.Device.Z.Resolution.ToString() + " ," + Digitizer.Device.Z.Units;
        //    lblDeviceAzimuth.Text = "Azimuth capabilities (Min, Max, Resolution, Units): " + Digitizer.Device.Azimuth.get_Min(true).ToString() + ", " + Digitizer.Device.Azimuth.get_Max(true).ToString() + " ," + Digitizer.Device.Azimuth.Resolution.ToString() + " ," + Digitizer.Device.Azimuth.Units;
        //    lblDevName.Text = " Device Name : " + Digitizer.Device.GetType().ToString();

        //    lblStatusContexts.Text = "Number of Contexts open : " + Digitizer.Status.OpenContexts.ToString();
        //    lblStatusSysContexts.Text = "Number of System Contexts open : " + Digitizer.Status.OpenSysContexts.ToString();
        //    lblStatusMaxRate.Text = "Maximum Packet Rate in use (packets/sec): " + Digitizer.Status.MaxCurrentPktRate.ToString();
        //    lblStatusMgrHandles.Text = "Number of Manager Handles open : " + Digitizer.Status.OpenMgrHandles.ToString();
        //    lblExtensionTag.Text = "Extension ID: " + Digitizer.Extension.ID.ToString();
        //    lblExtensionAbsSize.Text = "Size of Extension in a Packet (Absolute Mode): " + Digitizer.Extension.AbsoluteSize.ToString();
        //    lblExtensionRelSize.Text = "Size of Extension in a Packet (Relative Mode): " + Digitizer.Extension.RelativeSize.ToString();
        //    lblExtensionMask.Text = "Extension Or-Mask: " + Digitizer.Extension.OrMask.MaskValue.ToString();

        //}

        private void MainFrm_Closed(object Sender, EventArgs e)
        {

        }

        //private void Enable_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void Disable_Click(object sender, EventArgs e)
        //{
        //    //Disable.Enabled = false;
        //    ////Enable.Enabled = true;

        //    //OutContext();
        //    //Digitizer.Context.Enabled = false;
        //}

        //private void Disconnect_Click(object sender, EventArgs e)
        //{
        //   // string RemoveCOntextID = "FirstContext";
        //   // if (Disable.Enabled)
        //   // {
        //   //     Disable.Enabled = false;
        //   //    // Enable.Enabled = true;
        //   //     OutContext();
        //   //     Digitizer.Context.Enabled = false;
        //   // }
        //   // Digitizer.Connected = false;
        //   // Digitizer.RemoveContext(ref RemoveCOntextID);
        //   // Disable.Enabled = false;
        //   // //Enable.Enabled = false;
        //   // Disconnect.Enabled = false;
        //   //// Connect.Enabled = true;
        //   // //chkDigitise.CheckState = CheckState.Unchecked;
        //   //// chkDigitise.Enabled = false;

        //   // // Disable the Digitizer



        //}

        //private void OutContext() //Cursor has moved out of the context
        //{

        //    lblX.Enabled = false;
        //    lblY.Enabled = false;
        //    lblZ.Enabled = false;
        //    lblCursor.Enabled = false;
        //    lblPressure.Enabled = false;
        //    lblTangentPressure.Enabled = false;
        //    lblAzimuth.Enabled = false;
        //    lblAltitude.Enabled = false;
        //    lblTwist.Enabled = false;
        //    lblPitch.Enabled = false;
        //    lblRoll.Enabled = false;
        //    lblYaw.Enabled = false;
        //    prgX.Enabled = false;
        //    prgY.Enabled = false;
        //    prgZ.Enabled = false;
        //    prgPressure.Enabled = false;
        //    prgTangentPressure.Enabled = false;
        //}

        //private void InContext() //Cursor has moved into context
        //{
        //    lblX.Enabled = true;
        //    lblY.Enabled = true;
        //    lblZ.Enabled = true;
        //    lblCursor.Enabled = true;
        //    lblPressure.Enabled = true;
        //    lblTangentPressure.Enabled = true;
        //    lblAzimuth.Enabled = true;
        //    lblAltitude.Enabled = true;
        //    lblTwist.Enabled = true;
        //    lblPitch.Enabled = true;
        //    lblRoll.Enabled = true;
        //    lblYaw.Enabled = true;
        //    prgX.Enabled = true;
        //    prgY.Enabled = true;
        //    prgZ.Enabled = true;
        //    prgPressure.Enabled = true;
        //    prgTangentPressure.Enabled = true;
        //    //If digitising Then timClear.Enabled = False
        //}

        //private void sldGranularity_Scroll(object sender, EventArgs e)
        //{
        //    Digitizer.PktGranularity = (short)sldGranularity.Value;

        //}

        //private void chkDigitise_CheckedChanged(object sender, EventArgs e)
        //{
           


        //}

        // Event Handlers for the Digitizer Object

        public void PacketArrival(ref IntPtr ContextHandle, ref int Cursor_Renamed, ref int X, ref int Y, ref int Z, ref int Buttons, ref int Pressure, ref int TangentPressure, ref int Azimuth, ref int Altitude, ref int Twist, ref int Pitch, ref int Roll, ref int Yaw, ref int PacketSerial, ref int PacketTim)
        {
            //Show current stats. Note that it's a good idea not to update
            //if not necessary - 100+ updates a second can really hurt performance

            //tmpl = System.Math.Abs(X);

            //if (tmpl != prgX.Value)
            //{
            //    if (tmpl <= prgX.Maximum)
            //        prgX.Value = tmpl;
            //}
            //tmpl = System.Math.Abs(Y);
            //if (tmpl != prgY.Value)
            //{
            //    if (tmpl <= prgY.Maximum)
            //        prgY.Value = tmpl;
            //}
            //tmpl = System.Math.Abs(Z);
            //if (tmpl != prgZ.Value)
            //{
            //    if (tmpl <= prgZ.Maximum)
            //        prgZ.Value = tmpl;
            //}
            //tmpl = System.Math.Abs(Pressure);
            //if (tmpl != prgPressure.Value)
            //    prgPressure.Value = tmpl;
            //tmpl = System.Math.Abs(TangentPressure);
            //if (tmpl != prgTangentPressure.Value)
            //    prgTangentPressure.Value = tmpl;

            //if (Convert.ToInt32(lblX.Text) != X)
            //    lblX.Text = X.ToString();
            //if (Convert.ToInt32(lblY.Text) != Y)
            //    lblY.Text = Y.ToString();
            //if (Convert.ToInt32(lblZ.Text) != Z)
            //    lblZ.Text = Z.ToString();
            //if (Convert.ToInt32(lblCursor.Text) != Cursor_Renamed)
            //    lblCursor.Text = Cursor_Renamed.ToString();
            //if (Convert.ToInt32(lblPressure.Text) != Pressure)
            //    lblPressure.Text = Pressure.ToString();
            //if (Convert.ToInt32(lblTangentPressure.Text) != TangentPressure)
            //    lblTangentPressure.Text = TangentPressure.ToString();
            //if (Convert.ToInt32(lblAzimuth.Text) != Azimuth)
            //    lblAzimuth.Text = Azimuth.ToString();
            //if (Convert.ToInt32(lblAltitude.Text) != Altitude)
            //    lblAltitude.Text = Altitude.ToString();
            //if (Convert.ToInt32(lblTwist.Text) != Twist)
            //    lblTwist.Text = Twist.ToString();
            //if (Convert.ToInt32(lblPitch.Text) != Pitch)
            //    lblPitch.Text = Twist.ToString();
            //if (Convert.ToInt32(lblRoll.Text) != Roll)
            //    lblRoll.Text = Roll.ToString();
            //if (Convert.ToInt32(lblYaw.Text) != Yaw)
            //    lblYaw.Text = Yaw.ToString();

            Pen ppen = new Pen(Color.Black, 1);
            Graphics Gr;
            Graphics sh;
            if (Pressure > 0) // 'catch normalpressure and button 1
            {
                //if (Digitizer.Context.CursorIsInverted)
                //{
                //    ppen.Color = Color.Red;
                //    picDraw.Refresh();
                //}
                //else
                //{
                //    ppen.Color = Color.Blue;
                //}
                //tmpl = (int)Digitizer.Device.NormalPressure.get_Max(true);
                //RectWidth = (int)((Pressure / (float)tmpl) * 100);
                //if ((RectWidth >= 0) & (RectWidth <= 20))
                //    ppen.Color = Color.LawnGreen;
                //else if ((RectWidth >= 21) & (RectWidth <= 40))
                //    ppen.Color = Color.Blue;
                //else if ((RectWidth >= 41) & (RectWidth <= 100))
                //    ppen.Color = Color.Red;

                try
            {
                    //bmp = new Bitmap(picDraw.Image);
                    //Gr = Graphics.FromImage(picDraw.Image);
                    Gr = Graphics.FromImage(bmp);
                    sh = Graphics.FromImage(bmp);
                    sh = picDraw.CreateGraphics();
                    //Bitmap bmp = new Bitmap(picDraw.Width, picDraw.Height);
                    Gr.DrawLine(ppen, X, picDraw.Height - Y, Xold, picDraw.Height - Yold + 1);
                    sh.DrawLine(ppen, X, picDraw.Height - Y, Xold, picDraw.Height - Yold + 1);
                    //Gr.Flush();
                    //GraphicsState s = Gr.Save();
                    // Gr.DrawEllipse(ppen, X, picDraw.Height - Y, 1, 1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //   Application.DoEvents(); // Poor Data Capture & Rendering
            Xold = X;
            Yold = Y;
        }

        //public void ContextClosed(ref int Status, ref IntPtr ContextHandle, ref string ContextName)
        //{
        //    System.Diagnostics.Debug.WriteLine("Context ContextName = " + ContextName + "closed - status = " + Status);

        //}

        //public void ContextOpened(ref int Status, ref IntPtr ContextHandle, ref string ContextName)
        //{
        //    System.Diagnostics.Debug.WriteLine("Context ContextName = " + ContextName + "Opened - status = " + Status);

        //}

        //public void ContextRepositioned(ref int OnTop, ref IntPtr ContextHandle, ref string ContextName)
        //{
        //    System.Diagnostics.Debug.WriteLine("Context ContextName = " + ContextName + " repositioned - ontop = " + OnTop);
        //}

        //public void ContextUpdated(ref int Status, ref IntPtr ContextHandle, ref string ContextName)
        //{
        //    System.Diagnostics.Debug.WriteLine("Context ContextName =  " + ContextName + " updated - status = " + Status);

        //}

        //public void CursorChange(ref IntPtr ContextHandle, ref string ContextName) //Handles Tablet.CursorChange
        //{
        //    System.Diagnostics.Debug.WriteLine("Cursor changed for context " + ContextName);

        //}

        //public void InfoChange(ref IntPtr ManagerHandle, ref string InfoCategory, ref string InfoIndex)
        //{ //Handles Tablet.InfoChange
        //    System.Diagnostics.Debug.WriteLine("Information change - Category: " + InfoCategory + ", Index: " + InfoIndex);
        //}

        private void Save_Click(object sender, EventArgs e)
        {
            //picDraw.Image.Save(@"D:\images\", ImageFormat.Jpeg);
            //Bitmap bmp = new Bitmap(picDraw.Width, picDraw.Height);
            //picDraw.DrawToBitmap(bmp, picDraw.ClientRectangle);
            //picDraw.Image = bmp;
            //bmp.Save("file.bmp");
            //bmp.Size = new Size(300, 300);
            Rectangle section = new Rectangle(new Point(0, 0), new Size(300, 300));
            Bitmap CroppedImage = CropImage(bmp, section);
            //picDraw.Image = CroppedImage;
            //picDraw.Image.Save("asdf.bmp");
            //bmp.Save("asdf.bmp");
            CroppedImage.Save("asdf.bmp");
            MessageBox.Show("saved");
            this.Close();
            //this.Hide();

        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap result = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(result);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return result;
        }


  




        //public void ProximityChange(ref bool IsInContext, ref bool IsPhysical, ref IntPtr ContextHandle, ref string ContextName)
        //{

        //    //Handles Tablet.ProximityChange
        //    if (IsInContext)
        //    {
        //        tmps = "Now in context";
        //        //InContext();
        //    }
        //    else
        //    {
        //        tmps = "Now out of context";
        //      //  OutContext();
        //    }

        //    if (IsPhysical)
        //    {
        //        tmps = tmps + " due to hardware proximity change";
        //    }
        //    else
        //    {
        //        tmps = tmps + " due to software context switch";
        //    }
        //    //lblContext.Text = tmps;

        //}

        private void BurttonClear_Click(object sender, EventArgs e)
        {
            noidea();
            picDraw.Refresh();
            //Digitizer.PacketArrival += new Tablet.PacketArrivalEventHandler(PacketArrival);
            //bmp.Dispose();
            
        }
    }
}
