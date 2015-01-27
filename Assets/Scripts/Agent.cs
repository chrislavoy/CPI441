using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	public bool isSelected;
	//public bool canReceivePath;
	NavMeshAgent agent;
	public Vector3 oldPos;

	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update () 
	{
//		if (canReceivePath) 
//		{
//
//		}
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


	}

//	void OnTriggerEnter(Collider other)
//	{
//		print("Collision detected");
//		if (other.tag == "Crosswalk") 
//		{
//			print("Crosswalk detected");
//			Destroy(this.gameObject);
//		}
//	}
}
