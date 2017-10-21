using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	private Rigidbody2D rb;
	Vector2 screenPos;
	public Vector2 pipePos;
	Vector2 startingPosOdd = new Vector2(7f,-1.5f);
	Vector2 startingPosEven = new Vector2(14f,-1.5f);

	BoxCollider2D m_collider;
	public float pipeHeight;


	public GameObject pipeUp;


	public Vector2 velocity = new Vector2(-4f,0);
	public int range = 5;

	// Use this for initialization
	void Start () {
		m_collider = GetComponent<BoxCollider2D> ();
		rb = GetComponent<Rigidbody2D> ();
		//size = (int)pipeSize.GetComponent<SpriteRenderer> ().size.x ;
		rb.velocity = velocity;
		init ();
	}

	void Update () {
		pipeHeight = this.m_collider.bounds.min.y;
		screenPos = Camera.main.WorldToScreenPoint (transform.position);
		pipePos = Camera.main.WorldToScreenPoint (pipeUp.transform.position);
		if (screenPos.x  < 0-50) 
		{
			reset ();
		}
	}

	public void reset ()
	{
		if (this.name == "Pipe Pair odd")
			transform.position = new Vector3 (startingPosOdd.x, startingPosOdd.y + range * Random.value, 0);
		else
			transform.position = new Vector3 (startingPosEven.x, startingPosEven.y + range * Random.value, 0);
	}

	void init ()
	{
		transform.position = new Vector3 (transform.position.x, startingPosOdd.y + range * Random.value, 0);
	}



}
