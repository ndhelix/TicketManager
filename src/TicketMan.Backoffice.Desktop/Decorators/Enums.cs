using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using System.ComponentModel;
using TicketMan.Backoffice.Desktop.Core;

namespace TicketMan.Backoffice.Desktop
{

	public struct EnumDescriber
	{
		public string Value { get; set; }
		public string Caption { get; set; }
	}

	public class EnumDecorator<T>
	{
		public List<EnumDescriber> list;

		public EnumDecorator()
		{
			list = new List<EnumDescriber>();
			Array arr = Enum.GetValues(typeof(T));
			foreach (object o in arr)
			{
				list.Add(new EnumDescriber { Value = o.ToString(), Caption = EnumTranslator.Translate(typeof(T).Name, o.ToString()) });
			}
		}
	}
}
