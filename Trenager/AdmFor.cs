using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trenager
{
    public partial class AdmFor : Form
    {
        private readonly object openFileDialog1;

        public AdmFor()
        {
            InitializeComponent();
            dataGridView1.DataSource = DB_.SetLevesTab();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "txt files (*.txt)|*.txt";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog2.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Multiline = true;
            textBox1.Text = fileText.ToUpper();
            string d = fileText.Substring(1);
        }

        private void Add_Level_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            int m=9;
            try
            {
               m = Int32.Parse(textBox2.Text);
            }
            catch { MessageBox.Show("Admin ne tupi!"); }
            DB_.N_LevelAdd(temp, m);
            dataGridView1.DataSource = DB_.SetLevesTab();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i=0;
            bool result = Int32.TryParse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), out i);
            if (result)
            {
                i = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            else { MessageBox.Show("Выбрать уровень!"); return; }
            DB_.DelLev(i);
            dataGridView1.DataSource = DB_.SetLevesTab();
        }
    }
}
