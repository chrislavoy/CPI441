using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	public bool isSelected;
	NavMeshAgent agent;
	WaypointManager wpm;
	public Vector3 oldPos;
	public Vector3 endPos;

	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		StartCoroutine ("CheckIfAtDestination");
		wpm = Component.FindObjectOfType<WaypointManager>();
		endPos = agent.destination;
		GetNewDestination();
	}

	void Update () 
	{
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
					endPos = hit.point;
				}
			}
		}
	}

	public void TemporaryDestination(Vector3 newPos)
	{
		oldPos = agent.destination;
	}

	public void ResumeOldPath()
	{
		if (oldPos != Vector3.zero) 
		{
			agent.SetDestination (oldPos);
			oldPos = Vector3.zero;
		}
		else 
		{
			agent.SetDestination(endPos);
		}
	}

	IEnumerator CheckIfAtDestination()
	{
		while(Vector3.Distance(transform.position, endPos) >= 15.0f) 
		{
			yield return new WaitForSeconds (1);
		}

		GetNewDestination();
		StartCoroutine("CheckIfAtDestination");
	}

	void GetNewDestination()
	{
		agent.SetDestination(wpm.AssignNewDestination());
		endPos = agent.destination;
		oldPos = Vector3.zero;
	}
}
