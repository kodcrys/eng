using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLesson1 : MonoBehaviour {

	[SerializeField]
	GameObject[] objectsDrag;

	[SerializeField]
	GameObject[] objectsName;

	[SerializeField]
	AudioClip [] soundsOfLesson;

	[SerializeField]
	AudioSource audioSource;

	int indexSound;

	[SerializeField]
	UIAnimations btnSound;

	// Use this for initialization
	void Start () {
		indexSound = 0;
	}

	void Update() {
		if (audioSource.isPlaying == false)
			btnSound.SoundOff ();
	}
	
	public void ScaleMaxItem(int index) {
		objectsDrag [index].transform.localScale = new Vector3 (1.3f, 1.3f, 1f);
	}

	public void ScaleMinItem(int index) {
		objectsDrag [index].transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	public void PlaySound() {
		if(soundsOfLesson[indexSound] != null)
			audioSource.PlayOneShot (soundsOfLesson [indexSound]);
	}
}
