using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SQLite
{
    public partial class AddData : Form
    {
        private SQLiteDB _db;

        public AddData(SQLiteDB s)
        {
            _db = s;
            InitializeComponent();
        }
        private void AddData_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _db.AjouterEleve(nom.Text, prenom.Text, description.Text);
            MessageBox.Show("Données inserés");
            this.Close();
        }
    }
}
