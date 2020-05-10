using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Infrastructure.BlobClient
{
    public class BlobClient : IBlobClient
    {
        private readonly CloudStorageAccount _storageAccount;

        public BlobClient(string storageAccountKey, string storageAccountName)
        {
            if (string.IsNullOrEmpty(storageAccountKey))
            {
                throw new ArgumentException("storageAccountKey cannot be null or empty", nameof(storageAccountKey));
            }

            if (string.IsNullOrEmpty(storageAccountName))
            {
                throw new ArgumentException("storageAccountName cannot be null or empty", nameof(storageAccountName));
            }

            _storageAccount = new CloudStorageAccount(
                new StorageCredentials(storageAccountName, storageAccountKey),
                true);
        }

        public async Task<T> ReadBlobAsync<T>(string containerName, string fileName)
        {
            var blobClient = _storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.FetchAttributesAsync();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (var stream = await blockBlob.OpenReadAsync())
            {
                return (T)xmlSerializer.Deserialize(stream);
            }
        }
        public async Task<CloudBlockBlob> ReadBlobAsStreamAsync(string containerName, string fileName)
        {
            var blobClient = _storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.FetchAttributesAsync();
            

            //var stream = await blockBlob.OpenReadAsync();
            return blockBlob;
        }
        public Task<IEnumerable<T>> ReadBlobForListOfAsync<T>(string containerName, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
