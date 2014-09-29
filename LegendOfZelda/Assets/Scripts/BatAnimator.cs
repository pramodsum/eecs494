using UnityEngine;
using System.Collections;

public class BatAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		const  float DefaultMovespeed = 7.5f;
		public float moveSpeed;
		public bool movingUp = false;
		public int MAX_COUNT = 200;
	Vector2 movementDirection;

		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}
	
		void Update ()
		{

		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			
			//Sprite walking animations
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites [index];
			if (movingUp)
				movementDirection = Vector2.up;
			else 
				movementDirection = -Vector2.up;

			
			rigidbody2D.velocity = movementDirection * moveSpeed;
		}
	
		void OnTriggerEnter2D (Collider2D collider)
		{
		if( collider.tag == "Player"){
			Camera.main.GetComponent<HealthScript>().Hit();
		}
		if(collider.tag != "Weapon"){
			transform.position -= (new Vector3(movementDirection.x, movementDirection.y, 0)) * .2f;
			movementDirection = Vector2.zero;
			//Change direction when enemy collides with something
			movingUp = !movingUp;
		}
		}
}
