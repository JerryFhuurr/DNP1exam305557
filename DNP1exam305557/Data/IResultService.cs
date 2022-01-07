using System.Collections.Generic;
using System.Threading.Tasks;
using VolumeWebService.VolumeCalculator;

namespace VolumeWebService.Data
{
    public interface IResultService
    {
        Task<IList<VolumeResult>> GetResultsAsync();
        Task<VolumeResult> AddResultAsync(VolumeResult result);
        Task RemoveVolumeResultAsync(int Id);
    }
}
