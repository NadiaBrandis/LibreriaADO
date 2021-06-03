using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibreriaADO
{
    class DbManagerDisconnectedMode
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = Libreria;" + "integrated Security=true;";
        public static List<AudioLibri> GetAudioLibri()
        {

            List<AudioLibri> LibriA = new List<AudioLibri>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "select * from dbo.AudioLibri ";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "AudioLibri");
                foreach (DataRow row in dataset.Tables["AudioLibri"].Rows)
                {
                    var titolo = row["Titolo"];
                    var autore = row["Autore"];
                    var durata = row["Durata"];
                    var isbn = row["ISBN"];
                    AudioLibri Audio = new AudioLibri((string)titolo, (string)autore, (string)isbn, (int)durata);
                    LibriA.Add(Audio);
                    Console.WriteLine($"{titolo}, {autore}");
                }

                connection.Close();
            }
            return LibriA;
        }
        public static List<LibriCartacei> GetLibriCartacei()
        {
            List<LibriCartacei> LibriC = new List<LibriCartacei>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "select * from dbo.LibriCartacei ";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "LibriCartacei");
                foreach (DataRow row in dataset.Tables["LibriCartacei"].Rows)
                {
                    var titolo = row["Titolo"];
                    var autore = row["Autore"];
                    var numeroPagine = row["NumeroPagine"];
                    var quantita = row["Quantita"];
                    var isbn = row["ISBN"];
                    LibriCartacei libro = new LibriCartacei((string)titolo, (string)autore, (string)isbn, (int)numeroPagine, (int)quantita);
                    LibriC.Add(libro);

                    Console.WriteLine($"{titolo}, {autore}");
                }

                connection.Close();
            }
            return LibriC;
        }
        public static void GetTuttiLibri()
        {
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "select * from dbo.LibriCartacei ";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "LibriCartacei");
                    foreach (DataRow row in dataset.Tables["LibriCartacei"].Rows)
                    {
                        var titolo = row["Titolo"];
                        var autore = row["Autore"];
                        var numeroPagine = row["NumeroPagine"];
                        var quantita = row["Quantita"];
                        var isbn = row["ISBN"];



                        Console.WriteLine($"{titolo}, {autore}----LIBRO CARTACEO");
                    }


                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "select * from dbo.AudioLibri ";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "AudioLibri");
                    foreach (DataRow row in dataset.Tables["AudioLibri"].Rows)
                    {
                        var titolo = row["Titolo"];
                        var autore = row["Autore"];
                        var durata = row["Durata"];
                        var isbn = row["ISBN"];

                        Console.WriteLine($"{titolo}, {autore}----AUDIOLIBRO");
                    }

                    connection.Close();
                }

            }
        }
        public static void InserisciNuovoLibroCartaceo(string t, string a, int n, int q, string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand Selectcommand = new SqlCommand();
                Selectcommand.Connection = connection;
                Selectcommand.CommandType = System.Data.CommandType.Text;

                Selectcommand.CommandText = "insert into dbo.LibriCartacei values (@Titolo, @Autore, @Numeropagine,@Quantita,@ISBN)";
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;

                insertCommand.CommandText = "insert into dbo.LibriCartacei values (@Titolo, @Autore, @Numeropagine,@Quantita,@ISBN)";
                insertCommand.Parameters.AddWithValue("@Titolo", t);
                insertCommand.Parameters.AddWithValue("@Autore", a);
                insertCommand.Parameters.AddWithValue("@NumeroPagine", n);
                insertCommand.Parameters.AddWithValue("@Quantita", q);
                insertCommand.Parameters.AddWithValue("@ISBN", isbn);

                DataSet dataSet = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = Selectcommand;
                adapter.Fill(dataSet, "LibriCartacei");

                DataRow dt = dataSet.Tables["LibriCartacei"].NewRow();
                dt["Titolo"] = t;
                dt["Autore"] = a;
                dt["NumeroPagine"] = n;
                dt["Quantita"] = q;
                dt["ISBN"] = isbn;
                dataSet.Tables["LibriCartacei"].Rows.Add(dt);
                adapter.Update(dataSet, "LibriCartacei");

                connection.Close();
            }
        }
        public static void InserisciAudioLibro(string t, string a, int n, string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand Selectcommand = new SqlCommand();
                Selectcommand.Connection = connection;
                Selectcommand.CommandType = System.Data.CommandType.Text;

                Selectcommand.CommandText = "insert into dbo.AudioLibri values (@Titolo, @Autore, @Durata,@ISBN)";
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;

                insertCommand.CommandText = "insert into dbo.AudioLibri values (@Titolo, @Autore, @Durata,@ISBN)";
                insertCommand.Parameters.AddWithValue("@Titolo", t);
                insertCommand.Parameters.AddWithValue("@Autore", a);
                insertCommand.Parameters.AddWithValue("@Durata", n);

                insertCommand.Parameters.AddWithValue("@ISBN", isbn);

                DataSet dataSet = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = Selectcommand;
                adapter.Fill(dataSet, "AudioLibri");

                DataRow dt = dataSet.Tables["AudioLibri"].NewRow();
                dt["Titolo"] = t;
                dt["Autore"] = a;
                dt["Dutara"] = n;

                dt["ISBN"] = isbn;
                dataSet.Tables["AudioLibri"].Rows.Add(dt);
                adapter.Update(dataSet, "AudioLibri");

                connection.Close();
            }
        }
        public static void ModificaQuantitaLibri(int quantita, string titolo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand Selectcommand = new SqlCommand();
                Selectcommand.Connection = connection;
                Selectcommand.CommandType = System.Data.CommandType.Text;

                Selectcommand.CommandText = "select * from dbo.LibriCartaci";
                SqlCommand updateCommand = new SqlCommand();
                updateCommand.Connection = connection;
                updateCommand.CommandType = System.Data.CommandType.Text;

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;

                insertCommand.CommandText = "update dbo.LibriCartaci set Quantita = @Quantita where Titolo = @Titolo";
                insertCommand.Parameters.Add("@Titolo", System.Data.SqlDbType.NVarChar,50,"Titolo");
                insertCommand.Parameters.Add("@Quantita",System.Data.SqlDbType.Int,30,"Quantita");

                DataSet dataSet = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = Selectcommand;
                adapter.UpdateCommand = updateCommand;
                adapter.Fill(dataSet, "LibriCartacei");
                int count=0;
                DataTable dt = dataSet.Tables["LibriCartacei"];

                foreach (DataRow dr in dt.Rows)
                {
                    if(Convert.ToString(dr["Titolo"])==titolo)
                    {
                        break;
                    }
                    count++;
                }
                dt.Rows[count]["Quantita"] = quantita;
                adapter.Update(dataSet, "LibriCartacei");

                connection.Close();
            }
        }

    }
}
