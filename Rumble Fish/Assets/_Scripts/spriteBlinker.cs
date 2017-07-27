using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used to make an object blink back and forth
// code from https://www.youtube.com/watch?v=1EJOYWBcrzQ
public class spriteBlinker : MonoBehaviour {

	public Sprite cursor;

	float timer = 1f;
	float delay = 1f;

	void Start(){
	
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = cursor;
		
	}

	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			// the following if statements will make the cursor blink every 1 second
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == null) 
			{
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = cursor;
				timer = delay;
				return;
			}	
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == cursor) 
			{
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = null;
				timer = delay;
				return;
			}
		}
	}
}
