using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos;
using Domain.Commands;
using Domain.Entities;

namespace Application.Dtos
{
    public static class BatchsheetExtensions
    {

        public static CreateEbatchSheetCommand ToCreateCommand(this BatchsheetDto batchsheetDto)
        {
            return new CreateEbatchSheetCommand()
            {
                WorkOrderNumber = batchsheetDto.worder?.wonbr,
                WorkOrderId = batchsheetDto.worder?.woid,
                //WorkOrderArticle = batchsheetDto.Worder?.Woarticle,
                WorkOrderPartDesciption = $"{batchsheetDto.worder?.wopart} : {batchsheetDto.worder?.wodesc}",
                WorkOrderPart = batchsheetDto.worder?.wopart,
                PackDate = (batchsheetDto.worder?.packdate.Count == 0) ? string.Empty : string.Join(" ",batchsheetDto.worder?.packdate),
                QuantityRequired = (string.IsNullOrEmpty(batchsheetDto.worder?.qtyreq)) ? 0 : double.Parse(batchsheetDto.worder?.qtyreq),
                PackageSize = batchsheetDto.worder?.packsize,
                QCSample = batchsheetDto.worder?.qcsample,
                IssuedBy = batchsheetDto.worder?.useremail,
                ManufacturingComment = string.Join(" ", batchsheetDto.worder?.mfgcmmt),
                BestBeforeComment = string.Join(" ", batchsheetDto.worder?.bbcmmt),
                EndDateComment = string.Join(" ", batchsheetDto.worder?.edcmmt),
                GridBulkItem = GetBulkItemList(batchsheetDto),
                GridPrePrint = GetPrePrintList(batchsheetDto),
                GridPackaging = GetPackagingList(batchsheetDto),
                Group100101Description = GetGroupComment(batchsheetDto.worder?.group100?.grp100cmt),
                GroupBComment = GetGroupComment(batchsheetDto.worder?.groupb?.grpbcmt),
                GroupCComment = GetGroupComment(batchsheetDto.worder?.groupc?.grpccmt),
                GroupDComment = GetGroupComment(batchsheetDto.worder?.groupd?.grpdcmt),
                GroupEComment = GetGroupComment(batchsheetDto.worder?.groupe?.grpecmt),
                Group170Comment = batchsheetDto.worder?.group170?.grp170cmt + " : " + batchsheetDto.worder?.group171?.grp171cmt,
                Group161Description = GetGroupComment(batchsheetDto.worder?.group161?.grp161cmt),
                DataGridGroupA = GetDataGridGroupA(batchsheetDto.worder.groupa)
            };
        }

        private static List<DataGridGroupA> GetDataGridGroupA(batchsheetWorderGroupa groupa)
        {
            var dataGridGroupAList = new List<DataGridGroupA>();
            if (groupa != null)
            {
                foreach (var item in groupa.groupAItems)
                {
                    DataGridGroupA dataGridGroupA = new DataGridGroupA()
                    {
                        LeftComment = item.leftdesc,
                        RightComment = item.rightdesc,
                    };
                    dataGridGroupAList.Add(dataGridGroupA);

                }
            }

            return dataGridGroupAList;
        }

        private static List<string> GetGroupComment(List<string> groupCommentList)
        {
            var descList = new List<string>();
            if (groupCommentList != null)
            {
                foreach (var item in groupCommentList)
                {
                    descList.Add(item);
                }
            }

            return descList;
        }

        private static List<Domain.Entities.GridPackaging> GetPackagingList(BatchsheetDto batchsheetDto)
        {
            var gridPackagingList = new List<Domain.Entities.GridPackaging>();
            if (batchsheetDto.worder?.packaging.Count > 0)
            {
                foreach (var item in batchsheetDto.worder?.packaging)
                {
                    var packagingItem = new Domain.Entities.GridPackaging()
                    {
                        GridPackagingPartNo = item.part,
                        GridPackagingDescription = item.desc
                    };
                    gridPackagingList.Add(packagingItem);
                }
            }
            return gridPackagingList;
        }

        private static List<Domain.Entities.GridPrePrint> GetPrePrintList(BatchsheetDto batchsheetDto)
        {
            var gridPrePrintList = new List<GridPrePrint>();
            if (batchsheetDto.worder.preprint != null)
            {
                var gridPrePrint = new GridPrePrint()
                {
                    GridPrePrintPartNo = batchsheetDto.worder?.preprint.ppdet?.part,
                    GridPrePrintDescription = batchsheetDto.worder?.preprint.ppdet?.desc
                };
                gridPrePrintList.Add(gridPrePrint);
            }
            return gridPrePrintList;
        }

        private static List<Domain.Entities.GridBulkItem> GetBulkItemList(BatchsheetDto batchsheetDto)
        {
            var gridBulkItemList = new List<Domain.Entities.GridBulkItem>();
            if (batchsheetDto.worder.bulkitem != null)
            {
                var gridBulkItem = new Domain.Entities.GridBulkItem()
                {
                    GridBulkPartNo = batchsheetDto.worder.bulkitem?.bulkdet?.part,
                    GridBulkDescription = batchsheetDto.worder.bulkitem?.bulkdet?.desc
                };
                gridBulkItemList.Add(gridBulkItem);
            }
            return gridBulkItemList;
        }
    }
}
