using UnityEngine;
using System.Collections.Generic;

public class PlatformSpawner : MonoBehaviour {
	public GameObject PlatformPrefab;
	public GameObject PlatformFragilePrefab;
	public GameObject StartingPlatform;

	public int FragilePlatformSpawnRate;
	
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
		Platforms.Add (StartingPlatform);

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
		GameObject TypeToSpawn = Random.Range (1, FragilePlatformSpawnRate) == 1 ? PlatformFragilePrefab : PlatformPrefab;
		float distanceFromHighestPlatform = AverageDistanceBetweenPlatforms + 
			Random.Range(-StandardDeviationOfPlatformDistance, StandardDeviationOfPlatformDistance);
		var platform = Instantiate (TypeToSpawn,
		                            new Vector2 (Camera.main.transform.position.x, Platforms[0].transform.position.y + distanceFromHighestPlatform),
		                            transform.rotation) as GameObject;
		float speed = AveragePlatformSpeed + 
			Random.Range(-StandardDeviationOfPlatformSpeed, StandardDeviationOfPlatformSpeed);
		while (Platforms[0].GetComponent<PlatformMovement> () != null && 
		       (speed > Platforms[0].GetComponent<PlatformMovement> ().Speed - 0.3f &&
		 		speed < Platforms[0].GetComponent<PlatformMovement> ().Speed + 0.3f)) {
			speed = AveragePlatformSpeed + 
				Random.Range(-StandardDeviationOfPlatformSpeed, StandardDeviationOfPlatformSpeed);
		}
		platform.GetComponent<PlatformMovement> ().Speed = speed;
		if(Random.Range(0f,1f) < 0.5f) {
			platform.GetComponent<PlatformMovement>().MovingDirection = MovingDirection.Left;
		} else {
			platform.GetComponent<PlatformMovement>().MovingDirection = MovingDirection.Right;
		}
		platform.transform.localScale = new Vector3(GetRandomPlatformScale (), 1, 1);
		Platforms.Insert (0, platform);
	}

	private void RemovePlatforms() {
		List<int> indexesToRemove = new List<int>();
		for (int i = Platforms.Count - 1; i >= 1; i--) {
			if(Platforms[i].transform.position.y < Camera.main.transform.position.y - DistanceToKeepPlatforms) {
				indexesToRemove.Add(i);
			} else if(Platforms[i].GetComponent<PlatformLifeTime>() != null && Platforms[i].GetComponent<PlatformLifeTime>().Cull) {
				indexesToRemove.Add(i);
			}
		}
		foreach(int i in indexesToRemove) {
			Destroy(Platforms[i]);
			Platforms.RemoveAt(i);
		}
	}
}
