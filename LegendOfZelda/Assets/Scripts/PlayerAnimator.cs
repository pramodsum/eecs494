using UnityEngine;
using System.Collections;


public class PlayerAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
	    const  float DefaultMovespeed = 7.5f;
	const float moveSpeed = 7.5f;
		public Vector2 movementDirection;

		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}

	void Update(){
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				movementDirection = Vector2.right;
		} 
		if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			movementDirection = -Vector2.right;
		} 
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			movementDirection = Vector2.up;
		} 
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			movementDirection = -Vector2.up;
		}

	}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
		if (!Input.GetKey (KeyCode.D)&& 
		    !Input.GetKey (KeyCode.RightArrow) && 
		    !Input.GetKey (KeyCode.A) &&
		    !Input.GetKey (KeyCode.LeftArrow) &&
		    !Input.GetKey (KeyCode.W) &&
		    !Input.GetKey (KeyCode.UpArrow) &&
		    !Input.GetKey (KeyCode.S) &&
		    !Input.GetKey (KeyCode.DownArrow)) {
			movementDirection = Vector2.zero;
		}
			//Sprite walking animations
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites [index];
			gameObject.GetComponent<Rigidbody2D>().velocity = movementDirection * moveSpeed;
		}

	void OnTriggerEnter2D(Collider2D collider){
		if( collider.GetComponent<PhysicsObject>().ObjectType == PhysicsObjectType.Immovable ) {
			transform.position -= (new Vector3(movementDirection.x, movementDirection.y, 0)) * .3f;
			movementDirection = Vector2.zero;
		}
	}
	
}
