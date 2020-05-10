using Domain.Enumerations;
using System;

namespace Domain.Exceptions
{
    public class EbatchDomainException : Exception
    {
        public EbatchDomainException(string id, string err) : base($"Ebatch id {id}: {err}")
        {

        }
    }

    public class InvalidStateChange : EbatchDomainException
    {
        public InvalidStateChange(string id, EbatchState stateToChange, EbatchState currentState) 
            : base(id, $"There was an invalid change of state from {currentState.Value} to {stateToChange.Value}")
        {
        }
    }
}
