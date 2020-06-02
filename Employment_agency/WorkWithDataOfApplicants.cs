using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Employment_agency
{
    class WorkWithDataOfApplicants
    {
        // подключение к базе данных
        public SqlConnection connection = new SqlConnection (ConfigurationManager.ConnectionStrings ["Employment_agency.Properties.Settings.employment_agencyConnectionString"].ConnectionString);
        public SqlDataAdapter adapter;
        public SqlCommand cmd;
        public DataTable table;

        public WorkWithDataOfApplicants()
        {

        }

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

        // авторизация пользователя
        public bool userLogin(string loginUser, string passUser)
        {
            cmd = new SqlCommand("SELECT email, passwords FROM Client WHERE email = @loginUser AND passwords = @passUser", connection);
            openConnection();
            cmd.Parameters.Add("@loginUser", SqlDbType.VarChar).Value = loginUser;
            cmd.Parameters.Add("@passUser", SqlDbType.VarChar).Value = passUser;
            adapter = new SqlDataAdapter();
            table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            closeConnection();
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // проверка на совпадение пользователей в бд
        public bool isUserExists(string loginUser)
        {
            cmd = new SqlCommand("SELECT email, passwords FROM Client WHERE email = @loginUser", connection);
            openConnection();
            cmd.Parameters.Add("@loginUser", SqlDbType.VarChar).Value = loginUser;
            adapter = new SqlDataAdapter();
            table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            closeConnection();
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // регистрация пользователя
        public bool userRegistration(string email, string password, int Id_Applicant)
        {
            cmd = new SqlCommand("INSERT INTO Client (email, passwords, Id_Applicant) VALUES (@email, @password, @Id_Applicant)", connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
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

        // добавление данных пользователя
        public void addApplicants(string LastName, string FirstName, string Middlename, string DateOfBirth, string PhoneNumber, string email, string Adress,
            int Id_Pol, int Id_Nation)
        {
            cmd = new SqlCommand("INSERT INTO Applicant(LastName, FirstName, Middlename, DateOfBirth, PhoneNumber, Email, Adress, Id_Pol, Id_Nation) " +
                   "VALUES (@LastName, @FirstName, @Middlename, @DateOfBirth, @PhoneNumber, @Email, @Adress, @Id_Pol, @Id_Nation)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@Middlename", Middlename);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Adress", Adress);
            cmd.Parameters.AddWithValue("@Id_Pol", Id_Pol);
            cmd.Parameters.AddWithValue("@Id_Nation", Id_Nation);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция для поиска id соискателя
        public int findId(string Email)
        {
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Applicant FROM Applicant WHERE Email = @Email";
            sql.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Id_Applicant"].ToString();
            }
            thisReader.Close();
            connection.Close();
            int id = int.Parse(text);
            return id;
        }

        // функция для поиска имени пользователя 
        public string findName(int Id_Applicant)
        {
            string name = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT FirstName FROM Applicant WHERE Id_Applicant = @Id_Applicant";
            sql.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                name = thisReader["FirstName"].ToString();
            }
            thisReader.Close();
            connection.Close();
            return name;
        }

        // функция для поиска фамилии пользователя 
        public string findSurname(int Id_Applicant)
        {
            string surname = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT LastName FROM Applicant WHERE Id_Applicant = @Id_Applicant";
            sql.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                surname = thisReader["LastName"].ToString();
            }
            thisReader.Close();
            connection.Close();
            return surname;
        }

        // показ информации о пользователе
        public void DisplayClientData(int Id_Applicant, DataGridView dataGridView1)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Applicant.LastName AS Фамилия, Applicant.FirstName AS Имя, Applicant.Middlename AS Отчество, " +
                "Applicant.DateOfBirth AS Дата_рождения, Applicant.PhoneNumber AS Телефон, Client.Email as Email, Applicant.Adress AS Адрес, " +
                "Gender.Pol AS Пол, Nationality.Nationality AS Гражданство " +
                "FROM Applicant " +
                "JOIN Gender " +
                "ON Applicant.Id_Pol = Gender.Id_Pol " +
                "JOIN Nationality " +
                "ON Applicant.Id_Nation = Nationality.Id_Nation " +
                "JOIN Client " +
                "ON Applicant.Id_Applicant = Client.Id_Applicant " +
                "WHERE Applicant.Id_Applicant = @Id_Applicant";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
                adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        // изменение данных пользователя
        public void ChangeApplicant(int Id_Applicant, string LastName, string FirstName, string Middlename, string DateOfBirth,
            string PhoneNumber, string Email, string Adress, int Id_Pol, int Id_Nation, DataGridView dataGridView1)
        {
            if (LastName != "" && FirstName != "" && Middlename != "" && DateOfBirth != "" && PhoneNumber != "" && Email != "" && Adress != ""
                && Id_Pol != 0 && Id_Nation != 0)
            {
                cmd = new SqlCommand("UPDATE Applicant SET LastName=@LastName, FirstName=@FirstName, Middlename=@Middlename, DateOfBirth=@DateOfBirth, " +
                    "PhoneNumber=@PhoneNumber, Email=@Email, Adress=@Adress, Id_Pol=@Id_Pol, Id_Nation=@Id_Nation WHERE @Id_Applicant=Id_Applicant", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@Middlename", Middlename);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Adress", Adress);
                cmd.Parameters.AddWithValue("@Id_Pol", Id_Pol);
                cmd.Parameters.AddWithValue("@Id_Nation", Id_Nation);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Данные соискателя обновлены!");
                DisplayClientData(Id_Applicant, dataGridView1);
            }
            else
            {
                MessageBox.Show("Введите необходимые данные!!!");
            }
        }

        // функция для показа вакансий 
        public void displayVacancyData (int Id_Applicant, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий, которые выбрал соискатель
        public void jobOpenings(int Id_Applicant, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack " +
                "JOIN Summary " +
                "ON Jobs.Id_Job = Summary.Id_Job AND Summary.Id_Applicant = @Id_Applicant";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            sql.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий по определённой профессии или окладу
        public void showingAVacancyByProfession (string Work, int initial_salary, int final_salary, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack ";
            if (Work != "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Position.Work LIKE '%" + Work + "%'";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work == "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Position.Work LIKE '%" + Work + "%' AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Work", SqlDbType.VarChar).Value = Work;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий по определённому образованию
        public void educationJobShow(string Work, int initial_salary, int final_salary, int Id_Education, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack ";
            if (Work == "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Education = @Id_Education";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Education", SqlDbType.Int).Value = Id_Education;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Education = @Id_Education AND Position.Work LIKE '%" + Work + "%'";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Education", SqlDbType.Int).Value = Id_Education;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work == "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Education = @Id_Education AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Education", SqlDbType.Int).Value = Id_Education;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Education = @Id_Education AND Position.Work LIKE '%" + Work + "%' AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Education", SqlDbType.Int).Value = Id_Education;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий по опыту работы
        public void showingJobExperience(string Work, int initial_salary, int final_salary, int Id_Experience, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack ";
            if (Work == "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Experience = @Id_Experience";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Experience", SqlDbType.Int).Value = Id_Experience;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Experience = @Id_Experience AND Position.Work LIKE '%" + Work + "%'";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Experience", SqlDbType.Int).Value = Id_Experience;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work == "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Experience = @Id_Experience AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Experience", SqlDbType.Int).Value = Id_Experience;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Experience = @Id_Experience AND Position.Work LIKE '%" + Work + "%' AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Experience", SqlDbType.Int).Value = Id_Experience;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий по графику работы
        public void showingAVacancyOnAWorkSchedule(string Work, int initial_salary, int final_salary, int Id_Schedule, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack ";
            if (Work == "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Schedule = @Id_Schedule";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Schedule", SqlDbType.Int).Value = Id_Schedule;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Schedule = @Id_Schedule AND Position.Work LIKE '%" + Work + "%'";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Schedule", SqlDbType.Int).Value = Id_Schedule;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work == "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Schedule = @Id_Schedule AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Schedule", SqlDbType.Int).Value = Id_Schedule;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Schedule = @Id_Schedule AND Position.Work LIKE '%" + Work + "%' AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Schedule", SqlDbType.Int).Value = Id_Schedule;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для показа вакансий по социальному пакету
        public void socialPackVacancyShowing(string Work, int initial_salary, int final_salary, int Id_Socialpack, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN ProfessionalArea " +
                "ON Jobs.Id_ProfArea = ProfessionalArea.Id_ProfArea " +
                "JOIN Position " +
                "ON Jobs.Id_Work = Position.Id_Work " +
                "JOIN Education " +
                "ON Jobs.Id_Education = Education.Id_Education " +
                "JOIN Experience " +
                "ON Jobs.Id_Experience = Experience.Id_Experience " +
                "JOIN WorkSchedule " +
                "ON Jobs.Id_Schedule = WorkSchedule.Id_Schedule " +
                "JOIN Socialpack " +
                "ON Jobs.Id_Experience = Socialpack.Id_Socialpack ";
            if (Work == "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Socialpack = @Id_Socialpack";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Socialpack", SqlDbType.Int).Value = Id_Socialpack;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary == 0 && final_salary == 0)
            {
                cmdText += "WHERE Jobs.Id_Socialpack = @Id_Socialpack AND Position.Work LIKE '%" + Work + "%'";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Socialpack", SqlDbType.Int).Value = Id_Socialpack;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work == "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Socialpack = @Id_Socialpack AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Socialpack", SqlDbType.Int).Value = Id_Socialpack;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            else if (Work != "" && initial_salary != 0 && final_salary != 0)
            {
                cmdText += "WHERE Jobs.Id_Socialpack = @Id_Socialpack AND Position.Work LIKE '%" + Work + "%' AND Jobs.Salary BETWEEN @initial_salary AND @final_salary";
                SqlCommand sql = new SqlCommand(cmdText, connection);
                sql.Parameters.Add("@Id_Socialpack", SqlDbType.Int).Value = Id_Socialpack;
                sql.Parameters.Add("@initial_salary", SqlDbType.Int).Value = initial_salary;
                sql.Parameters.Add("@final_salary", SqlDbType.Int).Value = final_salary;
                adapter = new SqlDataAdapter(sql);
            }
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция для определения выбора вакансии соискателем (выбирал ли соискатель её или нет)
        public bool jobMatchingCheck(int Id_Applicant, int Id_Job)
        {
            cmd = new SqlCommand("SELECT Id_Resume FROM Summary WHERE Id_Applicant = @Id_Applicant AND Id_Job = @Id_Job", connection);
            openConnection();
            cmd.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            cmd.Parameters.Add("@Id_Job", SqlDbType.Int).Value = Id_Job;
            adapter = new SqlDataAdapter();
            table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            closeConnection();
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // функция для выбора и записи вакансии в таблицу резюме
        public void newJobPosting(string Date_application, int Id_Applicant, int Id_Job)
        {
            cmd = new SqlCommand("INSERT INTO Summary (Date_application, Id_Applicant, Id_Job) VALUES (@Date_application, @Id_Applicant, @Id_Job)", connection);
            cmd.Parameters.Add("@Date_application", SqlDbType.VarChar).Value = Date_application;
            cmd.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            cmd.Parameters.Add("@Id_Job", SqlDbType.Int).Value = Id_Job;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция по определению выбранных вакансий (если вакансия ранее была выбрана, то она закрашивается зелёным, а если нет - белым)
        public void lineFilling(int Id_Applicant, DataGridView dataGridView)
        {
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Job FROM Summary WHERE Id_Applicant = @Id_Applicant";
            sql.Parameters.Add("@Id_Applicant", SqlDbType.Int).Value = Id_Applicant;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                int id = int.Parse(thisReader["Id_Job"].ToString());
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (int.Parse(dataGridView.Rows[i].Cells[0].Value.ToString()) == id)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
            thisReader.Close();
            connection.Close();
        }
    }
}
