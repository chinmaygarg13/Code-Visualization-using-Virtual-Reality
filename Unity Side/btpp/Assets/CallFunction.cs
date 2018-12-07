using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CallFunction : EventTrigger {
	public override void OnPointerClick(PointerEventData data) {
		Debug.Log ("OnSelect called");
		Text code = GetComponent<Text> ();
		code.text = "int test_function() { \n cout << \"Inside function\"; \n} ";
	}
}
/*
public class transition_text : MonoBehaviour {
	Text code;
	// Use this for initialization
	void Start () {
/*		EventTrigger trigger = GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = EventTriggerType.Select;
		entry.
// Put cloding comment here
		code = GetComponent<Text>();		
		code.text = "void test_function() { \n cout << \"Inside function\"; \n} ";
	}
	
	// Update is called once per frame
	void Update () {
	}
	void onSelect() {
		code = GetComponent<Text>();		
		code.text = "void test_function() { \n cout << \"Inside function\"; \n} ";
	}
}
*/