using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedManager : MonoBehaviour
{
    public List<HumanFeatures> WantedList = new List<HumanFeatures>();
    
    void GenerateWantedList(int number)
    {
        WantedList.Clear();
        for (int i=0; i < number; i++)
        {
            WantedList.Add(
                new HumanFeatures(
                    Global.RandomEnumValue<Mouth>(),
                    Global.RandomEnumValue<Eyes>(),
                    Global.RandomEnumValue<Hair>(),
                    Global.RandomEnumValue<Ear>(),
                    Global.RandomEnumValue<Nose>()
                )
            );
            
        }
    }
}
