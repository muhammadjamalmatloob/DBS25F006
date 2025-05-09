using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.DL;

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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream profileMS = new MemoryStream();
                MemoryStream cnicFMS = new MemoryStream();
                MemoryStream cnicBMS = new MemoryStream();
                profile.Image.Save(profileMS, profile.Image.RawFormat);
                CnicF.Image.Save(cnicFMS, profile.Image.RawFormat);
                CnicB.Image.Save(cnicBMS, profile.Image.RawFormat);
                if (profile.BorderStyle == BorderStyle.None ||
                    CnicF.BorderStyle == BorderStyle.None ||
                    CnicB.BorderStyle == BorderStyle.None)
                {
                    MessageBox.Show("Please upload all documents.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetProfilePic(profileMS.ToArray()).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetProfilePic(profileMS.ToArray()).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetCnicFront(cnicFMS.ToArray()).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetCnicFront(cnicFMS.ToArray()).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ApplicationForm.application.SetCnicBack(cnicBMS.ToArray()).valid)
                {
                    MessageBox.Show(ApplicationForm.application.SetCnicBack(cnicBMS.ToArray()).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (AccountApplicationDL.Apply() > 0)
                {
                    MessageBox.Show("Application Submitted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
