using System;
using System.Data.Entity;

namespace aadrovez.DALC.Data
{
    public class AplicacionDbContext : DbContext, IDisposable
    {
        // Define tus DbSets y configuración aquí

        // El constructor base puede requerir una cadena de conexión
        public AplicacionDbContext() : base("name=stringConexion")
        {
        }

        // Si necesitas liberar recursos adicionales, puedes sobreescribir Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
