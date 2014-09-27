using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {
	public GameObject OpenDoorObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player" && Camera.main.GetComponent<Inventory>().HasKey()){
			collider.GetComponent<Inventory>().AmountOfKeys--;
			OpenDoorObject.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
