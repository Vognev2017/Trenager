using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class Levels : Form
    {
        int id_user = 2;
       int uroven=0;
        string path_image = null;
        DataContext db = new DataContext(connectionString);
        public Levels()
        {
            InitializeComponent();
        }
        public Levels(int id)
        {
            InitializeComponent();
            id_user =DB_.User_Id;

        }
        public int Uroven { set; get; }
        private static string path = Directory.GetCurrentDirectory();

        private static string str1 = path + @"\TrenDB.mdf";
        // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\res\Trenager_temp2\TrenDB.mdf;Integrated Security = True; Connect Timeout = 30";Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\TrenDB.mdf
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + str1 + ";Integrated Security=True;Connect Timeout=30";
        private void MyLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int prog = Convert.ToInt32(lbl.Tag.ToString()); 
            My(prog);
          uroven = prog;
        }
        private void My(int a)
        {
            DataContext db = new DataContext(connectionString);
            var res = (from r in db.GetTable<PopytT>()
                       where r.Lev_id==a && r.User_id== DB_.User_Id
                       select r).ToList();
            foreach(PopytT p in res)
            { 
            label1.Text = p.Kol_popyt.ToString();
            label2.Text = p.Ritm.ToString();
            label3.Text = p.Speed.ToString();
            label4.Text = p.Mistake.ToString();
                label10.Text = p.Datta.ToShortDateString();
            }
        }
        private Label myLabel(string s, Point poz,string lv)
        {
            Label lb = new Label();

            lb.BorderStyle = BorderStyle.Fixed3D;
            lb.FlatStyle = FlatStyle.Flat;
            lb.Font = new Font(lb.Font.Name, 12, lb.Font.Style);
            lb.Tag = lv;
            lb.Width = 70;
            lb.Height = 30;
            lb.Text = s;
          lb.BackColor = Color.Aqua;
            lb.Location = poz;
            lb.Click += MyLabel_Click;

            return lb;
        }
        private void Levels_Load(object sender, EventArgs e)
        {
            path_image = new DirectoryInfo("Image").FullName;
            DataContext db1 = new DataContext(connectionString);
            var put = db1.GetTable<UserT>().Where(s => s.Id == DB_.User_Id).FirstOrDefault();
            pictureBox1.ImageLocation = put.Avatar;
            lbLogin.Text = put.Login;
            lbFam.Text = put.Fam;
            lbName.Text = put.Name;
            lbEmail.Text = put.Email;
            Point poz = new Point {  X = 0, Y = 15 };
            DataContext db = new DataContext(connectionString);
           
            var query1 = (from u in db.GetTable<PopytT>()
                         where u.User_id == DB_.User_Id  
                         select u).ToList();
            for (int i = 0; i < query1.Count; i++)
                {
                   groupBox1.Controls.Add(myLabel((i+1).ToString(),poz,query1[i].Lev_id.ToString()));
                   poz.Y+= 35;
                   
                }
        }

        private void btLoadLevel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Levels_FormClosed(object sender, FormClosedEventArgs e)
        {
            Uroven = uroven;
        }

        private void btCloseStatistik_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext(connectionString);
            var m_level = db.GetTable<PopytT>().Max(s => s.Lev_id);
            uroven = m_level;
            Close();
        }

        private void btAddAvatar_Click(object sender, EventArgs e)
        {
            string _path_image = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = path_image;
            dlg.Filter= "JPG Files (*.jpg|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Title = "Выберите картинку";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _path_image = dlg.FileName.ToString();
                pictureBox1.ImageLocation = _path_image;
                DataContext db = new DataContext(connectionString);
                var us = db.GetTable<UserT>().Where(s => s.Id == DB_.User_Id).FirstOrDefault();
                us.Avatar = _path_image.ToString();
                db.SubmitChanges();
            }
        }
    }
    }
