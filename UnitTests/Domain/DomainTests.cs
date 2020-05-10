using Application.Common.Interfaces;
using Application.EbatchSheets.Commands;
using Cosmonaut;
using Cosmonaut.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using EbatchSheetEntity = Domain.Entities;

namespace UnitTests.Domain
{
    public class DomainTests
    {
        [Fact]
        public void EbatchSheet_Create_Successfully()
        {
            var request = new CreateEbatchSheetCommand
            {
                WorkOrderId = "WorkOrderId_01",
                WorkOrderNumber = "WorkOrderNumber_01",
                WorkOrderPart = "WorkOrderPart_01",
                WorkOrderPartDesciption = "WorkOrderPartDesciption_01",
                ManufacturingDate = DateTime.Now,
                ManufacturingComment = "ManufacturingComment",
                Panel9Signature = "Panel9Signature_Test",
                Panel9Signature2 = "Panel9Signature2_Test",
                ReconciliationCompletedbySignature = "ReconciliationCompletedbySignature_Test",
                EndDateComment = "End Date Comment",
                ExpiryDate = DateTime.Now.AddYears(2),
                QuantityRequired = 1000,
                IssuedBy = "Comvita",
                IssuedDate = DateTime.Now,
                EbatchVersion = "v.1",
                QCSample = "QC_Sample",
                PackageSize = "BIG",
                BestBeforeComment = "Before Comment",
                OuterShipperLabel = "Shipper Lable",
                PalletLabel = "Pallet Lable",
                PalletInformation = "Pallet Info",
                CleanCompletedSignature = "Signed",
                FinishedGoodUnit_NumberOfUnits = 100,
                FinishedGoodUnit_NumberOfUnitsInPart = 200,
                FinishedGoodUnit_TotalNumberOfUnits = 300,
                SecondUKOnly_NumberOfUnits = 200,
                SecondUKOnly_NumberOfUnitsInPart = 300,
                SecondUKOnly_TotalNumberOfUnits = 500,
                RoomCoordinatorSignature = "Room Signed",
                GMPReconciliatorSignature = "GMP Signed",
                CommentsSignOff = "Signed Off",

                GridBulkItem = new List<GridBulkItem>
                {
                    new GridBulkItem
                    {
                         GridBulkPartNo = "No1",
                         GridBulkDescription ="Description1"
                    },
                    new GridBulkItem
                    {
                         GridBulkPartNo = "No2",
                         GridBulkDescription ="Description2"
                    }
                }
            };

            var ebatchSheet = new EbatchSheetEntity.EbatchSheet();

            ebatchSheet.Create(request);

            Assert.Equal(EbatchState.ProductionReview.ToString(), ebatchSheet.CurrentState.Value);
            Assert.Equal(request.WorkOrderId, ebatchSheet.WorkOrderId);
            Assert.Equal(request.WorkOrderNumber, ebatchSheet.WorkOrderNumber);
            Assert.Equal(request.WorkOrderPart, ebatchSheet.WorkOrderPart);
            Assert.Equal(request.WorkOrderPartDesciption, ebatchSheet.WorkOrderPartDesciption);
            Assert.Equal(request.ManufacturingDate, ebatchSheet.ManufacturingDate);
            Assert.Equal(request.ManufacturingComment, ebatchSheet.ManufacturingComment);
            Assert.Equal(request.Panel9Signature, ebatchSheet.Panel9Signature);
            Assert.Equal(request.Panel9Signature2, ebatchSheet.Panel9Signature2);
            Assert.Equal(request.ReconciliationCompletedbySignature, ebatchSheet.ReconciliationCompletedbySignature);
            Assert.Equal(request.EndDateComment, ebatchSheet.EndDateComment);
            Assert.Equal(request.ExpiryDate, ebatchSheet.ExpiryDate);
            Assert.Equal(request.QuantityRequired, ebatchSheet.QuantityRequired);
            Assert.Equal(request.IssuedBy, ebatchSheet.IssuedBy);
            Assert.Equal(request.IssuedDate, ebatchSheet.IssuedDate);
            Assert.Equal(request.EbatchVersion, ebatchSheet.EbatchVersion);
            Assert.Equal(request.QCSample, ebatchSheet.QCSample);
            Assert.Equal(request.PackageSize, ebatchSheet.PackageSize);
            Assert.Equal(request.BestBeforeComment, ebatchSheet.BestBeforeComment);
            Assert.Equal(request.OuterShipperLabel, ebatchSheet.OuterShipperLabel);
            Assert.Equal(request.PalletLabel, ebatchSheet.PalletLabel);
            Assert.Equal(request.PalletInformation, ebatchSheet.PalletInformation);
            Assert.Equal(request.CleanCompletedSignature, ebatchSheet.CleanCompletedSignature);
            Assert.Equal(request.FinishedGoodUnit_NumberOfUnits, ebatchSheet.FinishedGoodUnit_NumberOfUnits);
            Assert.Equal(request.FinishedGoodUnit_NumberOfUnitsInPart, ebatchSheet.FinishedGoodUnit_NumberOfUnitsInPart);
            Assert.Equal(request.FinishedGoodUnit_TotalNumberOfUnits, ebatchSheet.FinishedGoodUnit_TotalNumberOfUnits);
            Assert.Equal(request.SecondUKOnly_NumberOfUnits, ebatchSheet.SecondUKOnly_NumberOfUnits);
            Assert.Equal(request.SecondUKOnly_NumberOfUnitsInPart, ebatchSheet.SecondUKOnly_NumberOfUnitsInPart);
            Assert.Equal(request.SecondUKOnly_TotalNumberOfUnits, ebatchSheet.SecondUKOnly_TotalNumberOfUnits);
            Assert.Equal(request.RoomCoordinatorSignature, ebatchSheet.RoomCoordinatorSignature);
            Assert.Equal(request.GMPReconciliatorSignature, ebatchSheet.GMPReconciliatorSignature);
            Assert.Equal(request.ReconciliationComment, ebatchSheet.ReconciliationComment);
            Assert.Equal(request.CommentsSignOff, ebatchSheet.CommentsSignOff);
            Assert.True(request.GridBulkItem.Count == ebatchSheet.GridBulkItem.Count);
        }

        [Fact]
        public void EbatchSheet_Update_Data_Successfully()
        {
            var request = new UpdateEbatchSheetCommand
            {
                WorkOrderId = "WorkOrderId_01",
                WorkOrderNumber = "WorkOrderNumber_01",
                WorkOrderPart = "WorkOrderPart_01",
                WorkOrderPartDesciption = "WorkOrderPartDesciption_01",
                ManufacturingDate = DateTime.Now,
                ManufacturingComment = "ManufacturingComment",
                Panel9Signature = "Panel9Signature_Test",
                Panel9Signature2 = "Panel9Signature2_Test",
                ReconciliationCompletedbySignature = "ReconciliationCompletedbySignature_Test",
                EndDateComment = "End Date Comment",
                ExpiryDate = DateTime.Now.AddYears(2),
                QuantityRequired = 1000,
                IssuedBy = "Comvita",
                IssuedDate = DateTime.Now,
                EbatchVersion = "v.1",
                QCSample = "QC_Sample",
                PackageSize = "BIG",
                BestBeforeComment = "Before Comment",
                OuterShipperLabel = "Shipper Lable",
                PalletLabel = "Pallet Lable",
                PalletInformation = "Pallet Info",
                CleanCompletedSignature = "Signed",
                FinishedGoodUnit_NumberOfUnits = 100,
                FinishedGoodUnit_NumberOfUnitsInPart = 200,
                FinishedGoodUnit_TotalNumberOfUnits = 300,
                SecondUKOnly_NumberOfUnits = 200,
                SecondUKOnly_NumberOfUnitsInPart = 300,
                SecondUKOnly_TotalNumberOfUnits = 500,
                RoomCoordinatorSignature = "Room Signed",
                GMPReconciliatorSignature = "GMP Signed",
                CommentsSignOff = "Signed Off",

                GridBulkItem = new List<GridBulkItem>
                {
                    new GridBulkItem
                    {
                        GridBulkPartNo = "No1",
                        GridBulkDescription = "Description1"
                    },
                    new GridBulkItem
                    {
                        GridBulkPartNo = "No2",
                        GridBulkDescription = "Description2"
                    }
                },
                GridPrePrint = new List<GridPrePrint>(),
                GridPackaging = new List<GridPackaging>(),
                DataGridGroupA = new List<DataGridGroupA>()
            };

            var ebatchSheet = new EbatchSheetEntity.EbatchSheet();

            ebatchSheet.UpdateDataWithoutChangingState(request);

            Assert.Equal(request.WorkOrderId, ebatchSheet.WorkOrderId);
            Assert.Equal(request.WorkOrderNumber, ebatchSheet.WorkOrderNumber);
            Assert.Equal(request.WorkOrderPart, ebatchSheet.WorkOrderPart);
            Assert.Equal(request.WorkOrderPartDesciption, ebatchSheet.WorkOrderPartDesciption);
            Assert.Equal(request.ManufacturingDate, ebatchSheet.ManufacturingDate);
            Assert.Equal(request.ManufacturingComment, ebatchSheet.ManufacturingComment);
            Assert.Equal(request.Panel9Signature, ebatchSheet.Panel9Signature);
            Assert.Equal(request.Panel9Signature2, ebatchSheet.Panel9Signature2);
            Assert.Equal(request.ReconciliationCompletedbySignature, ebatchSheet.ReconciliationCompletedbySignature);
            Assert.Equal(request.EndDateComment, ebatchSheet.EndDateComment);
            Assert.Equal(request.ExpiryDate, ebatchSheet.ExpiryDate);
            Assert.Equal(request.QuantityRequired, ebatchSheet.QuantityRequired);
            Assert.Equal(request.IssuedBy, ebatchSheet.IssuedBy);
            Assert.Equal(request.IssuedDate, ebatchSheet.IssuedDate);
            Assert.Equal(request.EbatchVersion, ebatchSheet.EbatchVersion);
            Assert.Equal(request.QCSample, ebatchSheet.QCSample);
            Assert.Equal(request.PackageSize, ebatchSheet.PackageSize);
            Assert.Equal(request.BestBeforeComment, ebatchSheet.BestBeforeComment);
            Assert.Equal(request.OuterShipperLabel, ebatchSheet.OuterShipperLabel);
            Assert.Equal(request.PalletLabel, ebatchSheet.PalletLabel);
            Assert.Equal(request.PalletInformation, ebatchSheet.PalletInformation);
            Assert.Equal(request.CleanCompletedSignature, ebatchSheet.CleanCompletedSignature);
            Assert.Equal(request.FinishedGoodUnit_NumberOfUnits, ebatchSheet.FinishedGoodUnit_NumberOfUnits);
            Assert.Equal(request.FinishedGoodUnit_NumberOfUnitsInPart, ebatchSheet.FinishedGoodUnit_NumberOfUnitsInPart);
            Assert.Equal(request.FinishedGoodUnit_TotalNumberOfUnits, ebatchSheet.FinishedGoodUnit_TotalNumberOfUnits);
            Assert.Equal(request.SecondUKOnly_NumberOfUnits, ebatchSheet.SecondUKOnly_NumberOfUnits);
            Assert.Equal(request.SecondUKOnly_NumberOfUnitsInPart, ebatchSheet.SecondUKOnly_NumberOfUnitsInPart);
            Assert.Equal(request.SecondUKOnly_TotalNumberOfUnits, ebatchSheet.SecondUKOnly_TotalNumberOfUnits);
            Assert.Equal(request.RoomCoordinatorSignature, ebatchSheet.RoomCoordinatorSignature);
            Assert.Equal(request.GMPReconciliatorSignature, ebatchSheet.GMPReconciliatorSignature);
            Assert.Equal(request.ReconciliationComment, ebatchSheet.ReconciliationComment);
            Assert.Equal(request.CommentsSignOff, ebatchSheet.CommentsSignOff);
            Assert.True(request.GridBulkItem.Count == ebatchSheet.GridBulkItem.Count);
        }

        [Fact]
        public void GetNextState_Correctly()
        {
            var ebatchSheet = new EbatchSheetEntity.EbatchSheet();

            var currentState = EbatchState.ProductionReview;

            var nextState = ebatchSheet.GetNextState(currentState);

            Assert.Equal(EbatchState.ChillerReview.Value, nextState.Value);
        }

        [Fact]
        public void ProceedNextState_InCorrectly()
        {
            var ebatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };
            var nextState = EbatchState.Completed;

            Assert.Throws<InvalidStateChange>(() => ebatchSheet.ProceedNextState(nextState));
        }

        [Fact]
        public void ProceedNextState_Correctly()
        {
            var ebatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };
            var expectNextState = EbatchState.ChillerReview;

            Assert.Equal(expectNextState.Value, ebatchSheet.ProceedNextState(EbatchState.ChillerReview).Value);
        }

        [Fact]
        public void ChangeState_Invalid_State()
        {
            var ebatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };

            var stateToChange = new EbatchState(10, "InvalidValue");

            Assert.Throws<ArgumentException>(() => ebatchSheet.ChangeState(stateToChange));
        }

        [Fact]
        public void ChangeState_Valid_State()
        {
            var ebatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };
            ebatchSheet.ChangeState(EbatchState.Completed);

            var expectState = EbatchState.Completed;

            Assert.True(expectState.Equals(ebatchSheet.CurrentState));
        }
    }
}
