﻿using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	public GameObject objToSpawn;
	public float timer;
	public float spawnPeriod;
	public int numberSpawnedEachPeriod;
	public Vector3 originInScreenCoords;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
		timer = 0;
		spawnPeriod = 5.0f;
		numberSpawnedEachPeriod = 3;

		originInScreenCoords = Camera.main.WorldToScreenPoint (new Vector3 (0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > spawnPeriod) {
			timer = 0;

			float width = Screen.width;
			float height = Screen.height;

			for(int i=0; i<numberSpawnedEachPeriod; i++) {
				float horizontalPos = Random.Range(0.0f, width);
				float verticalPos = Random.Range(0.0f, height);

				Instantiate(objToSpawn,
				            Camera.main.ScreenToWorldPoint(
									new Vector3( horizontalPos,
				            		verticalPos, originInScreenCoords.z )),
							Quaternion.identity);
			}

			/*
			Vector3 botLeft = new Vector3(0, 0, originInScreenCoords.z);
			Vector3 botRight = new Vector3(width, 0, originInScreenCoords.z);
			Vector3 topLeft = new Vector3(0, height, originInScreenCoords.z);
			Vector3 topRight = new Vector3(width, height, originInScreenCoords.z);

			Instantiate(objToSpawn,
			            Camera.main.ScreenToWorldPoint(botLeft), Quaternion.identity);
			Instantiate(objToSpawn,
			            Camera.main.ScreenToWorldPoint(botRight), Quaternion.identity);
			Instantiate(objToSpawn,
			 			Camera.main.ScreenToWorldPoint(topLeft), Quaternion.identity);
			Instantiate(objToSpawn,
			        	Camera.main.ScreenToWorldPoint(topRight), Quaternion.identity);
			*/

		}
	}
}
