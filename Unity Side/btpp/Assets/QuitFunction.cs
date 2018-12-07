using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitFunction : MonoBehaviour {

	public void QuitApp (){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
