using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

	//public GameObject bird;

	public float[] inputs = new float[3];
	public float[] weights = new float[3];
	public float sum = 0;

	private Bird bird;

	void Start () {
		for (int i = 0; i < weights.Length; i++) {
			weights [i] = Random.Range (-1.0f, 1.0f);
		}
		bird = gameObject.GetComponent<Bird> ();
		//inputs [2] = 1;
	}


	void Update()
	{
		sum = 0;
		//Y Distance above bottom pipe - tested
		inputs [0] = bird.transform.position.y - bird.birdOffsetY/2 - bird.nextPipeHeight;
		//Y Distance between top of Bird and Top pipe - tested
		inputs [1] = bird.nextPipeTop - bird.transform.position.y - bird.birdOffsetY;
		//X Distance between Bird and next Pipe - tested
		inputs [2] = bird.nextPipeX - bird.transform.position.x - bird.birdOffsetX/2;

		BirdJump (feedForward (inputs));
		//Debug.Log (sum);
	}

	float feedForward(float[] inputs)
	{
		for (int i = 0; i < weights.Length; i++) {
			sum += inputs[i] * (weights [i]);
		}
		//return activateSigmoid(((4f*sum)/125f));
		//return activateSigmoid(sum/1000);
		if (bird.alive)
			Debug.Log(gameObject.name + " Activated sum " + activateSigmoid (sum/10f));
		return activateSigmoid (sum);
		//return sum;
	}


	float activateSigmoid(float sum)
	{
		return (1.0f / (1.0f + Mathf.Exp (-sum)));
	}

	private void BirdJump(float activatedSum)
	{
		if (activatedSum <= 0.5f)
			bird.birdJump ();
	}

	int signActivation(float sum)
	{
		if (sum >= 0.5f)
			return 1;
		else
			return -1;
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