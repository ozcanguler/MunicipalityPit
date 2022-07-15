using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalityPit
{
    public partial class Form2 : Form
    {
        internal int px;
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            px = Convert.ToInt32(comboBox1.SelectedItem);
            this.Hide();
            Form1 form1 = new Form1();
            //MessageBox.Show(px.ToString());
            form1.receiveData(px);
            form1.Show();
           
        }
    }
}
