using UnityEngine;
using System.Collections;

public class PedestrianTest : MonoBehaviour 
{
	public int numberOfPedestrians;
	public float secondsToWait;
	public GameObject person;
	public int count;
	public GameObject parent;
	public WaypointManager wpm;
	
	void Start () 
	{
		StartCoroutine("SpawnPeople");
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			StartCoroutine("SpawnPeople");
		}
	}

	IEnumerator SpawnPeople()
	{
		for (int i = 0; i < numberOfPedestrians; i++) 
		{
			Vector3 tempPos = wpm.AssignNewDestination();
			GameObject clone = (GameObject)Instantiate(person, tempPos, Quaternion.identity);
			clone.transform.parent = parent.transform;
			yield return new WaitForSeconds(secondsToWait);
			count++;
		}
		StopCoroutine("SpawnPeople");
	}
}
