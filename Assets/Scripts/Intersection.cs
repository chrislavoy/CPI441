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
	}

	void Update () 
	{
		Timer ();
	}

	void Timer()
	{
		if (timer <= 0) 
		{
			print("CHANGE");
			// AllStop();
			if (allWaitTime > 0) 
			{
				allWaitTime -= Time.deltaTime;
			}
			else 
			{
				// Change();
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

		}
		foreach (GameObject cw in directionTwoCrosswalks) 
		{
			
		}
	}

	void Change()
	{

	}
}