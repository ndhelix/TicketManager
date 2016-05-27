using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Platform.Protocol.ObjectModel.Packages;
using System.ComponentModel;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class ServiceDecorator
	{
		private readonly Service _component;

		[DisplayName("Описание")]
		public string Description { get { return _component.Description; } }

		[DisplayName("Продолжительность действия услуги")]
		public string Duration { get { return Interval(_component.Duration); } }

		[DisplayName("Время оказания услуги")]
		public string Offset { get { return OrdinalDay(_component.Offset); } }

		[DisplayName("Места")]
		public List<PlaceAllocation> PlaceAllocations { get { return _component.PlaceAllocations; } }
		
		[DisplayName("Статус")]
		public ServiceStatus Status { get { return _component.Status; } }

		public ServiceDecorator(Service component)
		{
			_component = component;
		}

		string OrdinalDay(DateTimeSpan offset)
		{
			if (offset == null) return "";
			if (offset.Type != DateTimeSpanTypes.Days) return offset.ToString();
			return offset.Days.ToString() + "-й день";
		}

		string Interval(DateTimeSpan duration)
		{
			if (duration == null) return "";
			string days = RusDeclension("day", duration.Days);
			string nights = RusDeclension("night", duration.Nights);
			string sep = duration.Type == DateTimeSpanTypes.DaysAndNights ? " и " : "";
			string ret = days + sep + nights;

			if (ret == "")
				ret = duration.ToString();
			return ret;
		}

		string RusDeclension(string _word, int? n)
		{
			if (n == null) return "";
			string lastdigit = n.ToString();
			lastdigit = lastdigit[lastdigit.Length-1].ToString();
			string word = "";
			switch (_word)
			{
				case "day":
					switch (lastdigit)
					{
						case "1": word = "день"; break;
						case "2":
						case "3":
						case "4": word = "дня"; break;
						default: word = "дней"; break;
					}
					break;
				case "night":
					switch (lastdigit)
					{
						case "1": word = "ночь"; break;
						case "2":
						case "3":
						case "4": word = "ночи"; break;
						default: word = "ночей"; break;
					}
					break;
			}
			return n.ToString() + " " + word;
		}
	}
}
