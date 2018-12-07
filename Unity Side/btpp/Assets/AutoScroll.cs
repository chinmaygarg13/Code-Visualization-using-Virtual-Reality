using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour {
	ScrollRect sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<ScrollRect> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
