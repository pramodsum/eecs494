using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour
{
		public GameObject OpenDoorObject;

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter2D (Collider2D collider)
		{
				Debug.Log ("We collided!");
				if (collider.tag == "Player" && (Camera.main.GetComponent<Inventory> ().HasKey () || Camera.main.GetComponent<HealthScript> ().GodMode)) {
						if (!Camera.main.GetComponent<HealthScript> ().GodMode)
								Camera.main.GetComponent<Inventory> ().AmountOfKeys--;
						OpenDoorObject.SetActive (true);
						gameObject.SetActive (false);
				}
		}
}
