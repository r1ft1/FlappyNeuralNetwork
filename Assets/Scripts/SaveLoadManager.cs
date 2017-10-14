/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager {

	public static void SaveWeights (Perceptron bird) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/weights.sav", FileMode.Create);

		PerceptronData data = new PerceptronData (bird);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static float[] LoadWeights () {
		if (File.Exists (Application.dataPath + "/weights.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/weights.sav", FileMode.Open);

			PerceptronData data = bf.Deserialize (stream) as PerceptronData;

			stream.Close ();
			return data.weights;
		}
	}
		

}

[Serializable]
public class PerceptronData {

	public float[] weights;

	public PerceptronData (Perceptron bird) {
		weights = new float[3];
		weights [0] = bird.weights [0];
		weights [1] = bird.weights [1];
		weights [2] = bird.weights [2];
	} 
}
*/