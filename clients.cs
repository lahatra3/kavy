using System.Data.SqlClient;

class Clients {
    public Clients() {}

    public List<Dictionary<string, object>> findall() {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT * FROM clients";
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

    public Dictionary<string, object> findone(int client_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT * FROM clients WHERE id = @ClientId";
        Dictionary<string, object> resultat = new Dictionary<string, object>();

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", client_id);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) {
                resultat.Add(reader.GetName(reader.FieldCount - 1), reader.GetValue(reader.FieldCount - 1));
            }

            reader.Close();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }

        return resultat;
    }

    public void update(string nom, int client_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "UPDATE clients SET nom = @Nom WHERE id = @ClientId";

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nom", nom);
            command.Parameters.AddWithValue("@ClientId", client_id);
            command.ExecuteNonQuery();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }
    }

    public void delete(int client_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "DELETE FROM clients WHERE id = @ClientId";

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", client_id);
            command.ExecuteNonQuery();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }
    }
}
