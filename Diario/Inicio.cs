using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Diario
{
    public partial class Inicio : Form
    {
        int idusuario;
        private DiarioEntities1 op;
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();

            op.NewNotas(idusuario, Titulo.Text, dateTimePicker1.Value, Descripcion.Text, Convert.ToString(comboBox1.SelectedValue));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();

            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["Diario.Properties.Settings.DiarioConnectionString"];


            SqlConnection conn = new SqlConnection(setting.ConnectionString);

            string query = "SELECT [Titulo],[Fecha],[Descripcion] FROM [Diario].[dbo].[Notas] where idusuario";

            SqlCommand cmdVerCO = new SqlCommand(query, conn);


            try
            {

                conn.Open();

                SqlDataReader rdr = cmdVerCO.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                this.dataGridView1.DataSource = dt;

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se hapodido conectar" + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();
            op.verNotas(idusuario);
        }
        private void LoadNotas(DateTime Fecha)
        {
            op = new DiarioEntities1();



            var query = from d in op.verNotas(idusuario)  select d;

            try
            {
                this.dataGridView1.DataSource = query.ToList();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            OpenFileDialog open1 = new OpenFileDialog();
            open1.InitialDirectory = "C:\\imagenes";
            open1.ShowDialog();
        }
    }
}
