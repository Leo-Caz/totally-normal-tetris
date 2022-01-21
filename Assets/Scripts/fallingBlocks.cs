using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlocks : MonoBehaviour
{
	public Rigidbody2D rb;
	public float movementSpeed = 10f;
	public bool hasLanded = false;

	void FixedUpdate() {
		if (!hasLanded) {
			float horizontalMove = Input.GetAxisRaw("Horizontal");
			rb.AddForce(new Vector2(horizontalMove * movementSpeed, 0f), ForceMode2D.Force);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		foreach (ContactPoint2D contact in collision.contacts) {
			int contactLayer = contact.collider.gameObject.layer;
			if (contactLayer == LayerMask.NameToLayer("Blocs") || contactLayer == LayerMask.NameToLayer("Ground")) {
				hasLanded = true;
			}
		}
	}
}
