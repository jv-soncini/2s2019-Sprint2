using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> Funcionarios = new List<FuncionariosDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string Query = "select * from Funcionarios";

                con.Open();

                SqlDataReader sdr;



                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
                            ,
                            Nome = sdr["Nome"].ToString()
                            ,
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        Funcionarios.Add(funcionario);
                    }
                    return Funcionarios;
                }


            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                string Query = "select * from Funcionarios where IdFuncionario = @IdFuncionario";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@idFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {

                            FuncionariosDomain funcionario = new FuncionariosDomain()
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
                                ,
                                Nome = sdr["Nome"].ToString()
                                ,
                                Sobrenome = sdr["Sobrenome"].ToString()
                                ,
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            };  
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }
        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "insert into Funcionarios (Nome, SobreNome, DataNascimento) values (@Nome, @sobrenome, @DataNascimento)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Delete from Funcionarios where IdFuncionario = @IdFuncionario";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    cmd.ExecuteNonQuery();


                }
            }
        }

        public void Atualizar(FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Update Funcionarios set Nome = @Nome, SobreNome = @Sobrenome, DataNascimento = @DataNascimento where IdFuncionario = @Id";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@id", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorNome(string Nome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                string Query = "select * from Funcionarios where Nome = @Nome";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {

                            FuncionariosDomain funcionario = new FuncionariosDomain()
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
                                ,
                                Nome = sdr["Nome"].ToString()
                                ,
                                Sobrenome = sdr["Sobrenome"].ToString()
                                ,
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }

        }
            public List<FuncionariosDomain> ListarNomeCompleto()
            {
            List<FuncionariosDomain> Funcionarios = new List<FuncionariosDomain>();


            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string Query = "select * from VwNomeCompleto";

                con.Open();

                SqlDataReader sdr;



                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
                            ,
                            Nome = sdr["NomeCompleto"].ToString()
                            ,
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        Funcionarios.Add(funcionario);
                    }
                    return Funcionarios;
                }


            }
        }
    }
}
