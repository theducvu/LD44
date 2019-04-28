using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Features;

public class WantedManager : MonoBehaviour
{
    public List<string> WantedList = new List<string>();
    public HumanGenerator humanGen;
    
    void GenerateWantedList(int number)
    {
        WantedList.Clear();
        for (int i=0; i < number; i++)
        {
            HumanFeatures perp = humanGen.GenerateHumanFeatures();
            WantedList.Add(
                perp.code
            );
            
        }
    }

    public bool CheckContain(HumanFeatures f)
    {
        foreach (string perpcode in WantedList)
        {
            if (perpcode == f.code)
            {
                return true;
            }
        }
        return false;
    }
}
