using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

	//public GameObject bird;

	public float[] inputs = new float[3];
	public float[] weights = new float[3];
	public float sum = 0;

	void Start () {
		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (-1.0f,1.0f);
		}
		inputs [2] = 1;
	}


	void Update()
	{
		inputs [0] = gameObject.GetComponent<Bird> ().birdHeight;
		inputs [1] = gameObject.GetComponent<Bird> ().nextPipeHeight;
		//feedForward (inputs);
		birdJump (feedForward (inputs));
		//Debug.Log (sum);
		//respawnReset();
	}

	float feedForward(float[] inputs)
	{
		for (int i = 0; i < weights.Length; i++) {
			sum += inputs[i] * weights [i];
		}
		return activateSigmoid(sum/100);
	}


	float activateSigmoid(float sum)
	{
		return (1 / (1 + Mathf.Exp (-sum)));
	}

	void birdJump(float activatedSum)
	{
		if (activatedSum > 0.5f)
			gameObject.GetComponent<Bird> ().birdJump ();
	}

	int signActivation(float sum)
	{
		if (sum >= 0)
			return 1;
		else
			return -1;
	}

//	void respawnReset() {
//		if (bird.GetComponent<Bird> ().didRespawn)
//			sum = 0;
//	}


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