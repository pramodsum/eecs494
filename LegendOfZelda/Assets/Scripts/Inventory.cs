using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int AmountOfKeys;
	public Text KeyText;

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
		KeyText.text = "Keys x " + AmountOfKeys;
	}
}
