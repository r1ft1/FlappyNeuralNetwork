using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject rocks;
	int numPipes;

	void Start () {
		numPipes = 2;
		Instantiate (rocks);
	}


	void Update()
	{
		if (numPipes < 2) {
			CreateObstacle ();
		}
	}

	void CreateObstacle () {
		Instantiate (rocks);
	}
}
