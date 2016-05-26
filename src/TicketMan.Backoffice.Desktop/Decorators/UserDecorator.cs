using System;
using System.Collections.Generic;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Profile;
using System.ComponentModel;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class UserDecorator
	{
		protected User _component;

		[DisplayName("Глобальный идентификатор")]
		public long Id { get { return _component.Id; } }

		[DisplayName("Идентификатор контрагента")]
		public long PartyId { get { return _component.PartyId; } }

		[DisplayName("E-mail (логин)")]
		public string EmailAddress { get { return _component.EmailAddress; } }

		//[DisplayName("Сайт")]
		//public string SiteSlug { get { return _component.SiteSlug; } }

		[DisplayName("Имя")]
		public string FirstName { get { return _component.FirstName; } }

		[DisplayName("Фамилия")]
		public string LastName { get { return _component.LastName; } }

		[DisplayName("Номера телефонов")]
		public string PhoneNumbers
		{
			get
			{
				if (_component.PhoneNumbers != null)
					return string.Join("; ", _component.PhoneNumbers.ToArray());
				else
					return null;
			}
		}

		[DisplayName("Организация")]
		public string OrganizationCode { get
		{
		    return _component.Type == UserType.Customer
		               ? "[Физ. лицо]"
		               : _component.OrganizationCode;
		} }

		//[DisplayName("Внешний идентификатор")]
		//public string ExternalId { get { return _component.ExternalId; } }

		//[DisplayName("Тип")]
		//public string Type { get { return EnumTranslator.Translate("UserType", _component.Type.ToString()); } }

		//[DisplayName("Роли")]
		//public string Roles { get { return _component.Roles.Concatenate(i => i.Name); } }

		//[DisplayName("Права пользователя")]
		//public string Permissions { get { return _component.Permissions.Concatenate(i => i.Name); } }


		public UserDecorator(User component)
		{
			_component = component;
		}
	}

    public class AgencyUserDecorator : UserDecorator
    {
        public AgencyUserDecorator(User component)
            : base(component)
        {
            _component = component;
        }

        [DisplayName("Сайт")]
        public string SiteSlug { get { return _component.SiteSlug; } }
    }
}
