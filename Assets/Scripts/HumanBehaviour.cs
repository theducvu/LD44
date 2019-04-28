using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour
{
    public Collider ground;
    public float rayDist;
    public RaycastHit res;
    public Vector3 PICKUP_OFFSET_VECTOR;
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

        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider>();
        // foreach ()

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
        Vector3 oldtransform = transform.position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ground.Raycast(ray, out res, rayDist))
        {
            transform.position = res.point + PICKUP_OFFSET_VECTOR;
        }
        //  = (Vector3)(Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-0.1f * walkDirection, 0f, 0f);
        // print(transform.position);
    }

    public void SetDirection(int direction)
    {
        walkDirection = direction;
        Vector3 s = transform.localScale;
        transform.localScale = new Vector3(s.x * walkDirection, s.y, s.z);
    }

    public void SetColour(Color colour)
    {
        foreach (SpriteRenderer spr in GetComponentsInChildren<SpriteRenderer>())
        {
            spr.color = colour;
        }
    }

    // Pick up
    private void OnMouseDown() {
        PickUp();
    }

    private void PickUp() {
        pickedUp = true;
        anim.SetBool("pickedup", true);
        transform.localScale *= 1.2f;
    }

    // Put down
    private void OnMouseUp() {
        PutDown();
    }

    private void PutDown() {
        pickedUp = false;
        anim.SetBool("pickedup", false);
        transform.localScale /= 1.2f;
    }

    public void SetFeatures(HumanFeatures features)
    {

    }
}
