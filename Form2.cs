using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.DirectoryServices;

namespace WinFormsAppCFX
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            conn = new MySqlConnection(); // Initialisation vide
        }

    }
}
