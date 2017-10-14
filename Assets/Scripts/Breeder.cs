using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour {

	public GameObject[] birds = new GameObject[5];
	List<int> score = new List<int> (5);

	public Obstacles pipe1;
	public Obstacles pipe2;


	int high;
	int second;

	void Update () {

		// Check if all birds are dead
		if (birds[0].GetComponent<Bird> ().alive == false && birds[3].GetComponent<Bird> ().alive == false && 
			birds[1].GetComponent<Bird> ().alive == false && birds[4].GetComponent<Bird> ().alive == false && 
			birds[2].GetComponent<Bird> ().alive == false) 
		{
			Debug.Log ("All dead");

			//Get two fittest Birds
			for (int i = 0; i < birds.Length; i++) {
				score.Add (birds[i].GetComponent<Bird> ().score.score);
			}
			score.Sort ();
			int highest = score[score.Count-1];
			int secondHighest = score[score.Count-2];

			for (int i = 0; i < birds.Length; i++) {
				if (birds[i].GetComponent<Bird> ().score.score == highest) {
					high = i;
				}
				if (birds[i].GetComponent<Bird> ().score.score == secondHighest) {
					second = i;
				}
			}

			//Combine Weights by averaging the highest and second highest weights
			for (int i = 0; i < birds [high].GetComponent<Perceptron> ().weights.Length; i++) {
				birds [high].GetComponent<Perceptron> ().weights [i] = (birds [high].GetComponent<Perceptron> ().weights [i] *
					birds [second].GetComponent<Perceptron> ().weights [i]) / 2;
			}

			//Create next Generation
			for (int i = 0; i < birds.Length; i++) {
				for (int y = 0; y < birds [high].GetComponent<Perceptron> ().weights.Length; y++)
					birds [i].GetComponent<Perceptron> ().weights [y] = birds [high].GetComponent<Perceptron> ().weights [y];
			}

			//Randomly Mutate the next Generation
			for (int i = 0; i < birds.Length; i++) {
				for (int y = 0; y < birds [high].GetComponent<Perceptron> ().weights.Length; y++) {
					if (Random.value >= 0.5f)
						birds [i].GetComponent<Perceptron> ().weights [y] = birds [i].GetComponent<Perceptron> ().weights [y] * 1.1f;
					else
						birds [i].GetComponent<Perceptron> ().weights [y] = birds [i].GetComponent<Perceptron> ().weights [y] * 0.9f;
				}
			}
			Debug.Log ("Mutated");

			//Reset Bird Positions and start Next Generation
			for (int i = 0; i < birds.Length; i++) {
				birds [i].GetComponent<Bird> ().respawn ();
				birds [i].GetComponent<Bird> ().alive = true;
				pipe1.GetComponent<Obstacles> ().reset ();
				pipe2.GetComponent<Obstacles> ().reset ();
				birds [i].GetComponent<Bird> ().score.score = 0;
			}
			Debug.Log ("Reset");
		
		}


	}
}