using System;

using System.Data;
using System.Data.OleDb;

using System.Windows.Forms;

namespace KCH
{



    public partial class Form2 : Form
    {
        private void clearall()
        {
            dataGridView1.Rows.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox4.Text = "0";
            // textBox6.Text = "";
            button2.Enabled = false;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox6.ReadOnly = true;
            dataGridView1.ReadOnly = true;
            button3.Text = "قائمة جديدة";


        }


        private void open()
        {
            if (button3.Text != "تراجع")
            {
                button3.Text = "تراجع";
                button2.Enabled = true;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox6.ReadOnly = false;

                dataGridView1.ReadOnly = false;

                textBox2.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "";
                dataGridView1.Rows.Clear();
            }
            else
            {
                clearall();

            }


        }
        OleDbConnection connction = new OleDbConnection();
        OleDbConnection co = new OleDbConnection();
        
        OleDbDataAdapter da1;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        
        OleDbCommand com;
        
        Boolean flage = true;

       
        public Form2()
        {
            InitializeComponent();
            connction.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|KTC.accdb;
Persist Security Info=False;";
            clearall();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            open();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double to = 0;
            double t1 = 0;
            double t2 = 0;
            double tf = 0;
            double bro = 0;
            double pay = 0;
            double cut1;
            double S_P = 0;
            flage = true;

            if (dataGridView1.Rows.Count - 1 == 0)
                flage = false;
            check();
            if (flage == true)
            {

                com = connction.CreateCommand();
                com.CommandType = CommandType.Text;




                try

                {
                    com.CommandText = "insert into Info_Cost(Name_C,Da,Address_C,discount,pay,bro,Final_price,S_P,nodes) Values('" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "'," + 0 + "," + 0 + "," + 0 + "," + 0 + ","+0+",'"+textBox5.Text+"')";

                    connction.Open();
                    com.ExecuteNonQuery();
                    connction.Close();
                    da1 = new OleDbDataAdapter("select Max(ID_C)from Info_Cost Where Name_C like '" + textBox2.Text + "%'", connction);
                    dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                        textBox1.Text = dt1.Rows[0][0].ToString();


                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {


                        t1 = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                        t2 = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        to = t2 * t1;
                        tf = tf + to;
                       

                        com.CommandText = "insert into Menu_Cost(ID_C,ID_O,Name_Object,No_Object,Price_object,Total_price) Values(" + Convert.ToInt32(textBox1.Text) + "," + (i + 1) + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + "," + dataGridView1.Rows[i].Cells[3].Value + ","  + to + ")";
                        dataGridView1.Rows[i].Cells[0].Value = (i + 1);
                        dataGridView1.Rows[i].Cells[5].Value = (to);
                        connction.Open();
                        com.ExecuteNonQuery();
                        connction.Close();
                    }

                    if (textBox6.Text == "")
                        cut1 = 0;

                    else
                        cut1 = Convert.ToDouble(textBox6.Text);
                         S_P = (tf - cut1);

                   
                  pay = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(":الرجاء ادخال المبلغ الواصل من قبل الزبون","ادخال المبلغ",S_P.ToString()));

                    bro = S_P - pay;



                   
                 
                    
                    
                    com.CommandText = "update Info_Cost set discount=" + cut1 + ",pay=" + pay + ",bro=" + bro + ",Final_price=" + tf + ",S_P="+S_P+" where ID_C=" + Convert.ToInt32(textBox1.Text) + "";

                    connction.Open();
                    com.ExecuteNonQuery();
                    connction.Close();

                    textBox8.Text = pay.ToString();
                    textBox4.Text = S_P.ToString();
                    textBox7.Text = tf.ToString();
                    textBox9.Text = bro.ToString();

                    MessageBox.Show("تم حفظ البيانات بنجاح");





                    button2.Enabled = false;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    dataGridView1.ReadOnly = true;

                    button3.Text = "قائمة جديدة";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("هناك نقص في البيانات المدخلة يرجى مراجع البيانات","خطا في الادخال");

                    Console.WriteLine(ex.Message);
                }
            }
            else
                MessageBox.Show("هناك نقص اما باسم الزبون او بنوع المادة او العدد او سعر المفرد!!الرجاء ادخال البيانات كاملة هناك");
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








        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }



        public void check()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value == null || dataGridView1.Rows[i].Cells[2].Value == null || dataGridView1.Rows[i].Cells[3].Value == null || textBox2.Text == "")
                {
                    flage = false;
                     break;
                }

            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {



            if (textBox1.Text != "")
            {
                if (button3.Text != "تراجع")
                {
                    Form4 f4 = new Form4(Convert.ToInt32(textBox1.Text));
                   
                 f4.Show();
                    this.Hide();
                }
                else MessageBox.Show("يرجى حفظ البيانات قبل الطباعة");

            }


            else
            {
                MessageBox.Show("يرجى اختيار رقم القائمة لغرض الطباعة");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int noOFRecoreds = 0;

            try
            {
                noOFRecoreds = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(":الرجاء ادخال عدد القوائم المراد حذفها سيتم الحذف من التاريخ الاقدم الى الاحدث", "ادخال عدد القوائم", "10"));
            }
            catch (Exception ex) { }
            if (noOFRecoreds <= 0)
                MessageBox.Show("يرجى ادخال عدد القوائم لغرض حذفها");
            else
            {
                try
                {
                    OleDbDataAdapter da1 = new OleDbDataAdapter("select  top " + noOFRecoreds + " da,ID_C from Info_Cost", connction);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            
                            com = connction.CreateCommand();
                            com.CommandType = CommandType.Text;




                            try

                            {
                                com.CommandText = "DELETE * FROM  Menu_Cost where ID_C =" + dt1.Rows[i][1].ToString();

                                connction.Open();
                                com.ExecuteNonQuery();
                                connction.Close();
                                com.CommandText = "DELETE * FROM   Info_Cost where ID_C =" + dt1.Rows[i][1].ToString();

                                connction.Open();
                                com.ExecuteNonQuery();
                                connction.Close();

                            }
                            catch (Exception ex) { }
                        }
                    }
                }
                catch (Exception ex) { }
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
