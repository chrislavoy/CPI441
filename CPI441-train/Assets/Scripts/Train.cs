using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour 
{

	NavMeshAgent agent;
	//public NavMeshAgent agent2;
	//bool atStationOne = true;
	public GameObject node1;
	public GameObject node2;
	public GameObject node3;
	public GameObject node4;


	// Use this for initialization
	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();

		agent.SetDestination(node2.transform.position);
		//agent2.SetDestination(agent.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{

			//agent.SetDestination(node2.transform.position);

		if (agent.transform.position.x == node2.transform.position.x && agent.transform.position.z == node2.transform.position.z)
		{
			//atStationOne = false;
			agent.SetDestination(node3.transform.position);
			//agent.autoBraking = false;
		}

		if (agent.transform.position.x == node3.transform.position.x && agent.transform.position.z == node3.transform.position.z)
		{
			//atStationOne = false;
			agent.SetDestination(node4.transform.position);
			//agent.autoBraking = false;
		}

		if (agent.transform.position.x == node4.transform.position.x && agent.transform.position.z == node4.transform.position.z)
		{
			//atStationOne = false;
			agent.SetDestination(node1.transform.position);
			//agent.autoBraking = false;
		}

		if (agent.transform.position.x == node1.transform.position.x && agent.transform.position.z == node1.transform.position.z)
		{
			//atStationOne = false;
			agent.SetDestination(node2.transform.position);
			//agent.autoBraking = false;
		}
//		if(agent.transform.position == node2.transform.position)
//			agent.SetDestination(node1.transform.position);
//		if(agent.transform.position == node2.transform.position)
//			atStationOne = false;
//		if(agent.transform.position == node1.transform.position)
//			atStationOne = true;
//
//		if(atStationOne == true)
//		{
			//agent.SetDestination(node2.transform.position);
			/*Ray ray = Camera.main.ScreenPointToRay(node2.transform.position);
			RaycastHit hit;
			if(Physics.Raycast(ray , out hit, 500))
			{
				Debug.DrawLine(ray.origin,hit.point);
				agent.SetDestination(hit.point);
			}*/
//		}
//		else if(atStationOne == false)
//		{
//			agent.SetDestination(node1.transform.position);
//			Ray ray = Camera.main.ScreenPointToRay(node1.transform.position);
//			RaycastHit hit;
//			if(Physics.Raycast(ray , out hit, 500))
//			{
//				Debug.DrawLine(ray.origin, hit.point);
//				agent.SetDestination(hit.point);
//			}
		//}

		/*if (Input.GetMouseButton(0)) 
		{
			//Ray ray = Camera.main.ScreenPointToRay(station.transform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 500))
			{
				Debug.DrawLine(ray.origin, hit.point);
				agent.SetDestination(hit.point);
			}
		}*/
	}
}

