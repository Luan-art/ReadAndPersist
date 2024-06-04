
using Repositories;
using System.Diagnostics;

namespace Services
{
    public class ReadAndPersistService
    {
        private IRadarRepository iRadarRepository;
        public ReadAndPersistService()
        {
            iRadarRepository = new SqlRepository();
        }

        public bool Recuperar()
        {
            try
            {
                iRadarRepository.Recuperar(); 

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
