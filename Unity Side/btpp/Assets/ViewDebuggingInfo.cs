using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ViewDebuggingInfo : MonoBehaviour {
	Text code;
	// Use this for initialization
	void Start () {
		code = GetComponent<Text> ();
		ReadString ();
	}
	
	// Update is called once per frame
	void Update () {
		ReadString ();
	}

	void ReadString()
	{
		string path = "Assets/gdb.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path); 
		code.text = reader.ReadToEnd().ToString();
		//Debug.Log(reader.ReadToEnd());
		reader.Close();
	}
}
