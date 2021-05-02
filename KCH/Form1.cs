using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KCH
{
    public partial class Form1 : Form
    {
        OleDbConnection connction = new OleDbConnection();
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
         OleDbCommand com;
        public Form1()
        {
            InitializeComponent();
            try { connction.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|KTC.accdb;
Persist Security Info=False;"; } catch(Exception ex) { MessageBox.Show(ex.Message); }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            da = new OleDbDataAdapter("Select * from Login where username='" + textBox1.Text + "' and p='" + textBox2.Text + "'", connction);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                textBox1.Text = "";
                textBox2.Text = "";
                Form2 f1 = new Form2();
                f1.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("");
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String inp1, inp2;
            da = new OleDbDataAdapter("Select * from Login where username='" + textBox1.Text + "' and p='" + textBox2.Text + "'", connction);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                 
                inp1 = Microsoft.VisualBasic.Interaction.InputBox(":الرجاء ادخال اسم المستخدم الجديد");
                inp2 = Microsoft.VisualBasic.Interaction.InputBox(":الرجاء ادخال كلمة المرور الجديد");
                if (inp1 == "")
                    MessageBox.Show("!!اسم المستخدم خاطأ يرجا التاكد");

                else if (inp2 == "")
                    MessageBox.Show("!! رمز الدخول خاطأ يرجا التاكد");

                else
                {

                    try
                    {
                        connction.Open();
                        com = connction.CreateCommand();
                        com.CommandType = CommandType.Text;
                        com.CommandText = ("update Login set username='" + inp1 + "', p='"+inp2+"' where username='" + textBox1.Text + "'");
                        com.ExecuteNonQuery();
                        connction.Close();


                        MessageBox.Show("تم التعديل");


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }

                }
            }
                else

                MessageBox.Show("سم المستخدم او رمز الدخول خاطأ يرجا التاكد");
            





        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Width = pictureBox1.Width + 1;
            pictureBox1.Height = pictureBox1.Height + 1;

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Width = pictureBox1.Width - 1;
            pictureBox1.Height = pictureBox1.Height - 1;
        }


        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Width = pictureBox2.Width + 1;
            pictureBox2.Height = pictureBox2.Height + 1;

        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Width = pictureBox2.Width - 1;
            pictureBox2.Height = pictureBox2.Height - 1;
        }

      
    }
}
