using System;
using System.Collections;
using System.Collections.Generic;

namespace BNPKata
{
    public interface ISerializer
    {
        IEnumerable<Tap> Serialize(string isAny);
    }

    public record Tap
    {
        public string UnixTimeStamp { get; init; }
        public string CustomerId { get; init; }
        public string Station { get; init; }
    }
}