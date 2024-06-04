using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public class SqlRepository : IRadarRepository
    {
        string strConn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";

        public void NotificarObservadores(List<Radar> mensagem)
        {
            Console.WriteLine("Cheguei no notificar Observadores");

            MongoRepository mR = new MongoRepository();

            mR.Atualizar(mensagem);

        }

        public bool Recuperar()
        {
            List<Radar> records = new List<Radar>();
            bool result = false;
            string sql = "Select concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido," +
                " situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM Radar";

            try
            {
                using (var conexaosql = SqlConnection.Instance) // Usando a instância única da conexão
                {
                    conexaosql.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conexaosql))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Radar r = new Radar
                                {
                                    Concessionaria = reader.GetString(0),
                                    ano_do_pnv_snv = reader.GetInt32(1),
                                    tipo_de_radar = reader.GetString(2),
                                    Rodovia = reader.GetString(3),
                                    Uf = reader.GetString(4),
                                    km_m = (double)reader.GetDecimal(5),
                                    Municipio = reader.GetString(6),
                                    tipo_pista = reader.GetString(7),
                                    Sentido = reader.GetString(8),
                                    Situacao = reader.GetString(9),
                                    data_da_inativacao = reader.IsDBNull(10) ? null : new DateTime[] { reader.GetDateTime(10) },
                                    Latitude = (double)reader.GetDecimal(11),
                                    Longitude = (double)reader.GetDecimal(12),
                                    velocidade_leve = reader.GetInt32(13)
                                };

                                records.Add(r);
                            }
                        }
                    }
                }

                NotificarObservadores(records);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }
    }
}
