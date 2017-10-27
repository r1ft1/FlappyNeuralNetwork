using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour {

	public int timeSpeed;
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = (float)timeSpeed;
	}
}
