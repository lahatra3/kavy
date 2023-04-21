using System.Data.SqlClient;

class Listes {
    public Listes() {}

    public List<Dictionary<string, object>> findall() {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT * FROM listes";
        List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for(int i = 0; i < reader.FieldCount; i++) {
                    row.Add(reader.GetName(i), reader.GetValue(i));
                }
                results.Add(row);
            }
            reader.Close();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }

        return results;
    }
}
