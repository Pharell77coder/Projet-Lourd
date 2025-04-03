using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Projet_Lourd
{
    public partial class Form2 : Form
    {
        private MySqlConnection conn;
        private string selectedTable;

        public Form2()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadDatabaseTables();
            button1.Click += button1_Click;
            NomDesTables.SelectedIndexChanged += NomDesTables_SelectedIndexChanged;
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "server=localhost;database=bdd_commerce;uid=root;pwd=";
            conn = new MySqlConnection(connectionString);
        }

        private void LoadDatabaseTables()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SHOW TABLES", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NomDesTables.Items.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des tables : {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void NomDesTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = NomDesTables.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTable))
            {
                DisplayTableData();
            }
        }

        private void DisplayTableData()
        {
            try
            {
                conn.Open();
                string query = $"SELECT * FROM `{selectedTable}`";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur d'affichage : {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedTable))
            {
                MessageBox.Show("Veuillez sélectionner une table.");
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une ligne.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            Dictionary<string, string> rowData = new Dictionary<string, string>();

            foreach (DataGridViewCell cell in dataGridView1.SelectedRows[0].Cells)
            {
                string columnName = dataGridView1.Columns[cell.ColumnIndex].Name;
                string cellValue = cell.Value?.ToString() ?? "";
                rowData[columnName] = cellValue;
            }

            Form3 form = new Form3(selectedTable, id, rowData);
            form.ShowDialog();
            DisplayTableData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}