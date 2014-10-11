using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public Vector3 finalPosition;
	[SerializeField] float easeSpeed = 0.04f;
	float lastMoveAmountX = 0;
	float lastMoveAmountY = 0;

	void FixedUpdate () {
		lastMoveAmountX = transform.position.x;
		lastMoveAmountY = transform.position.y;
		transform.position = new Vector3(transform.position.x + (finalPosition.x - transform.position.x) * easeSpeed, transform.position.y + (finalPosition.y - transform.position.y) * easeSpeed, 0f);
		lastMoveAmountX -= transform.position.x;
		lastMoveAmountY -= transform.position.y;

		if(Mathf.Abs(lastMoveAmountX) <= 0.01 && Mathf.Abs(lastMoveAmountY) <= 0.01){
			GameManager.gm.allowMovement = true;
			Destroy(this);
		}
	}
}
