using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from https://www.youtube.com/watch?v=WGn1zvLSndk
public class spawner : MonoBehaviour {

	// array of different customers
	public GameObject[] customers;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;

	// int to decide which customer spawns
	int randCustomer; 

	// Use this for initialization
	void Start () {
		StartCoroutine (waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
		// making spawnWait a random value
		spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

	IEnumerator waitSpawner()
	{
		// controlling how long it waits before it starts spawning
		yield return new WaitForSeconds (startWait);

		// neverending loop right now
		while (!stop) 
		{
			// picking random customer to spawn
			randCustomer = Random.Range (0, 4);

			// picking where to spawn customer
			Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 
													Random.Range(-spawnValues.y, spawnValues.y),
														Random.Range(-spawnValues.z, spawnValues.z)); // (x, y, z)

			// to actually spawn objects
			// (what to spawn, where to spawn, and rotation)
			Instantiate (customers[randCustomer], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}

	}
}
