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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if(textBox1.Text =="" || textBox2.Text == "")
            {
                MessageBox.Show("Caixa de texto vazia!", "formulário incompleto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Class1 con = new Class1();

                try
                {
                    con.conectar();

                    string sql = "SELECT * FROM usuario WHERE email = '" + textBox1.Text + "' AND senha = '" + textBox2.Text + "'"; // Query sql

                    SQLiteDataAdapter dados = new SQLiteDataAdapter(sql, con.conn);// Realizando a Query de consulta                    
                    DataTable usuario = new DataTable();

                    dados.Fill(usuario);// passando os dados do meu dataadpter para o datatable

                    if (usuario.Rows.Count < 1)
                    {
                        MessageBox.Show("Usuário Invalido", "Registro não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Focus();
                    }
                    else
                    {
                        string nome = usuario.Rows[0]["nome"].ToString();
                        string sobrenome = usuario.Rows[0]["sobrenome"].ToString();

                        MessageBox.Show("Bem Vindo(a)" + nome + " " + sobrenome, "Login", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    con.desconectar();

                }

            
        

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.CriarBancoSQLite();
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.CriarTabelaSQlite();
                button3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }
        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Class1.GetClientes();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                MessageBox.Show("Informe os dados cliente a incluir");
                return;
            }
            try
            {
                          
                Class1.Cliente cli = new Class1.Cliente();
                cli.Id    =  textBox3.Text;
                cli.Nome  =  textBox4.Text;
                cli.Email =  textBox5.Text;

                Class1.Add(cli);

                ExibirDados();
                LimpaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }
        private bool Valida()
        {
            if (string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void LimpaDados()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                const string mensagem = "Deseja Encerrar ?";
                const string titulo = "Encerrar";
                var resultado = MessageBox.Show(mensagem, titulo,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["Id"].Value.ToString();
                textBox4.Text = row.Cells["Nome"].Value.ToString();
                textBox5.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Valida())
            {
                MessageBox.Show("Informe os dados cliente a atualizar");
                return;
            }

            try
            {


                Class1.Cliente cli = new Class1.Cliente();
               
                cli.Id = textBox3.Text;
                cli.Nome = textBox4.Text;
                cli.Email = textBox5.Text;

                Class1.Update(cli);
                ExibirDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Informe o ID do cliente a ser Excluído");
                return;
            }
            try
            {
                int codigo1 = Convert.ToInt32(textBox3.Text);
                /*string codigo2 = textBox4.Text;
                string codigo3 = textBox5.Text;*/

                Class1.Delete(codigo1);
                //Class1.Delete(codigo1, codigo2, codigo3);
                ExibirDados();
                LimpaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Informe o ID do cliente a ser Localizado");
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                int codigo = Convert.ToInt32(textBox3.Text);

                dt = Class1.GetCliente(codigo);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        string[] word = { "2", "3" };

        private void Form1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 2; i++)
            {
                groupBox3.Controls["button" + word[i]].Enabled = false;
               
            }

            DirectoryInfo diretorio = new DirectoryInfo(@"C:\\dados");

            FileInfo[] Arquivos = diretorio.GetFiles();

            foreach (FileInfo arquivo in Arquivos)
            {
                 
                comboBox1.Items.Add(arquivo.Name);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "" && textBox6.Text != null)
            {
                Class1.teste = textBox6.Text;
            }
            else if (comboBox1.Text != "" && comboBox1.Text != null)
            {
                string teste = comboBox1.Text;
                string[] teste2 = teste.Split('.');
              
                Class1.teste = teste;
            }
            else
            {
                MessageBox.Show("Crie um novo banco ou escolha um ja existente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            
            for (int i = 0; i < 2; i++)
            {
                groupBox3.Controls["button" + word[i]].Enabled = true;

            }

            try
            {
                Class1.CriarBancoSQLite();
                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

            try
            {
                Class1.CriarTabelaSQlite();
                button3.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }

        Random rand = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox7.Text = $"{DateTime.Now.ToLongTimeString()}".ToString();
            textBox3.Text = (rand.Next(10000)).ToString(); 
            textBox4.Text = (rand.Next(10000)).ToString();
            textBox5.Text = (rand.Next(10000)).ToString();

            if (!Valida())
            {
                MessageBox.Show("Informe os dados cliente a incluir");
                return;
            }
            try
            {

                Class1.Cliente cli = new Class1.Cliente();
                cli.Id = textBox3.Text;
                cli.Nome = textBox4.Text;
                cli.Email = textBox5.Text;
                cli.Hora = textBox7.Text;

                Class1.Add(cli);

                ExibirDados();
                LimpaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button11.Text = "Start";
               



            }
            else
            {
                timer1.Enabled = true;
                button11.Text = "Stop";
            }

            ExibirDados();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Class1.GravarFicheiro();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
