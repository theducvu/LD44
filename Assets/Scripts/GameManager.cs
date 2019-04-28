using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool running = true;
    public static GameManager _instance;

    Dictionary<string, Sprite> featureDict = new Dictionary<string, Sprite>();

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadFeatures();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void LoadFeatures(){
        foreach (Mouth value in Enum.GetValues(typeof(Mouth)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Mouth/" + value.ToString() + ".png", typeof(Sprite)));
    }
    
    public static GameManager Instance() {
        return _instance;
    }

    private void StartLevel() {
        FindObjectOfType<WantedManager>();
    }
}
