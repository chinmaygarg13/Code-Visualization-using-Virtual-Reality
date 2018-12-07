using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartDebug (){
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}	

	public void QuitApp (){
		Debug.Log ("QUIT!");
		Application.Quit ();
	}
}
