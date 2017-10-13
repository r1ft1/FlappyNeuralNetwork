using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour {

	public GameObject bird1;
	public GameObject bird2;
	public GameObject bird3;
	public GameObject bird4;
	public GameObject bird5;



	void Start () {

	}

	void Update () {
		// Check if all birds are dead
		if (bird1.GetComponent<Bird> ().alive == false && bird2.GetComponent<Bird> ().alive == false && 
			bird3.GetComponent<Bird> ().alive == false && bird4.GetComponent<Bird> ().alive == false && 
			bird5.GetComponent<Bird> ().alive == false) 
		{
			Debug.Log ("All dead");
			//save function
		}
			
		//Get two fittest Birds

		//Store bestWeights
		//for (int i = 0; i < bestWeights.Length; i++)
		//bestWeights[i] = bestBird1[i];
	}
}
