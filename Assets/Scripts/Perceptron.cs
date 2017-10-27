using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

	//public GameObject bird;

	public float[] inputs = new float[2];
	public float[] weights = new float[2];
	public float sum = 0;

	void Start () {
		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (0f,1.0f);
		}
		//inputs [2] = 1;
	}


	void Update()
	{
		sum = 0;
		inputs [0] = gameObject.GetComponent<Bird> ().transform.position.y;
		inputs [1] = gameObject.GetComponent<Bird> ().nextPipeHeight;
		//feedForward (inputs);
		BirdJump (feedForward (inputs));
		//Debug.Log (sum);
		//respawnReset();
	}

	float feedForward(float[] inputs)
	{
		for (int i = 0; i < weights.Length; i++) {
			sum += inputs[i] * (weights [i]/10);
		}
		//return activateSigmoid(((4f*sum)/125f));
		//return activateSigmoid(sum/1000);
		//return activateSigmoid (sum/10f);
		return sum;
	}


	float activateSigmoid(float sum)
	{
		return (1 / (1 + Mathf.Exp (-sum)));
	}

	private void BirdJump(float activatedSum)
	{
		if (activatedSum < 0.5f)
			gameObject.GetComponent<Bird> ().birdJump ();
	}

	int signActivation(float sum)
	{
		if (sum >= 0.5)
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