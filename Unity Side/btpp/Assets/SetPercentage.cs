using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPercentage : MonoBehaviour {

	Text percentage;

	// Use this for initialization
	void Start () {
		percentage = GetComponent<Text> ();
	}

	public void textupdate(float value) {
		percentage.text = value.ToString() + "%";
	}
}
