using Cosmonaut;
using Cosmonaut.Attributes;
using Domain.Commands;
using Domain.Enumerations;
using Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    [CosmosCollection("ebatchsheet-dev")]
    public class EbatchSheet
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        [CosmosPartitionKey]
        public string PartitionKey { get; set; }

        public string Owner { get; set; }
        public string ManufacturingComment { get; set; }
        public string BestBeforeComment { get; set; }
        public string EndDateComment { get; set; }
        public EbatchState CurrentState { get; set; }
        public string WorkOrderId { get; set; }
        public string WorkOrderNumber { get; set; }
        public string WorkOrderPart { get; set; }
        public string WorkOrderPartDesciption { get; set; }
        public string WorkOrderArticle { get; set; }
        public string Panel9Signature { get; set; }
        public string Panel9Signature2 { get; set; }
        public string ReconciliationCompletedbySignature { get; set; }
        public double QuantityRequired { get; set; }
        public string IssuedBy { get; set; }
        public string EbatchVersion { get; set; }
        public DateTime IssuedDate { get; set; }
        public string QCSample { get; set; }
        public string PackageSize { get; set; }
        public string GroupBComment { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public string PackageDate { get; set; }
        public DateTime BatchStartDate { get; set; }
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

        [JsonProperty("_ts")]
        public long TimeStamp { get; set; }
        public DateTime ModifiedDate
        {
            get => DateTimeOffset.FromUnixTimeSeconds(TimeStamp).UtcDateTime;
        }

        public EbatchSheet()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void Create(CreateEbatchSheetCommand request)
        {
            PartitionKey = "EbatchSheet";
            CurrentState = EbatchState.ProductionReview;
            CreatedDate = DateTime.UtcNow;
            Owner = request.Owner;
            WorkOrderId = request.WorkOrderId;
            WorkOrderNumber = request.WorkOrderNumber;
            WorkOrderPartDesciption = request.WorkOrderPartDesciption;
            WorkOrderPart = request.WorkOrderPart;
            WorkOrderArticle = request.WorkOrderArticle;
            ManufacturingDate = request.ManufacturingDate;
            ManufacturingComment = request.ManufacturingComment;
            Panel9Signature = request.Panel9Signature;
            Panel9Signature2 = request.Panel9Signature2;
            ReconciliationCompletedbySignature = request.ReconciliationCompletedbySignature;
            EndDateComment = request.EndDateComment;
            ExpiryDate = request.ExpiryDate;
            BatchStartDate = request.BatchStartDate;
            QuantityRequired = request.QuantityRequired;
            IssuedBy = request.IssuedBy;
            IssuedDate = request.IssuedDate;
            EbatchVersion = request.EbatchVersion;
            QCSample = request.QCSample;
            PackageSize = request.PackageSize;
            PackageDate = request.PackDate;
            BestBeforeComment = request.BestBeforeComment;
            OuterShipperLabel = request.OuterShipperLabel;
            PalletLabel = request.PalletLabel;
            ChangeOfLabelNotice = request.ChangeOfLabelNotice;
            PalletInformation = request.PalletInformation;
            CleanCompletedSignature = request.CleanCompletedSignature;
            FinishedGoodUnit_NumberOfUnits = request.FinishedGoodUnit_NumberOfUnits;
            FinishedGoodUnit_NumberOfUnitsInPart = request.FinishedGoodUnit_NumberOfUnitsInPart;
            FinishedGoodUnit_TotalNumberOfUnits = request.FinishedGoodUnit_TotalNumberOfUnits;
            SecondUKOnly_NumberOfUnits = request.SecondUKOnly_NumberOfUnits;
            SecondUKOnly_NumberOfUnitsInPart = request.SecondUKOnly_NumberOfUnitsInPart;
            SecondUKOnly_TotalNumberOfUnits = request.SecondUKOnly_TotalNumberOfUnits;
            RoomCoordinatorSignature = request.RoomCoordinatorSignature;
            GMPReconciliatorSignature = request.GMPReconciliatorSignature;
            ReconciliationComment = request.ReconciliationComment;
            CommentsSignOff = request.CommentsSignOff;

            GridPrePrint = request.GridPrePrint;
            GridPackaging = request.GridPackaging;
            DataGridGroupA = request.DataGridGroupA;
            GridBulkItem = request.GridBulkItem;
        }

        public void UpdateDataWithoutChangingState(UpdateEbatchSheetCommand request)
        {
            //UPDATE
            Owner = request.Owner;
            WorkOrderId = request.WorkOrderId;
            WorkOrderNumber = request.WorkOrderNumber;
            WorkOrderPartDesciption = request.WorkOrderPartDesciption;
            WorkOrderPart = request.WorkOrderPart;
            WorkOrderArticle = request.WorkOrderArticle;
            ManufacturingDate = request.ManufacturingDate;
            BatchStartDate = request.BatchStartDate;
            ManufacturingComment = request.ManufacturingComment;
            Panel9Signature = request.Panel9Signature;
            Panel9Signature2 = request.Panel9Signature2;
            ReconciliationCompletedbySignature = request.ReconciliationCompletedbySignature;
            EndDateComment = request.EndDateComment;
            ExpiryDate = request.ExpiryDate;
            QuantityRequired = request.QuantityRequired;
            IssuedBy = request.IssuedBy;
            IssuedDate = request.IssuedDate;
            EbatchVersion = request.EbatchVersion;
            QCSample = request.QCSample;
            PackageSize = request.PackageSize;
            PackageDate = request.PackDate;
            BestBeforeComment = request.BestBeforeComment;
            OuterShipperLabel = request.OuterShipperLabel;
            PalletLabel = request.PalletLabel;
            ChangeOfLabelNotice = request.ChangeOfLabelNotice;
            PalletInformation = request.PalletInformation;
            CleanCompletedSignature = request.CleanCompletedSignature;
            FinishedGoodUnit_NumberOfUnits = request.FinishedGoodUnit_NumberOfUnits;
            FinishedGoodUnit_NumberOfUnitsInPart = request.FinishedGoodUnit_NumberOfUnitsInPart;
            FinishedGoodUnit_TotalNumberOfUnits = request.FinishedGoodUnit_TotalNumberOfUnits;
            SecondUKOnly_NumberOfUnits = request.SecondUKOnly_NumberOfUnits;
            SecondUKOnly_NumberOfUnitsInPart = request.SecondUKOnly_NumberOfUnitsInPart;
            SecondUKOnly_TotalNumberOfUnits = request.SecondUKOnly_TotalNumberOfUnits;
            RoomCoordinatorSignature = request.RoomCoordinatorSignature;
            GMPReconciliatorSignature = request.GMPReconciliatorSignature;
            ReconciliationComment = request.ReconciliationComment;
            CommentsSignOff = request.CommentsSignOff;

            GridPrePrint = request.GridPrePrint != null ? request.GridPrePrint.Where(x => !string.IsNullOrEmpty(x.GridPrePrintPartNo)).ToList() : new List<GridPrePrint>();
            GridPackaging = request.GridPackaging != null ? request.GridPackaging.Where(x => !string.IsNullOrEmpty(x.GridPackagingPartNo)).ToList() : new List<GridPackaging>();
            DataGridGroupA = request.DataGridGroupA != null ? request.DataGridGroupA.Where(x => !(string.IsNullOrEmpty(x.LeftComment) && (string.IsNullOrEmpty(x.RightComment)))).ToList() : new List<DataGridGroupA>(); ;
            GridBulkItem = request.GridBulkItem != null ? request.GridBulkItem.Where(x => !string.IsNullOrEmpty(x.GridBulkPartNo)).ToList() : new List<GridBulkItem>();
        }



        public EbatchState ProceedNextState(EbatchState nextEbatchState)
        {
            var nextCorrectState = GetNextState(CurrentState);
            if (!nextCorrectState.Equals(nextEbatchState))
            {
                throw new InvalidStateChange(this.Id, nextEbatchState, CurrentState);
            }
            CurrentState = nextEbatchState;
            return CurrentState;
        }

        public EbatchState ChangeState(EbatchState stateToChange)
        {
            if (EbatchState.Validate(stateToChange.Id, stateToChange.Value))
            {
                CurrentState = stateToChange;
            }
            return CurrentState;
        }

        public EbatchState GetNextState(EbatchState currentState)
        {
            var stateFlows = Enumeration.GetAll<EbatchState>().ToList();
            var currentStateIndex = stateFlows.FindIndex(x => x.Equals(currentState));
            var nextCorrectState = (currentStateIndex < stateFlows.Count - 1) ? stateFlows[currentStateIndex + 1] : stateFlows.Last();
            return nextCorrectState;
        }
    }

    public class GridBulkItem
    {
        public string GridBulkPartNo { get; set; }
        public string GridBulkDescription { get; set; }
        public string GridBulkFinishedQuantityPacked { get; set; }
        public string GridBulkItemSignature { get; set; }
        public string GridBulkReturns { get; set; }
    }
    public class GridPrePrint
    {
        public string GridPrePrintPartNo { get; set; }
        public string GridPrePrintSignature { get; set; }
        public string GridPrePrintDescription { get; set; }
        public string GridPrePrintQualityUsed { get; set; }
        public string GridPrePrintWaste { get; set; }

    }
    public class GridPackaging
    {
        public string GridPackagingQANo { get; set; }
        public string GridPackagingPartNo { get; set; }
        public string GridPackagingDescription { get; set; }
        public string GridPackagingFinishedQuantity { get; set; }
        public string GridPackagingWasteSample { get; set; }
    }
    public class DataGridGroupA
    {
        public string LeftComment { get; set; }
        public string RightComment { get; set; }
    }
    public class FinishedGoodUnit
    {
        public int NumberOfUnits { get; set; }
        public int NumberOfUnitsInPart { get; set; }
        public int TotalNumberOfUnits { get; set; }
    }
    public class SecondUKOnly
    {
        public int NumberOfUnits { get; set; }
        public int NumberOfUnitsInPart { get; set; }
        public int TotalNumberOfUnits { get; set; }
    }
}
