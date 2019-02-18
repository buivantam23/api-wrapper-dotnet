using Uiza.Net.Services.Interface;

namespace Uiza.Net.Services
{
    /// <summary>
    ///
    /// </summary>
    public static class UizaServices
    {
        #region PUBLIC PROPERTIES

        /// <summary>
        ///
        /// </summary>
        public static IEntityService Entity
        {
            get
            {
                if (_entity == null)
                    _entity = new EntityService();
                return _entity;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public static IStorageService Storage
        {
            get
            {
                if (_storage == null)
                    _storage = new StorageService();
                return _storage;
            }
        }

        #endregion PUBLIC PROPERTIES

        #region PRIVATE PROPERTY

        private static IEntityService _entity;
        private static IStorageService _storage;

        #endregion PRIVATE PROPERTY
    }
}