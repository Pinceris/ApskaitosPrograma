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
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string connectionString;

        public void Login()
        {

            server = "localhost";
            database = "test";
            user = "root";
            password = "";

            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}", server, user, password, database);

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();

                MessageBox.Show("successful connection");

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
            Login();
            
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
