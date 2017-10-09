using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject rocks;
	Obstacles pipes;
	int numPipes;

	void Start () {
		pipes = rocks.GetComponent<Obstacles> ();
		numPipes = 2;
		Instantiate (rocks);
	}


	void Update()
	{
		if (pipes) {
			
		}
	}


}
