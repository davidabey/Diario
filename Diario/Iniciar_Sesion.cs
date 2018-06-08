using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

namespace Diario
{
    public partial class Iniciar_Sesion : Form
    {
        private DiarioEntities1 op;
        public Iniciar_Sesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();
            ObjectParameter Output = new ObjectParameter("resultado", typeof(string));


            if (!String.IsNullOrEmpty(Nombre.Text) && !String.IsNullOrEmpty(Contraseña.Text))
            {
                try
                {
                    op.NewUser(Nombre.Text,Contraseña.Text,dateTimePicker1.Value,Output);
                    MessageBox.Show(Output.Value.ToString(),"",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Complete los datos","",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            op = new DiarioEntities1();
            ObjectParameter Output = new ObjectParameter("resultado", typeof(int));

            if (!String.IsNullOrEmpty(Nombre.Text) && !String.IsNullOrEmpty(Contraseña.Text))
            {
                try
                {
                    op.Verificar(Nombre.Text, Contraseña.Text, Output);
                    
                    if (Convert.ToInt32(Output.Value) > 0)
                    {
                        MessageBox.Show("Bienvenido usuario", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form frm = new Inicio();
                        frm.Show();
                    }
                    else
                        MessageBox.Show("Datos Incorrectos", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Complete los datos", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }
    }
}
