using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Benday.EasyAuthDemo.Api.AzureStorage
{

    public class AzureBlobImageStorageHelper : IAzureBlobImageSasTokenGenerator
    {
        private AzureBlobImageStorageOptions _Options;
        
        public AzureBlobImageStorageHelper(IOptionsMonitor<AzureBlobImageStorageOptions> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            
            _Options = options.CurrentValue;
        }
        
        public Uri GetBlobUriWithSasToken(string containerName, string blobName)
        {
            var builder = new BlobSasBuilder();
            
            builder.BlobContainerName = containerName;
            
            if (blobName.StartsWith("/") == true)
            {
                blobName = blobName.Substring(1);
            }
            
            string containerPrefix = containerName + "/";
            
            if (blobName.StartsWith(containerPrefix) == true)
            {
                blobName = blobName.Substring(containerPrefix.Length);
            }
            
            builder.BlobName = blobName;
            
            builder.SetPermissions(BlobSasPermissions.Read);
            
            builder.ExpiresOn = DateTime.UtcNow.AddSeconds(
            _Options.ReadTokenExpirationInSeconds);
            
            var credentials = GetAzureCredentials();
            
            var parameters = builder.ToSasQueryParameters(credentials);
            
            var token = parameters.ToString();
            
            string path;
            
            if (_Options.UseDevelopmentStorage == true)
            {
                path = string.Format("{0}/{1}/{2}",
                credentials.AccountName, containerName, blobName);
            }
            else
            {
                path = string.Format("{0}/{1}", containerName, blobName);
            }
            UriBuilder fullUri = new UriBuilder(BlobServiceClientInstance.Uri)
            {
                Path = path,
                Query = token
            };
            
            return fullUri.Uri;
        }
        
        public Uri GetBlobUri(string containerName, string blobName)
        {
            var builder = new BlobSasBuilder();
            
            builder.BlobContainerName = containerName;
            
            if (blobName.StartsWith("/") == true)
            {
                blobName = blobName.Substring(1);
            }
            
            string containerPrefix = containerName + "/";
            
            if (blobName.StartsWith(containerPrefix) == true)
            {
                blobName = blobName.Substring(containerPrefix.Length);
            }
            
            var credentials = GetAzureCredentials();
            
            string path;
            
            if (_Options.UseDevelopmentStorage == true)
            {
                path = string.Format("{0}/{1}/{2}",
                credentials.AccountName, containerName, blobName);
            }
            else
            {
                path = string.Format("{0}/{1}", containerName, blobName);
            }
            
            UriBuilder fullUri = new UriBuilder(BlobServiceClientInstance.Uri)
            {
                Path = path
            };
            
            return fullUri.Uri;
        }
        
        private BlobServiceClient _BlobServiceClientInstance;
        private BlobServiceClient BlobServiceClientInstance
        {
            get
            {
                if (_BlobServiceClientInstance == null)
                {
                    if (_Options.UseDevelopmentStorage == true)
                    {
                        _BlobServiceClientInstance =
                        new BlobServiceClient("UseDevelopmentStorage=true");
                    }
                    else
                    {
                        var endpoint = new Uri(
                        String.Format(
                        "https://{0}.blob.core.windows.net",
                        _Options.AccountName));
                        
                        _BlobServiceClientInstance =
                        new BlobServiceClient(endpoint,
                        GetAzureCredentials());
                    }
                }
                
                return _BlobServiceClientInstance;
            }
        }
        
        private StorageSharedKeyCredential GetAzureCredentials()
        {
            if (_Options.UseDevelopmentStorage == true)
            {
                string accountName = "devstoreaccount1";
                string accountKey = "Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==";
                
                var temp = new StorageSharedKeyCredential(
                accountName, accountKey);
                
                return temp;
            }
            else
            {
                if (String.IsNullOrWhiteSpace(_Options.AccountName) == true)
                {
                    throw new InvalidOperationException(
                    "Azure account name is not configured.");
                }
                
                if (String.IsNullOrWhiteSpace(_Options.AccountKey) == true)
                {
                    throw new InvalidOperationException(
                    "Azure account key is not configured.");
                }
                
                var temp = new StorageSharedKeyCredential(
                _Options.AccountName, _Options.AccountKey);
                
                return temp;
            }
        }
    }
}
