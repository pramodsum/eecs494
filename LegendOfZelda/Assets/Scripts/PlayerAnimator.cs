using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{
	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	const  float DefaultMovespeed = 4.8f;
	const float moveSpeed = 4.8f;
	public Vector2 movementDirection;
	public Vector2 faceDirection = -Vector2.up;
	int directionIndex = 0;
	// Use this for initialization
	void Start ()
	{
			spriteRenderer = renderer as SpriteRenderer;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				movementDirection = Vector2.right;
							faceDirection = Vector2.right;

			directionIndex = 1;
		} 
		if (Input.GetKey (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			movementDirection = -Vector2.right;
			faceDirection = -Vector2.right;

			directionIndex = 3;
		} 
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			movementDirection = Vector2.up;
			faceDirection = Vector2.up;

			directionIndex = 2;
		} 
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			movementDirection = -Vector2.up;
			faceDirection = -Vector2.up;

			directionIndex = 0;
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
		index = index % sprites.Length % 2;
		spriteRenderer.sprite = sprites [directionIndex * 2 + index];
		Vector2 velocity = movementDirection * moveSpeed;
		if(movementDirection == Vector2.up || movementDirection == -Vector2.up){
			float remainder = Mathf.Abs(transform.position.x % .5f);
			Debug.Log (remainder);
			if((remainder > 0.05f  && remainder < .25f && transform.position.x < 0) || 
			   (remainder >= .25f && transform.position.x > 0)){
				transform.Translate (.025f / 16f, 0 ,0);
			} else if( (remainder > 0.05f && remainder < .25f && transform.position.x > 0) ||
			          (remainder >= .25f && transform.position.x < 0)){
				transform.Translate(-.025f / 16f, 0 ,0 );
			}
		} else if( movementDirection == Vector2.right || movementDirection == -Vector2.right){
			float remainder = Mathf.Abs(transform.position.y % .5f);
			if((remainder > 0.02f  && remainder < .25f && transform.position.y < 0) || 
			   (remainder >= .25f && transform.position.y > 0)){
				transform.Translate (0, .025f / 16f ,0);
			} else {
				transform.Translate(0, -0.025f / 16f ,0 );
			}

		}
		gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.GetComponent<PhysicsObject>() == null) return;
		PhysicsObjectType objectType = collider.GetComponent<PhysicsObject>().ObjectType;
		if( objectType == PhysicsObjectType.Immovable ||
		    (objectType == PhysicsObjectType.Locked && !Camera.main.GetComponent<Inventory>().HasKey())) {
			transform.position -= (new Vector3(movementDirection.x, movementDirection.y, 0)) * .2f;
			movementDirection = Vector2.zero;
		}
		if( objectType == PhysicsObjectType.Enemy){
			Camera.main.GetComponent<HealthScript>().Hit();
			transform.position -= (new Vector3(movementDirection.x, movementDirection.y, 0)) * .2f;
			movementDirection = Vector2.zero;
		}
	}
	
}
