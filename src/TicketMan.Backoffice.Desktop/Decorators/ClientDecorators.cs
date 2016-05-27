using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using TicketMan.Platform.Protocol.Extensions;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;
using System.Collections.Generic;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Backoffice.Desktop.Core;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class ClientDecorator
	{
		private readonly Client _component;
		private readonly ServiceType _serviceType;
		private Arrangement _arrangement;
		private List<ArrangementDecorator> _arrangements;

		public ClientDecorator(Client component, Arrangement arrangement, ServiceType serviceType)
		{
			_component = component;
			_serviceType = serviceType;
			_arrangement = arrangement;
		}

		[DisplayName("Гражданство")]
		public string Citizenship { get { return _component.Citizenship.Russian; } }

		//[DisplayName("Идентификатор страны")]
		//public long? CitizenshipCountryID { get { return _component.CitizenshipCountryID; } }

		[DisplayName("Контактная информация")]
		public List<Contacts> Contacts { get { return new List<Contacts> { _component.Contacts }; } }

		[DisplayName("Дата рождения")]
		public Date? DateOfBirth { get { return _component.DateOfBirth; } }


		[DisplayName("Уникальный идентификатор")]
		public long ID { get { return _component.ID; } }

		private string _fio;
		[DisplayName("ФИО")]
		public string FIO
		{
			get
			{
				if (_fio == null)
				{
					string fioru = _component.LastName.Russian + " " + _component.FirstName.Russian + " " + _component.PatronymicName;
					fioru = fioru.Trim();
					string fioen = _component.FirstName.English + " " + _component.LastName.English;
					fioen = fioen.Trim();
					string sep = fioru.Length * fioen.Length == 0 ? "" : " / ";
					_fio = fioru + sep + fioen;
				}
				return _fio;
			}
		}

		//[DisplayName("Имя")]
		//public string FirstName { get { return _component.FirstName.English + " / " + _component.FirstName.Russian; } }
		//[DisplayName("Фамилия")]
		//public string LastName { get { return _component.LastName.English + " / " + _component.LastName.Russian; } }
		//[DisplayName("Отчество")]
		//public string PatronymicName { get { return _component.PatronymicName; } }

		private List<PassportDecorator> _passports;
		[DisplayName("Паспорта")]
		public List<PassportDecorator> Passports
		{
			get
			{
				return _passports ?? (_passports = _component.Passports != null
												? _component.Passports.ConvertAll(x => new PassportDecorator(x))
												: null);
			}
		}


		[DisplayName("Пол")]
		public Sex Sex { get { return _component.Sex; } }

		private List<KeyValuePair> _extensions;
		[DisplayName("Дополнительная информация")]
		public List<KeyValuePair> Extensions
		{
			get
			{
				if (_extensions == null)
					switch (_serviceType)
					{
						case ServiceType.Flights:
							_extensions = Utils.ParseExtensions(_component.Extensions);
							//var ext = _component.Extensions ?? null; 
							//var 

							break;
						default:
							_extensions = null;
							break;
					}
				return _extensions;
				//FlightClient
			}
			set { throw new System.NotImplementedException(); }
		}


		[DisplayName("Услуга")]
		public List<ArrangementDecorator> Arrangements
		{
			get
			{
				return _arrangements ??
							 (_arrangements = new List<ArrangementDecorator> { new ArrangementDecorator(_arrangement) }
							 );
			}
		}
	}

	public class PassportDecorator
	{
		private readonly Passport _component;
		public PassportDecorator(Passport component)
		{
			_component = component;
		}

		[DisplayName("Истекает")]
		public Date? ExpiresOn { get { return _component.ExpiresOn; } }

		[DisplayName("Выдан")]
		public string IssuedBy { get { return _component.IssuedBy; } }
	
		[DisplayName("Дата выдачи")]
		public Date? IssuedOn { get { return _component.IssuedOn; } }
		
		[DisplayName("Номер")]
		public string Number { get { return _component.Number; } }
		
		[DisplayName("Серия")]
		public string Series { get { return _component.Series; } }
		
		[DisplayName("Тип")]
		public string Type { get { return EnumTranslator.Translate("PassportType", _component.Type.ToString()); } }

	}
}
