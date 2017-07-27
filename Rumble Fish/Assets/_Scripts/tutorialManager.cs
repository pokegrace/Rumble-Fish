using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used for tutorial1 and tutorial2, to make the textboxes appear and disappear.
public class tutorialManager : MonoBehaviour {

	public GameObject[] textBox;
	public bool playerMoveEnable = false;
	int j = 0;

	// Use this for initialization
	void Start () {

		// setting all textboxes to invisible
		for (int i = 0; i < textBox.Length; i++) 
		{
			textBox [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		// if the mouse is clicked and it's the first text box
		if (Input.GetMouseButtonDown (0) && j == 0) 
		{
			textBox [j].SetActive (true);
			j++;
		}
		// but if it's the second+ text box, then set the previous textbox to inactive
		else if(Input.GetMouseButtonDown(0) && j != 0)
		{
			textBox [j - 1].SetActive (false);
			textBox [j].SetActive (true);
			j++;
		}

	}
}
