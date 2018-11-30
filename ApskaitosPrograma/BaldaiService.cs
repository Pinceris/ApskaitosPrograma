using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class BaldaiService
{
    
    public static List<Baldas> getBaldai()
    {
        List<Baldas> bSarasas = new List<Baldas>();

        string q = "select Pavadinimas, Kaina, Laikas from baldai";

        using (MySqlConnection con = MySqlService.getConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand(q, con))
            {
                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ws = new Baldas("", 0, 0);
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
    public static void insertOrder(int chair, int table, int sofa, int totalsum)
    {
        MySqlConnection con = MySqlService.getConnection();
        con.Open();
        MySqlCommand comm = con.CreateCommand();
        comm.CommandText = "INSERT INTO uzsakymai(kedes,stalai,sofos,suma) VALUES(@kedes, @stalai, @sofos, @suma)";
        comm.Parameters.AddWithValue("@kedes", chair);
        comm.Parameters.AddWithValue("@stalai", table);
        comm.Parameters.AddWithValue("@sofos", sofa);
        comm.Parameters.AddWithValue("@suma", totalsum);
        comm.ExecuteNonQuery();
        con.Close();
    }
}