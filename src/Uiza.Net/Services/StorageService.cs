using Uiza.Net.Parameters;
using Uiza.Net.Response;
using Uiza.Net.Services.Interface;

namespace Uiza.Net.Services
{
    /// <summary>
    ///
    /// </summary>
    internal class StorageService : Service, IStorageService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual UizaData Create(CreateStogeParameter param)
        {
            return this.PostRequest<UizaData>(Constants.ApiAction.STORAGE, param);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="storageId"></param>
        /// <returns></returns>
        public virtual UizaData Delete(string storageId)
        {
            return this.DeleteRequest<UizaData>(Constants.ApiAction.STORAGE, new RetrieveItemParameter() { Id = storageId });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="storageId"></param>
        /// <returns></returns>
        public virtual UizaData Retrieve(string storageId)
        {
            return this.GetRequest<UizaData>(Constants.ApiAction.STORAGE, new RetrieveItemParameter() { Id = storageId });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual UizaData Update(UpdateStorageParameter param)
        {
            return this.PutRequest<UizaData>(Constants.ApiAction.STORAGE, param);
        }
    }
}