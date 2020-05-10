using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Domain.Commands
{
    public class CreateEbatchSheetCommand : IRequest<string>
    {
        public string Owner { get; set; }
        public string WorkOrderId { get; set; }
        public string WorkOrderNumber { get; set; }
        public string WorkOrderPart { get; set; }
        public string WorkOrderPartDesciption { get; set; }
        public string WorkOrderArticle { get; set; }
        public string Panel9Signature { get; set; }
        public string Panel9Signature2 { get; set; }
        public string ReconciliationCompletedbySignature { get; set; }
        public string EndDateComment { get; set; }
        public double QuantityRequired { get; set; }
        public string QCSample { get; set; }
        public string PackageSize { get; set; }
        public string IssuedBy { get; set; }
        public string EbatchVersion { get; set; }
        public DateTime IssuedDate { get; set; }
        public string PackDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime BatchStartDate { get; set; }
        public string ManufacturingComment { get; set; }
        public string BestBeforeComment { get; set; }
        public List<GridBulkItem> GridBulkItem { get; set; }
        public List<GridPrePrint> GridPrePrint { get; set; }
        public List<GridPackaging> GridPackaging { get; set; }
        public List<DataGridGroupA> DataGridGroupA { get; set; }
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
        public List<string> Group100101Description { get; set; }
        public List<string> GroupBComment { get; set; }
        public List<string> GroupCComment { get; set; }
        public List<string> GroupDComment { get; set; }
        public List<string> GroupEComment { get; set; }
        public string Group170Comment { get; set; }
        public List<string> Group161Description { get; set; }

    }
}
