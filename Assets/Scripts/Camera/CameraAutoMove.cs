﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoMove : MonoBehaviour {


	Plane zeroPlane = new Plane(Vector3.up, Vector3.zero);

	Coroutine running;

	void Start(){
	}

	public void MoveCameraParallelToZeroPlane(Vector3 lookPoint, float speed){
		running = StartCoroutine (LerpCamera (lookPoint, speed));
	}

	public void CancelAutoMove(){
		StopCoroutine (running);
	}

	IEnumerator LerpCamera(Vector3 lookPoint, float speed){

		if (running != null) {
			CancelAutoMove ();
		}

		Ray r = Camera.main.ViewportPointToRay (new Vector2(0.5f, 0.5f));
		float distance = 0;
		zeroPlane.Raycast (r, out distance);
		Vector3 currentLookPoint = r.GetPoint (distance);

		Vector3 endPoint = transform.position + new Vector3 (lookPoint.x - currentLookPoint.x, 0, lookPoint.z - currentLookPoint.z);

		while (Vector3.Distance(transform.position, endPoint) > 0.1f) {
			transform.position = Vector3.Lerp (transform.position, endPoint, speed);
			yield return null;
		}
	}
}
