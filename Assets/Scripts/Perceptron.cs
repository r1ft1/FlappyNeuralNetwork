using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

	public GameObject bird;

	float[] inputs = new float[3];
	public float[] weights = new float[3];
	float sum = 0;

	void Start () {
		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (-1.0f,1.0f);
		}
		inputs [2] = 1;
	}


	void FixedUpdate()
	{
		inputs [0] = bird.GetComponent<Bird>().birdHeight;
		inputs [1] = bird.GetComponent<Bird>().nextPipeHeight;
		feedForward (inputs);
		birdJump (sum);
	}

	float feedForward(float[] inputs)
	{
		for (int i = 0; i < weights.Length; i++) {
			sum += inputs [i] * weights [i];
		}
		return activateSigmoid(sum);
	}


	public float activateSigmoid(float sum)
	{
		return 1 / (1 + Mathf.Exp (-sum));
	}

	void birdJump(float sum)
	{
		if (activateSigmoid(sum) >= 0.5)
			bird.GetComponent<Bird>().birdJump();
	}

	//public void Save()
	//{
	//	SaveLoadManager.SaveWeights (this);
	//}

	//public void Load()
	//{
	//	float[] loadedWeights = SaveLoadManager.LoadWeights ();
	//	weights [0] = loadedWeights [0];
	//	weights [1] = loadedWeights [1];
	//	weights [2] = loadedWeights [2];
	//}

}                                                                