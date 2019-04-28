using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Features;

public class HumanGenerator : MonoBehaviour
{
    public GameObject humanPrefab;
    public float DIST_BETW_HUMANS; // 2f
    public float TIME_BETW_HUMANS; // min 0.15f
    int Direction;
    float y;
    float last_y;
    Vector3 location;

    [SerializeField]
    public Color[] possibleColours;
    WantedManager wantedManager;
    System.Random random;

    private void Start()
    {
        random = new System.Random();
        wantedManager = GetComponent<WantedManager>();
        StartCoroutine("GenerateHumans");
        
    }

    private IEnumerator GenerateHumans()
    {
        while (GameManager.Instance().running)
        {
            MakeNewHuman();
            yield return new WaitForSeconds(TIME_BETW_HUMANS);
        }
        yield return null;
    }

    private void MakeNewHuman()
    {
        Direction = Random.value < 0.5f ? 1 : -1;
        do {
            y = (float)Random.Range(-4, 6);
        } while (last_y == y);
        last_y = y;

        // Ok, it says y but I actually need to use Z now cause I switched to faux2d with a 3d camera
        int color_id = Random.Range(0, possibleColours.Length);
        location = new Vector3(Direction * 9, 0f, y * DIST_BETW_HUMANS + (Random.value - 0.5f) / 5f);
        GameObject human = Instantiate(humanPrefab, location, transform.rotation);
        HumanBehaviour hb = human.GetComponent<HumanBehaviour>();
        hb.WALK_SPEED = Random.Range(1f, 2f);
        hb.SetColour(possibleColours[color_id]);
        // print(wantedManager);
        HumanFeatures hf;
        hf = GenerateHumanFeatures();
        // do { hf = GenerateHumanFeatures(); }
        // while (wantedManager.CheckContain(hf) && Random.value < 0.95f);
        
        hb.SetDirection(Direction);
        hb.SetFeatures(hf);
    }

    public HumanFeatures GenerateHumanFeatures(){
        return new HumanFeatures(
            Global.RandomEnumValue<Mouth>(random),
            Global.RandomEnumValue<Eyes>(random),
            Global.RandomEnumValue<Hair>(random),
            Global.RandomEnumValue<Ear>(random),
            Global.RandomEnumValue<Nose>(random)
        );
    }
}
