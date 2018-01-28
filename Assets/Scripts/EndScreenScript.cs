using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour {

	private float _timeTilRestart = 0.0f;

	protected void Update() {
		
		if(_timeTilRestart < 5.0f) 
			_timeTilRestart += Time.deltaTime; 
		if(_timeTilRestart > 5.0f) 
			SceneManager.LoadScene("MainMenu");
		
	}

	public void BtnEvt_BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
