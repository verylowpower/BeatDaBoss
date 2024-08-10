using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{	
	[SerializeField] float speed;
	[SerializeField] float drag;
	bool grounded;
	public Rigidbody2D body;
	void Start()
	{
		
	}

	
	void Update()
	{   
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");

		if (Mathf.Abs(xInput)>0)
		{
			body.velocity = new Vector2(xInput*speed,body.velocity.y);
		}
		
		if (Mathf.Abs(yInput)>0)
		{
			body.velocity = new Vector2(body.velocity.x,yInput*speed);
		}
		
		//Vector2 direction = new Vector2(xInput, yInput).normalized;
		//body.velocity = direction*speed;
	}
	
	void FixedUpdate()
	{	
		if(grounded)
		{
			body.velocity *= drag;	
		}
		
	}
	
	void CheckGround()
	{
		if(gameObject.CompareTag("Ground"))
		{
			
		}
	}
}
