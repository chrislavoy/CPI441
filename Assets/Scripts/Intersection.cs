using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Intersection : MonoBehaviour 
{
	// Public Variables
	public float timer;
	public float allWaitTime;
	public GameObject topCrosswalk;
	public GameObject leftCrosswalk;
	public GameObject rightCrosswalk;
	public GameObject bottomCrosswalk;

	// Private Variables
	private List<GameObject> directionOneCrosswalks;
	private List<GameObject> directionTwoCrosswalks;
	private bool directionOneAllowed;
	private float timerValue;
	private float allWaitTimeValue;

	void Start () 
	{
		timerValue = timer;
		allWaitTimeValue = allWaitTime;
		directionOneCrosswalks = new List<GameObject> ();
		directionTwoCrosswalks = new List<GameObject> ();
		directionOneCrosswalks.Add (topCrosswalk);
		directionOneCrosswalks.Add (bottomCrosswalk);
		directionTwoCrosswalks.Add (leftCrosswalk);
		directionTwoCrosswalks.Add (rightCrosswalk);
		directionOneAllowed = true;
//		foreach (GameObject cw in directionOneCrosswalks) 
//		{
//			cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.green;
//		}
//		foreach (GameObject cw in directionTwoCrosswalks) 
//		{
//			cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
//		}
	}

	void Update() 
	{
		Timer();
	}

	void Timer()
	{
		if (timer <= 0) 
		{
			//print("CHANGE");
			AllStop();
			if (allWaitTime > 0) 
			{
				allWaitTime -= Time.deltaTime;
			}
			else 
			{
				Change();
				allWaitTime = allWaitTimeValue;
				timer = timerValue;
			}
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}

	void AllStop()
	{
		foreach (GameObject cw in directionOneCrosswalks) 
		{
			cw.GetComponent<Crosswalk>().crossAllowed = false;
//			cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
		}
		foreach (GameObject cw in directionTwoCrosswalks) 
		{
			cw.GetComponent<Crosswalk>().crossAllowed = false;
//			cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
		}
	}

	void Change()
	{
		if(directionOneAllowed)
		{
			foreach (GameObject cw in directionOneCrosswalks) 
			{
				cw.GetComponent<Crosswalk>().crossAllowed = false;
				//cw.gameObject.renderer.material.color = Color.red;
//				cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
			}
			foreach (GameObject cw in directionTwoCrosswalks) 
			{
				cw.GetComponent<Crosswalk>().crossAllowed = true;
				//cw.gameObject.renderer.material.color = Color.green;
//				cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.green;
			}
			directionOneAllowed = false;
		}
		else 
		{
			foreach (GameObject cw in directionOneCrosswalks) 
			{
				cw.GetComponent<Crosswalk>().crossAllowed = true;
				//cw.gameObject.renderer.material.color = Color.green;
//				cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.green;
			}
			foreach (GameObject cw in directionTwoCrosswalks) 
			{
				cw.GetComponent<Crosswalk>().crossAllowed = false;
				//cw.gameObject.renderer.material.color = Color.red;
//				cw.gameObject.GetComponentInChildren<Renderer>().renderer.material.color = Color.red;
			}
			directionOneAllowed = true;
		}
	}
}