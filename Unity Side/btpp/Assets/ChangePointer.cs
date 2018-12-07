using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ChangePointer : EventTrigger {
	Text code;
	static int codeno = 0;
	List<int> lst = new List<int>();
	string main;
	bool back = false;
	ShowGdbInfo scriptInstance = null;
	// Use this for initialization
	void Start () {
		code = GetComponent<Text> ();
		main = code.text;
		if (Input.GetKey (KeyCode.Space)) {
			GameObject tempObj = GameObject.Find("Canvas2/Panel/Image/ScrollRect/Exec Info");
			scriptInstance = tempObj.GetComponent<ShowGdbInfo>();
		}
		if (scriptInstance == null) {
			//code.text = "NULL";				// Not Working
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void OnPointerClick(PointerEventData data) {
		if (codeno == 0) {
			Debug.Log ("OnSelect called");
			Text code = GetComponent<Text> ();
			if (true || !back)
				;
				//code.text = "void test_function() { \n cout << \"Inside function\"; \n} ";
			else
				code.text = main;
			back = !back;
			codeno = 1;
		} else {
			//code.text = "Second function";
			codeno = 0;
		}
	}
}