using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public interface IAsyncDataSource
    {
        Task<List<int>> GetLotsOfDataAsync(int numberOfObjects);
    }
}