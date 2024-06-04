
using Services;

namespace Controllers
{
    public class ReadAndPersistController
    {
        private ReadAndPersistService readAndPersistService;

        public ReadAndPersistController()
        {
            readAndPersistService = new ReadAndPersistService();
        }

        public bool Recuperar()
        {
            return readAndPersistService.Recuperar();
        }

    }
}
