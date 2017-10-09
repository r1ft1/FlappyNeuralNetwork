using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

	public Bird bird;

	float[] inputs = new float[3];
	float[] weights = new float[3];
	float sum = 0;

	void Start () {
		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (-1.0f,1.0f);
		}
		inputs [2] = 1;

	}


	void FixedUpdate()
	{
		inputs [0] = bird.birdHeight;
		inputs [1] = bird.nextPipeHeight;
		feedForward (inputs);
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

}                                                                