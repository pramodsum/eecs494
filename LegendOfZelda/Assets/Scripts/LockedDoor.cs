using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {
	public bool IsOpen;
	// Use this for initialization
	void Start () {
		IsOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player" && collider.GetComponent<Inventory>().HasKey()){
			collider.GetComponent<Inventory>().AmountOfKeys--;
			gameObject.GetComponent<OpenDoor>().enabled = true;
			gameObject.GetComponent<PhysicsObject>().enabled = false;
			IsOpen = true;
		}
	}
}
