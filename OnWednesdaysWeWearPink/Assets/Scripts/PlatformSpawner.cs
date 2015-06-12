﻿using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {
	public GameObject Platform;
	void Start () {

		var offset = -1f;

		for (int i = 0; i < 10; i++) {
			var platform = Instantiate(Platform, 
			            new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y + (i*3) + offset), 
			            transform.rotation) as GameObject;
			platform.GetComponent<PlatformMovement>().Speed = Random.Range(0.5f, 4f);
			if(Random.Range(0f,1f) < 0.5f) {
				platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Left;
			} else {
				platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Right;
			}


		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}