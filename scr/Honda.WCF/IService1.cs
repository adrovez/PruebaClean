using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Honda.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<List<TablaCodigoWCF>> getListarTablaCodigo(string pFiltro);
        [OperationContract]
        Task<TablaCodigoWCF> getBuscarTablaCodigo(int id);
        [OperationContract]
        Task<int> setAgregarTablaCodigo(TablaCodigoWCF item);

        [OperationContract]
        Task<bool> setActualizarTabalCodigo(TablaCodigoWCF item);

        [OperationContract]
        Task<bool> setEliminarTabalCodigo(int Id);

        // TODO: agregue aquí sus operaciones de servicio
    }

    [DataContract]
    public class TablaCodigoWCF
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
