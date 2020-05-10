namespace EbatchSheet.Web.Models
{
    public class BlobStorageFileInfo
    {
        public string FileName { get; set; }
        public string Container { get; set; }
        public string SourceFilePath { get; set; }
    }
    public class BlobStorageData
    {
        public BlobStorageFileInfo BlobStorageFileInfo { get; set; }
    }
}
