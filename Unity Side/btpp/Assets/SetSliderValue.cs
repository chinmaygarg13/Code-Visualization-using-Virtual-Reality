using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class SetSliderValue : MonoBehaviour {

	string Total_code;
	string[] lines;
	public Slider TimeSlider;
	public Slider MemCons;
	public Slider CpuUsage;

	// Use this for initialization
	void Start () {
		Load ();
		lines = Total_code.Split ('\n');
		TimeSlider.value = evaluate (0)*100;
		MemCons.value = evaluate(5);
		CpuUsage.value = evaluate (6);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	float evaluate(int index) {
		for (int i = 0; i < lines [index].Length; ++i) {
			if (lines [index] [i] == '=') {
				++i;
				++i;
				float val = 0;
				string s_val = get(index, i);
				val = (float)System.Convert.ToDouble (s_val);
				return val;
			}
		}
		return 0.0f;
	}

	string get(int index, int i) {
		string value = "0";
		while (i < lines [index].Length && (lines[index][i] == '.' || Char.IsDigit(lines[index][i]))) {
			value += lines [index] [i];
			++i;
		}
		return value;
	}

	void Load() {
		string path = "Assets/time.txt";
		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path); 
		Total_code = reader.ReadToEnd().ToString();
		//Debug.Log(reader.ReadToEnd());
		reader.Close();
	}
}
