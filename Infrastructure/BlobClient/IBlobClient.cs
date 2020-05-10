using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Infrastructure.BlobClient
{
    public interface IBlobClient
    {
        Task<T> ReadBlobAsync<T>(string containerName, string fileName);
        Task<IEnumerable<T>> ReadBlobForListOfAsync<T>(string containerName, string fileName);

        Task<CloudBlockBlob> ReadBlobAsStreamAsync(string containerName, string fileName);
    }
}
