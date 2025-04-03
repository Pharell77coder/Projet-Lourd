using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Projet_Lourd
{
    public partial class Form3 : Form
    {
        private string tableName;
        private string connectionString = "server=localhost;database=bdd_commerce;uid=root;pwd=";
        private Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();
        private int recordId;
        private Dictionary<string, string> rowData;

        public Form3(string selectedTable, int id, Dictionary<string, string> data)
        {
            InitializeComponent();
            tableName = selectedTable;
            recordId = id;
            rowData = data;
            LoadTableStructure();
        }

        private void LoadTableStructure()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"DESCRIBE {tableName}";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        string columnName = row["Field"].ToString();

                        Label label = new Label
                        {
                            Text = columnName,
                            AutoSize = true
                        };

                        TextBox textBox = new TextBox
                        {
                            Name = $"txt{columnName}",
                            Width = 200
                        };

                        if (columnName.ToLower() == "password")
                        {
                            textBox.PasswordChar = '*';
                            textBox.ReadOnly = true;
                        }
                        else
                        {
                            textBox.Text = rowData != null && rowData.ContainsKey(columnName) ? rowData[columnName] : "";
                        }

                        textBoxes[columnName] = textBox;

                        flowLayoutPanel1.Controls.Add(label);
                        flowLayoutPanel1.Controls.Add(textBox);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    List<string> updateFields = new List<string>();

                    foreach (var entry in textBoxes)
                    {
                        if (entry.Key.ToLower() != "password")
                        {
                            updateFields.Add($"{entry.Key} = '{entry.Value.Text}'");
                        }
                    }

                    string query = $"UPDATE {tableName} SET {string.Join(", ", updateFields)} WHERE id = {recordId}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Données mises à jour !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"DELETE FROM {tableName} WHERE id = {recordId}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Donnée supprimée !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    foreach (var entry in textBoxes)
                    {
                        columns.Add(entry.Key);
                        values.Add($"'{entry.Value.Text}'");
                    }

                    string query = $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", values)})";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Nouvelle donnée ajoutée !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }
    }
}
