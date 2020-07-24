using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Class1
    {

        // do anterior
        /*public SQLiteConnection conn = new SQLiteConnection("Data Source = WindowsFormsApp1.sdb");
        
        public void conectar()
        {
            conn.Open();
        }

        public void desconectar()
        {
            conn.Close();
        }*/

        //==========================================================================================================//
        private static SQLiteConnection sqliteConnection;
        //==========================================================================================================//
        public Class1()
        { }
        //==========================================================================================================//
        private static SQLiteConnection DbConnection()
        {
            //if(!File.Exists(@"c:\dados\Cadastro"+teste+".sqlite"))
            //MessageBox.Show(@"c:\dados\Cadastro"+teste+".sqlite");
            sqliteConnection = new SQLiteConnection("Data Source =c:\\dados\\Cadastro" + teste + ".sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static string teste;
        //==========================================================================================================//
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"C:\dados\Cadastro" + teste + ".sqlite");
            }
            catch
            {
                throw;
            }
        }
        //==========================================================================================================//
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Clientes(teste INTEGER PRIMARY KEY, hora STRING, id STRING, Nome Varchar(50), email VarChar(80))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================================================================================================//
        public static DataTable GetClientes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        //==========================================================================================================//
        public static DataTable GetCliente(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================================================================================================//
        public class Cliente
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }

            public string Hora { get; set; }
            public string teste { get; set; }


        }
        public class Cliente2
        {
            public string Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
        }
        //==========================================================================================================//
        public static void Add(Cliente luan)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Clientes(hora, id, Nome, email ) values (@hora, @id, @nome, @email)";
                    cmd.Parameters.AddWithValue("@Id", luan.Id);
                    cmd.Parameters.AddWithValue("@Nome", luan.Nome);
                    cmd.Parameters.AddWithValue("@Email", luan.Email);
                    cmd.Parameters.AddWithValue("@hora", luan.Hora);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================================================================================================//
        public static void Update(Cliente cliente)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (cliente.Id != null)
                    {
                        cmd.CommandText = "UPDATE Clientes SET Hora=@hora, Nome=@Nome, Email=@Email WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", cliente.Id);
                        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@hora", cliente.Hora);

                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================================================================================================//
        public static void Delete(int Id)
        //public static void Delete(int Id, string Nome, int Email)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    //md.CommandText = "DELETE FROM Clientes Where Nome=@Nome, Email=@Email, Id=@Id";
                    cmd.CommandText = "DELETE FROM Clientes Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    /*md.Parameters.AddWithValue("@Nome", Nome);
                     cmd.Parameters.AddWithValue("@Email", Email);*/
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //==========================================================================================================//
        public static void GravarFicheiro()
        {
            DataTable dados = new DataTable();
            dados = GetClientes();

            /*string pasta_documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nome_ficheiro = pasta_documentos + @"\ficheiro_contactos.txt";*/
            int cont = 0;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Salvar Arquivo Texto";
            //Define as extensões permitidas
            saveFileDialog1.Filter = "Text File|.txt";
            //define o indice do filtro
            saveFileDialog1.FilterIndex = 0;
            //Atribui um valor vazio ao nome do arquivo
            saveFileDialog1.FileName = "Tia1" + DateTime.Now.ToString("dd_MMyyyy_HHmmss");
            //Define a extensão padrão como .txt
            saveFileDialog1.DefaultExt = ".txt";
            //define o diretório padrão
            saveFileDialog1.InitialDirectory = @"c:\dados";
            //restaura o diretorio atual antes de fechar a janela
            saveFileDialog1.RestoreDirectory = true;

            //Abre a caixa de dialogo e determina qual botão foi pressionado
            DialogResult resultado = saveFileDialog1.ShowDialog();

            //Se o ousuário pressionar o botão Salvar
            if (resultado == DialogResult.OK)
            {
                //Cria um stream usando o nome do arquivo
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                StreamWriter ficheiro = new StreamWriter(fs);
                foreach (DataRow t in dados.Rows)
                {
                    if (cont < 4)
                    {
                        ficheiro.WriteLine("Arquivo:VG 1 pol subsea TGV 013 000-19 assinatura hidráulica 10000 psi-07_08_2019-16_02_52.TIA");
                        ficheiro.WriteLine($"{DateTime.Now.ToLongDateString()}");
                        ficheiro.WriteLine("Descrição:");
                        ficheiro.WriteLine("Linha1(psi):Atuador");
                        ficheiro.WriteLine("Linha2(psi):Descarga");
                        ficheiro.WriteLine("Linha3(psi):Admissão");
                        ficheiro.WriteLine("");
                        ficheiro.Write("REG;", "{0,-8}");
                        ficheiro.Write("Hora;", "{1,-20}");
                        ficheiro.Write("Linha1", "{2,-10}");
                        ficheiro.Write("Linha2", "{3,-10}");
                        ficheiro.WriteLine("Linha3", "{4,-10}");

                        cont++;
                    }

                    else
                    {

                    }
                    //StringBuilder sb = new StringBuilder();
                    // $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}"
                    //ficheiro.WriteLine(t["teste"] +":"+ t["hora"]+"Id: "+ t["id"]+";"+"Nome: "+ t["Nome"]+ ";"+"E-mail: "+ t["email"]);
                    //ficheiro.WriteLine($"{t["teste"]},{0,10}{t["hora"]},{1,5:N1}{t["id"]},{0,25}{t["Nome"]},{0,30}{t["email"]},{0,35}");
                    ficheiro.WriteLine("{0,-8}{1,-20}{2,-10}{3,-10}{4,-10}", t["teste"] + ";", t["hora"] + ";", t["id"] + ";", t["Nome"] + ";", t["email"] + ";");

                }



                ficheiro.Dispose();
            }

            // $"{DateTime.Now.ToLongTimeString()}" hora
            // $"{DateTime.Now.ToLongDateString()}" data
            //==========================================================================================================//
            //==========================================================================================================//



        }
    }
}
