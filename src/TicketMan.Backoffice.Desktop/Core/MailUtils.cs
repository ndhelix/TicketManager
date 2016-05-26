using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CreativeGroup.Messager.Tamplate;
using CreativeGroup.Messager.Objects;
using CreativeGroup.Messager;

namespace TicketMan.Backoffice.Desktop.Core
{
	public static class MailUtils
	{
		public static int SendErrorMessage(string msg, string stacktrace)
		{
			var template =
					@"<?Tittle:ApplicationError?>
<?FullMessage:
Message: 
<%Message%>

StackTrace: 
<%StackTrace%>
?>
<?ShortMessage: Test?>
";
			var message = TemplateMessage.GetMessage(template,
																											 new
																											 {
																												 Message = msg,
																												 StackTrace = stacktrace																											 
																											 });

			var adresses = new MessageAddressCollection();
			adresses.EMails.FromAddress = "Backoffice.Desktop@TicketMan.ru";
			adresses.EMails.ToAddresses.Add("sgabrielyan@TicketMan.ru");

			//adresses.Phones.FromAddress = "89150819401";
			//adresses.Phones.ToAddresses.Add("89150819401");

			MessageSender.SendMessage(adresses, message);
			return message.MessageID;
		}
	}
}
