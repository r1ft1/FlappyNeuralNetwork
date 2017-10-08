using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron {

	// Use this for initialization
	void Start () {
		float[] inputs = new float[3];
		float[] weights = new float[3];
		float sum;

		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (-1.0f,1.0f);
		}

	}

	public double activateSigmoid(float sum)
	{
		return 1 / (1 + Mathf.Exp (-sum));
	}

}
