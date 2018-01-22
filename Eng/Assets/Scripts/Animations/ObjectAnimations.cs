using System.Collections;
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

	[SerializeField]
	AudioSource meowSound;

	[SerializeField]
	AudioSource soundlesson;

	[SerializeField]
	GameObject winCanvas;

	[SerializeField]
	GameObject introCanvas;

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
				meowSound.Stop ();
				objectAniClass.AniChangeFrameSprite1 (sprTarget);
				yield return new WaitForSeconds (Random.Range (3.5f, 7f));
				if(soundlesson.isPlaying == false && winCanvas.activeSelf == false && introCanvas.active == false)
					meowSound.Play ();
				objectAniClass.AniChangeFrameSprite2 (sprTarget);
				yield return new WaitForSeconds (0.56f);
				break;
			case ObjectAni.cloudAniMove:
				objectAniClass.Move ();
				break;
			} 
			yield return new WaitForSeconds (0.02f);
		}
	}
}
