﻿using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int AmountOfKeys{
		get;
		set;
	}

	public bool HasKey( ){
		return AmountOfKeys > 0;
	}

	// Use this for initialization
	void Start () {
		AmountOfKeys = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
