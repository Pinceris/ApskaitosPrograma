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

        public List<Baldas> baldai;

        public Form1()
        {
            baldai = BaldaiService.getBaldai();
            InitializeComponent();
            initTable();
        }

        private void initTable()
        {
            DataTable table = BaldaiService.getOrderTable();
            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            int kaina = 0;
            int laikas = 0;

            foreach (Baldas b in baldai)
            {
                switch (b.Tipas)
                {
                    case (Tipas.CHAIR):
                        kaina += calculatePrice(b, textBox1.Text);
                        laikas += calculateTime(b, textBox1.Text);
                        break;
                    case (Tipas.DESK):
                        kaina += calculatePrice(b, textBox2.Text);
                        laikas += calculateTime(b, textBox2.Text);
                        break;
                    case (Tipas.SOFA):
                        kaina += calculatePrice(b, textBox3.Text);
                        laikas += calculateTime(b, textBox3.Text);
                        break;
                }
            }

            textBox4.Text = Convert.ToString(kaina);
            textBox5.Text = Convert.ToString(laikas);

            MessageBox.Show("Press 'Confirm' if you wish to place the order");
        }

        private int calculatePrice(Baldas b, String value)
        {
            return b.Kaina * ParseInt(value);
        }

        private int calculateTime(Baldas b, String value)
        {
            return (int)b.Laiko * ParseInt(value);
        }

        private int ParseInt(String value)
        {
            int.TryParse(value, out int result);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out int kedes);
            int.TryParse(textBox2.Text, out int stalai);
            int.TryParse(textBox3.Text, out int sofos);
            int.TryParse(textBox4.Text, out int suma);

            BaldaiService.insertOrder(kedes, stalai, sofos, suma);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
    
