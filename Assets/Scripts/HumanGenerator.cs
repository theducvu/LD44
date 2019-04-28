using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    List<HumanFeatures> wantedList;

    private void Start()
    {
        StartCoroutine("GenerateHumans");
        wantedList = FindObjectOfType<WantedManager>().WantedList;
    }

    private IEnumerator GenerateHumans()
    {
        while (GameManager.Instance().running)
        {
            MakeNewHuman();
            yield return new WaitForSeconds(0.5f);
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

        HumanFeatures hf;
        do { hf = GenerateHumanFeatures(); }
        while (wantedList.Contains(hf));

        hb.SetFeatures(hf);
        hb.SetDirection(Direction);
    }

    HumanFeatures GenerateHumanFeatures(){
        return new HumanFeatures(
            Global.RandomEnumValue<Mouth>(),
            Global.RandomEnumValue<Eyes>(),
            Global.RandomEnumValue<Hair>(),
            Global.RandomEnumValue<Ear>(),
            Global.RandomEnumValue<Nose>()
        );
    }
}
