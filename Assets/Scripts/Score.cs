/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int score = 0;
	int maxScore = 0;
	int Pipe;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score++;
		if (score >= maxScore)
			maxScore++;
		//Pipe = bird.numPipe;
	}

	void OnGUI()
	{
		GUI.color = Color.black;
		GUILayout.Label ("Score: " + score.ToString ());
		GUILayout.Label ("Max Score: " + maxScore.ToString ());
		//GUILayout.Label ("Pipes: " + Pipe.ToString ());
	}
}


//Score needs to stop when the birds die

*/