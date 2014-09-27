using UnityEngine;
using System.Collections;

public class KeyCollision : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player"){
			Camera.main.GetComponent<Inventory>().AmountOfKeys++;
			Destroy(gameObject);
		}
	}
}
