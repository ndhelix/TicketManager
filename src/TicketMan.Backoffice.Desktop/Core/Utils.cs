using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TicketMan.Platform.Api.Shared.Exceptions;
using System.Xml.Linq;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.Extensions;
using System.Windows.Forms;
using TicketMan.Backoffice.Desktop.Core;

namespace TicketMan.Backoffice.Desktop
{


	static class Utils
	{
		public static List<T> IList2LIst<T>(IList<T> iList)
		{
			if (iList == null) return null;
			List<T> result = new List<T>();
			foreach (T value in iList)
				result.Add(value);

			return result;
		}

		public static string ErrorMsg(LogicalApiException ex)
		{
			switch (ex.Code)
			{
				case ErrorCode.SaveingOrganizationWithoutContracts:
					return "Невозможно создать организацию без контрактов.";
				default:
					return ex.Message;
			}
		}

		public static List<KeyValuePair> XElement2List(XElement element)
		{
			var l = new List<KeyValuePair>();
			var list = from x in element.Attributes()
					   select new
					   {
						   Key = x.Name.ToString(),
						   x.Value
					   };
			foreach (var variable in list)
			{
				if (variable.Key != "xmlns")
					l.Add(new KeyValuePair { Key = variable.Key, Value = variable.Value });
			}
			foreach (var variable in element.Nodes())
			{
				l.AddRange(XElement2List((XElement)variable));
			}
			return l;
		}

		public static List<KeyValuePair> ParseExtensions(List<ProtocolExtension> extensions)
		{
			var l = new List<KeyValuePair>();
			foreach (var element in extensions.OfType<UnknownExtension>().Select(ext => (ext as UnknownExtension).XElement))
			{
				l.AddRange(Utils.XElement2List(element));
			}
			return l;
		}

		public static void ProcessException(string message, string stacktrace)
		{
			int msgnum = MailUtils.SendErrorMessage(message, stacktrace);
			MessageBox.Show("Ошибка. Следующая информация об ошибке отправлена разработчикам под сообщением №"
				+ msgnum.ToString() + ":" + "\n\n" + message,
				"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

	}


	public class KeyValuePair
	{
		[DisplayName("Параметр")]
		public string Key { get; set; }
		[DisplayName("Значение")]
		public string Value { get; set; }
	}

}
