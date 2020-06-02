using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Employment_agency
{
    class WorkWithJobData
    {
        // подключение к базе данных
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Employment_agency.Properties.Settings.employment_agencyConnectionString"].ConnectionString);
        public SqlDataAdapter adapter;
        public SqlCommand cmd;
        public DataTable table;

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

        // проверка на совпадение работодателя в бд
        public bool isEmployerExists(string email)
        {
            cmd = new SqlCommand("SELECT email, passwords FROM Employers WHERE email = @loginEmployer", connection);
            openConnection();
            cmd.Parameters.Add("@loginEmployer", SqlDbType.VarChar).Value = email;
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

        // проверка на совпадение инициализирующего ключа работодателя в бд
        public bool isEmployerKey(string Key, string Company)
        {
            cmd = new SqlCommand("SELECT * FROM UniqueKeys WHERE Registration_key = @Key AND Company = @Company", connection);
            openConnection();
            cmd.Parameters.Add("@Key", SqlDbType.VarChar).Value = Key;
            cmd.Parameters.Add("@Company", SqlDbType.VarChar).Value = Company;
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

        // функция для регистрации работодателя
        public bool employerRegistration(string email, string password, int Id_Key)
        {
            cmd = new SqlCommand("INSERT INTO Employers (email, passwords, Id_Key) VALUES (@email, @password, @Id_Key)", connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@Id_Key", SqlDbType.Int).Value = Id_Key;
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

        // функция для проверки работодателя на вход
        public bool employerLogin(string email, string password)
        {
            cmd = new SqlCommand("SELECT email, passwords FROM Employers WHERE email = @loginUser AND passwords = @passUser", connection);
            openConnection();
            cmd.Parameters.Add("@loginUser", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@passUser", SqlDbType.VarChar).Value = password;
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

        // функция для поиска id ключа работодателя
        public int findIdKey(string Key)
        {
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Key FROM UniqueKeys WHERE Registration_key = @Key";
            sql.Parameters.Add("@Key", SqlDbType.VarChar).Value = Key;
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

        // функция для поиска id работодателя
        public int findIdEmployer(string email)
        {
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Employer FROM Employers WHERE email = @email";
            sql.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Id_Employer"].ToString();
            }
            thisReader.Close();
            connection.Close();
            int id = int.Parse(text);
            return id;
        }

        // функция для поиска компании работодателя
        public string findCompany(int Id_Employer)
        {
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Company FROM UniqueKeys WHERE Id_Key = (SELECT Id_Key FROM Employers WHERE Id_Employer = @Id_Employer)";
            sql.Parameters.Add("@Id_Employer", SqlDbType.Int).Value = Id_Employer;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Company"].ToString();
            }
            thisReader.Close();
            connection.Close();
            return text;
        }

        // функция для поиска id вакансии по профессии
        public int findPosition(string position)
        {
            int id = 0;
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_Work FROM Position WHERE Work = @position";
            sql.Parameters.Add("@position", SqlDbType.VarChar).Value = position;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Id_Work"].ToString();
                id = int.Parse(text);
            }
            thisReader.Close();
            connection.Close();
            return id;
        }

        // функция добавления новой профессии
        public void addPosition(string position)
        {
            cmd = new SqlCommand("INSERT INTO Position (Work) VALUES (@position)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@position", position);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция для поиска id профессиональной области 
        public int findProfessionalArea(string professionalArea)
        {
            int id = 0;
            string text = "";
            connection.Open();
            SqlCommand sql = connection.CreateCommand();
            sql.CommandText = @"SELECT Id_ProfArea FROM ProfessionalArea WHERE ProfArea = @professionalArea";
            sql.Parameters.Add("@professionalArea", SqlDbType.VarChar).Value = professionalArea;
            SqlDataReader thisReader = sql.ExecuteReader();
            while (thisReader.Read())
            {
                text = thisReader["Id_ProfArea"].ToString();
                id = int.Parse(text);
            }
            thisReader.Close();
            connection.Close();
            return id;
        }

        // функция добавления новой профессиональной области
        public void addProfessionalArea(string professionalArea)
        {
            cmd = new SqlCommand("INSERT INTO ProfessionalArea (ProfArea) VALUES (@professionalArea)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@professionalArea", professionalArea);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция добавления новой вакансии работодателем 
        public void addVacancy (string Company, string Company_address, int Salary, int Id_Employer, int Id_Schedule, int Id_Work, int Id_Education, int Id_Experience,
            int Id_ProfArea, int Id_Socialpack){
            cmd = new SqlCommand("INSERT INTO Jobs(Company, Company_address, Salary, Id_Employer, Id_Schedule, Id_Work, Id_Education, Id_Experience, Id_ProfArea, Id_Socialpack) " +
                "VALUES (@Company, @Company_address, @Salary, @Id_Employer, @Id_Schedule, @Id_Work, @Id_Education, @Id_Experience, @Id_ProfArea, @Id_Socialpack)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Company", Company);
            cmd.Parameters.AddWithValue("@Company_address", Company_address);
            cmd.Parameters.AddWithValue("@Salary", Salary);
            cmd.Parameters.AddWithValue("@Id_Employer", Id_Employer);
            cmd.Parameters.AddWithValue("@Id_Schedule", Id_Schedule);
            cmd.Parameters.AddWithValue("@Id_Work", Id_Work);
            cmd.Parameters.AddWithValue("@Id_Education", Id_Education);
            cmd.Parameters.AddWithValue("@Id_Experience", Id_Experience);
            cmd.Parameters.AddWithValue("@Id_ProfArea", Id_ProfArea);
            cmd.Parameters.AddWithValue("@Id_Socialpack", Id_Socialpack);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция показа всех вакансий для конкретной компании
        public void DisplayVacancyData(int Id_Employer, DataGridView dataGridView1)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Jobs.Id_Job, Jobs.Company AS Компания, Jobs.Company_address AS Адрес_компании, ProfessionalArea.ProfArea AS Профобласть, Position.Work AS Профессия, Jobs.Salary AS Оклад, Education.Education AS Образование, " +
                "Experience.Experience AS Опыт_работы, WorkSchedule.Schedule AS График_работы, Socialpack.Socialpack AS Социальный_пакет " +
                "FROM Jobs " +
                "JOIN Employers " +
                "ON Jobs.Id_Employer = Employers.Id_Employer AND Jobs.Id_Employer = @Id_Employer " +
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
                "GROUP BY Jobs.Id_Job, Jobs.Company, Jobs.Company_address, ProfessionalArea.ProfArea, Position.Work, Jobs.Salary, " +
                "Education.Education, Experience.Experience, WorkSchedule.Schedule, Socialpack.Socialpack";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            sql.Parameters.Add("@Id_Employer", SqlDbType.Int).Value = Id_Employer;
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        // функция изменения данных вакансии
        public void changeVacancy(int Id_Job, string Company, string Company_address, int Salary, int Id_Employer, int Id_Schedule, int Id_Work, 
            int Id_Education, int Id_Experience, int Id_ProfArea, int Id_Socialpack, DataGridView dataGridView1)
        { 
            if (Company != "" && Company_address != "" && Salary != 0 && Id_Schedule != 0 && Id_Work != 0 && Id_Education != 0 && Id_Experience != 0
                && Id_ProfArea != 0 && Id_Socialpack != 0)
            {
                cmd = new SqlCommand("UPDATE Jobs SET Company = @Company, Company_address = @Company_address, Salary = @Salary, @Id_Employer = Id_Employer, Id_Schedule = @Id_Schedule, Id_Work = @Id_Work, " +
                    "Id_Education = @Id_Education, Id_Experience = @Id_Experience, Id_ProfArea = @Id_ProfArea, Id_Socialpack = @Id_Socialpack WHERE @Id_Job = Id_Job", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id_Job", Id_Job);
                cmd.Parameters.AddWithValue("@Company", Company);
                cmd.Parameters.AddWithValue("@Company_address", Company_address);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                cmd.Parameters.AddWithValue("@Id_Employer", Id_Employer);
                cmd.Parameters.AddWithValue("@Id_Schedule", Id_Schedule);
                cmd.Parameters.AddWithValue("@Id_Work", Id_Work);
                cmd.Parameters.AddWithValue("@Id_Education", Id_Education);
                cmd.Parameters.AddWithValue("@Id_Experience", Id_Experience);
                cmd.Parameters.AddWithValue("@Id_ProfArea", Id_ProfArea);
                cmd.Parameters.AddWithValue("@Id_Socialpack", Id_Socialpack);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Данные вакансии обновлены!");
            }
            else
            {
                MessageBox.Show("Введите необходимые данные!!!");
            }
        }

        // функция удаления вакансии
        public void deleteVacancy(int Id_Job, DataGridView dataGrid)
        {
            cmd = new SqlCommand("DELETE Jobs WHERE Id_Job = @Id_Job", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Job", Id_Job);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Вакансия удалена из списка!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
         * Запрос для создания представления
         * CREATE VIEW ApplicantVacancy AS SELECT Applicant.LastName AS Фамилия, Applicant.FirstName AS Имя, Applicant.Middlename AS Отчество, 
         * Applicant.DateOfBirth AS Дата_рождения, Applicant.PhoneNumber AS Телефон, 
         * Applicant.Email as Email, Summary.Date_application as Дата_подачи, Summary.Id_Job AS ID_Вакансии 
         * FROM Applicant 
         * INNER JOIN Gender
         * ON Applicant.Id_Pol = Gender.Id_Pol 
         * JOIN Nationality 
         * ON Applicant.Id_Nation = Nationality.Id_Nation
         * INNER JOIN Summary 
         * ON Applicant.Id_Applicant = Summary.Id_Applicant
        */

        // функция для показа списка соискателей по определённой вакансии (используется представление, описанное выше)
        public void DisplayJobApplicants(int Id_Job, DataGridView dataGridView)
        {
            connection.Open();
            DataTable dt = new DataTable();
            string cmdText = @"SELECT Фамилия, Имя, Отчество, Дата_рождения, Телефон, Email, Дата_подачи " +
                              "FROM ApplicantVacancy " +
                              "GROUP BY Фамилия, Имя, Отчество, Дата_рождения, Телефон, Email, Дата_подачи, ID_Вакансии " +
                              "HAVING ID_Вакансии = @Id_Job";
            SqlCommand sql = new SqlCommand(cmdText, connection);
            sql.Parameters.Add("@Id_Job", SqlDbType.Int).Value = Id_Job;
            adapter = new SqlDataAdapter(sql);
            adapter.Fill(dt);
            dataGridView.DataSource = dt;
            connection.Close();
        }

        // функция удаления соискателя из списка
        public void deleteApplicants(int Id_Applicant, int Id_Job)
        {
            cmd = new SqlCommand("DELETE Summary WHERE Id_Applicant = @Id_Applicant AND Id_Job = @Id_Job", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
            cmd.Parameters.AddWithValue("@Id_Job", Id_Job);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления всех записей по данной вакансии и выбранному соискателю
        public void selectionApplicantForThisVacancy(int Id_Applicant, int Id_Job)
        {
            cmd = new SqlCommand("DELETE Summary WHERE Id_Job = @Id_Job OR Id_Applicant = @Id_Applicant", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Applicant", Id_Applicant);
            cmd.Parameters.AddWithValue("@Id_Job", Id_Job);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция удаления вакансии в случае выбора подходящей кандидатуры
        public void deleteAClosedVacancy(int Id_Job)
        {
            cmd = new SqlCommand("DELETE Jobs WHERE Id_Job = @Id_Job", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@Id_Job", Id_Job);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        // функция для передачи списка соискателей в Excel
        public void ExportExcel(DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // создаем новый WorkBook             
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // новый Excelsheet в workbook               
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;
            // задаем имя для worksheet            
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }
            // закрываем подключение к excel            
            app.Quit();
        }

        public void ExportWord(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count != 0)
            {
                int RowCount = dataGridView.Rows.Count;
                int ColumnCount = dataGridView.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = dataGridView.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Microsoft.Office.Interop.Word.Document oDoc = new Microsoft.Office.Interop.Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Microsoft.Office.Interop.Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dataGridView.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Microsoft.Office.Interop.Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "your header text";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                oDoc.SaveAs2("Список соискателей");
            }
        }
    }
}
