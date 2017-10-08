using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	private Rigidbody2D rb;


	public Vector2 velocity = new Vector2(-4f,0);
	public int range = 5;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - range * Random.value, transform.position.x);
	}

	void Update () {
		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPos.x < -100) 
		{
			Destroy (gameObject);
		}
	}

}
