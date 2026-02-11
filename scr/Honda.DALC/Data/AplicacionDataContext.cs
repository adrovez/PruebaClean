using System.Data.Entity;

namespace Honda.DALC.Data
{
    public class AplicacionDataContext : DbContext
    {
        public AplicacionDataContext() : base("stringConexion")
        {
        }
    }
}
