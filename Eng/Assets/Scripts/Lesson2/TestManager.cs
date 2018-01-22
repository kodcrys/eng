using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour {

	public SoundLessionManager sounds;

	public GameObject RightCheck;
	public GameObject[] WrongCheck;
	public Transform answerPanel;
	public GameObject correctTest;
	public Animator correctTestAnimation;
	public bool[] answers;

	void Start(){
		InitShop ();
		correctTest.SetActive (false);
		correctTestAnimation.enabled = false;
		RightCheck.SetActive (false);
		for (int i = 0; i < WrongCheck.Length; i++) {
			WrongCheck [i].SetActive (false);
		}
	}

	public void ChooseAnswer(int currentIndex){
		if (answers [currentIndex] == true) {
			RightCheck.SetActive (true);
			if (sounds.audioSound.isPlaying == false) {
				sounds.audioSound.PlayOneShot (sounds.sounds [0]);
			}
			correctTest.SetActive (true);
			correctTestAnimation.enabled = true;
			UIManagerLession2.instance.allLession.sawTest [UIManagerLession2.instance.allLession.currentTest] = true;
			if (UIManagerLession2.instance.allLession.currentTest <= UIManagerLession2.instance.allLession.tests.Count - 1) {
				UIManagerLession2.instance.allLession.currentTest++;
			}
		} else {
			if (sounds.audioSound.isPlaying == false) {
				sounds.audioSound.PlayOneShot (sounds.sounds [1]);
			}

			if (answers [0] == true) {
				if (WrongCheck.Length - currentIndex == 1) {
					WrongCheck [0].SetActive (true);
				} else {
					WrongCheck [1].SetActive (true);
				}
			} else if (answers [1] == true || answers [2] == true) {
				if (WrongCheck.Length - currentIndex == 2) {
					WrongCheck [0].SetActive (true);
				} else {
					WrongCheck [1].SetActive (true);
				}
			}

		}
		Debug.Log (WrongCheck.Length - currentIndex);
	}

	private void InitShop(){
		if (answerPanel == null) {
			Debug.Log ("You did not asign the panel");
		}

		int i = 0;
		foreach (Transform t in answerPanel) {
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => ChooseAnswer (currentIndex));
			i++;
		}
	}
}
