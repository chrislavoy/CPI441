using UnityEngine;
using System;
using System.Collections;

public class TimeOfDay : MonoBehaviour
{
	public bool lightChanges;
	public bool timeChanges;
	public float dayLength;
	
	public float currentTime;
	public int currentHour;
	private Light sun;
	
	void Start () 
	{
		sun = GetComponent<Light>();
		currentTime = (transform.rotation.x / 360.0f) * 24.0f + (;
	}

	void Update () 
	{
		if (timeChanges) 
		{
			currentTime += Time.deltaTime;
			//currentTime = currentTime % dayLength;

			currentHour = (int)(Mathf.Ceil((currentTime / dayLength) * 24.0f) % 24.0f);
			//currentHour = (int) currentTime / (int)dayLength;
			Mathf.Clamp(currentHour, 0, 24);
		}

		if (lightChanges) 
		{
			transform.Rotate(Vector3.right * ((Time.deltaTime / dayLength) * 360.0f), Space.Self);

			if (currentHour >= 7 && currentHour <= 18) 
			{
				sun.intensity = Mathf.Lerp(0.0f, 1.0f, Time.time);
				RenderSettings.fog = true;
				RenderSettings.ambientIntensity = Mathf.Lerp(0.5f, 1.0f, Time.time);
			}
			else
			{
				sun.intensity = Mathf.Lerp(1.0f, 0.0f, Time.time);
				RenderSettings.fog = false;
				RenderSettings.ambientIntensity = Mathf.Lerp(1.0f, 0.5f, Time.time);
			}
		}
	}
}
