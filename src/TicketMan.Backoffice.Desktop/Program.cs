using System;
using System.Windows.Forms;
using System.Threading;
using TicketMan.Platform.Api.Shared.Exceptions;

namespace TicketMan.Backoffice.Desktop
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
		Thread.CurrentThread.CurrentCulture =  new System.Globalization.CultureInfo("ru-RU");
		Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");

		Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

#if (DEBUG)
	 //if (DialogResult.OK == new FrmLogin().ShowDialog())
			Application.Run(new FrmMain());
#endif

#if (!DEBUG)

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Application.ThreadException += ApplicationThreadException;
			//new Updater().CheckForUpdates();

     try
      {
        if (DialogResult.OK == FrmLogin.OnlyInstance.ShowDialog())
        {
          Application.Run(new FrmMain());
        }
      }
      catch (LogicalApiException e)
      {
        MessageBox.Show(String.Format("Ошибка. Код: {0}. Сообщение: {1}", e.Code, e.Message));
      }
      catch (AuthorizationApiException e)
      {
        MessageBox.Show(String.Format("Ошибка. Не хватает разрешения '{0}'. Сообщение сервера: '{1}'", e.Permission, e.Message));
      }
      catch (ArgumentApiException e)
      {
        MessageBox.Show(String.Format("Ошибка. В запросе неверно указан аргумент '{0}'. Сообщение сервера: '{1}'", e.ArgumentName, e.Message));
      }
      catch (SystemApiException e)
      {
        MessageBox.Show(String.Format("Ошибка. Критическая ошибка сервера: '{0}'", e.Message));
      }
     catch (Exception e)
     {
         MessageBox.Show(String.Format("Ошибка. '{0}'", e.Message));
     }

#endif
    }


		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				var ex = (Exception)e.ExceptionObject;
				Utils.ProcessException(ex.Message, ex.StackTrace);
			}
			catch (Exception)
			{
				//do nothing - Another Exception! Wow not a good thing.
			}
			finally
			{
				//Application.Exit();
			}
		}

		public static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				Utils.ProcessException(e.Exception.Message, e.Exception.StackTrace);
			}
			catch (Exception)
			{
				//do nothing - Another Exception! Wow not a good thing.
			}
		}


  }
}
