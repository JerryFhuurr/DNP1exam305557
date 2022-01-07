using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolumeWebService.Persistence;
using VolumeWebService.VolumeCalculator;

namespace VolumeWebService.Data
{
    public class SqliteResultService : IResultService
    {
        private ResultDbContext ctx;

        public SqliteResultService(ResultDbContext ctx) { this.ctx = ctx; }

        public async Task<VolumeResult> AddResultAsync(VolumeResult result)
        {
            EntityEntry<VolumeResult> newlyAdded = await ctx.Results.AddAsync(result);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<IList<VolumeResult>> GetResultsAsync()
        {
            return await ctx.Results.ToListAsync();
        }

        public async Task RemoveVolumeResultAsync(int Id)
        {
            VolumeResult toDelete = await ctx.Results.FirstOrDefaultAsync(r => r.Id == Id);
            if (toDelete != null)
            {
                ctx.Results.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
