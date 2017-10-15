using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breeder : MonoBehaviour {

	public GameObject[] birds = new GameObject[10];
	List<int> score = new List<int> (10);

	public Obstacles pipe1;
	public Obstacles pipe2;


	int high;
	int second;

	void Update () {

		// Check if all birds are dead
		if (birds[0].GetComponent<Bird> ().alive == false && birds[5].GetComponent<Bird> ().alive == false && 
			birds[1].GetComponent<Bird> ().alive == false && birds[6].GetComponent<Bird> ().alive == false && 
			birds[2].GetComponent<Bird> ().alive == false && birds[7].GetComponent<Bird> ().alive == false &&
			birds[3].GetComponent<Bird> ().alive == false && birds[8].GetComponent<Bird> ().alive == false && 
			birds[4].GetComponent<Bird> ().alive == false && birds[9].GetComponent<Bird> ().alive == false) 
		{
			Debug.Log ("All dead");

			//Genetic Algorithm
			//Get two fittest Birds
			for (int i = 0; i < birds.Length; i++) {
				score.Add (birds[i].GetComponent<Bird> ().finalScore);
			}

			score.Sort ();

			int highest = score[score.Count-1];
			int secondHighest = score[score.Count-2];

			for (int i = 0; i < birds.Length; i++) {
				if (birds[i].GetComponent<Bird> ().finalScore == highest) {
					high = i;
				}
				else if (birds[i].GetComponent<Bird> ().finalScore == secondHighest) {
					second = i;
				}
			}

			//Combine Weights by averaging the highest and second highest weights
			for (int i = 0; i < birds [high].GetComponent<Perceptron> ().weights.Length; i++) {
				birds [high].GetComponent<Perceptron> ().weights [i] = (birds [high].GetComponent<Perceptron> ().weights [i] + birds [second].GetComponent<Perceptron> ().weights [i]) / 2;
			}

			//Create next Generation
			for (int i = 0; i < birds.Length; i++) {
				for (int y = 0; y < birds [high].GetComponent<Perceptron> ().weights.Length; y++)
					birds [i].GetComponent<Perceptron> ().weights [y] = birds [high].GetComponent<Perceptron> ().weights [y];
			}

			//Randomly Mutate Some of the next Generation
			for (int i = 0; i < birds.Length; i++) {
				for (int y = 0; y < birds [high].GetComponent<Perceptron> ().weights.Length; y++) {
					if (Random.value >= 0.5f) {
						if (Random.value > 0.5f)
							birds [i].GetComponent<Perceptron> ().weights [y] -= birds [i].GetComponent<Perceptron> ().weights [y] / 2;
						else
							birds [i].GetComponent<Perceptron> ().weights [y] += birds [i].GetComponent<Perceptron> ().weights [y] / 2;
					}
					else
						birds [i].GetComponent<Perceptron> ().weights [y] = Random.value;
					//if (Random.value >= 0.5f)
					//	birds [i].GetComponent<Perceptron> ().weights [y] += Random.value * 0.5f * 2 - 0.5f;
					//else
					//	birds [i].GetComponent<Perceptron> ().weights [y] += Random.value * 0.5f * 2 - 0.5f;
				}
			}
			Debug.Log ("Mutated");

			//Reset Bird Positions and start Next Generation
			for (int i = 0; i < birds.Length; i++) {
				birds [i].GetComponent<Bird> ().respawn ();
				birds [i].GetComponent<Bird> ().alive = true;
			}
			pipe1.GetComponent<Obstacles> ().reset ();
			pipe2.GetComponent<Obstacles> ().reset ();
			Debug.Log ("Reset");
		
		}


	}
}