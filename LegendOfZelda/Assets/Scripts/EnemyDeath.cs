using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public int HitPoints = 1;
	public GameObject Loot;

	public void Hit( ){
		HitPoints--;
		if(HitPoints == 0){
			if(Loot != null) Instantiate(Loot, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
