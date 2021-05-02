using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KCH
{
    public partial class Form3 : Form

    {
        OleDbConnection connction = new OleDbConnection();
        OleDbDataAdapter da;
        DataTable dt = new DataTable();



       
        OleDbDataAdapter da1;
        DataTable dt1 = new DataTable();
       public Form3()
        {
            InitializeComponent();
            connction.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|KTC.accdb;
Persist Security Info=False;";
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {

           
            ser(textBox4.Text.ToString());
           
        }

    
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void ser(String Tex)
        {
            //داله البحث
            if (radioButton1.Checked == true && Tex != "")
            {
               
               


                da1 = new OleDbDataAdapter("select * from Info_Cost Where ID_C like '" + Tex + "'", connction);
                dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    button2.Visible = true;
                    textBox7.Text = dt1.Rows[0][0].ToString();
                    textBox3.Text = dt1.Rows[0][1].ToString();
                    dateTimePicker1.Text = dt1.Rows[0][2].ToString();
                    textBox6.Text = dt1.Rows[0][4].ToString();
                    textBox5.Text = dt1.Rows[0][5].ToString();
                    textBox2.Text = dt1.Rows[0][6].ToString();
                    textBox1.Text = dt1.Rows[0][7].ToString();
                    textBox8.Text = dt1.Rows[0][8].ToString();

                    da = new OleDbDataAdapter("select * from Menu_Cost Where ID_C like '" + Tex + "'", connction);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لأتوجد بيانات للعرض");
                }

            }
               else if(radioButton1.Checked == false && Tex != "")
               {

                da = new OleDbDataAdapter("select ID_C,Name_C,Da from Info_Cost Where Name_C like '" + textBox4.Text + "%'", connction);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    textBox7.Text = dt.Rows[0][0].ToString();
                    textBox3.Text = dt.Rows[0][1].ToString();
                    dateTimePicker1.Text = dt.Rows[0][2].ToString();
                    dataGridView2.DataSource = dt;
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
           
            



        }

        private void button4_Click(object sender, EventArgs e)
        {

           
          if (!textBox7.Text.Equals(""))
            {
                if (button2.Visible == true)
                {
                    if(MessageBox.Show("سيتم طباعة البيانات دون حفظ التعديلات للاستمرار اضغط نعم","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                       Form4 f4 = new Form4(Convert.ToInt32(textBox7.Text));

                        f4.Show();
                        this.Hide();
                    }

                    else MessageBox.Show("يرجى حفظ البيانات بستخدام زر الحفظ اعلاه","تنبيه");
                }
                else
                {
                    Form4 f4 = new Form4(Convert.ToInt32(textBox7.Text));

                    f4.Show();
                    this.Hide();

                }
            }
            else { MessageBox.Show("يرجى اختيار رقم القائمة لغرض الطباعة","تنبيه"); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            { 
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            textBox7.Text = row.Cells["ID_CC"].Value.ToString();
            dateTimePicker1.Text = row.Cells["Date_"].Value.ToString();
            textBox3.Text = row.Cells["Name_CC"].Value.ToString();
                radioButton1.Checked = true;
                ser(textBox7.Text.ToString());
            }
            

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable get = new DataTable();
            get.Columns.Add("ID_C", typeof(Int32));
            get.Columns.Add("Name_object",typeof(string));
            get.Columns.Add("No_object", typeof(Int32));
            get.Columns.Add("price_object", typeof(Int32));
           
            

            OleDbCommand com = new OleDbCommand();
            com = connction.CreateCommand();
            com.CommandType = CommandType.Text;
             int i = 0;
            int x = 0, y = 0;
            int z = 0;
            int to = 0;
           
            Boolean flage = true;


            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                
                if  (dataGridView1.Rows[i].Cells[2].Value.ToString()==""|| dataGridView1.Rows[i].Cells[3].Value.ToString()==""|| dataGridView1.Rows[i].Cells[4].Value.ToString()=="")
                {
                    flage = false;
                    break;
                    
                }

             
            }

            if (flage == true)
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    


                    get.Rows.Add(Convert.ToInt32(textBox7.Text), dataGridView1.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value));

                    com.CommandText = "delete from Menu_Cost Where ID_C=" + Convert.ToInt32(textBox7.Text) + "";
                    connction.Open();
                    com.ExecuteNonQuery();
                    connction.Close();
                }

                for (i = 0; i < get.Rows.Count; i++)
                {
                    to = Convert.ToInt32(get.Rows[i][2]) * Convert.ToInt32(get.Rows[i][3]);
                    x = x + to;
                    
                  
                    dataGridView1.Rows[i].Cells[5].Value = to;
                    com.CommandText = ("insert into Menu_Cost(ID_C,ID_O,Name_Object,No_Object,Price_object,Total_price) values (" + Convert.ToInt32(get.Rows[i][0].ToString()) + "," + (i + 1) + ",'" + get.Rows[i][1].ToString() + "'," + Convert.ToInt32(get.Rows[i][2]) + "," + Convert.ToInt32(get.Rows[i][3]) + "," + to + ")");

                    connction.Open();
                    com.ExecuteNonQuery();
                    connction.Close();
                }

                if (textBox6.Text == "")
                    textBox6.Text = "0";
                textBox1.Text = x.ToString();
                textBox8.Text = (x - Convert.ToInt32(textBox6.Text)).ToString();

                
                z =  Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox(":الرجاء ادخال المبلغ الواصل من قبل الزبون", "ادخال المبلغ", textBox8.Text));
                textBox5.Text = z.ToString();
                y = Convert.ToInt32(textBox8.Text) - z;
                textBox2.Text = y.ToString();
                com.CommandText = ("update Info_Cost set Da='" + dateTimePicker1.Text + "',discount=" + textBox6.Text + ",pay=" + z + ",bro=" + y + ",Final_price=" + x + ", S_P="+Convert.ToInt32(textBox8.Text)+" where ID_C=" + Convert.ToInt32(textBox7.Text) + "");
                // com.CommandText = ("insert into Menu_Cost(Name_object) values ('abdallah') ");
                connction.Open();
                com.ExecuteNonQuery();
                connction.Close();
                MessageBox.Show("تم تعديل البيانات");
                button2.Visible = false;


            }//end if of falge
            else MessageBox.Show("هناك نقص في البيانات المدخلة");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
