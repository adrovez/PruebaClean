using aadrovez.BLL.Services;

namespace aadrovez.BLL.Factory
{
    public static class ServiceFactory
    {
        public static ITablaCodigoService CreateTablaCodigoService()
        {
            return new TablaCodigoService();
        }
    }
}
