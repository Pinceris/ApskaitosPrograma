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
        List<baldas> bSarasas = new List<baldas>();

        public List<baldas> Login()
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


            string q = "select Pavadinimas, Kaina, Laikas from baldai";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    con.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var ws = new baldas("",0,0);
                        ws.Pavadinimas = reader.GetString("Pavadinimas");
                        ws.Kaina = reader.GetInt32("Kaina");
                        ws.Laiko = reader.GetInt32("Laikas");
                        bSarasas.Add(ws);
                    }
                    reader.Close();
                    return bSarasas;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            Login();
            
        }

    public class baldas
        {
            public string Pavadinimas { get; set; }
            public int Kaina { get; set; }
            public Double Laiko { get; set; }
            public baldas(string pavadinimas, int kaina, double laiko)
            {
                Pavadinimas = pavadinimas;
                Kaina = kaina;
                Laiko = laiko;
            }
        }
        
        
        
        private void buttonMain_Click(object sender, EventArgs e)
        {
            

        }
        
    }
    
}
