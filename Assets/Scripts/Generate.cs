using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject rocks;

	void Start () {
		InvokeRepeating ("CreateObstacle", 0f, 1.5f);
	}

	void CreateObstacle () {
		Instantiate (rocks);
	}
}
