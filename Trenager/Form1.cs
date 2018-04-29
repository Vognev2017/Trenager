using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace Trenager
{
    public partial class Form1 : Form
    {
        private static string path = Directory.GetCurrentDirectory();
        private static string name_file = path + @"\Tren.txt";



        //private static string path = Directory.GetCurrentDirectory();

        //private static string str1 = path + @"\NameFile.txt";

       
        Button but = new Button();
        List<Button> ListBut = new List<Button>();
        List<string> myTrenager = new List<string>();
        Color bt_Press = ColorTranslator.FromHtml("#FFFFFF");
        public static int col_simvol = 1;// s public static int col_simvol = -1;
        public static int t = 0;
        int sek = 0;
        int h = 0;
        int m = 0;
        public static double res = 0.0;
        int index = 0;
        public static int bt_error = -1;  // s  public static int bt_error = 0;
        bool bt = false;
        int slognost = 0;
        string s_lang = "";
        bool LEng = false;
        bool LRu = false;
        bool LUa = false;
        string temp_Tag = "";
        string tem_s = null;
        bool lesson = false;
        int b_ind = 0;
        int a = 1;
       // 
        bool start = false;
        bool flag_Click = false;
        bool pauza = false;
        int statistika = 1;

      //  string slovo = "";
       
        string[] bt_nameEnglish = {
            "`","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Q","W","E","R","T", "Y", "U", "I", "O", "P","[","]","\\",
            "CapsLk", "A", "S", "D", "F_","G","H","_J","K","L",";", "'","Enter",
            "Shrift","Z","X","C","V","B","N","M",",",".","/","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};
        string[] bt_nameRu = {
            "Ё","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Й","Ц","У","К","Е", "Н", "Г", "Ш", "Щ", "З","Х","Ъ","\\",
            "CapsLk", "Ф", "Ы", "В", "А_", "П","Р","_О","Л","Д","Ж", "Э","Enter",
            "Shrift","Я","Ч","С","М","И","Т","Ь","Б","Ю",".","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};
        string[] bt_nameUa = {
            "`","1", "2", "3", "4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","Й","Ц","У","К","Е", "Н", "Г", "Ш", "Щ", "З","Х","Ї","\\",
            "CapsLk", "Ф", "І", "В", "А_","П","Р","_О","Л","Д","Ж", "Є","Enter",
            "Shrift","Я","Ч","С","М","И","Т","Ь","Б","Ю",".","Shrift",
            "Ctrl","Win","Alt"," ","Alt","","Cntrl"};//"Oem4",
        string[] bt_teg = {"Oemtilde","D1","D2","D3","D4","D5","D6","D7","D8","D9","D0","OemMinus","Oemplus","Back",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","OemOpenBrackets","Oem6","Oem5",
            "Capital","A","S","D","F","G","H","J","K","L","Oem1","Oem7","Return",
            "ShiftKey","Z","X","C","V","B","N","M","Oemcomma","OemPeriod","OemQuestion","ShiftKey",
            "ControlKey","LWin","Menu","Space","Menu","Apps","ControlKey" };

        protected override bool ProcessDialogKey(Keys keyData)
        { 
            switch (keyData)
            {
                case Keys.Tab:
                    return true;
                default:
                    return base.ProcessDialogKey(keyData);
            }
        }
        public static int work_level = 0;
        public Form1()
        {
            PriW fr = new PriW();
            fr.ShowDialog();
            InitializeComponent();           
            richTextBox1.Focus();
            richTextBox1.Select();
           
        }
        // button
        public void ButColor(List<Button> but)
        {
            System.Drawing.Color bt_clr = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");
            System.Drawing.Color bt_clrM = System.Drawing.ColorTranslator.FromHtml("#ED1C24");//#FFC8F5
            System.Drawing.Color bt_clrMR = System.Drawing.ColorTranslator.FromHtml("#E9C177");//#FFC8F5

            System.Drawing.Color bt_clrB = System.Drawing.ColorTranslator.FromHtml("#FF7F27");//#23FFC4
            System.Drawing.Color bt_clrBR = System.Drawing.ColorTranslator.FromHtml("#FFA7CD");//#23FFC4

            System.Drawing.Color bt_clrSr = System.Drawing.ColorTranslator.FromHtml("#3AE2CE");//#FEFFA5
            System.Drawing.Color bt_clrSrR = System.Drawing.ColorTranslator.FromHtml("#FFDD00");

            System.Drawing.Color bt_clrUk = System.Drawing.ColorTranslator.FromHtml("#22B14C");//#D2FFFF
            System.Drawing.Color bt_clrUkR = System.Drawing.ColorTranslator.FromHtml("#A349A4");//#EDF903
            System.Drawing.Color bt_clrBig = System.Drawing.ColorTranslator.FromHtml("#00A2E8");//
            for (int i = 0; i < but.Count; i++)
            {
                if (i == 14  || i == 54|| i == 55 || i == 57|| i == 58) but[i].BackColor = bt_clr;// i == 54 ||

                if (i == 0 || i == 15 || i == 16 || i == 29 || i == 28 || i == 41 || i == 42 || i == 53 ) but[i].BackColor = bt_clrM;
                if (i == 12 || i == 13 || i > 24 && i <= 27 || i == 40 || i == 52 || i == 59 || i == 38 || i == 39 || i == 51) but[i].BackColor = bt_clrMR;
                //

                if (i == 1 || i == 2 || i == 16 || i == 30 || i == 42 || i == 45 ) but[i].BackColor = bt_clrB;//|| i == 55
                if (i == 10 || i == 11 || i == 23 || i == 24 || i == 37 || i == 50) but[i].BackColor = bt_clrBR;


                if (i == 3 || i == 4 || i == 17 || i == 31 || i == 43) but[i].BackColor = bt_clrSr;//|| i == 1
                if (i == 8 || i == 9 || i == 22 || i == 36 || i == 49) but[i].BackColor = bt_clrSrR;

                if (i == 5 || i == 6 || i == 18 || i == 19
                    || i == 32 || i == 33 || i == 44 || i == 45 || i == 46) but[i].BackColor = bt_clrUk;

                if (i == 7 || i == 20 || i == 21
                    || i == 34 || i == 35 || i == 47 || i == 48) but[i].BackColor = bt_clrUkR;

                if (i == 56 ) but[i].BackColor = bt_clrBig;//|| i == 57
            }

        }
        public void NameBut(List<Button> n_but, string[] name)
        {
            for (int i = 0; i < n_but.Count; i++)
            {
                n_but[i].Text = name[i];
            }

        }
        public void Klava1()//string[] bt_name
        {
            System.Drawing.Color bt_clr = System.Drawing.ColorTranslator.FromHtml("#E1E1E1");

            int r = 5;
            Point poz = new Point();
            Button t_bt = new Button();
            int pos = 0;
            poz.X = 5;
            poz.Y = 5;
            int btX = Convert.ToInt32(panel2.Width / (14));//45 54  
           int btY = Convert.ToInt32(panel2.Height / (5)+r);//45 70
            int btD = btX + Convert.ToInt32(btX * 0.45);//65 78
            int sum = 0;

            //первая
            for (int i = 0; i < 14; i++)
            {
                if (i == 13)
                {

                    t_bt = BtCreate(poz, btX, btD, "", bt_teg[i], bt_clr);//bt_name[i]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btD + r;
                    //pos = i;
                }
                else
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[i], bt_clr);//bt_name[i]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r/2);

                }
                pos = i;
                sum += btX + (r / 2);
            } 
            //вторая
            poz.Y = btY;//-(r*2)
            poz.X = 5;
            int ii = pos + 1;
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)
                {

                    t_bt = BtCreate(poz, btX, (btD-2), "", bt_teg[ii], bt_clr);//bt_name[ii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD - 2) + (r / 2);
                }
                else
                {
                    string ret = bt_teg[ii].ToString();
                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[ii], bt_clr); //bt_name[ii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX+ (r / 2);
                }
                ii++;
            }
            //третья
            poz.Y = btY*2;//-(r*5)
            poz.X = 5;
            int iii = ii;
            for (int i = 0; i < 13; i++)
            {
                if (i == 0 || i == 12 && iii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, (btD+16), "", bt_teg[iii], bt_clr);//bt_name[iii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD + 16) + (r / 2);
                }
                else if (iii < bt_teg.Length)
                {


                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iii], bt_clr);//bt_name[iii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iii++;
            }
            //четвертая
            poz.Y = btY * 3 ;//- (r * 8)
            poz.X = 5;
            int iiii = iii;
            for (int i = 0; i < 12; i++)
            {
                if (i == 0 || i == 11 && iiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, (btD+btD/2+1), "", bt_teg[iiii], bt_clr);//bt_name[iiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD + btD/2+1) + (r / 2);
                }
                else if (iiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iiii], bt_clr);//bt_name[iiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iiii++;
            }
            //пятая
            poz.Y = btY * 4;//-(r*11)
            poz.X = btD/2;
            int iiiii = iiii;
            for (int i = 0; i <= 7; i++)
            {
                if (i == 3)
                {

                    t_bt = BtCreate(poz, btX, (btD*6- btD), "", bt_teg[iiiii], bt_clr);//bt_name[iiiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + (btD * 6 - btD) + (r / 2);
                }
                else if (iiiii < bt_teg.Length)
                {

                    t_bt = BtCreate(poz, btX, btX, "", bt_teg[iiiii], bt_clr);//bt_name[iiiii]
                    panel2.Controls.Add(t_bt);
                    ListBut.Add(t_bt);
                    poz.X = poz.X + btX + (r / 2);
                }
                iiiii++;
            }

        }
        public Button BtCreate(Point poz, int h, int w, string s, string s_tag, Color cl)//#E1E1E1
        {

            Button tb = new Button();
            tb.Location = poz;
            tb.Text = s;
            tb.Width = w;
            tb.Height = h;
            tb.Tag = s_tag;
            tb.BackColor = cl;
            tb.Font = new Font(tb.Font.Name, 12, tb.Font.Style| FontStyle.Bold);
           
            tb.Visible = true;
            return tb;

        }
        //key
        public bool IndexSimvol(int a, int rr)
        {
            if (a == 1)
            {
                if (rr == 0 || rr < 15 || rr == 25 || rr == 26 || rr == 27 || rr == 28 || rr == 38 || rr == 39 || rr == 40 || rr == 41 || rr == 49 || rr == 50
                  || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 2)
            {
                if (rr < 15 || rr == 27 || rr == 28 || rr == 40 || rr == 41
                   || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 3)
            {
                if (rr == 0 || rr < 15 || rr == 27 || rr == 28 || rr == 40 || rr == 41
                   || rr == 51 || rr == 52 || rr == 53 || rr == 54 || rr == 55 || rr == 57 || rr == 58 || rr == 59 || rr == 60)
                    return false;
                else return true;
            }
            if (a == 4)
            {
                if (rr == 60 || rr == 59 || rr == 58 || rr == 57 || rr == 55 || rr == 54 || rr == 53 || rr == 52 || rr == 13 || rr == 28 || rr == 40 || rr == 41 || rr == 14)
                    return false;
                else return true;
            }
            if (a == 5)
            {
                if (rr == 60 || rr == 59 || rr == 58 || rr == 57 || rr == 55 || rr == 54 || rr == 53 || rr == 52 || rr == 13 || rr == 28 || rr == 40 || rr == 41 || rr == 14)
                    return false;
                else return true;
            }
            if (a == 6)
            {
                if (rr == 60 || rr == 59 || rr == 58 || rr == 57 || rr == 55 || rr == 54 || rr == 53 || rr == 52 || rr == 13 || rr == 28 || rr == 40 || rr == 41 || rr == 14)
                    return false;
                else return true;
            }
            return false;
        }
        public string Tren(int a, int b)
        {
            string sim = "";
            int rr = 1;
            Random r = new Random();
            rr = r.Next(60);
            bool flag = true;
            /////первый
            if (a == 1 && b == 1)
            {
               
                while(flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(1, rr))
                    {
                        index = rr;
                        sim = bt_nameEnglish[index];
                        but.Tag = bt_teg[index];
                        flag=false;
                    }
                }
            }
            if (a == 2 && b == 1)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(2, rr))
                    {
                        index = rr;
                        sim = bt_nameRu[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 3 && b == 1)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(3, rr))
                    {
                        index = rr;
                        sim = bt_nameUa[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            ////////////////2 уровень
            if (a == 1 && b == 2)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(4, rr))
                    {
                        index = rr;
                        sim = bt_nameEnglish[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            if (a == 2 && b == 2)
            {
                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(5, rr))
                    {
                        index = rr;
                        sim = bt_nameRu[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }
            ////////////////3 уровень
            if (a == 3 && b == 2)
            {

                while (flag)
                {
                    rr = r.Next(60);
                    if (IndexSimvol(6, rr))
                    {
                        index = rr;
                        sim = bt_nameUa[index];
                        but.Tag = bt_teg[index];
                        flag = false;
                    }
                }
            }

            //ButColor(ListBut);
            for (int i = 0; i < ListBut.Count; i++)
            {
                if (i == index)
                    label10.BackColor = ListBut[i].BackColor;
            }
            return sim;
        }
        public void MyColSimvol(int a, int ti, int cl_sm)
        {
            res = 0;

            if (ti > 0 && cl_sm > 0)
            { 
                res = (cl_sm)/ti * 60;//- bt_error0***0.06 60f  && Form1.col_simvol > bt_error + 1
                label5.Text = res.ToString();
            }
            if (a == 2)
            {
                if (t == 60)
                {
                    timer3.Stop();

                    res =(col_simvol - bt_error) /t   * 60.0f;
                    MessageBox.Show("Подсчет остановлен", "Ваша скорость набора = " + res.ToString());
                }
            label5.Text = res.ToString();
            }
            
        }
        //form
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = DB_.Trenager_Name;

            radioButton1.Checked = true;
            btnPauza.Text = "Start";
            slognost = 1;
            s_lang = "English";
            label1.Text = s_lang;

            if (rbtTime.Checked == true)
            {

            }

            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FEFFA5");//#FF7F27#23FFC4
            panel1.Width = 5;
            panel1.Height = Height;
            panel3.BackColor = System.Drawing.ColorTranslator.FromHtml("#FEFFA5");
            panel3.Width = panel2.Width;
            panel3.Height = 5;


        }
 //moi func        
        public void MyFun()
        {
            if (LEng == true)
            {
                label6.Text = Tren(1, slognost);
                label6.ForeColor = (label10.BackColor);
            }

            if (LRu == true)
            {
                label6.Text = Tren(2, slognost);
                label6.ForeColor = (label10.BackColor);
            }

            if (LUa == true)
            {
                label6.Text = Tren(3, slognost);
                label6.ForeColor = (label10.BackColor);
            }

        }
        public bool MynotBukv(string s)
        {
            string[] notBukv = { "`", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=", "[", "]", "\\", ":", "'", ",", ".", "/", " " };
            for(int i=0;i<notBukv.Length;i++)
            {
                if (notBukv[i].Contains(s) == true)
                    return false;
            }
            return true;
        }
        public void Language(string s)
        { 
            int r = 0;
            int r2 = 0;
            int r3 = 0;
            for (int i = 0; i < bt_nameEnglish.Length; i++)
            {
                if (s.Contains(bt_nameEnglish[i]) == true && MynotBukv(s) == true) r++;
               
            }
            
            for (int i = 0; i < bt_nameUa.Length; i++)
            {
                if (s.Contains(bt_nameUa[i]) == true && MynotBukv(s) == true) r2++;
                if (s.Contains("Ы") == true || s.Contains("ы")==true|| s.Contains("Ё") == true || s.Contains("ё") == true || s.Contains("ъ") == true) 
                    {
                    LRu = true;
                    NameBut(ListBut, bt_nameRu);
                    break;
                }
            }
            for (int i = 0; i < bt_nameRu.Length; i++)
            {
                if (s.Contains(bt_nameRu[i]) == true && MynotBukv(s) == true) r3++;

            }
            
             if(r>r2&&r>r3)
            {
                //MessageBox.Show("English");
                LEng = true;
                NameBut(ListBut, bt_nameEnglish);
                r = 0;
                r2 = 0;
                r3 = 0;
            }
            if(r2 > r && r2 > r3)
            {
                // MessageBox.Show("Ua");
                LUa = true;
                NameBut(ListBut, bt_nameUa);
                r = 0;
                r2 = 0;
                r3 = 0;
            }
            if (r3 > r && r3 > r2)
            {
                // MessageBox.Show("Ua");
                LRu = true;
                NameBut(ListBut, bt_nameRu);
                r = 0;
                r2 = 0;
                r3 = 0;
            }
        }
        public void Lesson(string s)
        {
            if (LEng == true)
            {
                for(int i=0;i<bt_nameEnglish.Length;i++)
                {
                    if(ListBut[i].Tag.ToString()==(s))
                    label10.BackColor = ListBut[i].BackColor;
                }
                label6.Text =s ;
                label6.ForeColor = (label10.BackColor);
            }

            if (LRu == true)
            {
                for (int i = 0; i < bt_nameRu.Length; i++)
                {
                    if (ListBut[i].Tag.ToString() == (s))
                        label10.BackColor = ListBut[i].BackColor;
                }
                label6.Text = s;

                label6.ForeColor = (label10.BackColor);
            }

            if (LUa == true)
            {
                for (int i = 0; i < bt_nameUa.Length; i++)
                {
                    if (ListBut[i].Tag.ToString() == (s))
                        label10.BackColor = ListBut[i].BackColor;
                }
                label6.Text = s;

                label6.ForeColor = (label10.BackColor);
            }

        }
        public void Provreka_Down(KeyEventArgs e,string s)
        {
            foreach (Button b in ListBut)
            {
                if (b.Tag.ToString() == e.KeyData.ToString())
                {
                    b.BackColor = bt_Press;
                    col_simvol++;//s      !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // mas[t]=ritm;
                    //ritm=0;
                }
            }
            if (textBox1.SelectedText == e.KeyData.ToString())
            {
                bt = true;
            }
            else bt = false;
           
        }
        public void Provreka_Up( KeyEventArgs e,string temp)
        {
            ButColor(ListBut);
            if (temp.ToUpper() == e.KeyCode.ToString()|| temp == "Space " && e.KeyCode.ToString() == "Space")
            {
                textBox1.Select(b_ind, 1);
                label20.Text = textBox1.SelectedText;
                b_ind++;
            }
            foreach (Button teb in ListBut)
            {
                if (teb.Tag.ToString() == temp)
                    label10.BackColor = teb.BackColor;
            }

            label6.Text = textBox1.SelectedText;
            label6.ForeColor = (label10.BackColor);
       
    }
        public void Start(bool les)
        {
            lbGo.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;

            if (rbtTime.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start(); t = 0;
                statistika = 1;
            }
            if (rbtStatistic.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start(); t = 0;
                statistika = 2;
            }
            if (LEng == true)//&& lesson==false
            {
                Klava1();
                NameBut(ListBut, bt_nameEnglish);
                ButColor(ListBut);
                label6.Text = Tren(1, slognost);
            }
            if (LRu == true)//&& lesson == false
            {
                Klava1();//bt_nameRu
                NameBut(ListBut, bt_nameRu);
                ButColor(ListBut);
                label6.Text = Tren(2, slognost);
            }
            if (LUa == true)//&& lesson == false
            {
                Klava1();//bt_nameUa
                NameBut(ListBut, bt_nameUa);
                ButColor(ListBut);
                label6.Text = Tren(3, slognost);
            }
            // richTextBox1.Select();
            panel3.Size = new Size(panel2.Width, panel5.Height * 3);
            panel8.Visible = false;
            if(les==true)
            {
                textBox1.Select();
            }
            else
            {
                richTextBox1.Select();
            }
        }
        //rihcTextBox
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string temp = "";
            if (start == true)
            {
                foreach (Button b in ListBut)
                {
                    if (b.Tag.ToString() == e.KeyCode.ToString())
                    {
                        b.BackColor = bt_Press;
                        temp=b.Text;
                    }
                }

                if (but.Tag.ToString() == e.KeyCode.ToString())
                {
                    bt = true;
                }
                else bt = false;
                
            }
            else
            {
                MyFun();
            }
            start = true;
            /////           //s

            // label2.Text = e.KeyCode.ToString();
            label2.Text =temp;
        }
        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (bt == false)
            {
                bt_error++;
            }
            else
            {
                ButColor(ListBut);
            
                if (LEng == true)
            {
                label6.Text = Tren(1, slognost);             
                label6.ForeColor = (label10.BackColor);
            }

                if (LRu == true )
                {
                    label6.Text = Tren(2, slognost);      
                    label6.ForeColor = (label10.BackColor);
                }

                if (LUa == true )
                {
                    label6.Text = Tren(3, slognost);
                    label6.ForeColor = (label10.BackColor);
                }
                
           }
            label7.Text = bt_error.ToString();
            ButColor(ListBut);
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            col_simvol++;
            label3.Text = col_simvol.ToString();

        }
//radioButton slognost
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            slognost = 2;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            slognost = 3;
        }
//timer        
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (panel1.Width == 265)
            {
                timer2.Enabled = false;
                lbPanelOpen.Text = "<<";
            }
            else
            {
                panel1.Width += 20;
            }
            richTextBox1.Focus(); //s
            richTextBox1.Select(); //s
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (panel1.Width == 5)
            {
                timer1.Enabled = false;
                lbPanelOpen.Text = ">>";
            }
            else
            { panel1.Width -= 20; }
            richTextBox1.Focus(); //s
            richTextBox1.Select(); //s
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            // label9.Text = DateTime.Now.ToLongTimeString();
            sek++;
            t++;
            
            // Set the caption to the current time.

            if (sek == 60)
            {
                m++;
                sek = 0;

            }
            if (m == 60)
            {
                h++;
                m = 0;
            }

            label4.Text = h.ToString() + " " + m.ToString() + " " + sek.ToString();
             double CS = col_simvol;
             if (t > 60) CS = CS / t * 60;
             label5.Text = CS.ToString();
           // MyColSimvol(statistika,t,col_simvol);
           // END_Level();
        }
//label
        private void lbGo_Click(object sender, EventArgs e)
        {
            LEng = true;
            panel3.Visible = false;
            lbGo.Visible = false;
            Progress.Visible = false;

            // panel4.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;

            if (rbtTime.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start();
                statistika = 1;
            }
            if (rbtStatistic.Checked == true)
            {
                timer3.Interval = 1000;
                timer3.Start();
                statistika = 1; // s!  statistika = 2; // s!  
            }
            if (LEng == true)//&& lesson==false
            {
                Klava1();
                NameBut(ListBut, bt_nameEnglish);
                ButColor(ListBut);
                label6.Text = Tren(1, slognost);
            }
            if (LRu == true)//&& lesson == false
            {
                Klava1();//bt_nameRu
                NameBut(ListBut, bt_nameRu);
                ButColor(ListBut);
                label6.Text = Tren(2, slognost);
            }
            if (LUa == true)//&& lesson == false
            {
                Klava1();//bt_nameUa
                NameBut(ListBut, bt_nameUa);
                ButColor(ListBut);
                label6.Text = Tren(3, slognost);
            }
             richTextBox1.Focus();
             richTextBox1.Select();
             panel3.Size = new Size(panel2.Width, panel5.Height * 3);

             MyFun();
        }
        private void lbPanelOpen_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus(); //s
            richTextBox1.Select(); //s
            switch (panel1.Width)
            {
                case 5:
                    timer2.Enabled = true;

                    break;
                case 265:
                    timer1.Enabled = true;

                    break;
            }
        }
//button
        private void btnGo_Click(object sender, EventArgs e)
        {

            if (!flag_Click)
            {

                flag_Click = !flag_Click;
                timer3.Interval = 1000;
                timer3.Start();
                btnGo.Text = "Stop";
               // panel4.Visible = false;
            }
            else
            {
                timer3.Stop();
                btnGo.Text = "Start";

            }
            richTextBox1.Select();
        }
//смена раскладки
        private void btnEngl_Click(object sender, EventArgs e)
        {
            LEng = true;
            LRu = false;

            LUa = false;
            start = false;

            NameBut(ListBut, bt_nameEnglish);
            s_lang = "English";

            label1.Text = s_lang;
            index = 0;
            col_simvol = 0;
            bt_error = 0;
            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
            richTextBox1.Select();

        }
        private void btnRu_Click(object sender, EventArgs e)
        {
            s_lang = "Русский";
            label1.Text = s_lang;
            LRu = true;
            LEng = false;
            LUa = false;
            start = false;

            NameBut(ListBut, bt_nameRu);

            richTextBox1.Select();
            index = 0;
            col_simvol = 0;
            bt_error = 0;
            label6.Text = "";

            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
        }
        private void btnUA_Click(object sender, EventArgs e)
        {
            s_lang = "Українська";
            NameBut(ListBut, bt_nameUa);

            LRu = false;
            LEng = false;
            LUa = true;
            start = false;
            label1.Text = s_lang;
            index = 0;
            col_simvol = 0;
            bt_error = 0;
            label6.Text = "";
            label3.Text = "";
            label7.Text = "";
            label10.BackColor = Color.White;
            richTextBox1.Select();
        }
//очистить
        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            t = 0;
            richTextBox1.Select();
            rbtStatistic.Checked = false;
            rbtTime.Checked = false;
            panel4.Visible = true;
            label3.Text = "";
            label5.Text = "";
            label7.Text = "";
            label4.Text = "";
        }
//pauza
        private void btnPauza_Click(object sender, EventArgs e)
        {
            if (pauza)
            {
                pauza = !pauza;

                if (rbtTime.Checked == true || rbtStatistic.Checked == true)
                {
                    timer3.Interval = 1000;
                    timer3.Start();
                }

                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                btnPauza.Text = "Пауза";
            }
            else
            {
                if (rbtTime.Checked == true || rbtStatistic.Checked == true) timer3.Stop();
                // lbGo.Visible = true;
                // panel2.Visible = false;
                panel4.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                btnPauza.Text = "Продолжить";
                pauza = !pauza;
            }
            richTextBox1.Focus();
            richTextBox1.Select();
        }
//режим редактора
        private void button1_Click(object sender, EventArgs e)
        {
            Point Xfrm = new Point();
            Point Yfrm = new Point();
            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height-panel2.Height;
            panel2.Location = new Point (panel2.Location.X,temY ) ;
            panel3.Location = new Point(panel3.Location.X, temX);
            panel3.Size = new Size(panel2.Width, temY-temX  );
            panel3.BackColor = Color.Coral;
           
            // panel2.Location;
        }
//открыть файл 
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Multiline = true;
            textBox1.Text= fileText.ToUpper();
            string d = fileText.Substring(1);
            Language(fileText.ToUpper());
            textBox1.ReadOnly = true;
            textBox1.SelectionStart = 0;
            textBox1.Select(0, 1);
            textBox1.Focus();
            richTextBox1.Visible = false;
            richTextBox1.Enabled = false;
            label6.Text = "";
            label10.BackColor = bt_Press;
            //textBox1.SelectionStart=0;
            //  richTextBox1.ReadOnly = true;
            // richTextBox1.Text = fileText.ToUpper();
            //  richTextBox1.Select();
            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height - panel2.Height-panel5.Height;
            
             panel3.Location = new Point(panel5.Location.X, panel5.Bottom);//temY - temX 
            
            panel3.Size = new Size(panel2.Width, panel5.Height+30);
           panel2.Location = new Point(panel2.Location.X, panel3.Bottom);
            panel3.BackColor = Color.Coral;
            panel3.Visible = true;
           // label21.Text = temX.ToString();
           // label20.Text = temY.ToString();
            lesson = true;
            b_ind = 0;

            //panel8.Visible = false;
           
           // Start(true);
          
        }
        public string goNo(string s)
        {
            string tem = null;
            string t_s = null;
           // if (s.Length > 1) s = s.Substring(1);
            for (int i = 0; i < bt_teg.Length; ++i)
                {
                if (ListBut[i].Text == "F_" || ListBut[i].Text == "А_") t_s = ListBut[i].Text.Substring(0,1);
                else
                    if (ListBut[i].Text == "_J" || ListBut[i].Text == "_О") t_s = ListBut[i].Text.Substring(1);
                else
                    t_s = ListBut[i].Text;
                if (t_s==s)
                   // if (ListBut[i].Text.Contains(s.ToUpper()) == true)
                    {
                  tem = ListBut[i].Tag.ToString();
                    temp_Tag= ListBut[i].Tag.ToString();

                }
                 }
        
                return tem;
           
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ButColor(ListBut);

            if (e.KeyCode == Keys.Enter && tem_s == "\n" || tem_s == "\n\r" || tem_s == "\r")
            {
                e.Handled = true;
                textBox1.Text += Environment.NewLine;
                b_ind += 2;
                a++;
                label6.Text = "";
                textBox1.SelectionStart = textBox1.Text.Length - 1;
                textBox1.ScrollToCaret();
                textBox1.Select(b_ind, a);

            }
            else
            {
                a = 1;
                textBox1.Select(b_ind, a);
            }
            tem_s = textBox1.SelectedText;
            
            label20.Text = textBox1.SelectedText;
            if (goNo(tem_s)!= null )
            {           
                foreach (Button teb in ListBut)
                {
                    if (teb.Tag.ToString() == temp_Tag)
                        label10.BackColor = teb.BackColor;
                }
                label6.Text = textBox1.SelectedText;
                label6.ForeColor = (label10.BackColor);
            }
            temp_Tag = null;
                tem_s = null;
            ButColor(ListBut);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ButColor(ListBut);
            textBox1.Select(b_ind, a);
            tem_s = textBox1.SelectedText;
            if (e.KeyCode == Keys.Enter && tem_s == "\n" || tem_s == "\n\r" || tem_s == "\r")
            {
                e.Handled = true;
                textBox1.Text += Environment.NewLine;
                b_ind += 2;
                a++;
                label6.Text = "";
                textBox1.SelectionStart = textBox1.Text.Length - 1;
                textBox1.ScrollToCaret();
                textBox1.Select(b_ind, a);
            }
            else
            {
                a = 1;
                textBox1.Select(b_ind, a);
            }
            tem_s = textBox1.SelectedText;
            if (tem_s!=null&&tem_s.Length > 1)
            { tem_s = tem_s.Substring(1); }
         
          
            if (goNo(tem_s ) ==e .KeyCode.ToString())
            {
                b_ind++;
                foreach (Button teb in ListBut)
                {
                    if (teb.Tag.ToString() == temp_Tag)
                        label10.BackColor = teb.BackColor;
                }
                label6.Text = textBox1.SelectedText;
                label6.ForeColor = (label10.BackColor);
               
            }
            foreach (Button b in ListBut)
            {
                if (b.Tag.ToString() == e.KeyData.ToString())
                {
                    b.BackColor = bt_Press;
                }
            }
                       
            if (textBox1.SelectedText == e.KeyData.ToString())
            {
                bt = true;
            }
            else bt = false;
           
        }      
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void Progress_Click(object sender, EventArgs e)
        {

            panel3.Visible = false;
            lbGo.Visible = false;
            Progress.Visible = false;

            panel8.Visible = false;
            panel4.Visible = false;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;

            rbtTime.Checked = true;
            {
                timer3.Interval = 1000;
                timer3.Start();
                statistika = 1;
            }

            panel3.Size = new Size(panel2.Width, panel5.Height * 3);   

            string fileText = DB_.Load_Level();
            textBox1.Multiline = true;
            textBox1.Text = fileText.ToUpper();
            string d = fileText.Substring(1);
            Language(fileText.ToUpper());
            textBox1.ReadOnly = true;
            textBox1.SelectionStart = 0;
            textBox1.Select(0, 1);
            textBox1.Focus();
            richTextBox1.Visible = false;
            richTextBox1.Enabled = false;
            label6.Text = "";
            label10.BackColor = bt_Press;

            int temX = 0;
            int temY = 0;
            temX = panel5.Bottom;
            temY = ClientSize.Height - panel2.Height - panel5.Height;

            panel3.Location = new Point(panel5.Location.X, panel5.Bottom);//temY - temX 

            panel3.Size = new Size(panel2.Width, panel5.Height + 30);
            panel2.Location = new Point(panel2.Location.X, panel3.Bottom);
            panel3.BackColor = Color.Coral;
            panel3.Visible = true;

            lesson = true;
            b_ind = 0;
            Language(fileText);
            MyFun();

            richTextBox1.Focus();
            richTextBox1.Select();
            Start(true);
        }
        private void timer4_Tick(object sender, EventArgs e)
        {

        }
      
        private void label14_Click(object sender, EventArgs e)
        {
            
            if (DB_.User_Id > 0)
            { 
            Levels fr = new Levels(DB_.User_Id);
            fr.ShowDialog();
                work_level = fr.Uroven;
               
            }
            label14.Text="Уровень : "+ work_level.ToString();
        }

        
    }
}

////////////////////////






