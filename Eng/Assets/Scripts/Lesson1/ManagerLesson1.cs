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

	[Header("PosTrue")]
	[SerializeField]
	GameObject[] posTrue;
	[SerializeField]
	GameObject[] overPosTrue;
	[SerializeField]
	int indexOver;
	[SerializeField]
	GameObject[] overPosTrue1;
	[SerializeField]
	int indexOver1;
	[SerializeField]
	GameObject[] overPosTrue2;
	[SerializeField]
	int indexOver2;

	[HideInInspector]
	public bool isTrue;

	// Use this for initialization
	void Start () {
		isTrue = true;
		indexSound = -1;
	}

	void Update() {
		UnlockPosTrue (indexSound);
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
		if (isTrue) {
			indexSound++;
			isTrue = false;
		}
		if(indexSound < soundsOfLesson.Length && soundsOfLesson[indexSound] != null)
			audioSource.PlayOneShot (soundsOfLesson [indexSound]);
	}

	void UnlockPosTrue(int indexSound) {
		for (int i = 0; i < posTrue.Length; i++) {
			if (indexSound >= 0) {
				if (i <= indexSound)
					posTrue [i].SetActive (true);
				else
					posTrue [i].SetActive (false);

				if (overPosTrue.Length > 0 && i == indexOver) {
					for (int j = 0; j < overPosTrue.Length; j++)
						overPosTrue [j].SetActive (true);
				}

				if (overPosTrue1.Length > 0 && i == indexOver1) {
					for (int j = 0; j < overPosTrue1.Length; j++)
						overPosTrue1 [j].SetActive (true);
				}

				if (overPosTrue2.Length > 0 && i == indexOver2) {
					for (int j = 0; j < overPosTrue.Length; j++)
						overPosTrue2 [j].SetActive (true);
				}
			}
		}
	}

	public void Home(string nameScene){
		UnityEngine.SceneManagement.SceneManager.LoadScene (nameScene);
	}

	public void LevelCountinue(int level){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Lesson"+level);
	}
}
