using UnityEngine;
using System.Collections;

public class TrainEnter : MonoBehaviour {
	
	//public GameObject[] occupants;
	public int max_occupants = 100;
	//public int [] count;
	public int count = 0;
	public GameObject entrance;
	public GameObject [] nextStation;

	// Use this for initialization
	void OnCollisionEnter(Collision collision) 
	{
		//if(collision.transform.position == entrance.transform.position)
		//{
			if (count < max_occupants) 
			{
			
				if (collision.gameObject.tag == "Pedestrian") 
				{
					Destroy (collision.gameObject);
					count++;
				}
			}
		//}
		/*if (count2 < max_occupants) 
		{
			if (collision.gameObject.tag == "Pedestrian") 
			{
				Destroy (collision.gameObject);
				count2++;
			}
		}
		if (count3 < max_occupants) 
		{
			if (collision.gameObject.tag == "Pedestrian") 
			{
				Destroy (collision.gameObject);
				count3++;
			}
		}
		if (count4 < max_occupants) 
		{
			if (collision.gameObject.tag == "Pedestrian") 
			{
				Destroy (collision.gameObject);
				count4++;
			}
		}
	}*/

	}
}