using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedPanel : MonoBehaviour
{
    private bool OnScreen;
    public Vector3 defaultOFFposition;
    public Vector3 targetONposition;
    public float MOVE_FACTOR;
    public float moveDistance;

    private void Start() {
        defaultOFFposition = transform.position;
        targetONposition = transform.position + new Vector3(0, moveDistance, 0);
    }

    private void Update() {
        Move();
    }

    private void Move() {
        if (OnScreen)
        {
            transform.position = Vector3.Lerp(transform.position, targetONposition, MOVE_FACTOR);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, defaultOFFposition, MOVE_FACTOR);
        }
    }

    // private void OnMouseOver() {
    //     OnScreen = true;
    // }

    // private void OnMouseExit() {
    //     OnScreen = false;
    // }

    public void SetOnscreen(bool enable)
    {
        OnScreen = enable;
    }
}
