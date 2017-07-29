using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used for tutorial1 and tutorial2, to make the textboxes appear and disappear.
public class tutorialManager : MonoBehaviour {

	public GameObject[] textBox;
	int j = 1;

	// Use this for initialization
	void Start () 
	{
		textBox [0].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// boolean checks if a panel is open or not
		bool panelOpen = GameObject.Find ("UIManager").GetComponent<UIManager> ().panelOpen;

		// if panel is open, don't take any actions. otherwise, continue
		if (!panelOpen) {

			// deactivate the first text box and activate the next
			if (Input.GetKeyDown ("space") && j != 0) {
				textBox [j - 1].SetActive (false);
				textBox [j].SetActive (true);
				j++;
			}
		}
	}
}
