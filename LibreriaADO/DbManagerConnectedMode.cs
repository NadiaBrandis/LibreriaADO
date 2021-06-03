using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibreriaADO
{
    class DbManagerConnectedMode
    {
        public List<LibriCartacei> TuttiLibriCartacei =DbManagerConnectedMode.GetLibriCartacei();
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                         "Initial Catalog = Libreria;" + "integrated Security=true;";

        public static List<LibriCartacei> GetLibriCartacei()
        {
            List<LibriCartacei> LibriC = new List<LibriCartacei>();
            

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            // Associo la connessione
            command.Connection = connection;
            // Definisco il tipo del comando
            command.CommandType = System.Data.CommandType.Text;
            // comando
            command.CommandText = "select * from dbo.LibriCartacei";
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var id = reader[0];
                var titolo = reader[1];
                var autore = reader[2];
                var numeroPagine = reader[3];
                var quantita = reader[4];
                var isbn = reader[5];
                LibriCartacei libro = new LibriCartacei((string)titolo,(string) autore, (string)isbn,(int) numeroPagine, (int)quantita);
                LibriC.Add(libro);
                
                Console.WriteLine($"{id} - Titolo: {titolo}, Autore: {autore}, NUmero di Pagine: {numeroPagine}, Quantità in magazzino: {quantita}, Codice: {isbn}");
                

            }
            connection.Close();
            return LibriC;
        }

        public static List<AudioLibri> GetAudiolibri()
        {
            List<AudioLibri> LibriA = new List<AudioLibri>();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            // Associo la connessione
            command.Connection = connection;
            // Definisco il tipo del comando
            command.CommandType = System.Data.CommandType.Text;
            // comando
            command.CommandText = "select * from dbo.AudioLibri ";

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var id = reader[0];
                var titolo = reader[1];
                var autore = reader[2];
                var durata = reader[3];

                var isbn = reader[4];
                AudioLibri Audio= new AudioLibri((string)titolo, (string)autore, (string)isbn,(int)durata);
                LibriA.Add(Audio);
                

                Console.WriteLine($"{id} - Titolo: {titolo}, Autore: {autore}, Durata: {durata},Codice: {isbn}");


            }

            connection.Close();
            return LibriA;
        }

        public static void GetTuttiLibri()
        {
            {
                SqlConnection connection1 = new SqlConnection(connectionString);
                connection1.Open();

                SqlCommand command1 = new SqlCommand();
                // Associo la connessione
                command1.Connection = connection1;
                // Definisco il tipo del comando
                command1.CommandType = System.Data.CommandType.Text;
                // comando
                command1.CommandText = "select * from dbo.LibriCartacei";
               

                SqlDataReader reader1 = command1.ExecuteReader();
              
                while (reader1.Read())
                {
                    var titolo = reader1[1];
                    var autore = reader1[2];
                    Console.WriteLine($"Titolo: {titolo}, Autore: {autore} ---Libro Cartaceo");



                }

               
                connection1.Close();
            }
            {
                SqlConnection connection2 = new SqlConnection(connectionString);
                connection2.Open();

                SqlCommand command2 = new SqlCommand();
                // Associo la connessione
                command2.Connection = connection2;
                // Definisco il tipo del comando
                command2.CommandType = System.Data.CommandType.Text;
                // comando
                command2.CommandText = "select * from dbo.AudioLibri";
              
                SqlDataReader reader2 = command2.ExecuteReader();
              
                while (reader2.Read())
                {
                    var titolo = reader2[1];
                    var autore = reader2[2];
                    Console.WriteLine($"Titolo: {titolo}, Autore: {autore} ---Audiolibro");


                }

                connection2.Close();
            }
        }

       public static void VisualizzaLibro(string tit)
        {
            {
                SqlConnection connection1 = new SqlConnection(connectionString);
                connection1.Open();

                SqlCommand command1 = new SqlCommand();
                // Associo la connessione
                command1.Connection = connection1;
                // Definisco il tipo del comando
                command1.CommandType = System.Data.CommandType.Text;
                // comando
                command1.CommandText = "select * from dbo.LibriCartacei where Titolo=@Titolo";
                command1.Parameters.AddWithValue("@Titolo", tit);

                SqlDataReader reader1 = command1.ExecuteReader();
               
                while (reader1.Read())
                {
                    var titolo = reader1[1];
                    var autore = reader1[2];
                    Console.WriteLine($"Titolo: {titolo}, Autore: {autore} ---Libro Cartaceo");







                }

                connection1.Close();
            }
            {
                SqlConnection connection2 = new SqlConnection(connectionString);
                connection2.Open();

                SqlCommand command2 = new SqlCommand();
                // Associo la connessione
                command2.Connection = connection2;
                // Definisco il tipo del comando
                command2.CommandType = System.Data.CommandType.Text;
                // comando
                command2.CommandText = "select * from dbo.AudioLibri where Titolo=@Titolo";
                command2.Parameters.AddWithValue("@Titolo", tit);

                SqlDataReader reader2 = command2.ExecuteReader();
                
                while (reader2.Read())
                {
                    var titolo = reader2[1];
                    var autore = reader2[2];
                    Console.WriteLine($"Titolo: {titolo}, Autore: {autore} ---Audiolibro");







                }

              


                connection2.Close();
            }
        }

        public static void InserisciAudioLibro(string t, string a, int n, string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // !!!!
                SqlCommand command = new SqlCommand();
                // Associo la connection
                command.Connection = connection;
                // Definisco il tipo dell'input
                command.CommandType = System.Data.CommandType.Text;



                command.CommandText = "insert into dbo.LibriCartacei values (@Titolo, @Autore, @Durata,@ISBN)";
                command.Parameters.AddWithValue("@Titolo", t);
                command.Parameters.AddWithValue("@Autore", a);
                command.Parameters.AddWithValue("@Durata", n);
               
                command.Parameters.AddWithValue("@ISBN", isbn);
              
                command.ExecuteNonQuery();




                connection.Close();
            }
        }

        public static void InserisciLibroCartaceo(string t,string a,int n,int q,string isbn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // !!!!
                SqlCommand command = new SqlCommand();
                // Associo la connection
                command.Connection = connection;
                // Definisco il tipo dell'input
                command.CommandType = System.Data.CommandType.Text;

              

                command.CommandText = "insert into dbo.LibriCartacei values (@Titolo, @Autore, @NumeroPagine,@Quantita,@ISBN)";
                command.Parameters.AddWithValue("@Titolo", t);
                command.Parameters.AddWithValue("@Autore", a);
                command.Parameters.AddWithValue("@NumeroPagine", n);
                command.Parameters.AddWithValue("@Quantita", q);
                command.Parameters.AddWithValue("@ISBN", isbn);
                //
                command.ExecuteNonQuery();
              



                connection.Close();
            }
        }

       

        public static void ModificaMinuti(string t, int minuti)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                // Associo la connection
                command.Connection = connection;
                // Definisco il tipo dell'input
                command.CommandType = System.Data.CommandType.Text;


                //update LibriCartacei set Quantita=7 where Titolo='I promessi sposi'
                command.CommandText = "update dbo.AudioLibri  set Durata = @Durata where Titolo = @Titolo";
                command.Parameters.AddWithValue("@Titolo", t);
                command.Parameters.AddWithValue("@Quantita", minuti);


                command.ExecuteNonQuery();
                //command.Dispose();
                connection.Close();
            }
        }

        public static void ModificaQuantita(string titolo,int quantita)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                SqlCommand command = new SqlCommand();
                // Associo la connection
                command.Connection = connection;
                // Definisco il tipo dell'input
                command.CommandType = System.Data.CommandType.Text;


                //update LibriCartacei set Quantita=7 where Titolo='I promessi sposi'
                command.CommandText = "update dbo.LibriCartaci set Quantita = @Quantita where Titolo = @Titolo";
                command.Parameters.AddWithValue("@Titolo", titolo);
                command.Parameters.AddWithValue("@Quantita", quantita);


                command.ExecuteNonQuery();
                //command.Dispose();
                connection.Close(); 
            }
        }
    }


        

    
}

