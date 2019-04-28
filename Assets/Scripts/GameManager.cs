using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Features;

public class GameManager : MonoBehaviour
{
    public bool running = true;
    public static GameManager _instance;
    public int level = 0;
    public int selected = -1;

    Dictionary<string, Sprite> featureDict = new Dictionary<string, Sprite>();
    WantedManager wantedManager;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadFeatures();
            GetManagers();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void GetManagers(){
        wantedManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WantedManager>();
    }

    void LoadFeatures(){
        foreach (Mouth value in Enum.GetValues(typeof(Mouth)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Mouth/" + value.ToString(), typeof(Sprite)));
        foreach (Eyes value in Enum.GetValues(typeof(Eyes)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Eyes/" + value.ToString(), typeof(Sprite)));
        foreach (Nose value in Enum.GetValues(typeof(Nose)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Nose/" + value.ToString(), typeof(Sprite)));
        foreach (Hair value in Enum.GetValues(typeof(Hair)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Hair/" + value.ToString(), typeof(Sprite)));
        foreach (Ear value in Enum.GetValues(typeof(Ear)))
            featureDict.Add(value.ToString(), (Sprite)Resources.Load("Ear/" + value.ToString(), typeof(Sprite)));
    }
    
    public static GameManager Instance() {
        return _instance;
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            level ++;
        }
    }

    public Sprite GetSprite(string featureName)
    {
        return featureDict[featureName];
    }

    public void BringEmIn(HumanFeatures perpFeatures)
    {
        if (wantedManager.WantedList.Contains(perpFeatures.code))
        {
            
        }
    }
}
