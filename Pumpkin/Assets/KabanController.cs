using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabanController : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float moveSpeed = 0.00002f;
    private GameObject mainCamera;
    private float cameraOffset = 3f;
    GameObject kaban;
    float hInput = 0f;
    bool isFacingRight = true;
    private float offset = 0f;

    // Use this for initialization
    void Start () {
        kaban = GameObject.Find("kaban_0");
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (offset > 50)
        {
            Flip();
            offset = 0;
        }
        offset++;
        float a = 5f;
        if (!isFacingRight)
            a *= -1;
        rigidBody.velocity = new Vector2(a, rigidBody.velocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
