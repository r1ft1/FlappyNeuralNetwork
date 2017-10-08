using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0,300);
	private Rigidbody2D rb;
	public bool godMode = false;
	float distancePipe;
	Vector2 direction = new Vector2 (1,0);
	Vector2 rayOrigin = new Vector2 (0, 0);
	float birdOffset;
	float distAbovePipe;




	void Start()
	{
		rb = GetComponent<Rigidbody2D>();



		//Ray2D laser = new Ray2D(rayOrigin, direction);
		birdOffset = GetComponent<SpriteRenderer> ().bounds.size.y / 2;

		rayOrigin.Set(transform.position.x, transform.position.y - birdOffset);
	}


	void Update () 
	{
		if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
			rb.velocity = Vector2.zero;
			rb.AddForce (jumpForce);
		}

		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPos.y > Screen.height || screenPos.y < 0)
			Die();
		
		distAbovePipe = (transform.position.y - birdOffset) - (0);


	}


	void FixedUpdate()
	{
		
		RaycastHit2D laser = Physics2D.Raycast (transform.position, Vector2.right * 1000f);
		Debug.DrawRay (transform.position, direction * 1000f, Color.red);

		if (laser.collider != null)
			distancePipe = Mathf.Abs(laser.point.x - transform.position.x);
		Debug.Log (distancePipe);

	}


	void OnCollisionEnter2D(Collision2D other) 
	{
		Die ();   //Called when collision between GameObjects that have Collider2d Components
	}


	void Die ()
	{
		if (!godMode)
			SceneManager.LoadScene("Game");  //Reload the scene, restarting game
	}
}
