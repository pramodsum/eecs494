﻿using UnityEngine;
using System.Collections;

public class BatAnimator : MonoBehaviour
{
		public Sprite[] sprites;
		public float framesPerSecond;
		private SpriteRenderer spriteRenderer;
		const  float DefaultMovespeed = 7.5f;
		public float moveSpeed;
		public bool movingUp = false;
		int count = 0;
		public int MAX_COUNT = 200;
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
				//Sprite movement animations
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % sprites.Length;
				spriteRenderer.sprite = sprites [index];

				if (count == MAX_COUNT) {
						count = 0;
						if (movingUp) 
								movingUp = false;
						else
								movingUp = true;
				} else { 
						count++;
						if (movingUp)
								transform.Translate (Vector2.up * moveSpeed / 100);
						else
								transform.Translate (-1 * Vector2.up * moveSpeed / 100);
				}
		}
}
