using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public GameObject[] HeartHalves;
	public int MaxHeartHalves = 6;
	public int CurrentHeartHalves = 6;

	// Use this for initialization
	void Start () {
		CurrentHeartHalves = MaxHeartHalves;
	}
	
	// Update is called once per frame

	public void Hit( ){
		if( CurrentHeartHalves > 0 ) CurrentHeartHalves--;
		HeartHalves[CurrentHeartHalves].GetComponent<Image>().color = new Color(0,0,0,0);
	}

	public void Heal(int amount){
		CurrentHeartHalves += amount;
		if(CurrentHeartHalves > MaxHeartHalves) CurrentHeartHalves = MaxHeartHalves;
		for( int i = 0; i < CurrentHeartHalves; i++ ){
			HeartHalves[CurrentHeartHalves].GetComponent<Image>().color = new Color(1,0,0,1);
		}
	}
}
