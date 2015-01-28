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
		return waypoints[Random.Range(0, waypoints.Length)].transform.position;
	}
}
