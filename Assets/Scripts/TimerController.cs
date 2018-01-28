using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	public HealthEventManager GameManager;
	private Text _timerText;

	void Awake () {
		_timerText = GetComponent<Text>();
	}
	
	void Update () {
		string minSec = string.Format("{0}:{1:00}", (int)GameManager.GameTime / 60, (int)GameManager.GameTime % 60); 
		_timerText.text = minSec;
	}
}
