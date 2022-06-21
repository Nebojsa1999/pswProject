﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSWProjekat.Models;

namespace PSWProjekat.Service.Core
{
    public interface IRefferalService : IBaseService<Refferal>
    {
        public IEnumerable<Refferal> getAll();

    }
}
