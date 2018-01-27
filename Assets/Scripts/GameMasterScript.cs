﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

	public static GameMasterScript TheMaster {
		get;
		private set;
	}

	public int LowerLevelBound;
	public int UpperLevelBound;
	public int LeftLevelBound;
	public int RightLevelBound;

	[SerializeField]
	int StartingState;

	[SerializeField]
	private int _currentState;
	public int CurrentState {
		get
		{
			return _currentState;
		}
		set
		{
			_currentState = value;
			if(StateChanged != null) {
				StateChanged.Invoke(this, new EventArgs());
			}
		}
	}

	[SerializeField]
	Text diedText;

	[SerializeField]
	string firstScene;

	public void WeDied() {
		diedText.enabled = true;
	}

	void Awake() {
		if(GameMasterScript.TheMaster != null) {
			Destroy(this);
			return;
		}

		GameMasterScript.TheMaster = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleRestart() {
		var inputRestart = Input.GetAxis("Restart");

		if(inputRestart > 0) {
			var currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}

		var inputRestartGame = Input.GetAxis("RestartGame");

		if(inputRestartGame > 0) {
			var currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(firstScene);
		}
	}

	void FixedUpdate() {
		HandleRestart();
	}

	public event EventHandler StateChanged;
}
