using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mouth
{
    NORMAL,
    MOUSTACHE,
    BEARD,
    LIPSTICK
}

public enum Eyes
{
    NORMAL,
    GLASSES,
    EYEPATCH,
    SCAR
}

public enum Nose
{
    BUTTON,
    HAWK,
    GREEK,
    CLOWN
}

public enum Ear
{
    NORMAL,
    SHREK,
    ELF,
    SQUARE
}

public enum Hair
{
    BALD,
    BUZZ,
    LONG,
    MOHAWK,
}


public class HumanFeatures
{
    public Mouth mouth;   
    public Eyes eyes;
    public Hair hair;
    public Ear ear;
    public Nose nose;

    public HumanFeatures() { }
    
    public HumanFeatures(Mouth nmouth, Eyes neyes, Hair nhair, Ear near, Nose nnose)
    {
        mouth = nmouth;
        eyes = neyes;
        hair = nhair;
        ear = near;
        nose = nnose;
    }
    
    public bool CompareFeatures(HumanFeatures other)
    {
        if (ear != other.ear)
            return false;
        if (mouth != other.mouth)
            return false;
        if (hair != other.hair)
            return false;
        if (eyes != other.eyes)
            return false;
        if (nose != other.nose)
            return false;

        return true;
    }
}
