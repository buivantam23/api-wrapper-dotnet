using Uiza.Net.Parameters;
using Uiza.Net.Response;

namespace Uiza.Net.Services.Interface
{
    /// <summary>
    ///
    /// </summary>
    public interface IStorageService : IBaseServices,
        ICreate<UizaData, CreateStogeParameter>,
        IRetrieve<UizaData>,
        IUpdate<UizaData, UpdateStorageParameter>,
        IDelete<UizaData>
    {
    }
}