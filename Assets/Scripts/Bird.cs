using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

	//PipePass pipePass;
	public GameObject pipeOdd;
	public GameObject pipeEven;
	//public GameObject pipeUP;

	//Camera camera;

	public bool odd = true;

	public Vector2 jumpForce = new Vector2 (0,300);
	private Rigidbody2D rb;
	public bool godMode = false;
	public bool alive = true;
	public bool dead = false;

	public int numPipes = 0;
	public float score = 0f;
	public float finalScore;

	public Vector3 initialPosition;

	public float birdHeight;
	public float nextPipeHeight;
	public float nextPipeTop;
	public float nextPipeX;

	public float birdOffsetY;
	public float birdOffsetX;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//pipeOdd = GameObject.Find ("Pipe Pair odd");
		//pipeEven = GameObject.Find ("Pipe Pair even");
		birdOffsetY = gameObject.GetComponent<CircleCollider2D> ().bounds.size.y;
		birdOffsetX = gameObject.GetComponent<CircleCollider2D> ().bounds.size.x;
	}


	void Update () 
	{
		//birdOffset = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
		if (Input.anyKeyDown || Input.GetMouseButtonDown (0)) {
			if (gameObject.name == "Bird manual control") {
				rb.velocity = Vector2.zero;
				rb.AddForce (jumpForce);
			}
		}

		if (alive)
			score += 1f * Time.deltaTime;


		if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
			rb.velocity = Vector2.zero;
			rb.AddForce (jumpForce);
		} 


		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPos.y > Screen.height || screenPos.y < 0)
			Die();

		if (odd) {
			//nextPipeHeight = pipeOdd.transform.position.y;
			//pipeUP = pipeOdd.transform.Find ("pipeUP").gameObject;
			nextPipeHeight = pipeOdd.GetComponent<Obstacles>().pipeHeight;
			nextPipeTop = pipeOdd.GetComponent<Obstacles>().pipeTop;
			nextPipeX = pipeOdd.GetComponent<Obstacles>().pipeX;
			Debug.Log ("odd");
		} else {
			//pipeUP = pipeEven.transform.Find ("pipeUP").gameObject;
			nextPipeHeight = pipeEven.GetComponent<Obstacles>().pipeHeight;
			nextPipeTop = pipeEven.GetComponent<Obstacles>().pipeTop;
			nextPipeX = pipeEven.GetComponent<Obstacles>().pipeX;
			Debug.Log ("even");
		}
		//birdHeight = transform.position.y;
		birdHeight = gameObject.transform.position.y;
	}


	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.gameObject.tag == "Pipe")
			Die ();   //Called when collision with GameObjects with tag 
	}


	void Die ()
	{
		if (!godMode) {
			alive = false;
			finalScore = score;
			//gameObject.SetActive (false); THIS PREVENTS ACCESS TO SCRIPTS
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}
	}

	public void birdJump()
	{
		rb.velocity = Vector2.zero;
		rb.AddForce (jumpForce);
	}

	public void respawn()
	{
		alive = true;
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.GetComponent<CircleCollider2D>().enabled = true;
		rb.velocity = Vector2.zero;
		//gameObject.GetComponent<Perceptron>().sum = 0;
		score = 0;
		numPipes = 0;
		odd = true;
		finalScore = 0;
		//gameObject.SetActive (true);
		gameObject.transform.position = initialPosition;
	}
}
