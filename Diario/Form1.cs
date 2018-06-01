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
    public partial class Form1 : Form
    {
        private DiarioEntities1 op;
        public Form1()
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
            ObjectParameter Output = new ObjectParameter("resultado", typeof(string));

            if (!String.IsNullOrEmpty(Nombre.Text) && !String.IsNullOrEmpty(Contraseña.Text))
            {
                try
                {
                    op.Verificar(Nombre.Text, Contraseña.Text, Output);
                    MessageBox.Show(Output.Value.ToString());
                    if (Output.Value.ToString()>0 )
                    {
                        Form frm = new Form2();
                        frm.Show();


                    }
                  
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
