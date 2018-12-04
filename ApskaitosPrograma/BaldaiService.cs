using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

public class BaldaiService
{

    public static List<Baldas> getBaldai()
    {
        using (MySqlConnection con = MySqlService.getConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("select Pavadinimas, Kaina, Laikas from baldai", con))
            {
                try
                {
                    con.Open();
                    return extractBaldai(cmd);
                } catch(Exception e)
                {
                    MessageBox.Show("Unable to connect to MySql");
                    List<Baldas> baldai = new List<Baldas>();
                    baldai.Add(new Baldas(Tipas.DESK, 10, 5));
                    baldai.Add(new Baldas(Tipas.CHAIR, 10, 5));
                    baldai.Add(new Baldas(Tipas.SOFA, 10, 5));
                    return baldai;
                }
                
                
            }
        }
    }

    private static List<Baldas> extractBaldai(MySqlCommand cmd)
    {
        List<Baldas> bSarasas = new List<Baldas>();
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var ws = new Baldas(Tipas.CHAIR, 0, 0);
            ws.Tipas = (Tipas)Enum.Parse(typeof(Tipas), reader.GetString("Pavadinimas"));
            ws.Kaina = reader.GetInt32("Kaina");
            ws.Laiko = reader.GetInt32("Laikas");
            bSarasas.Add(ws);
        }
        reader.Close();
        return bSarasas;
    }

    public static void insertOrder(int chair, int table, int sofa, int totalsum)
    {
        using(MySqlConnection con = MySqlService.getConnection())
        {
            try
            {
                con.Open();
                AddBaldas(chair, table, sofa, totalsum, con);
                MessageBox.Show("Your order was placed");
            } catch(Exception e)
            {
                MessageBox.Show("Unable to connect to MySql");
            }

        }
    }

    private static void AddBaldas(int chair, int table, int sofa, int totalsum, MySqlConnection con)
    {
        MySqlCommand comm = con.CreateCommand();
        comm.CommandText = "INSERT INTO uzsakymai(kedes,stalai,sofos,suma) VALUES(@kedes, @stalai, @sofos, @suma)";
        comm.Parameters.AddWithValue("@kedes", chair);
        comm.Parameters.AddWithValue("@stalai", table);
        comm.Parameters.AddWithValue("@sofos", sofa);
        comm.Parameters.AddWithValue("@suma", totalsum);
        comm.ExecuteNonQuery();
    }

    public static DataTable getOrderTable()
    {
        using (MySqlConnection con = MySqlService.getConnection())
        {
            try
            {
                con.Open();

                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT * from uzsakymai";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, con);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to connect to MySql");
                return new DataTable();
            }

        }
    }
}