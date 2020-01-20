using DbModels.Models;
using PhonesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesApi.Mappers
{
	interface IMapperService: IMapper<InOrder, Order>
	{
	}
}
