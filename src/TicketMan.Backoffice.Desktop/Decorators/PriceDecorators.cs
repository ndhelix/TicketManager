using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using System.ComponentModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Platform.Protocol.ObjectModel.Packages;

namespace TicketMan.Backoffice.Desktop.Decorators
{


	public class PriceDetailsDecorator
	{
		private readonly PriceDetails _component;

		public PriceDetailsDecorator(PriceDetails component)
		{
			_component = component ?? new PriceDetails();
		}

		[DisplayName("Cтоимость с точки зрения юридических лиц")]
		public List<PriceDetail> Details { get { return _component.Details; } }
	
		[DisplayName("Общая стоимость")]
		public decimal Total { get { return decimal.Round(_component.Total, 2); } }

		[DisplayName("Различная информация о стоимости")]
		public List<UnclassifiedPriceDetail> UnclassifiedDetails { get { return _component.UnclassifiedDetails; } }

	}

}