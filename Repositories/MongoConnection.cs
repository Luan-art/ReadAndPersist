using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MongoConnection
    {
        private static readonly Lazy<MongoRepository> _instance = new Lazy<MongoRepository>(() => new MongoRepository());

        public static MongoRepository Instance => _instance.Value;

        private MongoConnection() { }
    }
}
