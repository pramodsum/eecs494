using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShutDoor : MonoBehaviour {

	public GameObject[] Enemies;
	public bool IsOpen;
	private int EnemyCount;

	// Use this for initialization
	void Start () {
		IsOpen = false;
		EnemyCount = Enemies.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(EnemyCount == 0){
			IsOpen = true;
			gameObject.GetComponent<OpenDoor>().enabled = true;
			gameObject.GetComponent<PhysicsObject>().enabled = false;
		}
	}
}
