using UnityEngine;
using System.Collections;

public class Crosswalk : MonoBehaviour 
{
	public Vector3 allowedVector;
	public bool crossAllowed;

	public Vector3 endPos1, endpos2;
	// Use this for initialization
	void Start () 
	{
		//allowedVector = Vector3.forward;
		crossAllowed = false;
		endPos1 = new Vector3(transform.position.x - (transform.localScale.x / 2), transform.position.y, transform.position.z);
		endpos2 = new Vector3 (endPos1.x + transform.localScale.x, endPos1.y, endPos1.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	Vector3 FindClosestNode(Vector3 otherPos)
	{
		float distance1 = Vector3.Distance(otherPos, endPos1);
		float distance2 = Vector3.Distance(otherPos, endpos2);
		
		return (distance1 > distance2) ? endpos2 : endPos1;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pedestrian") 
		{
			//			if (!crossAllowed) 
			//			{
			//				float difference = Vector3.Dot(other.transform.forward, allowedVector);
			//				print(difference);
			//				if (difference >= 0.5f || difference <= -0.5f) 
			//				{
			//					other.GetComponent<NavMeshAgent>().speed = 0;
			//				}
			//				else
			//				{
			//					other.GetComponent<NavMeshAgent>().speed = 5;
			//				}
			//
			//			}
			//			else
			//			{
			//				other.GetComponent<NavMeshAgent>().speed = 5;
			//			}
			if (!crossAllowed)
			{
				other.SendMessage("TemporaryDestination", FindClosestNode(other.transform.position));
			}
			else
			{
				other.SendMessage("ResumeOldPath");
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.rigidbody.velocity.magnitude >= 0.01) 
		{
			if (!crossAllowed) 
			{
				other.SendMessage("TemporaryDestination", FindClosestNode(other.transform.position));
			}
			else
			{
				//other.GetComponent<NavMeshAgent>().speed = 5;
				other.SendMessage("ResumeOldPath");
			}
		}
	}
}
