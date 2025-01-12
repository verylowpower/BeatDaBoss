using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
	float horizontal;
	public float speed;
	public float jumpForce = 0.0f;
	public float jumpForce2 = 10.0f;
	public bool isFacingRight = true;
	public bool canJump = true;

	private float coyoteTime = 0.1f;
	private float coyoteTimeCounter;
	public PhysicsMaterial2D bounceMaterial, normalMaterial;

	[SerializeField] Rigidbody2D body;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		if (jumpForce == 0.0f && isGrounded())
		{
			MoveChar();
		}
		//Jump();
		JumpUp(); // Check for the LeftShift jump
		Flip();
	}

	private void FixedUpdate()
	{
		isGrounded();
		if (isGrounded())
			coyoteTimeCounter = coyoteTime;
		else
			coyoteTimeCounter = -Time.fixedDeltaTime;
	}

	private void MoveChar()
	{
		body.velocity = new Vector2(horizontal * speed, body.velocity.y);
	}

	private bool isGrounded()
	{
		bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
		if (grounded)
		{
			canJump = true;
		}
		return grounded;
	}

	public void JumpUp() // Jump straight up
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded())
		{
			body.velocity = new Vector2(horizontal*speed, jumpForce2); // Zero out horizontal velocity for straight-up jump
			jumpForce = 0.0f;
			canJump = false;
		}
	}

	// public void Jump() // jump with power charge
	// {
	// 	if (jumpForce >= 0)
	// 	{
	// 		body.sharedMaterial = bounceMaterial;
	// 	}
	// 	else
	// 	{
	// 		body.sharedMaterial = normalMaterial;
	// 	}

	// 	if (Input.GetKey("space") && isGrounded() && canJump)
	// 	{
	// 		jumpForce += 0.17f;
	// 	}

	// 	if (Input.GetKeyDown("space") && isGrounded() && canJump)
	// 	{
	// 		body.velocity = new Vector2(0.0f, body.velocity.y);
	// 	}

	// 	if (jumpForce >= 15.0f && isGrounded() && canJump)
	// 	{
	// 		float tempx = horizontal * speed;
	// 		float tempy = jumpForce;
	// 		body.velocity = new Vector2(tempx, tempy);
	// 		Debug.Log("Jump executed with force: " + jumpForce);
	// 		Invoke("ResetJump", 0.2f);
	// 	}

	// 	if (Input.GetKeyUp("space"))
	// 	{
	// 		if (isGrounded())
	// 		{
	// 			body.velocity = new Vector2(horizontal * speed, jumpForce);
	// 			jumpForce = 0.0f;
	// 		}
	// 		canJump = true;
	// 	}
	// }

	void ResetJump()
	{
		canJump = false;
		jumpForce = 0f;
	}

	private void Flip()
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
	
	// void OnCollisionEnter2D(Collision2D collision) 
	// {
	// 	if(collision.gameObject.CompareTag("Wall"))	
	// 	{
	// 		bounceMaterial.bounciness = 3f;
	// 	}else
	// 	{
	// 		bounceMaterial.bounciness = 0.45f;
	// 	}
	// }
	
	// void OnTriggerEnter2D(Collider2D collision)
	// {
	// 	if(collision.gameObject.CompareTag("Wall"))	
	// 	{
	// 		bounceMaterial.bounciness = 1.2f;
	// 	}else
	// 	{	
	// 		bounceMaterial.bounciness = 0.45f;
	// 		if(collision.gameObject.CompareTag("Ground"))
	// 		{
	// 			normalMaterial.bounciness = 0f; // chỉnh sửa sau
	// 		}
	// 	}
	// }
	
	// void ResetBounce()
	// {
	// 	bounceMaterial.bounciness = 0.45f;
	// }
}
