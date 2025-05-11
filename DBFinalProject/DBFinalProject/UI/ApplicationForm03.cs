using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class ApplicationForm03 : KryptonForm
    {
        ApplicationForm2 form2;
        public ApplicationForm03(ApplicationForm2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (.jpg;.jpeg;.png) | *.jpg;.jpeg;*.png";
            openFileDialog1.Title = "Select Profile Picture";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    profile.Image = Image.FromFile(openFileDialog1.FileName);
                    profile.BorderStyle = BorderStyle.FixedSingle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (.jpg;.jpeg;.png) | *.jpg;.jpeg;*.png";
            openFileDialog1.Title = "Select Profile Picture";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CnicF.Image = Image.FromFile(openFileDialog1.FileName);
                    CnicF.BorderStyle = BorderStyle.FixedSingle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (.jpg;.jpeg;.png) | *.jpg;.jpeg;*.png";
            openFileDialog1.Title = "Select Profile Picture";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CnicB.Image = Image.FromFile(openFileDialog1.FileName);
                    CnicB.BorderStyle = BorderStyle.FixedSingle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.Show();   
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] profilePicBytes, cnicFrontBytes, cnicBackBytes;
                using (MemoryStream profileMS = new MemoryStream())
                {
                    profile.Image.Save(profileMS, profile.Image.RawFormat);
                    profilePicBytes = profileMS.ToArray();
                }

                using (MemoryStream cnicFMS = new MemoryStream())
                {
                    CnicF.Image.Save(cnicFMS, CnicF.Image.RawFormat);
                    cnicFrontBytes = cnicFMS.ToArray();
                }

                using (MemoryStream cnicBMS = new MemoryStream())
                {
                    CnicB.Image.Save(cnicBMS, CnicB.Image.RawFormat);
                    cnicBackBytes = cnicBMS.ToArray();
                }
                if (profile.BorderStyle == BorderStyle.None ||
                    CnicF.BorderStyle == BorderStyle.None ||
                    CnicB.BorderStyle == BorderStyle.None)
                {
                    MessageBox.Show("Please upload all documents.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetProfilePic(profilePicBytes).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetProfilePic(profilePicBytes).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetCnicFront(cnicFrontBytes).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetCnicFront(cnicFrontBytes).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetCnicBack(cnicBackBytes).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetCnicBack(cnicBackBytes).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Task<bool> applyMessage = EmailSender.SendEmailAsync(ApplicationForm.application.GetEmail(), "Account Aplication", "You applied for an account in Apex Bank");

                if (await applyMessage)
                {
                    if (AccountApplicationDL.Apply() > 0)
                    {
                        MessageBox.Show("Application Submitted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new MainInterface().Show();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while sending your application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show("Can't connect to internet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
