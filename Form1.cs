using System.Data;
using System.Runtime.CompilerServices;

namespace SQLite
{
    public partial class Form1 : Form
    {
        SQLiteDB sqliteDatabase;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqliteDatabase = new SQLiteDB("Eleves.db", recreate: false);
            DataTable table = sqliteDatabase.getEleve();
            dataGridView1.DataSource = table;
            //dataGridView1.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddData formAdd = new AddData(sqliteDatabase);
            formAdd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = sqliteDatabase.getEleve();
            dataGridView1.DataSource = table;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //sqliteDatabase.
        }
    }
}
