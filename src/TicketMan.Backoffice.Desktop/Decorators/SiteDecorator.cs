using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;

namespace TicketMan.Backoffice.Desktop.Decorators
{
    public class SiteDecorator
    {
        private readonly Site _component;

        [DisplayName("SiteSlug")]
        public string SiteSlug { get { return _component.SiteSlug; } }

        [DisplayName("Название")]
        public string Name { get { return _component.Name; } }

        [DisplayName("Организация")]
        public string OrganizationCode { get { return _component.OrganizationCode; } }

        [DisplayName("Активность")]
        public bool IsActive { get { return _component.IsActive; } }

        [DisplayName("Рассылка сообщений")]
        public bool? IsCreatingUserMessageRequired { get { return _component.IsCreatingUserMessageRequired; } }

        [DisplayName("Автоматическая выписка")]
        public string AutoIssues { get
        {
            //if (_component.AutoIssues != null)
              //  return string.Join("; ", _component.AutoIssues.ToArray());
            //else
            {
                return null;
            }
        } 
        }

        
        public SiteDecorator(Site component)
		{
			_component = component;
		}
    }
}
