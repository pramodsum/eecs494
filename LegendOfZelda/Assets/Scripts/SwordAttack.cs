using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

	public GameObject attack;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)){
			Vector2 attackDirection = gameObject.GetComponent<PlayerAnimator>().faceDirection;
			attack.transform.position = transform.position + new Vector3(attackDirection.x, attackDirection.y, 0);
			StartCoroutine("Attack");
		}
	}

	IEnumerator Attack(){
		attack.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		attack.SetActive(false);
	}

}
