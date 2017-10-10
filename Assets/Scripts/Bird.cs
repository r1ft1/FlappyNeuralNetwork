using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0,300);
	private Rigidbody2D rb;
	public bool godMode = false;
	bool alive = true;
	public int numPipe = 0;

	float birdOffset;

	public float birdHeight;
	public float nextPipeHeight;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		birdOffset = GetComponent<SpriteRenderer> ().bounds.size.y / 2;
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
	}


	void FixedUpdate()
	{
		birdHeight = transform.position.y;
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


	void heightOfNearestPipe()
	{
		
	}

}
