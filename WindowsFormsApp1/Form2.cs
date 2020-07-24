using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        long cont1 = 0;
        long cont2 = 0;
        long cont3 = 0;
        long cont4 = 0;

        Class1 con = new Class1();
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Caixa de texto vazio ", "Formulário Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                     
                textBox1.Focus();
                               
            }
            else
            {
               Class1 con = new Class1();

                try
                {
                    con.conectar();
                    string sql = "INSERT INTO usuario(nome , sobrenome, email, senha) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                    SQLiteCommand comando = new SQLiteCommand(sql, con.conn);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Registro efetuado com sucesso!", "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Focus();

                    con.desconectar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }*/

            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button1.Text = "Desconectado";
            }
            else
            {
                timer1.Enabled = true;
                button1.Text = "Conectado";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*con.conectar();
            
            string sql = "INSERT INTO usuario(nome , sobrenome, email, senha) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

            SQLiteCommand comando = new SQLiteCommand(sql, con.conn);

            comando.ExecuteNonQuery();*/

            // MessageBox.Show("Registro efetuado com sucesso!", "Registro Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /* textBox1.Clear();
             textBox2.Clear();
             textBox3.Clear();
             textBox4.Clear();
             textBox1.Focus();*/

            /*textBox1.Text = cont1.ToString();
            textBox2.Text = cont2.ToString();
            textBox3.Text = cont3.ToString();
            textBox4.Text = cont4.ToString();

            cont1++;
            cont2++;
            cont3++;
            cont4++;

            con.desconectar();*/
        }
    }
}
