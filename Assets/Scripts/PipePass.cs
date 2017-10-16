using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePass : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		gameObject.GetComponent<Bird>().odd = !gameObject.GetComponent<Bird>().odd;
		gameObject.GetComponent<Bird>().numPipes++;
	}
}
