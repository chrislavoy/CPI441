using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	public bool isSelected;
	//public bool canReceivePath;
	NavMeshAgent agent;
	public Vector3 oldPos;
	TimeOfDaySystem time;
	PedestrianTest test;
	public float timeOfDay;
	
	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		time = GameObject.FindGameObjectWithTag ("GameController").GetComponent<TimeOfDaySystem>();
		test = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<PedestrianTest>();
		timeOfDay = 0;
	}
	
	void FixedUpdate () 
	{
		//		if (canReceivePath) 
		//		{
		//
		//		}
		timeOfDay = time.currentCycleTime;
		if ((time.worldTimeHour >= 18) && (time.worldTimeHour <= 22)) {
			GameObject gameTime;
			gameTime = GameObject.FindGameObjectWithTag ("Stadium");
			TemporaryDestination (gameTime.transform.position);

		} else {

			ResumeOldPath();
		}
		if (isSelected) 
		{
			if (Input.GetMouseButton(0)) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 300))
				{
					Debug.DrawLine(ray.origin, hit.point);
					agent.SetDestination(hit.point);
					oldPos = hit.point;
				}
			}
		}

	}
	
	public void TemporaryDestination(Vector3 newPos)
	{
		oldPos = agent.destination;
		agent.SetDestination (newPos);
	}
	
	public void ResumeOldPath()
	{
		if (oldPos != Vector3.zero) 
		{
						agent.SetDestination (oldPos);
						oldPos = Vector3.zero;
				} 
		else {
			agent.SetDestination(test.stop[(int)Random.Range(0,test.stop.Length)].transform.position);
				}
		
		
	}
}