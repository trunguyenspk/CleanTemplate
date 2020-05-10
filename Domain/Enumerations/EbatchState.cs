using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Enumerations
{
    /// <summary>
    /// The order is used to determine next-state, do not change below order
    /// </summary>
    public class EbatchState : Enumeration
    {
        public static EbatchState Initial = new EbatchState(0, "Initial");
        public static EbatchState ProductionReview = new EbatchState(1, "ProductionReview");
        public static EbatchState ChillerReview = new EbatchState(2, "ChillerReview");
        public static EbatchState WarehouseReview = new EbatchState(3, "WarehouseReview");
        public static EbatchState QualityReview = new EbatchState(4, "QualityReview");
        public static EbatchState Completed = new EbatchState(5, "Completed");

        public EbatchState(int id, string value) : base(id, value)
        {
        }

        public static bool Validate(int id, string value)
        {
            var allStates = GetAll<EbatchState>().ToList();
            if (allStates.Find(x => x.Id == id && x.Value == value) == null)
            {
                throw new ArgumentException($"EbatchState has invalid argument with constructor on id {id} and value {value}");
            }
            return true;
        }
    }
}
