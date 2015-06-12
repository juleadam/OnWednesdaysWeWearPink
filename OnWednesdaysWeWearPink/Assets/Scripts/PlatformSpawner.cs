using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {
	public GameObject PlatformPrefab;
	public GameObject StartingPlatform;
	
	public float DistanceToSpawnPlatforms;
	public float DistanceToKeepPlatforms;

	public float AverageDistanceBetweenPlatforms;
	public float StandardDeviationOfPlatformDistance;
	public float AveragePlatformSpeed;
	public float StandardDeviationOfPlatformSpeed;

	public float XSPlatformScale;
	public float SPlatformScale;
	public float MPlatformScale;
	public float LPlatformScale;
	public float XLPlatformScale;

	public float NrOfStartingPlatforms = 10;

	private List<GameObject> Platforms;

	void Start () {
		Platforms = new List<GameObject> ();
		//InitialPlatform
		Platforms.Add (StartingPlatform);
//		float distanceFromStartingPlatform = AverageDistanceBetweenPlatforms + 
//			Random.Range(-StandardDeviationOfPlatformDistance, StandardDeviationOfPlatformDistance);
//		var platform = Instantiate (PlatformPrefab,
//		                           new Vector2 (Camera.main.transform.position.x, StartingPlatform.position.y + distanceFromStartingPlatform),
//		                           transform.rotation) as GameObject;
//
//		platform.GetComponent<PlatformMovement>().Speed = AveragePlatformSpeed + 
//			Random.Range(-StandardDeviationOfPlatformSpeed, StandardDeviationOfPlatformSpeed);
//		if(Random.Range(0f,1f) < 0.5f) {
//			platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Left;
//		} else {
//			platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Right;
//		}
//		platform.transform.localScale = new Vector3(GetRandomPlatformScale (), 1, 1);
//		Platforms.Add(platform);

		for (int i = 0; i < NrOfStartingPlatforms; i++) {
			SpawnPlatform();
		}
	}

	void Update () {
		while(Platforms[0].transform.position.y < Camera.main.transform.position.y + DistanceToSpawnPlatforms) {
			SpawnPlatform();
		}
		RemovePlatforms ();
	}

	private float GetRandomPlatformScale() {
		switch (Random.Range (1, 5)) {
			case 1:
				return XSPlatformScale;
			case 2:
				return SPlatformScale;
			case 3:
				return MPlatformScale;
			case 4:
				return LPlatformScale;
			case 5:
				return XLPlatformScale;
		}
		return MPlatformScale;
	}

	private void SpawnPlatform() {
		float distanceFromHighestPlatform = AverageDistanceBetweenPlatforms + 
			Random.Range(-StandardDeviationOfPlatformDistance, StandardDeviationOfPlatformDistance);
		var platform = Instantiate (PlatformPrefab,
		                            new Vector2 (Camera.main.transform.position.x, Platforms[0].transform.position.y + distanceFromHighestPlatform),
		                            transform.rotation) as GameObject;
		
		platform.GetComponent<PlatformMovement>().Speed = AveragePlatformSpeed + 
			Random.Range(-StandardDeviationOfPlatformSpeed, StandardDeviationOfPlatformSpeed);
		if(Random.Range(0f,1f) < 0.5f) {
			platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Left;
		} else {
			platform.GetComponent<PlatformMovement>()._movingDirection = MovingDirection.Right;
		}
		platform.transform.localScale = new Vector3(GetRandomPlatformScale (), 1, 1);
		Platforms.Insert (0, platform);
	}

	private void RemovePlatforms() {
		List<int> indexesToRemove = new List<int>();
		for (int i = Platforms.Count - 1; 
		     i >= 1 && 
		     Platforms[i].transform.position.y < Camera.main.transform.position.y - DistanceToKeepPlatforms;
		     i--) {
			indexesToRemove.Add(i);
		}
		foreach(int i in indexesToRemove) {
			Destroy(Platforms[i]);
			Platforms.RemoveAt(i);
		}
	}
}
