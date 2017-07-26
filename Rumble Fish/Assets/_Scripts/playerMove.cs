using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from https://www.youtube.com/watch?v=26qF22kg9MA
// to move the player

public class playerMove : MonoBehaviour {

	public float moveSpeed;
	private bool move = false;
	public GameObject point;
	private Vector3 target;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// first argument: checking if mouse button is clicked
		// second argument: finding the bool in textManager and making sure that the player can't move during text scene.
		// if text scene is over, player can move
		if (Input.GetMouseButtonDown (0) && GameObject.Find("TextManager").GetComponent<textManager>().playerMoveEnable) 
		{
			// setting target to the current mouse position
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			// set move to true
			if (move == false) move = true;

			Instantiate (point, target, Quaternion.identity);
		}
		if (move == true)
			transform.position = Vector3.MoveTowards (transform.position, target, moveSpeed * Time.deltaTime);

	}
}
