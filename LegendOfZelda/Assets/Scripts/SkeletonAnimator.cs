using UnityEngine;
using System.Collections;

public class SkeletonAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		public float moveSpeed;
		public int direction; // { up, down, right, left }
		Vector3 colliderPosition;
	
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

				if (direction == 0)
						transform.Translate (Vector2.up * moveSpeed / 100);
				else if (direction == 1)
						transform.Translate (-1 * Vector2.up * moveSpeed / 100);
				else if (direction == 2)
						transform.Translate (Vector2.right * moveSpeed / 100);
				else 
						transform.Translate (-1 * Vector2.right * moveSpeed / 100);
		}
	
	
		void OnTriggerEnter2D (Collider2D collider)
		{
				//Change direction when enemy collides with something
				direction = Random.Range (0, 3);
		}
}
