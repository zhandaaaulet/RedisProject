using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisProject.Data.Interfaces
{
    public interface IGroupContext
    {
        IDatabase Redis { get; }
    }
}
