using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Move : MonoBehaviour
{
	float horizontal;
	public float speed;
	public float jumpForce = 0.0f;
	public bool isFacingRight = true;
	public bool canJump = true;
	
	public PhysicsMaterial2D bounceMaterial, normalMaterial;

	// private bool isWallSliding;
	// private float wallSlidingSpeed = 2f;

	// private bool isWallJumping;
	// private float wallJumpingDirection;
	// private float wallJumpingTime = 0.2f;
	// private float wallJumpingCounter;
	// private float wallJumpingDuration = 0.4f;
	// private Vector2 wallJumpingPower = new Vector2(8f, 16f);

	[SerializeField] Rigidbody2D body;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask groundLayer;
	//[SerializeField] private Transform wallCheck;
	//[SerializeField] private LayerMask wallLayer;

	void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		if(jumpForce ==0.0f && isGrounded())
		{
			MoveChar();
		}
		Jump();
		// WallSlide();
		// WallJump();

		Flip();
		// if (!isWallJumping)
		// {
		// 	Flip();
		// }
	}


	private void MoveChar()
	{
		body.velocity = new Vector2(horizontal * speed, body.velocity.y);
		// if (!isWallJumping)
		// {
		// 	body.velocity = new Vector2(horizontal * speed, body.velocity.y);
		// }
	}
	private bool isGrounded()
	{
		bool grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
		if (grounded)
		{
			canJump = true;
		}
		//Debug.Log("Is Grounded: " + grounded); // Kiểm tra xem có trả về true không
		return grounded;
	}

	public void Jump()
	{	
		if(jumpForce >=0)
		{
			body.sharedMaterial = bounceMaterial;
		}
		else
		{
			body.sharedMaterial = normalMaterial;
		}
		
		
		if (Input.GetKey("space") && isGrounded()&&canJump)
		{
			jumpForce += 0.1f;
			//Debug.Log("Jump Force Increased: " + jumpForce);
		}
		
		if(Input.GetKeyDown("space") && isGrounded()&& canJump)
		{
			body.velocity = new Vector2 (0.0f,body.velocity.y);
		}

		if (jumpForce >= 20f && isGrounded()&&canJump)
		{
			float tempx = horizontal * speed;
			float tempy = jumpForce;
			body.velocity = new Vector2(tempx, tempy);
			Debug.Log("Jump executed with force: " + jumpForce);
			Invoke("ResetJump",0.2f);
		}
		
		if (Input.GetKeyUp("space"))
		{
			if(isGrounded())
			{
				body.velocity = new Vector2(horizontal*speed,jumpForce);
				jumpForce = 0.0f;
			}
			canJump = true;
		}
		
	}


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

	//sử dụng sau
	// private bool IsWalled()
	// {
	// 	return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
	// }

	// private void WallSlide()
	// {
	// 	if (IsWalled() && !isGrounded() && horizontal != 0f)
	// 	{
	// 		isWallSliding = true;
	// 		body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, -wallSlidingSpeed, float.MaxValue));
	// 	}
	// 	else
	// 	{
	// 		isWallSliding = false;
	// 	}
	// }

	// private void WallJump()
	// {
	// 	if (isWallSliding)
	// 	{
	// 		isWallJumping = false;
	// 		wallJumpingDirection = -transform.localScale.x;
	// 		wallJumpingCounter = wallJumpingTime;

	// 		CancelInvoke(nameof(StopWallJumping));
	// 	}
	// 	else
	// 	{
	// 		wallJumpingCounter -= Time.deltaTime;
	// 	}

	// 	if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
	// 	{
	// 		isWallJumping = true;
	// 		body.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
	// 		wallJumpingCounter = 0f;

	// 		if (transform.localScale.x != wallJumpingDirection)
	// 		{
	// 			isFacingRight = !isFacingRight;
	// 			Vector3 localScale = transform.localScale;
	// 			localScale.x *= -1f;
	// 			transform.localScale = localScale;
	// 		}

	// 		Invoke(nameof(StopWallJumping), wallJumpingDuration);
	// 	}
	// }

	// private void StopWallJumping()
	// {
	// 	isWallJumping = false;
	// }
}