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

        public List<Baldas> Login()
        {
            return BaldaiService.getBaldai();
        }

        public Form1()
        {
            InitializeComponent();
            Login();
            
        }
      
               
        private void buttonMain_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
