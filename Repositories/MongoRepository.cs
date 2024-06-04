using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class MongoRepository
    {
        string strConn = "mongodb://root:Mongo%402024%23@localhost:27017/";

        public MongoRepository() { }

        public bool Atualizar(List<Radar> radares)
        {
            Console.WriteLine("Mongo");
            try
            {
                MongoClient client = new MongoClient(strConn);
                var database = client.GetDatabase("ListaRadares");
                var collection = database.GetCollection<BsonDocument>("Radar");
                List<BsonDocument> documents = new List<BsonDocument>();

                foreach (Radar r in radares)
                {
                    BsonDocument document = new BsonDocument
                    {
                        { "Concessionaria", r.Concessionaria },
                        { "ano_do_pnv_snv", r.ano_do_pnv_snv },
                        { "tipo_de_radar", r.tipo_de_radar },
                        { "Rodovia", r.Rodovia },
                        { "Uf", r.Uf },
                        { "km_m", r.km_m },
                        { "Municipio", r.Municipio },
                        { "tipo_pista", r.tipo_pista },
                        { "Sentido", r.Sentido },
                        { "Situacao", r.Situacao },
                        { "data_da_inativacao", r.data_da_inativacao != null ? new BsonArray(r.data_da_inativacao.Select(d => new BsonDateTime(d))) : BsonNull.Value },
                        { "Latitude", r.Latitude },
                        { "Longitude", r.Longitude },
                        { "velocidade_leve", r.velocidade_leve },
                    };

                    documents.Add(document);
                }

                collection.InsertMany(documents);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao adicionar documentos ao MongoDB: " + ex.Message);
                return false;
            }
        }
    }
}
