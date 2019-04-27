using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    public int walkDirection;
    public float WALK_SPEED;
    public bool pickedUp;
    public bool onScreen;
    Rigidbody2D rbody;
    Animator anim;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // walkDirection = Random.value > 0.5f ? 1 : -1;
        // Vector3 s = transform.localScale;
        // transform.localScale = new Vector3(s.x * walkDirection, s.y, s.z);
    }

    private void Update()
    {
        if (!pickedUp)
        {
            Walk();
        }
        else
        {
            Drag();
        }
        CheckOutside();
    }

    private void CheckOutside()
    {
        float x = transform.position.x;
        if (!onScreen)
        {
            if (x > -8.5f && x < 8.5f)
                onScreen = true;
        }
        else
        {
            if (x < -8.5f || x > 8.5f)
                Destroy(this.gameObject);
        }
    }

    private void Walk()
    {
        transform.position -= new Vector3(walkDirection * WALK_SPEED * Time.deltaTime, 0, 0);
    }

    private void Drag() {
        transform.position = (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-0.1f * walkDirection, -0.85f, 0);
        // print(transform.position);
    }

    public void SetDirection(int direction)
    {
        walkDirection = direction;
        Vector3 s = transform.localScale;
        transform.localScale = new Vector3(s.x * walkDirection, s.y, s.z);
    }

    // Pick up
    private void OnMouseDown() {
        pickedUp = true;
        anim.SetBool("pickedup", true);
    }

    // Put down
    private void OnMouseUp() {
        pickedUp = false;
        anim.SetBool("pickedup", false);
        transform.position += new Vector3(0, -0.25f, 0);
    }
}
