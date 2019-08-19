using Senai.Sstop.Webapi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.Webapi.Repositories
{
    public class EstiloRepository
    {

        private string stringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Sstop; User Id=sa/Pwd=132;"; 
            
            

        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string Query = "Select IdEstilo, Nome From Estilos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //pegar os valores da tabela e armazenar dentro da aplicação do backend
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdEstilo"]),
                            Nome = sdr["Nome"].ToString()

                        };
                        estilos.Add(estilo);
                    }
                }
            }
            return estilos;
        }
    }
}
