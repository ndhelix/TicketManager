namespace TicketMan.Platform.Api.Sdk
{
    /// <summary>
    /// Тут собраны все общие параметры, необходимые для теста
    /// </summary>
    internal static class Config
    {
        public static string Url
        {
#if !LocalDebug2
            get { return "http://localhost:30340/"; }
#else
            get { return "http://beta.api2.TicketMan.ru/"; }
#endif
        }

        public static string SiteSlug { get { return "TicketMan"; } }

        public static string ApiKey { get { return "114e712df18e40f38fdfe7be6534d731"; } }

        public static string UserLogin { get { return "test@test.ru"; } }

        public static string UserPassword { get { return "XNU%yF7;r;Vd"; } }
    }
}
