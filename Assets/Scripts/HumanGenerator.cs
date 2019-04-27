using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGenerator : MonoBehaviour
{
    public float HUMANS_PER_SECOND;
    public GameObject humanPrefab;
    int Direction;
    float y;
    float last_y;
    Vector3 location;

    private void Start()
    {
        StartCoroutine("GenerateHumans");
    }

    private IEnumerator GenerateHumans()
    {
        while (GameManager.Instance().running)
        {
            MakeNewHuman();
            yield return new WaitForSeconds(0.15f);
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
        location = new Vector3(Direction * 9, y * 0.6f + (Random.value - 0.5f) / 5f, 0f);
        GameObject human = Instantiate(humanPrefab, location, transform.rotation);
        HumanBehaviour hb = human.GetComponent<HumanBehaviour>();
        hb.WALK_SPEED = Random.Range(1f, 2f);
        hb.SetDirection(Direction);
    }
}
