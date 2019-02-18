## Storage
You can add your storage (FTP, AWS S3) with UIZA. After synced, you can select your content easier from your storage to create entity.
See details [here](https://docs.uiza.io/#storage).

## Add a storage
You can sync your storage (FTP, AWS S3) with UIZA. After synced, you can select your content easier from your storage to create entity.
See details [here](https://docs.uiza.io/#add-a-storage).

```Cshard
using Uiza.Net.Services;

UizaConfiguration.SetupUiza(new UizaConfigOptions
{
	ApiKey = "your-ApiKey",
	ApiBase = "your-workspace-api-domain.uiza.co"
});

var result = UizaServices.Storage.Create(new CreateStogeParameter()
{
    Name = "FTP Uiza",
    Host = "ftp-example.uiza.io",
    Description = "FTP of Uiza, use for transcode",
    StorageType = StorageInputTypes.Ftp,
    UserName = "uiza",
    Password = "=59x@LPsd+w7qW",
    Port = 21
});
Console.WriteLine(string.Format("Add New Storage Id = {0} Success", result.Data.id));
```

## Retrieve a storage
Get information of your added storage (FTP or AWS S3)
See details [here](https://docs.uiza.io/#retrieve-a-storage).

```Cshard
using Uiza.Net.Services;

UizaConfiguration.SetupUiza(new UizaConfigOptions
{
	ApiKey = "your-ApiKey",
	ApiBase = "your-workspace-api-domain.uiza.co"
});

var result = UizaServices.Storage.Retrieve("Storage Id");
Console.WriteLine(string.Format("Get Storage Id = {0} Success", result.Data.id));
```

## Update storage
Update storage's information
See details [here](https://docs.uiza.io/#update-storage).

```Cshard
using Uiza.Net.Services;

UizaConfiguration.SetupUiza(new UizaConfigOptions
{
	ApiKey = "your-ApiKey",
	ApiBase = "your-workspace-api-domain.uiza.co"
});

var result =uizaServices.Storage.Update(new UpdateStorageParameter()
{
	Id = "Entity Id",
    Name = "FTP Uiza Update",
    Host = "ftp-example.uiza.io",
    Description = "FTP of Uiza, use for transcode Update",
    StorageType = StorageInputTypes.S3,
    AwsAccessKey = "ASIAV*******GPHO2DTZ",
    AwsSecretKey = "dp****cx2mE2lZxsSq7kV++vWSL6RNatAhbqc",
    Port = 22
});
Console.WriteLine(string.Format("Update Storage Id = {0} Success", result.Data.id));
```

## Remove storage
Remove storage that added to Uiza
See details [here](https://docs.uiza.io/#remove-storage).

```Cshard
using Uiza.Net.Services;

UizaConfiguration.SetupUiza(new UizaConfigOptions
{
	ApiKey = "your-ApiKey",
	ApiBase = "your-workspace-api-domain.uiza.co"
});

var result = UizaServices.Storage.Delete("Storage Id");
Console.WriteLine(string.Format("Remove Storage Id = {0} Success", result.Data.id));
```

