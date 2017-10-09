using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	private Rigidbody2D rb;

	public GameObject pipeUp;

	public int numPipe;

	//public GameObject pipeSize;
	//int size;

	public Vector2 velocity = new Vector2(-4f,0);
	public int range = 5;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//size = (int)pipeSize.GetComponent<SpriteRenderer> ().size.x ;
		rb.velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y + range * Random.value, transform.position.x);
	}

	void Update () {
		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector2 pipePos = Camera.main.WorldToScreenPoint (pipeUp.transform.position);
		if (screenPos.x  < 0-50) 
		{
			Destroy (gameObject);

			Debug.Log (pipePos.y);
		}

		numPipe = GameObject.FindGameObjectsWithTag ("PipeUp").Length;
	}

}
