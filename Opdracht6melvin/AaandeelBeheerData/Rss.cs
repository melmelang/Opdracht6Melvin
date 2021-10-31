using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AaandeelBeheerData
{
    public class Rss
    {
        private string connectionString = @"Data Source=(LocalDB)\v11.0;  
			 AttachDbFilename=|DataDirectory|\AandelenBeheer.mdf; 
			 Integrated Security=True;   Connect Timeout=30";


        private SqlConnection GetDbConnectie()
        {

            return new SqlConnection(connectionString);

        }

        public void Bewaar(string titel, string auteur, string inhoud, string link, DateTime publicatieTijd)
        {

            string insertSqlText = "INSERT INTO Rss(titel, auteur, inhoud, link, publicatieTijd)     VALUES(@titel,  @auteur,  @inhoud,  @link, @publicatietijd)";
            SqlCommand insertSql = new SqlCommand(insertSqlText);
            insertSql.Connection = GetDbConnectie();
            insertSql.Parameters.Add(new SqlParameter("@titel", titel));
            insertSql.Parameters.Add(new SqlParameter("@auteur", auteur));
            insertSql.Parameters.Add(new SqlParameter("@inhoud", inhoud));
            insertSql.Parameters.Add(new SqlParameter("@link", link));
            insertSql.Parameters.Add(new SqlParameter("@publicatietijd", publicatieTijd));

            try
            {
                insertSql.Connection.Open(); insertSql.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Bewaar Rss mislukt." + ex.Message);
            }

            finally
            {
                if (insertSql.Connection.State == ConnectionState.Open)
                {
                    insertSql.Connection.Close();
                }
            }
        }
    }
}
