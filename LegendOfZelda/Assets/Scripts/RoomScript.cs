using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour
{
		public Sprite specialItem;
		private SpriteRenderer spriteRenderer;
		private SpriteRenderer keySpriteRenderer;
		public int numEnemies = 0;
		bool allEnemiesKilled = false;

		// Use this for initialization
		void Start ()
		{
				spriteRenderer = renderer as SpriteRenderer;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (numEnemies == 0) {
						allEnemiesKilled = true;
						Debug.Log ("YAY! Display Key!");
//						displaySpecialItem ();
				}
		}

		void displaySpecialItem ()
		{
				spriteRenderer = renderer as SpriteRenderer;
				keySpriteRenderer.sprite = specialItem;
				keySpriteRenderer.enabled = true;
		}
}
