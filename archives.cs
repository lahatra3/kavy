using System.Data.SqlClient;

class Archives {
    public Archives() {}

    public List<Dictionary<string, object>> findall() {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT a.id as id, a.titre as titre, a.description as description, a.liste_id as liste_id, l.nom as nom_liste" +
            "FROM archives a JOIN listes l ON a.liste_id = l.id";
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

    public Dictionary<string, object> findone(int archive_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT a.id as id, a.titre as titre, a.description as description, a.liste_id as liste_id, l.nom as nom_liste" +
            "FROM archives a JOIN listes l ON a.liste_id = l.id" +
            "WHERE id = @ArchiveId";
        Dictionary<string, object> resultat = new Dictionary<string, object>();

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ArchiveId", archive_id);
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

    public List<Dictionary<string, object>> findByListeId(int liste_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT a.id as id, a.titre as titre, a.description as description, a.liste_id as liste_id, l.nom as nom_liste" +
            "FROM archives a JOIN listes l ON a.liste_id = l.id" +
            "WHERE id = @ListeId";
        List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ListeId", liste_id);
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

    public List<Dictionary<string, object>> filtreArchive(string search) {
        SqlConnection connection =  Database.db_connection();
        string query = "SELECT a.id as id, a.titre as titre, a.description as description, a.liste_id as liste_id, l.nom as nom_liste" +
            "FROM archives a JOIN listes l ON a.liste_id = l.id" +
            "WHERE titre LIKE %@Search% OR description LIKE %@Search%";
        List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Search", search);
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

    public void update(string titre, string description, int archive_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "UPDATE archives SET titre = @Titre, description = @Description WHERE id = @ArchiveId";

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Titre", titre);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@ArchiveId", archive_id);
            command.ExecuteNonQuery();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }
    }

    public void delete(int archive_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "DELETE FROM archives WHERE id = @ArchiveId";

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ArchiveId", archive_id);
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
