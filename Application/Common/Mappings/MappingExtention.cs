using Application.Common.Models;
using Application.Identity;
using Domain.Entities;
using Domain.Enumerations;
using System;

namespace Application.Common.Mappings
{
    public static class MappingExtention
    {
        /*public static EbatchSheet ToDomainEntity(this CreateEbatchSheetCommand request)
        {
            var ebatchSheet = new EbatchSheet()
            {
                WorkOrderId = Guid.NewGuid().ToString(),
                Owner = request.Owner,
                WorkOrderNumber = request.WorkOrderNumber,
                WorkOrderDesciption = request.WorkOrderDesciption,
                WorkOrderPart = request.WorkOrderPart,
                WorkOrderArticle = request.WorkOrderArticle,
                ManufacturingDate = request.ManufacturingDate,
                ManufacturingComment = request.ManufacturingComment,
                GridBulkItem = request.GridBulkItem
            };
            return ebatchSheet;
        }*/

        public static EbatchSheetVm ToViewEntity(this EbatchSheet request)
        {
            var ebatchVm = new EbatchSheetVm()
            {
                Id = request.Id,
                CurrentState = request.CurrentState,
                NextState = request.GetNextState(request.CurrentState),
                WorkOrderId = request.WorkOrderId,
                Owner = request.Owner,
                WorkOrderNumber = request.WorkOrderNumber,
                WorkOrderPartDesciption = request.WorkOrderPartDesciption,
                WorkOrderPart = request.WorkOrderPart,
                WorkOrderArticle = request.WorkOrderArticle,
                ManufacturingDate = request.ManufacturingDate,
                BatchStartDate = request.BatchStartDate,
                EndDateComment = request.EndDateComment,
                ExpiryDate = request.ExpiryDate,
                ModifiedDate = request.ModifiedDate,
                CreatedDate = request.CreatedDate,
                PackDate = request.PackageDate,
                PackageSize = request.PackageSize,
                BestBeforeComment = request.BestBeforeComment,
                GroupBComment = request.GroupBComment,
                Panel9Signature = request.Panel9Signature,
                Panel9Signature2 = request.Panel9Signature2,
                QCSample = request.QCSample,
                QuantityRequired = request.QuantityRequired,
                ReconciliationCompletedbySignature = request.ReconciliationCompletedbySignature,
                ManufacturingComment = request.ManufacturingComment,
                IssuedDate = request.IssuedDate,
                IssuedBy = request.IssuedBy,
                EbatchVersion = request.EbatchVersion,
                OuterShipperLabel = request.OuterShipperLabel,
                PalletLabel = request.PalletLabel,
                ChangeOfLabelNotice = request.ChangeOfLabelNotice,
                PalletInformation = request.PalletInformation,
                CleanCompletedSignature = request.CleanCompletedSignature,
                GridBulkItem = request.GridBulkItem,
                GridPrePrint = request.GridPrePrint,
                GridPackaging = request.GridPackaging,
                DataGridGroupA = request.DataGridGroupA,
                FinishedGoodUnit_NumberOfUnits = request.FinishedGoodUnit_NumberOfUnits,
                FinishedGoodUnit_NumberOfUnitsInPart = request.FinishedGoodUnit_NumberOfUnitsInPart,
                FinishedGoodUnit_TotalNumberOfUnits = request.FinishedGoodUnit_TotalNumberOfUnits,
                SecondUKOnly_NumberOfUnits = request.SecondUKOnly_NumberOfUnits,
                SecondUKOnly_NumberOfUnitsInPart = request.SecondUKOnly_NumberOfUnitsInPart,
                SecondUKOnly_TotalNumberOfUnits = request.SecondUKOnly_TotalNumberOfUnits,
                RoomCoordinatorSignature = request.RoomCoordinatorSignature,
                GMPReconciliatorSignature = request.GMPReconciliatorSignature,
                ReconciliationComment = request.ReconciliationComment,
                CommentsSignOff = request.CommentsSignOff
            };
            return ebatchVm;
        }

        public static EbatchState GetReviewStateByRole(string userRole)
        {
            switch (userRole)
            {
                case UserRole.ProductionTeam: return EbatchState.ProductionReview;

                case UserRole.ChillerTeam: return EbatchState.ChillerReview;

                case UserRole.WarehouseTeam: return EbatchState.WarehouseReview;

                case UserRole.QualityTeam: return EbatchState.QualityReview;

                default: return null;
            }
        }
    }
}
