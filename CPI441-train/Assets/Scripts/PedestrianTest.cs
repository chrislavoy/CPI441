
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
}



/*

using UnityEngine;
using System.Collections;

public class PedestrianTest : MonoBehaviour 
{
	public int numberOfPedestrians;
	public float secondsToWait;
	public GameObject[] starts;
	public GameObject[] entrances;
	public GameObject person;
	public GameObject[] clones;
	public int count;
	Vector3 destination;
	public Vector3 startPoint;
	int randomNum;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("SpawnPeople");
		clones = new GameObject[numberOfPedestrians];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//destination = objects[Random.Range(0,objects.Length)].transform.position;
		//startPoint = starts[Random.Range(0,starts.Length)].transform.position;
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			StartCoroutine("SpawnPeople");
		}

		for (int x = 0; x <clones.Length; x++) {
			for (int y = 0; y < entrances.Length; y++) {
				if (clones [x].transform.position == entrances [y].transform.position) {
					Destroy (clones [x]);
				}
			}
		}


	

	}



	IEnumerator SpawnPeople()
	{
		for (int i = 0; i < numberOfPedestrians; i++) 
		{
			GameObject clones = (GameObject)Instantiate(person, startPoint, Quaternion.identity);
			clones.GetComponent<NavMeshAgent>().SetDestination(destination);
			yield return new WaitForSeconds(secondsToWait);
			count++;
		}
		StopCoroutine("SpawnPeople");
	}
}


using UnityEngine;
using System.Collections;

public class PedestrianTest : MonoBehaviour 
{
	public int numberOfPedestrians;
	public float secondsToWait;
	public GameObject start, stop;
	public GameObject person;
	public int count;
	
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
			GameObject clone = (GameObject)Instantiate(person, start.transform.position, Quaternion.identity);
			clone.GetComponent<NavMeshAgent>().SetDestination(stop.transform.position);
			yield return new WaitForSeconds(secondsToWait);
			count++;
		}
		StopCoroutine("SpawnPeople");
	}
}


*/

