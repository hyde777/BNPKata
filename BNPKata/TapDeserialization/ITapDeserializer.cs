using System;
using System.Collections;
using System.Collections.Generic;

namespace BNPKata
{
    public interface ITapDeserializer
    {
        IEnumerable<Tap> Serialize(string isAny);
    }
}