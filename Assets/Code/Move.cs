using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{	
	public float speed;
	[Range(0f, 1f)]
	public float groundDecay;
	public float jumpForce;
	public bool grounded;
	public BoxCollider2D groundCheck;
	public LayerMask groundMask;
	public Rigidbody2D body;
	float xInput;
	float yInput;
	private float coyoteTime = 0.1f; // thời gian chờ
	private float coyoteTimeCounter;

	
	void Start()
	{
		
	}

	void Update()
	{   
		GetInput();
		InputMove();
		if (grounded)
		{
			coyoteTimeCounter = coyoteTime;
		}
		else
		{
			coyoteTimeCounter -= Time.deltaTime;
		}
		
	}
	
	void FixedUpdate()
	{	
		CheckGround();
		ApplyFriction();
	}
	
	void GetInput()
	{
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
		//Vector2 direction = new Vector2(xInput, yInput).normalized;
		//body.velocity = direction*speed;
	}
	
	void InputMove()
	{
		if (Mathf.Abs(xInput)>0)
		{
			body.velocity = new Vector2(xInput*speed,body.velocity.y);
		}
		
		if (yInput > 0.1f && coyoteTimeCounter > 0f) // Sử dụng coyote time
		{
			body.velocity = new Vector2(body.velocity.x, jumpForce);
			body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
	}
	
	void ApplyFriction()
	{
		if(grounded && xInput==0 && yInput==0 )
		{
			body.velocity *= groundDecay;	
			//Debug.Log("On_Ground");
		}
		// else if(!grounded)
		// {
		// 	Debug.Log("Not Ground");
		// }
	}
	
	void CheckGround()
	{	
		grounded = Physics2D.OverlapArea(groundCheck.bounds.min,groundCheck.bounds.max,groundMask) != null;		
	}
}
