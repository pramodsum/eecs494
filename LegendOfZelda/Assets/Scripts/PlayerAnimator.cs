using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		public float moveSpeed;
		private Vector3 moveDirection;

		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Sprite walking animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % sprites.Length;
				spriteRenderer.sprite = sprites [index];
				// 1
				Vector3 currentPosition = transform.position;
				// 2
				if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
						transform.Translate (Vector2.right * moveSpeed / 100);
				} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
						transform.Translate (-Vector2.right * moveSpeed / 100);
				} else if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
						transform.Translate (Vector2.up * moveSpeed / 100);
				} else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
						transform.Translate (-Vector2.up * moveSpeed / 100);
				}
		}
}
