﻿using UnityEngine;
using System.Collections;


public class TriForceCollision : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player"){
			Application.LoadLevel("_Scene_1");
		}
	}
}