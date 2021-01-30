using Newtonsoft.Json;
using RedisProject.Data.Interfaces;
using RedisProject.Entities;
using RedisProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisProject.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IGroupContext _context;

        public GroupRepository(IGroupContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<Group> GetGroup(string name)
        {
            var group = await _context.Redis.StringGetAsync(name);
            if (group.IsNullOrEmpty)
            {
                return null;
            }
            try
            {
                return JsonConvert.DeserializeObject<Group>(group);
            }
            catch (Exception)
            {

                return null;
            }


        }

        public async Task<Group> UpdateGroup(Group group)
        {
            var updated = await _context.Redis.StringSetAsync(group.Name, JsonConvert.SerializeObject(group));
            if (!updated)
            {
                return null;
            }

            return await GetGroup(group.Name);
        }

        public async Task<bool> DeleteGroup(string name)
        {
            return await _context.Redis.KeyDeleteAsync(name);
        }
    }
}
