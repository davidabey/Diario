using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diario
{
    public partial class Form2 : Form
    {
        int idusuario;
        private DiarioEntities1 op;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();

            op.NewNotas(idusuario, Titulo.Text, dateTimePicker1.Value, Descripcion.Text, Convert.ToString(comboBox1.SelectedValue));
        }
    }
}
