using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBG : MonoBehaviour {

	public Vector2 scrollSpeed = new Vector2 (-4, 0);
	Vector2 translation = new Vector2 (20,0);
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 screenPos = Camera.main.WorldToScreenPoint (transform.position);
		rb.transform.Translate (scrollSpeed*Time.deltaTime);
		if (screenPos.x  < 0) {
			transform.Translate(translation);
		}
	}
}
