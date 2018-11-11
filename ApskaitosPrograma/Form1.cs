using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApskaitosPrograma
{
    
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }
    public class baldas
        {
            public int Kaina { get; set; }
            public Double Laiko { get; set; }
            public baldas(int kaina, double laiko)
            {
                Kaina = kaina;
                Laiko = laiko;
            }
        }
        int kKainas = 20;
        baldas kede = new baldas(10, 1);
        baldas stalas = new baldas(50, 2);
        baldas sofa = new baldas(100, 3);
        private void buttonMain_Click(object sender, EventArgs e)
        {
            int kiekK = Convert.ToInt32(textBox1.Text);
            int kiekS = Convert.ToInt32(textBox2.Text);
            int kiekSo = Convert.ToInt32(textBox3.Text);

            int skaicK = (kiekK * kede.Kaina)+ (kiekS * stalas.Kaina)+ (kiekSo * sofa.Kaina);
            double skaicL = (kede.Laiko * kiekK) + (kede.Laiko * kiekS) + (kede.Laiko * kiekSo);
            textBox4.Text = skaicK.ToString();
            textBox5.Text = skaicL.ToString();

        }
    }
}
