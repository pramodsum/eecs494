using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public GameObject[] HeartHalves;
	public int MaxHeartHalves = 6;
	public int CurrentHeartHalves = 6;

	public GameObject gameOverText;

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

	void Update( ){
		if(CurrentHeartHalves == 0){
			gameOverText.SetActive(true);
			if(Input.anyKey)
				Application.LoadLevel(Application.loadedLevelName);
		}
	}
	
}
