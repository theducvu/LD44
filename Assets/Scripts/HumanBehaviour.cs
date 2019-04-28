using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Features;

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
    Transform headAnchor;
    SpriteRenderer tempSprRndr = null;
    HumanFeatures features;
    Color myColour;

    private void Start()
    {
        headAnchor = transform.Find("body").Find("headA");
        // print(headAnchor);
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
            transform.position = res.point + new Vector3(PICKUP_OFFSET_VECTOR.x * walkDirection, PICKUP_OFFSET_VECTOR.y, PICKUP_OFFSET_VECTOR.z);
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
        myColour = colour;
    }

    // Pick up
    private void OnMouseDown() {
        if (GameManager.Instance().selected < 0)
            PickUp();
    }

    private void PickUp() {
        pickedUp = true;
        anim.SetBool("pickedup", true);
        transform.localScale *= 1.2f;
        BringFeaturesForward();
    }

    // Put down
    private void OnMouseUp() {
        if (GameManager.Instance().selected >= 0)
            GameManager.Instance().BringEmIn(features);
        else
            PutDown();
    }

    private void PutDown() {
        pickedUp = false;
        anim.SetBool("pickedup", false);
        transform.localScale /= 1.2f;
        SendFeaturesBackward();
    }

    public void SetFeatures(HumanFeatures feat)
    {
        this.features = feat;
        StartCoroutine("CreateFeatures");
    }
    
    private IEnumerator CreateFeatures()
    {
        yield return new WaitForSeconds(0.1f);
        MakeFeatures();
        SetMyColour();
        yield return null;
    }
    void MakeFeatures(){
        
        GameManager gman = GameManager.Instance();
        
        try {
            string mouthVal = features.mouth.ToString();
            Sprite mouthSpr = gman.GetSprite(mouthVal);
            tempSprRndr = headAnchor.Find("mouthA").Find(mouthVal).gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            tempSprRndr.sprite = mouthSpr;
            tempSprRndr.sortingOrder = 3;
        } catch {
            ;
        }
        
        try {
            string eyesVal = features.eyes.ToString();
            Sprite eyesSpr = gman.GetSprite(eyesVal);
            tempSprRndr = headAnchor.Find("eyesA").Find(eyesVal).gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            tempSprRndr.sprite = eyesSpr;
            tempSprRndr.sortingOrder = 3;
        } catch {
            ;
        }

        try {
            string earVal = features.ear.ToString();
            Sprite earSpr = gman.GetSprite(earVal);
            tempSprRndr = headAnchor.Find("earA").Find(earVal).gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            tempSprRndr.sprite = earSpr;
            tempSprRndr.sortingOrder = 3;
        } catch {
            ;
        }

        try {
            string noseVal = features.nose.ToString();
            Sprite noseSpr = gman.GetSprite(noseVal);
            tempSprRndr = headAnchor.Find("noseA").Find(noseVal).gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            tempSprRndr.sprite = noseSpr;
            tempSprRndr.sortingOrder = 3;
        } catch {
            ;
        }

        try {
            string hairVal = features.hair.ToString();
            if (hairVal == "BALD") return;
            Sprite hairSpr = gman.GetSprite(hairVal);
            tempSprRndr = headAnchor.Find("hairA").Find(hairVal).gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            tempSprRndr.sprite = hairSpr;
            tempSprRndr.sortingOrder = 3;
        } catch {
            ;
        }

        SendFeaturesBackward();
    }

    void SetMyColour(){
        foreach (SpriteRenderer spr in GetComponentsInChildren<SpriteRenderer>())
        {
            spr.color = myColour;
        }
    }

    void BringFeaturesForward()
    {
        foreach (SpriteRenderer spr in GetComponentsInChildren<SpriteRenderer>())
        {
            if (spr.gameObject.CompareTag("Features"))
                spr.GetComponent<SpriteRenderer>().sortingOrder = 25;
        }
    }

    void SendFeaturesBackward()
    {
        foreach (SpriteRenderer spr in GetComponentsInChildren<SpriteRenderer>())
        {
            if (spr.gameObject.CompareTag("Features"))
                spr.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }
}

