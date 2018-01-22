﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimations : MonoBehaviour {

	[SerializeField]
	enum ObjectAni { none, catAni, cloudAniMove }

	[SerializeField]
	ObjectAni objectAni = ObjectAni.none;

	[SerializeField]
	SpriteRenderer sprTarget;

	[SerializeField]
	ObjectAniClass objectAniClass;

	// Use this for initialization
	void Start () {
		StartCoroutine (RunAni ());
	}

	IEnumerator RunAni(){
		while (true) {
			switch (objectAni) {
			case ObjectAni.none:
				break;
			case ObjectAni.catAni:
				objectAniClass.AniChangeFrameSprite1 (sprTarget);
				yield return new WaitForSeconds (Random.Range(2f, 5f));
				objectAniClass.AniChangeFrameSprite2 (sprTarget);
				yield return new WaitForSeconds (0.2f);
				break;
			case ObjectAni.cloudAniMove:
				objectAniClass.Move ();
				break;
			} 
			yield return new WaitForSeconds (0.02f);
		}
	}
}
