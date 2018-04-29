using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class PriW : Form
    {
        public PriW()
        {
            InitializeComponent();
            label4.Text = DB_.Hello_;
            label2.Text = DB_.Trenager_Name;
            label3.Text = "v " + DB_.Version_Trenager.ToString();

        }

        private void Ok__Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                //измнение
                int temp= DB_.chekUser("4","4");//textBox1.Text, textBox2.Text
                if (temp>0 && temp<3) { this.Close(); }
                else { MessageBox.Show("Может создать нового пользователя?"); }
                if (temp == 3) f_admin.Visible = true; 
            }
            if (radioButton2.Checked == true)
            {
                // insert
                DB_.NewUserAdd(textBox1.Text,textBox2.Text);
                this.Close();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + @"\pmi.chm");

            Help.ShowHelp(this, "Кнопкодав.chm");
            //try
            //{
            //    Process SysInfo = new Process();
            //    SysInfo.StartInfo.ErrorDialog = true;
            //   // SysInfo.StartInfo.FileName = @"D:\res\Trenager_temp2\help.chm";
            //    SysInfo.StartInfo.FileName = @"Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\help.chm";
                
            //    SysInfo.Start();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void f_admin_Click(object sender, EventArgs e)
        {
            // dopil
            AdmFor fr = new AdmFor();
            fr.ShowDialog();
        }
    }
}
