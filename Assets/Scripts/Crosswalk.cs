using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crosswalk : MonoBehaviour 
{
	public Vector3 allowedVector;
	public bool crossAllowed;
	public List<GameObject> waiting;
	public Vector3 endPos1, endpos2;
	public float timer;


	void Start () 
	{
		if (transform.eulerAngles == new Vector3(0, 270, 0))
		{
			endPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z - (transform.localScale.x / 2) - 0.5f);
			endpos2 = new Vector3 (endPos1.x, endPos1.y, endPos1.z + transform.localScale.x  + 0.5f);
		}
		else 
		{
			endPos1 = new Vector3(transform.position.x - (transform.localScale.x / 2) - 0.5f, transform.position.y, transform.position.z);
			endpos2 = new Vector3 (endPos1.x + transform.localScale.x  + 0.5f, endPos1.y, endPos1.z);
		}
		waiting = new List<GameObject>();
	}

	void Update () 
	{
		if (crossAllowed) 
		{
			if (waiting.Count != 0) 
			{
				foreach (GameObject w in waiting) 
				{
					w.SendMessage("ResumeOldPath");
				}
				waiting.Clear();
			}
		}

		if (timer <= 0)
		{
			change();
			timer = 10;
		}
		else 
		{
			timer -= Time.deltaTime;
		}
	}

	public void change()
	{
		if (crossAllowed)
		{
			crossAllowed = false;
		}
		else 
		{
			crossAllowed = true;
		}
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
			if (!crossAllowed)
			{
				waiting.Add(other.gameObject);
				other.SendMessage("TemporaryDestination", FindClosestNode(other.transform.position));
			}
			else if (crossAllowed && timer <= 5.0f) 
			{
				waiting.Add(other.gameObject);
				other.SendMessage("TemporaryDestination", FindClosestNode(other.transform.position));
			}
		}
	}

	void OnDrawGizmos()
	{

	}
}
