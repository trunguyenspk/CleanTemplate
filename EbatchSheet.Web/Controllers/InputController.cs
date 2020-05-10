using Application.Dtos;
using EbatchSheet.Web.Models;
using Infrastructure.BlobClient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EbatchSheet.Web.Controllers
{
    public class InputController : ApiController
    {
        private readonly IBlobClient _blobClient;

        public InputController(IBlobClient blobClient)
        {
            _blobClient = blobClient;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFromBlob(BlobStorageData blobStorageData)
        {
            var blobStorageFileInfo = blobStorageData.BlobStorageFileInfo;
            var cloudblob = await _blobClient.ReadBlobAsStreamAsync(blobStorageFileInfo.Container, blobStorageFileInfo.FileName);
            using (var stream = await cloudblob.OpenReadAsync())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BatchsheetDto));
                var batchSheetDto = (BatchsheetDto)xmlSerializer.Deserialize(stream);
                StreamReader reader = new StreamReader(stream);
                stream.Position = 0;
                var fileContent = reader.ReadToEnd();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(fileContent);
                if (xml.SelectNodes("//groupa").Count > 0)
                {
                    XmlNodeList xnLeftDescList = xml.SelectNodes("//leftdesc");
                    XmlNodeList xnRightDescList = xml.SelectNodes("//rightdesc");
                    XmlNodeList xnGrpACmtList = xml.SelectNodes("//grpacmt/comment");
                    List<groupAItem> list = new List<groupAItem>();
                    batchsheetWorderGroupa groupa = new batchsheetWorderGroupa()
                    {
                        groupAItems = list
                    };
                    foreach (XmlNode xn in xnLeftDescList)
                    {
                        string test = xn.InnerText;
                        groupAItem item = new groupAItem
                        {
                            leftdesc = xn.InnerText
                        };
                        list.Add(item);
                    }
                    int i = 0;
                    foreach (var item in list)
                    {
                        item.rightdesc = xnRightDescList[i].InnerText;
                        item.grpacmt = new batchsheetWorderGroupaGrpacmt()
                        {
                            comment = xnGrpACmtList[i].InnerText
                        };
                        i++;
                    }
                    batchSheetDto.worder.groupa = groupa;
                }

                var command = batchSheetDto.ToCreateCommand();
                await Mediator.Send(command);

                return Ok();
            }
        }

    }
}
