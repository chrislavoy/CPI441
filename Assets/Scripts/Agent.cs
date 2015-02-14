using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	//public bool isSelected;
	NavMeshAgent agent;
	WaypointManager wpm;
	//public Vector3 oldPos;
	public Vector3 endPos;

	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		//StartCoroutine ("CheckIfAtDestination");
		wpm = Component.FindObjectOfType<WaypointManager>();
		endPos = agent.destination;
		GetNewDestination();
	}

	void Update () 
	{
//		if (isSelected) 
//		{
//			if (Input.GetMouseButton(0)) 
//			{
//				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//				RaycastHit hit;
//				if (Physics.Raycast(ray, out hit, 300))
//				{
//					Debug.DrawLine(ray.origin, hit.point);
//					agent.SetDestination(hit.point);
//					endPos = hit.point;
//				}
//			}
//		}

		CheckIfAtDestination();

//		if (rigidbody.velocity == Vector3.zero && Vector3.Distance(transform.position, endPos) >= 15.0f) 
//		{
//
//		}
	}

	public void TemporaryDestination(Vector3 newPos)
	{
		endPos = agent.destination;
		agent.SetDestination(newPos);
	}

	public void ResumeOldPath()
	{
		if (endPos != Vector3.zero) 
		{
			agent.SetDestination (endPos);
			//endPos = Vector3.zero;
		}
		else 
		{
			//agent.SetDestination(endPos);
			agent.SetDestination(wpm.AssignNewDestination());
		}
	}

//	IEnumerator CheckIfAtDestination()
//	{
//		while(Vector3.Distance(transform.position, endPos) >= 5.0f) 
//		{
//			yield return new WaitForSeconds (1);
//		}
//
//		GetNewDestination();
//		//StartCoroutine("CheckIfAtDestination");
//		//Destroy(this.gameObject);
//	}

	void CheckIfAtDestination()
	{
		if (Vector3.Distance(transform.position, endPos) <= 5.0f) 
		{
			GetNewDestination();
		}
	}

	void GetNewDestination()
	{
		//print(this.GetInstanceID() + "Getting new destination");
		agent.SetDestination(wpm.AssignNewDestination());
		endPos = agent.destination;
		//oldPos = Vector3.zero;
	}
}
