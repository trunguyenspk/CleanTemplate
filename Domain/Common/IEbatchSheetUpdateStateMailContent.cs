using Cosmonaut;
using Cosmonaut.Attributes;
using Domain.Commands;
using Domain.Enumerations;
using Domain.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Common
{
    public interface IEbatchSheetUpdateStateMailContent
    {
        string Body { get; set; }
        string NextState { get; set; }
    }

    public class EbatchSheetUpdateStateMailContent : IEbatchSheetUpdateStateMailContent
    {
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("nextState")]
        public string NextState { get; set; }
    }
}
