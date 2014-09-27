using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShutDoor : MonoBehaviour {

	public GameObject[] Enemies;
	public GameObject OpenDoorObject;
	public int EnemyCount;

	// Use this for initialization
	void Start () {
		EnemyCount = Enemies.Length;
	}
	
	// Update is called once per frame
	void Update () {
		EnemyCount = 0;
		foreach(var enemy in Enemies){
			if(enemy != null) EnemyCount++;
		}
		if(EnemyCount == 0){
			OpenDoorObject.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
