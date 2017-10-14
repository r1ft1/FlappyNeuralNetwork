using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePass : MonoBehaviour {

	public Bird bird;
	 


	void OnTriggerEnter2D(Collider2D other)
	{
		bird.odd = !bird.odd;
	}
}
