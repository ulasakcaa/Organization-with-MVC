﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IImageRepository<T> : IRepositoryBase<T> where T : class
    {

    }
}
