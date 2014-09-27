using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public GameObject ShutDoorObject;
	public int HitPoints = 1;

	public void Hit( ){
		HitPoints--;
		if(HitPoints == 0){
			Destroy(gameObject);
		}
	}
}
