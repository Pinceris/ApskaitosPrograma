using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApskaitosPrograma
{    
    
    public partial class Form1 : Form
    {

        public List<Baldas> baldai = BaldaiService.getBaldai();
        
        public Form1()
        {
            InitializeComponent();
          
            
        }
      
               
        private void buttonMain_Click(object sender, EventArgs e)
        {
            
            int kaina = (baldai[0].Kaina * Convert.ToInt32(textBox1.Text))+ (baldai[1].Kaina * Convert.ToInt32(textBox2.Text)) + (baldai[2].Kaina * Convert.ToInt32(textBox3.Text));
            int laikas = (int) (baldai[0].Laiko * Convert.ToInt32(textBox1.Text) + baldai[1].Laiko * Convert.ToInt32(textBox2.Text) + baldai[2].Laiko * Convert.ToInt32(textBox3.Text));

            textBox4.Text = Convert.ToString(kaina);
            textBox5.Text = Convert.ToString(laikas);


            MessageBox.Show("Press 'Confirm' if you wish to place the order");
            int kedes = 0;
            int stalai = 0;
            int sofos = 0;
            int suma = 0;

            int.TryParse(textBox1.Text, out kedes);
            int.TryParse(textBox2.Text, out stalai);
            int.TryParse(textBox3.Text, out sofos);
            int.TryParse(textBox4.Text, out suma);

            BaldaiService.insertOrder(kedes, stalai, sofos, suma);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
    
