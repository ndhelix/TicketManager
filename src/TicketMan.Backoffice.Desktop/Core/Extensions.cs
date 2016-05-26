using System;
using System.Collections.Generic;
using System.Linq;


namespace TicketMan.Backoffice.Desktop.Core
{
	public static class Extensions
	{

		public static string Concatenate<T>(this IEnumerable<T> list, Func<T, string> func)
		{
			return String.Join("; ", list.Select(func).ToArray());
		}

	}
}
