using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public GameObject[] HeartHalves;
	public int MaxHeartHalves = 6;
	public int CurrentHeartHalves = 6;
	public bool GodMode = false;
	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		CurrentHeartHalves = MaxHeartHalves;
	}

	public void Hit( ){
		if( CurrentHeartHalves > 0 && !GodMode) {
			CurrentHeartHalves--;
			HeartHalves[CurrentHeartHalves].GetComponent<Image>().color = new Color(0,0,0,0);
		}
	}

	public void Heal(int amount){
		for( int i = 0; i < amount; i++ ){
			if(CurrentHeartHalves < MaxHeartHalves){
				CurrentHeartHalves += 1;
				HeartHalves[CurrentHeartHalves - 1].GetComponent<Image>().color = new Color(1,0,0,1);
			} else {
				break;
			}
		}
	}

	void FixedUpdate( )
	{
		if(Input.GetKeyDown(KeyCode.G)){
			GodMode = !GodMode;
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
