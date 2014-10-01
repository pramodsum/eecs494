using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TriForceCollision : MonoBehaviour {
	bool won = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(won && Input.anyKeyDown){
			Application.LoadLevel("_Scene_0");
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if( collider.tag == "Player" && Application.loadedLevelName == "_Scene_0"){
			Application.LoadLevel("_Scene_1");
		} else {
			Text[] texts = Camera.main.GetComponentsInChildren<Text>();
			foreach(var text in texts){
				if(text.gameObject.name == "GameOverText"){
					text.text = "YOU WON!";
					text.gameObject.SetActive(true);
					won = true;
				} 
			}
		}
	}
}
