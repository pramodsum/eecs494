using UnityEngine;
using System.Collections;

public class BossAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		public float moveSpeed;
		public int direction; // { right, left }
		Vector3 colliderPosition;
		public Vector2 faceDirection = -Vector2.right;
		float deltaTime = 0;
	
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
				deltaTime += Time.fixedDeltaTime;
				if (deltaTime > 5.0f) {
						//Change direction
						faceDirection = Vector2.zero;
						direction += 1;
						direction %= 2;
						deltaTime = 0f;
				}
		
				//Sprite walking animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % sprites.Length;
				spriteRenderer.sprite = sprites [index];
				if (direction == 0)
						faceDirection = Vector2.right;
				else if (direction == 1)
						faceDirection = -Vector2.right;
		
				rigidbody2D.velocity = faceDirection * moveSpeed;
		}
	
	
		void OnTriggerEnter2D (Collider2D collider)
		{
				if (collider.tag == "Player") {
						Camera.main.GetComponent<HealthScript> ().Hit ();
				}
				if (collider.tag != "Weapon") {
						transform.position -= (new Vector3 (faceDirection.x, faceDirection.y, 0)) * .2f;
						faceDirection = Vector2.zero;
						//Change direction when enemy collides with something
						direction += 1;
						direction %= 2;
				}
		}
}
