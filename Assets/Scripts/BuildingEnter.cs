using UnityEngine;
using System.Collections;

public class BuildingEnter : MonoBehaviour {

	//public GameObject[] occupants;
	public int max_occupants = 100;
	public int count = 0;
	// Use this for initialization
	void OnCollisionEnter(Collision collision) {
		if (count < max_occupants) 
		{

			if (collision.gameObject.tag == "Pedestrian") {
					Destroy (collision.gameObject);
					count++;
				}
		}
	}
}
