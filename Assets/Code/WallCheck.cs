using UnityEditor;
using UnityEngine;

/// <summary>
/// character collider chạm vào collider của wall -> bounce tăng lên
/// ?
/// </summary>

public class WallCheck: MonoBehaviour
{
	[SerializeField] GameObject wallCheck;
	
	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.CompareTag("Wall"))	
		{
		
		}
	}
}