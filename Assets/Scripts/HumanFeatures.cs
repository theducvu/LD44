using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Features { 
    public enum Mouth
    {
        MOUTH_NORMAL,
        MOUSTACHE,
        BEARD,
        LIPSTICK,
        BUNNYTEETH
    }

    public enum Eyes
    {
        EYES_NORMAL,
        GLASSES,
        EYEPATCH,
        SCAR
    }

    public enum Nose
    {
        BUTTON,
        HAWK,
        CLOWN,
        PIG
    }

    public enum Ear
    {
        EAR_NORMAL,
        GOAT,
        ELF
    }

    public enum Hair
    {
        BALD,
        BUZZ,
        MULLET,
        MOHAWK,
        CHUN,
        ZUCC,
        THREE
    }


    public class HumanFeatures
    {
        public Mouth mouth;   
        public Eyes eyes;
        public Hair hair;
        public Ear ear;
        public Nose nose;
        public string code = "00000";

        public HumanFeatures() { }
        
        public HumanFeatures(Mouth nmouth, Eyes neyes, Hair nhair, Ear near, Nose nnose)
        {
            mouth = nmouth;
            eyes = neyes;
            hair = nhair;
            ear = near;
            nose = nnose;
            code = ((int)mouth).ToString() + ((int)eyes).ToString() + ((int)hair).ToString() + ((int)ear).ToString() + ((int)nose).ToString();
            // return this;
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
}