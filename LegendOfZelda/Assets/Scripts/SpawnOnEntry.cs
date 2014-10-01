using UnityEngine;
using System.Collections;

public class SpawnOnEntry : MonoBehaviour
{
		public GameObject[] enemies;
		public bool inRoom = false;

		void OnTriggerEnter2D (Collider2D collider)
		{
				for (int i = 0; i < enemies.Length; i++) {
						GameObject temp = Instantiate (enemies [i], new Vector3 (Random.Range (-3.5f, 3.5f), Random.Range (-6.0f, 6.0f), 0), transform.rotation) as GameObject;
						temp.transform.parent = transform;			
						Debug.Log ("INSTANTIATING ENEMY HERE: " + new Vector3 (Random.Range (-3.5f, 3.5f), Random.Range (-6.0f, 6.0f), 0));
				}
		}
}
