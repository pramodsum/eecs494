using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public void MoveUp( ){
		camera.transform.position += new Vector3( 0, 11, 0);
	}

	public void MoveDown( ){
		camera.transform.position -= new Vector3( 0, 11, 0);
	}

	public void MoveLeft( ) {
		camera.transform.position -= new Vector3( 16, 0, 0 );
	}

	public void MoveRight( ) {
		camera.transform.position += new Vector3( 16, 0, 0 );
	}
}
