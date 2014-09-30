using UnityEngine;
using System.Collections;

public class HeartCollision : MonoBehaviour {

	public int HealAmount = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Player"){
			HealthScript hs = Camera.main.GetComponent<HealthScript>();

			if(hs.CurrentHeartHalves < hs.MaxHeartHalves){
				Camera.main.GetComponent<HealthScript>().Heal(HealAmount);
				Destroy(gameObject);
			}

		}
	}
}
