using System.ComponentModel;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;
using System.Collections.Generic;
using TicketMan.Platform.Protocol.ObjectModel.Finances;
using TicketMan.Platform.Protocol.ObjectModel.Packages;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class ArrangementDecorator
	{
		private readonly Arrangement _component;

		public ArrangementDecorator(Arrangement component)
		{
			_component = component;
		}

		[DisplayName("Описание")]
		public string Description { get { return _component.Description; } }

		private List<DealInfo> _deals;
		[DisplayName("Cделки")]
		public List<DealInfo> Deals { get { return _deals ?? (_deals = Utils.IList2LIst(_component.Deals) ?? null); } }

		//[DisplayName("Уникальный в пределах заявки идентификатор")]
		//public long ID { get { return _component.ID; } }

		[DisplayName("Детализация цены")]
		public List<PriceDetailsDecorator> PriceDetails
		{
			get
			{
				//return new PriceDetailsDecorator(_component.PriceDetails);

				return new List<PriceDetailsDecorator> { new PriceDetailsDecorator(_component.PriceDetails) };
			}
		}

		private List<ServiceArrangement> _serviceArrangements;
		[DisplayName("Cписок распределений услуг")]
		public List<ServiceArrangement> ServiceArrangements { get { return _serviceArrangements ?? (_serviceArrangements = _component.ServiceArrangements ?? null); } }

	}
}

