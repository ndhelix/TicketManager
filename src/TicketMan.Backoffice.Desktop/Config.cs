namespace TicketMan.Backoffice.Desktop
{
	public static class Config
	{

#if (DEBUG)
		//private static string _url = "http://beta.api2.TicketMan.ru/"
			private static string _url = "http://api2.TicketMan.ru/"
			// private static string _url = "http://localhost.:30340/"
	, _siteSlug = "TicketMan"//"sunrise-test"//
	, _apiKey = "114e712df18e40f38fdfe7be6534d731"//"5514710e1ad4430e9bbe6a6d97743702"//
	, _userLogin = "nagaev@crog.ru"//"Yuriy.Dernovoy@sunrise-tour.ru"//
		//	, _userPassword = "XNU%yF7;r;Vd"; //"708090";//
		, _userPassword = "4hjLsgeXmsJm";

		public static string Url { get { return _url; } set { _url = value; } }
		public static string SiteSlug { get { return _siteSlug; } set { _siteSlug = value; } }
		public static string ApiKey { get { return _apiKey; } set { _apiKey = value; } }
		public static string UserLogin { get { return _userLogin; } set { _userLogin = value; } }
		public static string UserPassword { get { return _userPassword; } set { _userPassword = value; } }
#endif
#if (!DEBUG)
		public static string Url { get; set; }
		public static string SiteSlug { get; set; }
		public static string ApiKey { get; set; }
		public static string UserLogin { get; set; }
		public static string UserPassword { get; set; }
#endif
	}
}
