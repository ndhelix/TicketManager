using System;
using System.Collections.Generic;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using DevExpress.XtraTreeList.Nodes;

namespace TicketMan.Backoffice.Desktop
{
  public partial class FrmMain : DevExpress.XtraEditors.XtraForm
  {
    OrdersInfoRequest _ordersInfoRequest;
    PaymentReportsRequest _paymentReportsRequest;

    OrdersInfoRequest GetOrdersInfoRequest()
    {
			if (_ordersInfoRequest == null)
			{
				_ordersInfoRequest = new OrdersInfoRequest {BuyersID = new List<long>()};
			}
			_ordersInfoRequest.Statuses.Clear();
			_ordersInfoRequest.UniqueNumber = null;

			if (txtOrderNumberFilter.Text != "")
			{
				_ordersInfoRequest.CreatedOnFrom = null;
				_ordersInfoRequest.CreatedOnTo = null;

				_ordersInfoRequest.UniqueNumber = txtOrderNumberFilter.Text;
				return _ordersInfoRequest;
			}
			
		_ordersInfoRequest.CreatedOnFrom = dateRangeControl_Orders.From;
		_ordersInfoRequest.CreatedOnTo = dateRangeControl_Orders.To;

      foreach (object o in ccboOrderStatus.Properties.Items.GetCheckedValues())
      {
				_ordersInfoRequest.Statuses.Add((OrderStatus)Enum.Parse(typeof(OrderStatus), o.ToString(), true));
			}
			if (_ordersInfoRequest.Statuses.Count > 12)
				_ordersInfoRequest.Statuses.Clear();

      if (cbIgnoreBuyerFilter.Checked)
				_ordersInfoRequest.BuyersID.Clear();
      else
				if (treeBuyers.Selection.Count > 0)
				{
					//if (_ordersInfoRequest.BuyersID == null)
						//_ordersInfoRequest.BuyersID = new List<long>();
					_ordersInfoRequest.BuyersID.Clear();
					foreach (TreeListNode node in treeBuyers.Selection)
					{
						int a = 0;
						string s = node.RootNode.GetDisplayText(2);
						if (Int32.TryParse(s, out a))
						{
							_ordersInfoRequest.BuyersID.Add(a);
						}
					}
				}
    	return _ordersInfoRequest;
    }

    PaymentReportsRequest GetPaymentReportsRequest()
    {
      if (_paymentReportsRequest == null)
        _paymentReportsRequest = new PaymentReportsRequest();

	  _paymentReportsRequest.OrderUniqueNumber = null;

	  if (txtOrderNumberFilter2.Text != "")
	  {
		  _paymentReportsRequest.CreatedOnFrom = null;
		  _paymentReportsRequest.CreatedOnTo = null;

		  _paymentReportsRequest.OrderUniqueNumber = txtOrderNumberFilter2.Text;
		  return _paymentReportsRequest;
	  }
      _paymentReportsRequest.CreatedOnFrom = dateRangeControl_PaymentReports.From;
      _paymentReportsRequest.CreatedOnTo = dateRangeControl_PaymentReports.To;

     return _paymentReportsRequest;
    }

		void SetOrderFilterCommonGroup(bool b)
		{
			cbIgnoreBuyerFilter.Enabled = dateRangeControl_Orders.Enabled = ccboOrderStatus.Enabled	= b;
			if (!b || !cbIgnoreBuyerFilter.Checked)
				treeBuyers.Enabled = b;
		}

  }
}