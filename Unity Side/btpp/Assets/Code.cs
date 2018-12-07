using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Text code = GetComponent<Text>();
		code.text = "Hello World!";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Text code = GetComponent<Text>();
			code.text = "Code changed.";
		}
	}
}
