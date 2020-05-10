using Domain.Entities;
using Domain.Enumerations;
using System;
using System.Collections.Generic;
using Domain.Entities;
using Application.Common.Extensions;

namespace Application.Common.Models
{
    public class EbatchSheetVm
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }
        public string EbatchVersion { get; set; }
        public EbatchState CurrentState { get; set; }
        public EbatchState NextState { get; set; }
        public string WorkOrderId { get; set; }
        public string WorkOrderNumber { get; set; }
        public string WorkOrderPart { get; set; }
        public string WorkOrderPartDesciption { get; set; }
        public string WorkOrderArticle { get; set; }
        public string Panel9Signature { get; set; }
        public string Panel9Signature2 { get; set; }
        public string ReconciliationCompletedbySignature { get; set; }
        public double QuantityRequired { get; set; }
        public string QCSample { get; set; }
        public string BestBeforeComment { get; set; }
        public string EndDateComment { get; set; }
        public string PackageSize { get; set; }
        public string GroupBComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string PackDate { get; set; }
        public DateTime BatchStartDate { get; set; }
        public string ManufacturingComment { get; set; }

        private List<GridBulkItem> gridBulkItem;
        public List<GridBulkItem> GridBulkItem { get => gridBulkItem.IsNullOrEmpty() ? new List<GridBulkItem>() { new GridBulkItem() } : gridBulkItem; set => gridBulkItem = value; }

        private List<GridPrePrint> gridPrePrint;
        public List<GridPrePrint> GridPrePrint { get => gridPrePrint.IsNullOrEmpty() ? new List<GridPrePrint>() { new GridPrePrint() } : gridPrePrint; set => gridPrePrint = value; }

        private List<GridPackaging> gridPackaging;
        public List<GridPackaging> GridPackaging { get => gridPackaging.IsNullOrEmpty() ? new List<GridPackaging>() { new GridPackaging() } : gridPackaging; set => gridPackaging = value; }

        private List<DataGridGroupA> dataGridGroupA;
        public List<DataGridGroupA> DataGridGroupA { get => dataGridGroupA.IsNullOrEmpty() ? new List<DataGridGroupA>() { new DataGridGroupA() } : dataGridGroupA; set => dataGridGroupA = value; }

        public string OuterShipperLabel { get; set; }
        public string PalletLabel { get; set; }
        public string ChangeOfLabelNotice { get; set; }
        public string PalletInformation { get; set; }
        public string CleanCompletedSignature { get; set; }
        public int FinishedGoodUnit_NumberOfUnits { get; set; }
        public int FinishedGoodUnit_NumberOfUnitsInPart { get; set; }
        public int FinishedGoodUnit_TotalNumberOfUnits { get; set; }
        public int SecondUKOnly_NumberOfUnits { get; set; }
        public int SecondUKOnly_NumberOfUnitsInPart { get; set; }
        public int SecondUKOnly_TotalNumberOfUnits { get; set; }
        public string RoomCoordinatorSignature { get; set; }
        public string GMPReconciliatorSignature { get; set; }
        public string ReconciliationComment { get; set; }
        public string CommentsSignOff { get; set; }

    }
}
