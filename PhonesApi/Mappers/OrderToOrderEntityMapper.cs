using DbModels.Models;
using PhonesApi.Models;

namespace PhonesApi.Mappers
{
	public class OrderToOrderEntityMapper: IMapper<InOrder, Order>
	{
		public Order Map(InOrder order)
		{
			var dbOrder = new Order();
			dbOrder.UserId = order.Username;
			return dbOrder;
		}
	}
}