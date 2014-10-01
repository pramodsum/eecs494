
using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

	public GameObject attack;
	public float shootSpeed = 7.5f;
	public GameObject existingAttack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z) && existingAttack == null){
			Vector2 attackDirection = gameObject.GetComponent<PlayerAnimator>().faceDirection;
		    existingAttack = Instantiate(attack, transform.position + new Vector3(attackDirection.x, attackDirection.y, 0),Quaternion.identity) as GameObject;
			HealthScript hs = Camera.main.GetComponent<HealthScript>();
			if(hs.CurrentHeartHalves == hs.MaxHeartHalves){
				existingAttack.rigidbody2D.velocity = gameObject.GetComponent<PlayerAnimator>().faceDirection * shootSpeed;
			}
		}
	}

}
