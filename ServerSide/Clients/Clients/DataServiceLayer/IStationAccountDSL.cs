﻿using Shared.DataServiceLayer;
using Shared.Entities;
using Shared.Entities.Credit;
using Shared.Entities.Debit;
using Shared.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.DataServiceLayer
{
    public interface IStationAccountDSL : ICRUDOperationsDSL<StationAccountDTO>
    {
        Task<Response> GetAllByStationId(long stationId, DataSource dataSource);
    }
}
