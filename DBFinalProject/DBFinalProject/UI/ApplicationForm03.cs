using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace DBFinalProject
{
    public partial class ApplicationForm03 : KryptonForm
    {
        public ApplicationForm03()
        {
            InitializeComponent();
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
    }
}
