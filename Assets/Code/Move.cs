using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Test : MonoBehaviour
{
	float horizontal;
	public float speed;
	public float jumpForce;
	public bool isFacingRight = true;

	[SerializeField] Rigidbody2D body;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		Jump();
		Flip();
	}

	private void LateUpdate()
	{
		body.velocity = new Vector2(horizontal * speed, body.velocity.y);
	}

	private bool isGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}


	public void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded())
		{
			body.velocity = new Vector2(body.velocity.x, jumpForce);
		}

		if (Input.GetButtonUp("Jump") && body.velocity.y > 0f)
		{
			body.velocity = new Vector2(body.velocity.x, body.velocity.y * 0.5f);
		}
	}


	private void Flip()
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			isFacingRight = false;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}

}