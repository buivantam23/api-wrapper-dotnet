﻿using System;
using System.Collections.Generic;
using Uiza.Net.Configuration;
using Uiza.Net.Enums;
using Uiza.Net.Parameters;
using Uiza.Net.Services;
using Uiza.Net.UizaHandleException;

namespace Uiza.NetCore.ConsoleTest
{
    internal class Program
    {

        private static void TestCategory()
        {
            try
            {
                var createResult = UizaServices.Category.Create(new CreateCategoryParameter()
                {
                    Name = string.Format("Category name {0}", Guid.NewGuid().ToString()),
                    Type = CategoryTypes.Folder
                });

                Console.WriteLine(string.Format("Create New Category Id = {0} Success", createResult.Data.id));

                var resultUpdate = UizaServices.Category.Update(new UpdateCategoryParameter()
                {
                    Id = createResult.Data.id,
                    Name = string.Format("Category name {0}", Guid.NewGuid().ToString()),
                    Type = CategoryTypes.PlayList
                });

                Console.WriteLine(string.Format("Update Category Id = {0} Success", resultUpdate.Data.id));

                var retrieveResult = UizaServices.Category.Retrieve((string)createResult.Data.id);
                Console.WriteLine(string.Format("Get Category Id = {0} Success", retrieveResult.Data.id));

                var listResult = UizaServices.Category.List(new BaseParameter());
                Console.WriteLine(string.Format("Success Get List Category, total record {0}", listResult.MetaData.result));

                var listMetadata = new List<string>()
                    {
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                        Guid.NewGuid().ToString(),
                    };

                var entity = UizaServices.Entity.Create(new CreateEntityParameter()
                {
                    Name = "Sample Video",
                    InputType = EntityInputTypes.S3Uiza,
                    URL = ""
                });

                var createCategoryRelationResult = UizaServices.Category.CreateCategoryRelation(new CategoryRelationParameter()
                {
                    EntityId = entity.Data.id,
                    MetadataIds = listMetadata
                });
                Console.WriteLine(string.Format("Create Success Category Relation, total record {0}", createCategoryRelationResult.MetaData.result));

                var deleteCategoryRelationResult = UizaServices.Category.DeleteCategoryRelation(new CategoryRelationParameter()
                {
                    EntityId = entity.Data.id,
                    MetadataIds = listMetadata
                });
                Console.WriteLine(string.Format("Delete Success Category Relation, total record {0}", deleteCategoryRelationResult.MetaData.result));

                var resultDelete = UizaServices.Category.Delete((string)createResult.Data.id);
                Console.WriteLine(string.Format("Delete Category Id = {0} Success", resultUpdate.Data.id));

                UizaServices.Entity.Delete((string)entity.Data.id);
            }
            catch (UizaException ex)
            {
                var result = ex.UizaInnerException.Error;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void TestEntity()
        {
            try
            {
                var result = UizaServices.Entity.Create(new CreateEntityParameter()
                {
                    Name = "Sample Video",
                    InputType = EntityInputTypes.S3Uiza,
                    URL = ""
                });
                Console.WriteLine(string.Format("Create New Entity Id = {0} Success", result.Data.id));

                var getResultRetrieveCategory = UizaServices.Entity.Retrieve((string)result.Data.id);
                Console.WriteLine(string.Format("Get Entity Id = {0} Success", getResultRetrieveCategory.Data.id));

                var getResultRetrieveCategoryList = UizaServices.Entity.List(new RetrieveListEntitiesParameter() { publishToCdn = EntityPublishStatus.Success });
                Console.WriteLine(string.Format("Success Get EntitiesList, total record {0}", getResultRetrieveCategoryList.MetaData.result));

                var resultUpdateCategory = UizaServices.Entity.Update(new UpdateEntityParameter()
                {
                    Id = result.Data.id,
                    Name = "Sample update",
                    Description = "Description update",
                    ShortDescription = "ShortDescription update",
                    Poster = "/example.com/updatePoster",
                    Thumbnail = "/example.com/updateThumbnail"
                });

                var getAwsUploadKey = UizaServices.Entity.GetEntityAWSUploadKey();
                Console.WriteLine(string.Format("Get AWS Upload Key Success : temp_access_id = {0} ", getAwsUploadKey.Data.temp_access_id));

                var publishEntity = UizaServices.Entity.PublishEntity((string)result.Data.id);
                Console.WriteLine(string.Format("Publish Entity Success : entityId = {0} ", publishEntity.Data.entityId));

                var getStatusPublish = UizaServices.Entity.GetEntityStatusPublish((string)result.Data.id);
                Console.WriteLine(string.Format("Get Status Publish Success : temp_access_id = {0} ", getStatusPublish.Data.status));

                var searchEntity = UizaServices.Entity.SearchEntity("Sample");
                Console.WriteLine(string.Format("Search Success, , total record {0}", searchEntity.Data.Count));

                var deleteEntity = UizaServices.Entity.Delete((string)result.Data.id);
                Console.WriteLine(string.Format("Delete Entity Id = {0} Success", deleteEntity.Data.id));
            }
            catch (UizaException ex)
            {
                var result = ex.UizaInnerException.Error;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void TestStorage()
        {
            try
            {
                var result = UizaServices.Storage.Create(new CreateStorageParameter()
                {
                    Name = "FTP Uiza",
                    Host = "ftp-example.uiza.io",
                    Description = "FTP of Uiza, use for transcode",
                    StorageType = StorageInputTypes.Ftp,
                    UserName = "uiza",
                    Password = "=59x@LPsd+w7qW",
                    Port = 21
                });
                Console.WriteLine(string.Format("Create New Storage Id = {0} Success", result.Data.id));

                var getResultRetrieveStorage = UizaServices.Storage.Retrieve((string)result.Data.id);
                Console.WriteLine(string.Format("Get Storage Id = {0} Success", getResultRetrieveStorage.Data.id));

                var resultUpdateStorage = UizaServices.Storage.Update(new UpdateStorageParameter()
                {
                    Id = result.Data.id,
                    Name = "FTP Uiza Update",
                    Host = "ftp-example.uiza.io",
                    Description = "FTP of Uiza, use for transcode Update",
                    StorageType = StorageInputTypes.S3,
                    UserName = "uizaUpdate",
                    Password = "=59x@LPsd+w7qW",
                    AwsAccessKey = "ASIAV*******GPHO2DTZ",
                    AwsSecretKey = "dp****cx2mE2lZxsSq7kV++vWSL6RNatAhbqc",
                    Port = 22
                });
                Console.WriteLine(string.Format("Update Storage Id = {0} Success", resultUpdateStorage.Data.id));

                var deleteStorage = UizaServices.Storage.Delete((string)result.Data.id);
                Console.WriteLine(string.Format("Delete Storage Id = {0} Success", deleteStorage.Data.id));
            }
            catch (UizaException ex)
            {
                var result = ex.UizaInnerException.Error;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                UizaConfiguration.SetupUiza(new UizaConfigOptions
                {
                    ApiKey = "",
                    ApiBase = "https://apiwrapper.uiza.co"
                });
                TestEntity();
                TestCategory();
                TestStorage();
                Console.ReadLine();
            }
            catch (UizaException ex)
            {
                var result = ex.UizaInnerException.Error;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}