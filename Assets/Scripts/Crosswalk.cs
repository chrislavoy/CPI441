using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (BoxCollider))]

public class Crosswalk : MonoBehaviour 
{
	public Vector3 allowedVector;
	public bool crossAllowed;
	public List<GameObject> waiting;
	public Vector3 endPos1, endPos2;
	//public float timer;
	private GameObject parent;
	public bool isChild;
	private float scaler;
	public bool flipEndPoints;

	void Start () 
	{
		parent = this.transform.parent.gameObject;

		if (isChild) 
		{
			scaler = parent.transform.localScale.x;
		}
		else 
		{
			scaler = 1;
		}

		if (crossAllowed) 
		{
			gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.green;
		}
		else 
		{
			gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
		}
	
		//this.GetComponent<BoxCollider>().transform.position = this.transform.position + new Vector3 (0, 2, 0);

//		if (transform.eulerAngles == new Vector3(0, 270, 0))
//		{
//			endPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z - (transform.localScale.x / 2) - 0.5f);
//			endPos2 = new Vector3 (endPos1.x, endPos1.y, endPos1.z + transform.localScale.x  + 0.5f);
//		}
//		else 
//		{
//			endPos1 = new Vector3(transform.position.x - (transform.localScale.x / 2) - 0.5f, transform.position.y, transform.position.z);
//			endPos2 = new Vector3 (endPos1.x + transform.localScale.x  + 0.5f, endPos1.y, endPos1.z);
//		}
//		if (parent.transform.localScale.x > parent.transform.localScale.z) 
//		{
//			endPos1 = new Vector3(parent.transform.position.x - ((parent.transform.localScale.x * scaler) / 2) - 0.5f, parent.transform.position.y, parent.transform.position.z);
//			endPos2 = new Vector3 (endPos1.x + (parent.transform.localScale.x * scaler)  + 0.5f, endPos1.y, endPos1.z);
//		}
//		else 
//		{
//			endPos1 = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z - ((parent.transform.localScale.z * scaler) / 2) - 0.5f);
//			endPos2 = new Vector3 (endPos1.x, endPos1.y, endPos1.z + (parent.transform.localScale.z * scaler)  + 0.5f);
//		}

		CreateEndPos ();

		waiting = new List<GameObject>();
	}

	void CreateEndPos()
	{
		if (!flipEndPoints) 
		{
			if (transform.localScale.x > transform.localScale.z) 
			{
				endPos1 = new Vector3(transform.position.x - ((transform.localScale.x * scaler) / 2) - 4, transform.position.y, transform.position.z);
				endPos2 = new Vector3 (endPos1.x + (transform.localScale.x * scaler)  + 10, endPos1.y, endPos1.z);
			}
			else 
			{
				endPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z - ((transform.localScale.z * scaler) / 2) - 4);
				endPos2 = new Vector3 (endPos1.x, endPos1.y, endPos1.z + (transform.localScale.z * scaler)  + 10);
			}
		}
		else 
		{
			if (transform.localScale.x > transform.localScale.z) 
			{
				endPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z - ((transform.localScale.z * scaler) / 2) - 4);
				endPos2 = new Vector3 (endPos1.x, endPos1.y, endPos1.z + (transform.localScale.z * scaler)  + 10);
			}
			else 
			{
				endPos1 = new Vector3(transform.position.x - ((transform.localScale.x * scaler) / 2) - 4, transform.position.y, transform.position.z);
				endPos2 = new Vector3 (endPos1.x + (transform.localScale.x * scaler)  + 10, endPos1.y, endPos1.z);
			}
		}

		endPos1 += new Vector3 (0, 1, 0);
		endPos2 += new Vector3 (0, 1, 0);
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
					//waiting.Remove(w);
				}
				waiting.Clear();
			}
		}

//		if (timer <= 0)
//		{
//			change();
//			timer = 10;
//		}
//		else 
//		{
//			timer -= Time.deltaTime;
//		}
	}

	public void change()
	{
		if (crossAllowed)
		{
			crossAllowed = false;
			gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
		}
		else 
		{
			crossAllowed = true;
			gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.green;
		}
	}

	Vector3 FindClosestNode(Vector3 otherPos)
	{
		float distance1 = Vector3.Distance(otherPos, endPos1);
		float distance2 = Vector3.Distance(otherPos, endPos2);
		
		return (distance1 > distance2) ? endPos2 : endPos1;
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
			else /*if (crossAllowed && timer <= 5.0f) */
			{
				waiting.Add(other.gameObject);
				other.SendMessage("TemporaryDestination", FindClosestNode(other.transform.position));
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (endPos1, 1);
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere (endPos2, 1);
	}

//	void Initialize()
//	{
//		//parent = gameObject.transform.parent.gameObject;
//		//this.transform.localScale = gameObject.transform.parent.gameObject.transform.localScale;
//		//this.transform.position = new Vector3 (0, 2, 0);
//
//		this.GetComponent<BoxCollider> ().transform.position = this.transform.position + new Vector3 (0, 2, 0);
//	}
}
