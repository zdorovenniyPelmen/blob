using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerMovement : MonoBehaviour

{
    private Rigidbody2D rb;    
    public float speed;
    
    public float x, y;
    private bool isWalking; 

    //private Vector2 moveVelocity;
    
    public Animator anim;
    //public SpriteRenderer sr;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
	    //anim = GetComponent<Animator>();
	    //sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //moveVelocity = moveInput.normalized * speed;
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
	
	    if(x != 0 || y != 0)
	    {
	        anim.SetFloat("X", x);
  	        anim.SetFloat("Y", y);
            if (!isWalking)
	        {
		        isWalking = true;
		        anim.SetBool("IsMoving", isWalking);
	        }
        }
        else
        {
	        if (isWalking)   
            {
		        isWalking = false;
		        anim.SetBool("IsMoving", isWalking);
		        StopMoving();
	        }
        }
	 
	    moveDir = new Vector3(x, y).normalized;

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	    rb.velocity = moveDir * speed * Time.deltaTime;
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
}
