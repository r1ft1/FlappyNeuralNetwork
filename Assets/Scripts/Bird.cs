using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

	//Obstacles pipe;
	PipePass pipePass;
	public GameObject pipeOdd;
	public GameObject pipeEven;

	public bool odd = true;

	public Vector2 jumpForce = new Vector2 (0,300);
	private Rigidbody2D rb;
	public bool godMode = false;
	bool alive = true;
	public int numPipe = 0;

	//float birdOffset;

	public float birdHeight;
	public float nextPipeHeight;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		pipeOdd = GameObject.Find ("Pipe Pair odd");
		pipeEven = GameObject.Find ("Pipe Pair even");

		//birdOffset = GetComponent<SpriteRenderer> ().bounds.size.y / 2;
	}


	void Update () 
	{
		if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
			rb.velocity = Vector2.zero;
			rb.AddForce (jumpForce);
		}

		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		//if (screenPos.y > Screen.height || screenPos.y < 0)
		//	Die();

		if (odd) {
			nextPipeHeight = pipeOdd.transform.position.y;
			Debug.Log ("odd");
		} else {
			nextPipeHeight = pipeEven.transform.position.y;
			Debug.Log ("even");
		}
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
}
