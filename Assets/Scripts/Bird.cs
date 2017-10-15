using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

	public Perceptron perceptron;
	PipePass pipePass;
	public GameObject pipeOdd;
	public GameObject pipeEven;

	public bool odd = true;

	public Vector2 jumpForce = new Vector2 (0,300);
	private Rigidbody2D rb;
	public bool godMode = false;
	public bool alive = true;
	public bool dead = false;


	public float score = 0f;
	public float finalScore;

	public Vector3 initialPosition;

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
		score += 1f * Time.deltaTime;

		if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
			rb.velocity = Vector2.zero;
			rb.AddForce (jumpForce);
		}

		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPos.y > Screen.height || screenPos.y < 0)
			Die();

		if (odd) {
			nextPipeHeight = pipeOdd.transform.position.y;
			Debug.Log ("odd");
		} else {
			nextPipeHeight = pipeEven.transform.position.y;
			Debug.Log ("even");
		}

		birdHeight = transform.position.y;
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
			gameObject.SetActive (false);
			finalScore = score;
		}
	}

	public void birdJump()
	{
		rb.velocity = Vector2.zero;
		rb.AddForce (jumpForce);
	}

	public void respawn()
	{
		perceptron.GetComponent<Perceptron>().sum = 0;
		score = 0;
		odd = true;
		finalScore = 0;
		gameObject.SetActive (true);
		transform.position = initialPosition;
		transform.localEulerAngles = Vector3.zero;
	}
}
