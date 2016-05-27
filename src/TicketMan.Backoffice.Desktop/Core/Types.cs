using TicketMan.Platform.Protocol.ObjectModel.Contracts;

namespace TicketMan.Backoffice.Desktop.Core
{
	public struct ContractAndServiceType
	{
		public ContractType ContractType { get; set; }
		public string ServiceType { get; set; }
	}
}