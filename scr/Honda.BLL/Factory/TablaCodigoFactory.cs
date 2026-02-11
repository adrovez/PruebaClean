namespace Honda.BLL.Factory
{
    public static class TablaCodigoFactory
    {
        public static Services.ITablaCodigoService Create()
        {
            return new Services.TablaCodigoService();
        }
    }
}
