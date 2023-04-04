﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IBankAccountsRepository : ICommandRepository<CreditCard>, IRepository<CreditCard>
    {

    }
}