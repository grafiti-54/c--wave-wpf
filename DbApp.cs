using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WaveWpf.Models;
using System.Data.SQLite;

namespace WaveWpf
{
    public class DbApp
    {
        // ----------------------------    BASE DE DONNES ---------------------------------

        /// <summary>
        /// Fonction de connection à la base de données.
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection()
        {
            string connectionString = "Data Source=wave.db;";
            SQLiteConnection con = new SQLiteConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("SQLite Connection! \n" + ex.Message, "Erreur");
            }
            return con;
        }

        /// <summary>
        /// Création de la base de donnée si celle si n'existe pas dans le projet.
        /// </summary>
        
        /*
        public static void Create_db()
        {
            string path = "wave.db";
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = GetConnection())
                //using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE " +
                        "Users(id_user INTEGER PRIMARY KEY AUTOINCREMENT," +
                            "email VARCHAR(250),password VARCHAR(30),role BOOLEAN);" +
                        "\r\nCREATE TABLE Groupes(id_groupe INTEGER PRIMARY KEY AUTOINCREMENT,name VARCHAR(150),address VARCHAR(150),phone VARCHAR(15),id_user INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user));" +
                        "\r\nCREATE TABLE Concerts(id_concert INTEGER PRIMARY KEY AUTOINCREMENT,jour DATETIME,address VARCHAR(150),id_user INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user));" +
                        "\r\nCREATE TABLE Oeuvres(id_oeuvre INTEGER PRIMARY KEY AUTOINCREMENT,title VARCHAR(50),duration VARCHAR(50),id_user INTEGER NOT NULL,id_groupe INTEGER NOT NULL,FOREIGN KEY(id_user) REFERENCES Users(id_user),FOREIGN KEY(id_groupe) REFERENCES Groupes(id_groupe));" +
                        "\r\nCREATE TABLE Participe(id_groupe INTEGER,id_concert INTEGER,PRIMARY KEY(id_groupe, id_concert),FOREIGN KEY(id_groupe) REFERENCES Groupes(id_groupe),FOREIGN KEY(id_concert) REFERENCES Concerts(id_concert));\r\nCREATE TABLE Reserve(id_user INTEGER,id_concert INTEGER,name VARCHAR(150),firstname VARCHAR(150),phone VARCHAR(50),PRIMARY KEY(id_user, id_concert),FOREIGN KEY(id_user) REFERENCES Users(id_user),FOREIGN KEY(id_concert) REFERENCES Concerts(id_concert));";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("La base de données n'as pas pu etre crée");
                return;
            }
        }*/


        // ---------------------------    USERS    -----------------------------------

        /// <summary>
        /// Inscription d'un utilisateur dans le formulaire d'inscription
        /// </summary>
        /// <param name="user"></param>
        public static void RegisterUser(UserModel user)
        {

            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO Users(id_user,Email,Password,Role) VALUES (NULL, @Email, @Password, false)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Email", DbType.String).Value = user.Email;
            // Hash the password using BCrypt.Net-Next
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            cmd.Parameters.Add("@Password", DbType.String).Value = hashedPassword;

            if (IsEmailAlreadyRegistered(user.Email))
            {
                MessageBox.Show("Cette adresse email est déjà enregistrée.", "Erreur");
                return;
            }

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vous pouvez vous connecter. \n", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'inscription. \n" + ex.Message, "Erreur");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Connexion d'un utilisateur dans le formulaire de connexion.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool LoginUser(UserModel user)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT password, role FROM users WHERE email = @email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@email", user.Email);

            string hashedPassword = string.Empty;

            try
            {
                // Retrieve the hashed password from the database
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashedPassword = reader.GetString(0);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Erreur lors de la modification de l'utilisateur: " + ex.Message);
                con.Close();
                MessageBox.Show("Une erreur s'est produite lors de la tentative de connexion. Veuillez réessayer plus tard.", "Erreur de connexion");
                return false;
            }

            // Verify the password using BCrypt.Net-Next
            //bool passwordMatch = BCrypt.Net.BCrypt.Verify(user.Password, hashedPassword);
            bool passwordMatch = false;
            try
            {
                // Verify the password using BCrypt.Net-Next
                passwordMatch = BCrypt.Net.BCrypt.Verify(user.Password, hashedPassword);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Erreur lors de la vérification du mot de passe: " + ex.Message);
                // Afficher une message box pour l'utilisateur
                MessageBox.Show("Identifiants incorrects: " , "Erreur");
            }

            con.Close();

            if (!passwordMatch)
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect. Veuillez réessayer.", "Erreur de connexion");
            }

            return passwordMatch;
        }


        /*
        public static bool LoginUser(UserModel user)
        {

            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT password, role FROM users WHERE email = @email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@email", user.Email);

            string hashedPassword = string.Empty;

            try
            {
                // Retrieve the hashed password from the database
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        hashedPassword = reader.GetString(0);
                    }
                }
                /*
                // Retrieve the hashed password from the database
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashedPassword = reader.GetString(0);
                    }
                }
                
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Erreur lors de la modification de l'utilisateur: " + ex.Message);
                con.Close();
                return false;
            }

            // Verify the password using BCrypt.Net-Next
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(user.Password, hashedPassword);

            con.Close();
            return passwordMatch;
        }

        */

        /// <summary>
        /// Modification du role d'un utilisateur.
        /// </summary>
        /// <param name="user"></param>
        public static void UpdateUser(UserModel user)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE Users Set role=@Role where email=@Email";
                cmd.Prepare();
                cmd.Parameters.Add("@Email", DbType.String).Value = user.Email;
                cmd.Parameters.Add("@Role", DbType.Boolean).Value = user.Role ? user.Role : false;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification de l'utilisateur: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }

        }

        /// <summary>
        /// Suppression d'un utilisateur.
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUser(UserModel user)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "DELETE FROM users WHERE email =@Email";
                cmd.Prepare();
                cmd.Parameters.Add("@Email", DbType.String).Value = user.Email;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression de l'utilisateur: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }


        }

        /// <summary>
        /// //Vérification si l'utilisateur existe en base de données avant de le connecter
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UserExists(UserModel user)
        {
            string sql = "SELECT COUNT(*), role FROM users WHERE email = @email AND password = @password";
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@email", DbType.String).Value = user.Email;
            cmd.Parameters.Add("@password", DbType.String).Value = user.Password;

            try
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Erreur lors de la vérification de l'utilisateur. \n" + ex.Message, "Erreur");

                //MessageBox.Show("Erreur lors de la vérification de l'utilisateur. \n" + ex.Message, "Erreur",
                //MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Vérification avant inscription si l'user n'as pas un compte avec son adresse email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmailAlreadyRegistered(string email)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Email", DbType.String).Value = email;

            try
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification de l'email. \n" + ex.Message, "Erreur");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération du role de l'user qui se connecte pour le socker dans la session.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool GetUserRole(string email)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT Role FROM Users WHERE Email = @Email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Email", DbType.String).Value = email;

            try
            {
                bool isAdmin = Convert.ToBoolean(cmd.ExecuteScalar());
                return isAdmin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération du rôle de l'utilisateur. \n" + ex.Message, "Erreur");
                return false;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération de l'id de l'utilisateur qui se connecte pur le stocker dans la session
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int GetUserId(string email)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT id_user FROM Users WHERE Email = @Email";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Email", DbType.String).Value = email;

            try
            {
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return -1; // Utilisateur non trouvé
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération de l'ID utilisateur. \n" + ex.Message, "Erreur");
                return -1;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération du nombre d'utilisateurs inscrit sur l'app.
        /// </summary>
        public static void GetUsersCount()
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) as total_users FROM Users";

            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                //Console.WriteLine("Nombre total d'utilisateurs: " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du nombre total d'utilisateurs: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        // ---------------------------    GROUPES    -----------------------------------

        /// <summary>
        /// Récupération de la liste des groupes ajouté en base de données de l'app.
        /// </summary>
        /// <returns></returns>
        public static List<GroupeModel> GetAllGroupe()
        {
            List<GroupeModel> groupes = new List<GroupeModel>();
            SQLiteConnection con = null;
            try
            {
                con = GetConnection();
                SQLiteCommand cmd = new SQLiteCommand(con);
                cmd.CommandText = "SELECT * FROM Groupes";

                using (SQLiteDataReader reader = cmd.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        GroupeModel groupe = new GroupeModel();
                        groupe.Id = Convert.ToInt32(reader["id_groupe"]); // correspond au champs de la table en bdd sinon erreur.
                        groupe.Name = Convert.ToString(reader["name"]);
                        groupe.Address = Convert.ToString(reader["address"]);
                        groupe.Phone = Convert.ToString(reader["phone"]);
                        groupe.UserId = Convert.ToInt32(reader["id_user"]);
                        groupes.Add(groupe);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'erreur ici
                Console.WriteLine("Erreur lors de la récupération des groupes : " + ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return groupes;
        }

        /// <summary>
        /// Création d'un nouveau groupe dans la base de données de l'app.
        /// </summary>
        /// <param name="groupe"></param>
        public static void AddGroupe(GroupeModel groupe)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO Groupes(id_groupe,name,address,phone,id_user)" +
                " VALUES (NULL, @Name, @Address, @Phone, @IdAdmin)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Name", DbType.String).Value = groupe.Name;
                cmd.Parameters.Add("@Address", DbType.String).Value = groupe.Address;
                cmd.Parameters.Add("@Phone", DbType.String).Value = groupe.Phone;
                cmd.Parameters.Add("@IdAdmin", DbType.Int64).Value = groupe.UserId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du groupe: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Mise à jour jour d'un groupe. 
        /// </summary>
        /// <param name="groupe"></param>
        public static void UpdateGroupe(GroupeModel groupe)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "UPDATE Groupes Set Name = @Name, Address = @Address, Phone = @Phone, id_user = @IdUser where id_groupe = @Id";
                cmd.Prepare();
                cmd.Parameters.Add("@Name", DbType.String).Value = groupe.Name;
                cmd.Parameters.Add("@Address", DbType.String).Value = groupe.Address;
                cmd.Parameters.Add("@Phone", DbType.String).Value = groupe.Phone;
                cmd.Parameters.Add("@IdUser", DbType.Int16).Value = groupe.UserId;
                cmd.Parameters.Add("@Id", DbType.String).Value = groupe.Id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la mise à jour du groupe: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Suppression d'un groupe dans la base de données.
        /// </summary>
        /// <param name="groupe"></param>
        public static void DeleteGroupe(GroupeModel groupe)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "DELETE FROM groupes WHERE name =@Name";
                cmd.Prepare();
                cmd.Parameters.Add("@Name", DbType.String).Value = groupe.Name;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du groupe : " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération du nombre de groupes enregistré sur la bdd de l'app.
        /// </summary>
        public static void GetGroupesCount()
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) as total_groupes FROM Groupes";

            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du nombre total de groupe: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        // ---------------------------    OEUVRES    -----------------------------------

        /// <summary>
        /// Création d'une nouvelle oeuvre dans la base de données de l'app.
        /// </summary>
        /// <param name="oeuvre"></param>
        public static void AddOeuvre(OeuvreModel oeuvre)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO Oeuvres(id_oeuvre,title,duration,id_user,id_groupe) VALUES (NULL, @Title, @Duration, @IdUser, @IdGroupe)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Title", DbType.String).Value = oeuvre.Title;
                cmd.Parameters.Add("@Duration", DbType.String).Value = oeuvre.Duration;
                cmd.Parameters.Add("@IdUser", DbType.Int64).Value = oeuvre.UserId;
                cmd.Parameters.Add("@IdGroupe", DbType.Int32).Value = oeuvre.GroupeId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de l'oeuvre: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Modification d'une oeuvre dans la base de données de l'app.
        /// </summary>
        /// <param name="oeuvre"></param>
        public static void UpdateOeuvre(OeuvreModel oeuvre)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "UPDATE Oeuvres SET title = @Title, duration = @Duration, id_user = @IdUser, id_groupe = @IdGroupe WHERE id_oeuvre = @IdOeuvre";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Title", DbType.String).Value = oeuvre.Title;
                cmd.Parameters.Add("@Duration", DbType.String).Value = oeuvre.Duration;
                cmd.Parameters.Add("@IdUser", DbType.Int64).Value = oeuvre.UserId;
                cmd.Parameters.Add("@IdGroupe", DbType.Int32).Value = oeuvre.GroupeId;
                cmd.Parameters.Add("@IdOeuvre", DbType.Int32).Value = oeuvre.Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la mise à jour de l'oeuvre: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Suppression d'une oeuvre dans la base de données de l'app.
        /// </summary>
        /// <param name="oeuvre"></param>
        public static void DeleteOeuvre(OeuvreModel oeuvre)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "DELETE FROM oeuvres WHERE title =@Title";
                cmd.Prepare();
                cmd.Parameters.Add("@Title", DbType.String).Value = oeuvre.Title;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression de l'oeuvre : " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération du nombre d'oeuvres enregistré sur la bdd de l'app.
        /// </summary>
        public static void GetOeuvresCount()
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) as total_oeuvres FROM Oeuvres";

            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du nombre total d'oeuvres: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public static void GetOeuvreByGroupeId(GroupeModel groupe)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "SELECT title, duration FROM Oeuvres WHERE id_groupe = @idGroupe";
                cmd.Parameters.AddWithValue("@idGroupe", groupe.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération des oeuvres du groupe : " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }

        }


        // ---------------------------    CONCERTS    -----------------------------------

        /// <summary>
        /// Ajout d'un nouveau concert dans la bdd de l'app.
        /// </summary>
        /// <param name="concert"></param>
        public static void AddConcert(ConcertModel concert)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO Concerts(id_concert,jour,address,id_user) VALUES (NULL, @Jour, @Address, @IdUser)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Jour", DbType.String).Value = concert.Day.ToString();
                cmd.Parameters.Add("@Address", DbType.String).Value = concert.Address;
                cmd.Parameters.Add("@IdUser", DbType.Int64).Value = concert.UserId;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création du concert: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Modification d'un concert dans la base de données de l'app.
        /// </summary>
        /// <param name="oeuvre"></param>
        public static void UpdateConcertById(ConcertModel concert)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "UPDATE concerts SET jour = @Jour, address = @Address, id_user = @IdUser WHERE id_concert = @IdConcert";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Jour", DbType.String).Value = concert.Day;
                cmd.Parameters.Add("@Address", DbType.String).Value = concert.Address;
                cmd.Parameters.Add("@IdUser", DbType.Int64).Value = concert.UserId;
                cmd.Parameters.Add("@IdConcert", DbType.Int64).Value = concert.Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la mise à jour du concert: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Suppression d'un concert dans la base de données de l'app.
        /// </summary>
        /// <param name="concert"></param>
        public static void DeleteConcertById(ConcertModel concert)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "DELETE FROM concerts WHERE id_concert = @Id";
                cmd.Prepare();
                cmd.Parameters.Add("@Id", DbType.String).Value = concert.Id.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression du concert : " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Requete de c=récupéaration des information d'un concert selon son id.
        /// </summary>
        /// <param name="concert"></param>
        public static void GetConcertById(ConcertModel concert)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "SELECT jour as day, address FROM concerts WHERE id_concert = @Id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@Id", concert.Id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    concert.Day = reader.GetString(0);
                    concert.Address = reader.GetString(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du concert : " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Récupération du nombre de concerts enregistrés sur la bdd de l'app.
        /// </summary>
        public static void GetConcertsCount()
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) as total_concert FROM Concerts";

            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la récupération du nombre total de concerts: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        // -------------------------     PARTICIPE     -------------------------------------
        /// <summary>
        /// Ajout d'un nouveau groupe dans un concert en bdd.
        /// </summary>
        /// <param name="participe"></param>
        public static void AddParticipation(ParticipeModel participe)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Vérifier si le groupe est deja inscrit au concert
            cmd.CommandText = "SELECT COUNT(*) FROM Participe WHERE id_groupe = @GroupId AND id_concert = @ConcertId";
            cmd.Parameters.Add("@GroupId", DbType.Int32).Value = participe.IdGroupe;
            cmd.Parameters.Add("@ConcertId", DbType.Int32).Value = participe.IdConcert;
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                // Le groupe est deja inscrit au concert
                MessageBox.Show("Le groupe est déjà inscrit à ce concert.", "Erreur");
                return;
            }

            try
            {
                // Le groupe n'est pas inscrit au concert
                cmd.CommandText = "INSERT INTO Participe(id_groupe, id_concert) VALUES (@GroupId, @ConcertId)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@GroupId", DbType.Int32).Value = participe.IdGroupe;
                cmd.Parameters.Add("@ConcertId", DbType.Int32).Value = participe.IdConcert;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout de la participation: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        //-------------------------     RESERVATION     ------------------------------------
        /// <summary>
        /// Ajout d'un nouveau participant à un concert en bdd.
        /// </summary>
        /// <param name="reservation"></param>
        public static void AddReservation(ReservationModel reservation)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);


            // Vérifier si l'utilisateur est déjà inscrit au concert
            cmd.CommandText = "SELECT COUNT(*) FROM Reserve WHERE id_user = @UserId AND id_concert = @ConcertId";
            cmd.Parameters.Add("@UserId", DbType.Int32).Value = reservation.IdUser;
            cmd.Parameters.Add("@ConcertId", DbType.Int32).Value = reservation.IdConcert;
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                // L'utilisateur est déjà inscrit au concert
                MessageBox.Show("Vous etes déjà inscrit à ce concert.", "Erreur");
                return;
            }

            try
            {
                // L'utilisateur n'est pas encore inscrit au concert
                cmd.CommandText = "INSERT INTO Reserve(id_user, id_concert, name, firstname, phone) VALUES (@UserId, @ConcertId, @Name, @FirstName, @Phone)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@UserId", DbType.Int32).Value = reservation.IdUser;
                cmd.Parameters.Add("@ConcertId", DbType.Int32).Value = reservation.IdConcert;
                cmd.Parameters.Add("@Name", DbType.String).Value = reservation.Name;
                cmd.Parameters.Add("@FirstName", DbType.String).Value = reservation.FirstName;
                cmd.Parameters.Add("@Phone", DbType.String).Value = reservation.Phone;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout de la réservation: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        /// Requete qui retourne le nombre de participant à un concer
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public static int GetParticipation(ReservationModel reservation)
        {
            SQLiteConnection con = GetConnection();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT COUNT(*) FROM Reserve WHERE id_concert = @ConcertId";
            cmd.Parameters.Add("@ConcertId", DbType.Int32).Value = reservation.IdConcert;

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.Dispose();
            con.Close();

            return count;
        }
    }
}
