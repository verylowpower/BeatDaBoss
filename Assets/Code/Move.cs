using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{	
	[SerializeField] float speed = 2.5f;
	public Rigidbody2D body;
	void Start()
	{
		
	}

	
	void FixedUpdate()
	{   
		float xInput = Input.GetAxis("Horizontal");
		float yInput = Input.GetAxis("Vertical");

		Vector2 direction = new Vector2(xInput, yInput).normalized;
		body.velocity = direction*speed;
	}
}
