using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePass : MonoBehaviour {

	public GameObject breeder;

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			for (int i = 0; i < breeder.GetComponent<Breeder> ().birds.Length; i++) {
				if (other.gameObject == breeder.GetComponent<Breeder> ().birds [i]) {
					Debug.Log (breeder.GetComponent<Breeder> ().birds [i] + " has Passed");
					breeder.GetComponent<Breeder> ().birds [i].GetComponent<Bird> ().odd = 
						!breeder.GetComponent<Breeder> ().birds [i].GetComponent<Bird> ().odd;
					breeder.GetComponent<Breeder> ().birds [i].GetComponent<Bird> ().numPipes++;
				}
			}
		}
	}
}
