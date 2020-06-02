using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Employment_agency
{
    class WorkWithAdminData
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Employment_agency.Properties.Settings.employment_agencyConnectionString"].ConnectionString);
        public SqlDataAdapter adapter;
        public SqlCommand cmd;

        // функция для открытия соединения
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // функция для закрытия соединения
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // функция для возвращения соединения
        public SqlConnection getConnection()
        {
            return connection;
        }

        // показ всех соискателей
        public void displayApplicantsData(DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Id_Applicant, Applicant.LastName AS Фамилия, Applicant.FirstName AS Имя, Applicant.Middlename AS Отчество, " +
                "Applicant.DateOfBirth AS Дата_рождения, Applicant.PhoneNumber AS Телефон, Applicant.Email as Email, Applicant.Adress AS Адрес, " +
                "Gender.Pol AS Пол, Nationality.Nationality AS Гражданство " +
                "FROM Applicant " +
                "JOIN Gender " +
                "ON Applicant.Id_Pol = Gender.Id_Pol " +
                "JOIN Nationality " +
                "ON Applicant.Id_Nation = Nationality.Id_Nation ";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // показ всех работодателей
        public void displayEmployerData(DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Employers.Id_Employer, Employers.email AS Email_работодателя, UniqueKeys.Registration_key AS Инициализирующий_ключ, UniqueKeys.Company AS Компания " +
                  "FROM Employers " +
                  "JOIN UniqueKeys " +
                  "ON Employers.Id_Key = UniqueKeys.Id_Key " +
                  "WHERE Company != 'Employment_agency'";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // показ соискателя по email
        public void displayApplicantsDataOnEmail(string Email, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Id_Applicant, Applicant.LastName AS Фамилия, Applicant.FirstName AS Имя, Applicant.Middlename AS Отчество, " +
                "Applicant.DateOfBirth AS Дата_рождения, Applicant.PhoneNumber AS Телефон, Applicant.Email as Email, Applicant.Adress AS Адрес, " +
                "Gender.Pol AS Пол, Nationality.Nationality AS Гражданство " +
                "FROM Applicant " +
                "JOIN Gender " +
                "ON Applicant.Id_Pol = Gender.Id_Pol " +
                "JOIN Nationality " +
                "ON Applicant.Id_Nation = Nationality.Id_Nation " +
                "WHERE Applicant.Email = @Email";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            sql.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // показ работодателя по email
        public void displayEmployerDataOnEmail(string Email, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Employers.Id_Employer, Employers.email AS Email_работодателя, UniqueKeys.Registration_key AS Инициализирующий_ключ, UniqueKeys.Company AS Компания " +
                  "FROM Employers " +
                  "JOIN UniqueKeys " +
                  "ON Employers.Id_Key = UniqueKeys.Id_Key " +
                  "WHERE Company != 'Employment_agency' AND email = @Email";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            sql.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция удаления соискателя
        public void deleteApplicant(int Id_Applicant)
        {
            cmd = new SqlCommand("DELETE Applicant WHERE Id_Applicant = @Id_Applicant", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления аккаунта соискателя
        public void deleteApplicantAccount(int Id_Applicant)
        {
            cmd = new SqlCommand("DELETE Client WHERE Id_Applicant = @Id_Applicant", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления выбранных вакансий удалённым соискателем
        public void deleteSummaryApplicant(int Id_Applicant)
        {
            cmd = new SqlCommand("DELETE FROM Summary WHERE Id_Applicant = SOME (SELECT Id_Applicant FROM Applicant WHERE Id_Applicant = @Id_Applicant)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления аккаунта работодателя
        public void deleteEmployerAccount (int Id_Employer)
        {
            cmd = new SqlCommand("DELETE Employers WHERE Id_Employer = @Id_Employer", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Employer", Id_Employer);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления вакансий данного работодателя
        public void deleteVacancy(int Id_Employer)
        {
            cmd = new SqlCommand("DELETE Jobs WHERE Id_Employer = @Id_Employer", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Employer", Id_Employer);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления выбранных вакансий соискателями по удалённому работодателю
        public void deleteSummaryEmployer(int Id_Employer)
        {
            cmd = new SqlCommand("DELETE FROM Summary WHERE Id_Job = SOME (SELECT Id_Job FROM Jobs WHERE Id_Employer = @Id_Employer)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Employer", Id_Employer);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция для нахождения id универсального ключа
        public int findIdKey(int Id_Employer)
        {
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Key FROM Employers WHERE Id_Employer = @Id_Employer";
            sql.Parameters.Add("@Id_Employer", SqlDbType.Int).Value = Id_Employer;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Id_Key"].ToString();
            }
            thisReader.Close();
            connection.Close();
            int id = int.Parse(text);
            return id;
        }

        // функция удаления универсального ключа
        public void deleteEmployerKey(int Id_Key)
        {
            cmd = new SqlCommand("DELETE FROM UniqueKeys WHERE Id_Key = @Id_Key", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Key", Id_Key);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция добавления универсального ключа
        public bool registrationKey(string Registration_key, string Company)
        {
            cmd = new SqlCommand("INSERT INTO UniqueKeys (Registration_key, Company) VALUES (@Registration_key, @Company)", connection);
            cmd.Parameters.Add("@Registration_key", SqlDbType.VarChar).Value = Registration_key;
            cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
            connection.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            connection.Close();
        }
    }
}
