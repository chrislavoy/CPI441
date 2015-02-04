using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour 
{
	public GameObject[] waypoints;

	void Start()
	{
		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
	}

	public Vector3 AssignNewDestination()
	{
		if (waypoints.Length == 0) 
		{
			Start();
		}

		return waypoints[Random.Range(0, waypoints.Length)].transform.position;
	}

//	public GameObject AssignNewDestination()
//	{
//		print ("waypoints.Length = " + waypoints.Length);
//		return waypoints[0];
//	}
}
