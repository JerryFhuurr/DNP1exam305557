using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolumeWeb.VolumeCalculator;

namespace VolumeWeb.Data
{
    public interface IResultService
    {
        Task<IList<VolumeResult>> GetResultsAsync();
        Task AddCylinderResultAsync(VolumeCalculator.VolumeCalculator calculator);
        Task AddConeResultAsync(VolumeCalculator.VolumeCalculator calculator);
        Task RemoveVolumeResultAsync(int Id);
        Task AddCylinderResultAsync2([FromQuery] double r, [FromQuery] double h);
        Task AddConeResultAsync2([FromQuery] double r, [FromQuery] double h);
    }
}
