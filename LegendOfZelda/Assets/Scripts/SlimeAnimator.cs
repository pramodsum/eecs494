using UnityEngine;
using System.Collections;

public class SlimeAnimator : MonoBehaviour
{
		public float moveSpeed;
		public int direction; // { up, down, right, left }
		Vector3 colliderPosition;
	
		// Update is called once per frame
		void FixedUpdate ()
		{		
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
