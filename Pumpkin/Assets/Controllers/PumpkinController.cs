using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinController : MonoBehaviour {
    Rigidbody2D rigidBody;
    public float moveSpeed = 3f;
    private GameObject mainCamera;
    private float cameraOffset = 3f;
    GameObject pumpkin;
    float hInput = 0f;

    bool isFacingRight = true;
    Animator anim;

    bool isGrounded = false;

    public Transform groundCheck;

    float groundRadius = 0.2f;

    public LayerMask whatIsGround;
    // Use this for initialization
    void Start()
    {
        pumpkin = GameObject.Find("PumpkinIdle");
        mainCamera = GameObject.Find("Main Camera");
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Run();
        Move(hInput);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rigidBody.velocity.y);
        if (!isGrounded)
            return;
    }



    public void Run()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));


        rigidBody.velocity = new Vector2(move * moveSpeed, rigidBody.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

    public void Move(float horizontalInput)
    {
        
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rigidBody.velocity = new Vector2(horizontalInput * moveSpeed, rigidBody.velocity.y);
        if (horizontalInput > 0 && !isFacingRight)
            Flip();
        else if (horizontalInput < 0 && isFacingRight)
            Flip();
    }

    public void StartMoving(float horizontalInput)
    {
        //string s = "" + horizontalInput;
        Debug.Log("Move", null);
        hInput = horizontalInput;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("Ground", false);
            rigidBody.AddForce(new Vector2(0, 5500));
        }
       
    }

    public void Shut()
    {
        if (isGrounded)
        {
            anim.SetBool("Ground", false);
            rigidBody.AddForce(new Vector2(0, 5500));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Coin", null);
        
    }

    void Update()
    {
        mainCamera.transform.position = new Vector3(pumpkin.transform.position.x + cameraOffset, pumpkin.transform.position.y + cameraOffset, mainCamera.transform.position.z);
    }
}
