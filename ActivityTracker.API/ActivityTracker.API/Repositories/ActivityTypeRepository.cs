using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ActivityTracker.API.Repositories
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly IEntityModel _db;

        public ActivityTypeRepository(IEntityModel db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ActivityType>> GetActivityTypes()
        {
            try
            {
                return await _db.ActivityTypes.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}