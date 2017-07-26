using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// a lot of this code is from https://www.youtube.com/watch?v=vdSxOttY3zg&t=254s
public class textManager : MonoBehaviour {

	// declaring variables
	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	private bool isTyping = false;
	private bool cancelTyping = false;
	public bool playerMoveEnable = false;

	public float typeSpeed; 

	public string scene;

	// Use this for initialization
	void Start () 
	{

		// checking to make sure text file is there
		if (textFile != null) 
		{
			// split text in file wherever there is a new line
			textLines = (textFile.text.Split ('\n'));  
		}

		// to determine when to stop showing text
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1; 
		}

		// display first line of text
		StartCoroutine (TextScroll (textLines [0]));

	}

	void Update () 
	{

		// whenever mouse button is pressed, move to next line
		if (Input.GetMouseButtonDown(0)) 
		{
			if (!isTyping) {

				currentLine += 1;

				// stop once script is finished and change scene and allow player to move
				if (currentLine > endAtLine)
				{
					SceneManager.LoadScene (scene); // change this to changing dialogue box 
					playerMoveEnable = true;
				} 
				else 
				{ 
					StartCoroutine (TextScroll(textLines[currentLine]));
				}
			} 
			// if it's typing and hasn't cancelled yet but player clicks mouse ...
			else if(isTyping && !cancelTyping)
			{ 
				cancelTyping = true;			
			}
		}
	}

	// coroutine; can run this function and the rest of the code together
	// this function enables text to type one letter at a time
	private IEnumerator TextScroll(string lineOfText)
	{
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;

		while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
		{
			theText.text += lineOfText [letter];
			letter++; 
			yield return new WaitForSeconds (typeSpeed); // waiting before adding new letter
		}

		// if while loop is broken when player cancels typing, this will print whole line on screen
		theText.text = lineOfText; 
		isTyping = false;
		cancelTyping = false;
	}
}
