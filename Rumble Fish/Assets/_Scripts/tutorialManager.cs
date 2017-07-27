﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used for tutorial1 and tutorial2, to make the textboxes appear and disappear.
public class tutorialManager : MonoBehaviour {

	public GameObject[] textBox;
	int j = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// checking to see if panel is open or not
		bool panelOpen = GameObject.Find ("UIManager").GetComponent<UIManager> ().panelOpen;

		// if panel is not open, then we can keep using dialogue boxes
		// ISSUE: panel requires mouse click, and it opens up dialogue box when panel button is clicked
		if (!panelOpen) {
			// if the mouse is clicked and it's the first text box
			if (Input.GetMouseButtonDown (0) && j == 0) {
				textBox [j].SetActive (true);
				j++;
			}
			// but if it's the second+ text box, then set the previous textbox to inactive
			else if (Input.GetMouseButtonDown (0) && j != 0) {
				textBox [j - 1].SetActive (false);
				textBox [j].SetActive (true);
				j++;
			}
		}
	}
}
