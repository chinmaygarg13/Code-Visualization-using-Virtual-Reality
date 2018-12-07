using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadCode : MonoBehaviour {
	Text code;
	// Use this for initialization
	void Start () {
		code = GetComponent<Text> ();
		string path = "Assets/code.txt";
		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path); 
		code.text = reader.ReadToEnd().ToString();
		//Debug.Log(reader.ReadToEnd());
		reader.Close();
	}
}