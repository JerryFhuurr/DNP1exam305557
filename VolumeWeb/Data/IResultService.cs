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
    }
}
