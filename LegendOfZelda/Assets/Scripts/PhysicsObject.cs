﻿using UnityEngine;
using System.Collections;

public enum PhysicsObjectType {
	Movable,
	Immovable,
	Enemy
}

public class PhysicsObject : MonoBehaviour {

	public PhysicsObjectType ObjectType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
