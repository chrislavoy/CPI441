using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
	public bool isSelected;
	NavMeshAgent agent;
	public Vector3 oldPos;

	// Use this for initialization
	void Start ()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSelected) 
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

	public void TemporaryDestination(Vector3 newPos)
	{
		oldPos = agent.destination;
		agent.SetDestination (newPos);
	}

	public void ResumeOldPath()
	{
		agent.SetDestination (oldPos);
		oldPos = Vector3.zero;
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
