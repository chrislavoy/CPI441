
using UnityEngine;
using System.Collections;

public class PedestrianTest : MonoBehaviour 
{
	public int numberOfPedestrians;
	public float secondsToWait;
	public GameObject[] start, stop;
	public GameObject person;
	public int count;
	int startCount;
	int stopCount;
	
	// Use this for initialization
	void Start () 
	{

		StartCoroutine("SpawnPeople");
	}
	
	// Update is called once per frame
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
			GameObject clone = (GameObject)Instantiate(person, start[(int)Random.Range(0,start.Length)].transform.position, Quaternion.identity);
			clone.GetComponent<NavMeshAgent>().SetDestination(stop[(int)Random.Range(0,stop.Length)].transform.position);
			yield return new WaitForSeconds(secondsToWait);
			count++;
		}
		StopCoroutine("SpawnPeople");
	}

	void setGoal()
	{

	}
}


