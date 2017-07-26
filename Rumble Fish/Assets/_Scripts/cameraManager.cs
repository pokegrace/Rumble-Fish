﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from https://www.youtube.com/watch?v=Ta7v27yySKs

public class cameraManager : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

	private Camera cam;

	private float distance = 10.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensivityX = 4.0f;
	private float sensivityY = 1.0f;

	private void Start()
	{
		camTransform = transform;
		cam = Camera.main;
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
	}
}
