using System;
using System.Collections;
using System.Collections.Generic;

public static class Global
{
    public static T RandomEnumValue<T> (Random random)
    {
        var v = Enum.GetValues (typeof (T));
        return (T) v.GetValue (random.Next(v.Length));
    }
}
