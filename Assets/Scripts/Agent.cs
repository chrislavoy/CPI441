using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{

	NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				Debug.DrawLine(ray.origin, hit.point);
				agent.SetDestination(hit.point);
			}
		}
	}
}
