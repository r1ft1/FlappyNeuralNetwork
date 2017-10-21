using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePass : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			gameObject.GetComponent<Bird> ().odd = !gameObject.GetComponent<Bird> ().odd;
			gameObject.GetComponent<Bird> ().numPipes++;
		}
	}
}
