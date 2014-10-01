using UnityEngine;
using System.Collections;

public class BoomerangEnemyAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		public float moveSpeed = 4.8f;
		public int direction; // { up, down, right, left }
		public Vector2 movementDirection = -Vector2.right;
		float deltaTime = 0;
		public GameObject attack;
		public float shootSpeed = 7.5f;
	
		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				GameObject currentAttack;
				deltaTime += Time.fixedDeltaTime;
				if (deltaTime > 1.0f) {
						//Change direction
						direction = Random.Range (0, 3);
				}
		
				//Sprite walking animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				
		if (direction < 2) {
				index = index % sprites.Length % 2;
				spriteRenderer.sprite = sprites [direction * 2 + index];
				} else if (direction == 2) {
						spriteRenderer.sprite = sprites [direction + 2];
				} else {
						spriteRenderer.sprite = sprites [direction + 2];
			}

				if (direction == 0) 
						movementDirection = Vector2.up;
				else if (direction == 1)
						movementDirection = -Vector2.up;
				else if (direction == 2)
						movementDirection = Vector2.right;
				else 
						movementDirection = -Vector2.right;

				if (deltaTime > 1.0f) {
						deltaTime = 0f;
			
						//Forward
						currentAttack = Instantiate (attack, transform.position + new Vector3 (movementDirection.x, movementDirection.y, 0), Quaternion.identity) as GameObject;
						currentAttack.rigidbody2D.velocity = movementDirection * shootSpeed;
				}
		
				rigidbody2D.velocity = movementDirection * moveSpeed;
		}
	
	
		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.tag == "Player") {
						Camera.main.GetComponent<HealthScript> ().Hit ();
				}
				if (collider.tag != "Weapon") {
			Debug.Log ("Collided!");
						transform.position -= (new Vector3 (movementDirection.x, movementDirection.y, 0)) * .3f;
						movementDirection = Vector2.zero;
						//Change direction when enemy collides with something
						direction += 1;
						direction %= 4;
				}
		}
}
