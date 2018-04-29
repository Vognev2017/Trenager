using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Trenager
{
    [Table(Name = "LevelSpT")]
    public class LevelSpT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Exercise { get; set; }
        [Column]
        public int Mistake { get; set; }
    }

    [Table(Name = "PopytT")]
    public class PopytT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public int Lev_id { get; set; }
        [Column]
        public int User_id { get; set; }
        [Column]
        public int Kol_popyt { get; set; }
        [Column]
        public int Speed { get; set; }
        [Column]
        //изменение
        public int Mistake { get; set; }
        [Column]
        public double Ritm { get; set; }
        //изменения 
        [Column]
        public DateTime Datta { get; set; }
    }

    [Table(Name = "UserT")]
    public class UserT
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
       //изменения 
        [Column]
        public string Fam { get; set; }
        [Column]
        public string Name { get; set; }
        //изменения 
        [Column]
        public string Login { get; set; }
        //изменения 
        [Column]
        public string Email { get; set; }
        [Column]
        public int Dostup { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public int? Progres { get; set; }
        //изменения 
        [Column]
        public string Avatar { get; set; }
    }
    
    public static class DB_
    {
        public static string Trenager_Name{ get; set; }
        public static string Hello_ { get; set; }
        public static double Version_Trenager { get; set; }

        private static string path = Directory.GetCurrentDirectory();

        private static string str1 = path + @"\TrenDB.mdf";
       
        // static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\res\Trenager_temp2\TrenDB.mdf;Integrated Security = True; Connect Timeout = 30";Z:\StudentsFiles\RPZ\RPZ2\SV3\Trenager_temp2\TrenDB.mdf
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ str1 + ";Integrated Security=True;Connect Timeout=30";
        public static int Dostyup_L { get; private set; }
        public static int User_Id { get; private set; }
        public static int Mistake_L { get; private set; }

        static DB_ ()
        {
            DB_.Trenager_Name = "VoGEN";
            DB_.Hello_ = "Здесь могла быть ваша реклама";
            DB_.Version_Trenager = 0.5;
        }

        public static int chekUser(string log, string pas)
        {
            int res = 0;
            DataContext db = new DataContext(connectionString);
            Table<UserT> users = db.GetTable<UserT>();

            var selectedUsers = from user in users
                                where (user.Name == log && user.Password == pas)
                                select user;

            UserT Temp = selectedUsers.FirstOrDefault();
            if (selectedUsers.Count() > 0) res = Temp.Dostup; else MessageBox.Show("Something Wrong");

            if (res > 0) { Dostyup_L = res; User_Id=Temp.Id; }
            return res;
        }

        public static void NewUserAdd(string log, string pas)
        {
//Dopil
            DataContext db = new DataContext(connectionString);
            Table<UserT> TU = db.GetTable<UserT>();
            var SelUz = TU.Where(u => u.Name==log );
            if (SelUz.Count()>0) { MessageBox.Show("User "+ log + " is already exist!"); return; }
            UserT NU = new UserT { Name=log, Password=pas, Dostup=1}; // add Image!!!!!!!!!!!!!

            try
            {
                db.GetTable<UserT>().InsertOnSubmit(NU);
                db.SubmitChanges();
                Table<PopytT> PTs = db.GetTable<PopytT>();
                Table<UserT> TU2 = db.GetTable<UserT>();
                UserT NU2 = TU2.Where(u => u.Name==log).First();
                //изменение 
                PopytT NP = new PopytT { Lev_id = 1, Kol_popyt = 0, User_id = NU2.Id, Mistake = 0, Ritm=0, Speed=0, Datta=DateTime.Now };
                db.GetTable<PopytT>().InsertOnSubmit(NP);
              //  MessageBox.Show(" Теперь выберите продолжить и зайдите под выбранным именем ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void N_LevelAdd(string txt, int mis)
        {
            //Dopil
            try
            {
                DataContext db = new DataContext(connectionString);
                Table<LevelSpT> TU = db.GetTable<LevelSpT>();
                int maxId = TU.Max(u => u.Id);
                maxId++;
                LevelSpT NU = new LevelSpT { Exercise=txt, Mistake=mis }; 

            
                db.GetTable<LevelSpT>().InsertOnSubmit(NU);
                db.SubmitChanges();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static Table<LevelSpT> SetLevesTab ()
        {
            DataContext db = new DataContext(connectionString);
            Table<LevelSpT> AD_ = db.GetTable<LevelSpT>();
            return AD_;
        }

        public static void DelLev(int i)
        {
            DataContext db = new DataContext(connectionString);
            var lev = db.GetTable<LevelSpT>().OrderByDescending(u => u.Id == i).FirstOrDefault();
            if (lev != null)
            {
                db.GetTable<LevelSpT>().DeleteOnSubmit(lev);
                db.SubmitChanges();
            }
        }

        public static string Load_Level()
        {
            string temp="";
            DataContext db = new DataContext(connectionString);
            Table<LevelSpT> LU = db.GetTable<LevelSpT>();
            Table<UserT> TU2 = db.GetTable<UserT>();
            UserT NU2 = TU2.Where(u => u.Id == DB_.User_Id).First();
            int findlevel=1;
            if (NU2.Progres!=null) findlevel = (int)NU2.Progres;
            LevelSpT TL = LU.Where(u => u.Id == findlevel).First();
            temp = TL.Exercise;
            DB_.Mistake_L = TL.Mistake;
            return temp;
        }
    }
}
