using UnityEngine;
using System.Collections;

public enum DoorPosition {
	TOP,
	BOTTOM,
	LEFT,
	RIGHT
}

public class OpenDoor : MonoBehaviour {
	public Transform transport;
	public DoorPosition position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Player"){
			collider.transform.position = transport.position;
			if(position == DoorPosition.RIGHT){
				Camera.main.GetComponent<CameraMovement>().MoveRight ( );
			}
			if(position == DoorPosition.LEFT){
				Camera.main.GetComponent<CameraMovement>().MoveLeft ( );
			}
			if(position == DoorPosition.TOP){
				Camera.main.GetComponent<CameraMovement>().MoveUp ( );
			}
			if(position == DoorPosition.BOTTOM){
				Camera.main.GetComponent<CameraMovement>().MoveDown ( );
			}
		}
	}
}
