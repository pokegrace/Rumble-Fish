using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script manages the panel being set active
// code from https://www.youtube.com/watch?v=dvyiQLkaMcg
public class UIManager : MonoBehaviour {

	public GameObject panel;
	public bool isPaused;
	public Button myButton;
	// this bool is to make sure tutorialManager doesn't open any dialogue boxes
	public bool panelOpen;


	// Use this for initialization
	void Start () 
	{
		panelOpen = false;
		isPaused = false;

		// when button is clicked, then this panel will pop up
		Button btn = myButton.GetComponent<Button> ();
		btn.onClick.AddListener (switchPause);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isPaused) {
			pauseGame (true);
		} 
		else {
			pauseGame (false);
		}


	}

	// this method will pause or unpause the game
	void pauseGame(bool state)
	{
		if (state) {
			// pausing the game
			Time.timeScale = 0.0f;
			panelOpen = true;
		} 
		else {
			// unpausing the game
			Time.timeScale = 1.0f;
			panelOpen = false;
		}
		// panel will be set to active if state is true, and deactivate if state is false
		panel.SetActive (state);
	}

	// method will switch isPaused to false, if it's set to true and vice versa
	public void switchPause()
	{
		if (isPaused) {
			isPaused = false;
		} 
		else {
			isPaused = true;
		}
	}
}
