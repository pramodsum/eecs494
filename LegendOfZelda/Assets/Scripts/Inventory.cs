using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int AmountOfKeys;

	public bool HasKey( ){
		return AmountOfKeys > 0;
	}

	public void UseKey( ){
		AmountOfKeys--;
	}

	// Use this for initialization
	void Start () {
		AmountOfKeys = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
