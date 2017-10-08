using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	int score = 0;
	int maxScore = 0;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score++;
		if (score >= maxScore)
			maxScore++;
	}

	void OnGUI()
	{
		GUI.color = Color.black;
		GUILayout.Label ("Score: " + score.ToString ());
		GUILayout.Label ("Max Score: " + maxScore.ToString ());
	}
}
