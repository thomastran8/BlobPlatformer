﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FlagContact : MonoBehaviour {
//	Animation animate;
	private GameController gameController;
	public Collider2D player;
	private Collider2D col;
	Animator anim;
	// Use this for initialization
	void Start () {
	//	animate = GetComponent<Animation> ();
		anim = GetComponent<Animator> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame

	void Update () {
		if (col.IsTouching (player)) {
			anim.SetTrigger("Raised");
			gameController.incrementScore (100);
			StartCoroutine(nextLevel ());
		}
	}

	private IEnumerator nextLevel() {
		yield return new WaitForSeconds(2);
		Scene scene = SceneManager.GetActiveScene ();
		int i = scene.buildIndex;		
		SceneManager.LoadScene(i + 1);
	}

}
