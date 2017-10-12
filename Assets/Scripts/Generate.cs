using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject rocks;
	Obstacles pipes;


	void Start () {
		pipes = rocks.GetComponent<Obstacles> ();

		Instantiate (rocks);
	}


	void Update()
	{
		if (pipes) {
			
		}
	}


}
