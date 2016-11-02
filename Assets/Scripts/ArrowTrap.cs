﻿using UnityEngine;
using System.Collections;

public class ArrowTrap : MonoBehaviour {
	public Transform shootPoint;
	public GameObject Arrow;
	public bool alwaysShoot = false;

	bool isShooting = false;
	// Use this for initialization
	void Start () {
			StartCoroutine (ShootArrow ());
	}
	// Update is called once per frame
	void Update () {
		
	}
		


	void FixedUpdate() {
		if (alwaysShoot == true) {
			return;
		}//If always shooting, just return

		RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.left, Mathf.Infinity, 1 << 8); //raycast to the left
		//Debug.DrawRay(transform.position, Vector2.left, Color.green); show ray in scene view
		if (hit) {
				isShooting = true;
		}//if raycast hits player, begin shooting if not already shooting
		else {
			isShooting = false;
		}
	}

	IEnumerator ShootArrow() {
		while (true) {
			//shoot arrow
			if (isShooting || alwaysShoot) {
				Instantiate (Arrow, shootPoint.position, Quaternion.identity);
			}
			yield return new WaitForSeconds (1);
		}
	}//shoot arrow every second if player is in range

}
