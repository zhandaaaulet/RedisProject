using RedisProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisProject.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> GetGroup(string name);
        Task<Group> UpdateGroup(Group group);
        Task<bool> DeleteGroup(string name);
    }
}
