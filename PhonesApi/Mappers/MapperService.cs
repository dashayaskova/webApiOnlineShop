using System;
using DbModels.Models;
using PhonesApi.Models;

namespace PhonesApi.Mappers
{
	public class MapperService : IMapperService
	{
		private readonly IMapper<InOrder, Order> _orderToOrderEntityMapper;

		public MapperService(IMapper<InOrder, Order> orderToOrderEntityMapper)
		{
			_orderToOrderEntityMapper = orderToOrderEntityMapper ?? throw new ArgumentNullException(nameof(orderToOrderEntityMapper));
		}

		public Order Map(InOrder entity)
		{
			return _orderToOrderEntityMapper.Map(entity);
		}
	}
}