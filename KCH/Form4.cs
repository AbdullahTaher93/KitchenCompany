using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KCH
{
    public partial class Form4 : Form
    {
        public Form4(int x)
        {
            InitializeComponent();
            this.q1TableAdapter.Fill(this.kTCDataSet.q1,x);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kTCDataSet.q1' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
    }
}
