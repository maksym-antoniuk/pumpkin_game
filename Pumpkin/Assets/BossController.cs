using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float moveSpeed = 0.00002f;
    private GameObject mainCamera;
    private float cameraOffset = 3f;
    GameObject kaban;
    float hInput = 0f;
    public static bool isFacingRight = false;
    private float offset = 0f;
    public static bool kek = true;

    // Use this for initialization
    void Start () {
        kaban = GameObject.Find("boss");
        //kaban.SetActive(false);
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isFacingRight)
        {
            if (kek)
            {
                GetComponent<Animator>().Play("BossRunAnim");
                //kaban.SetActive(true);
                kek = false;
            }
            
            rigidBody.velocity = new Vector2(-5f, rigidBody.velocity.y);
        }
    }
}
