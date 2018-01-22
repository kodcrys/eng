using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerLession2 : MonoBehaviour {

	public static UIManagerLession2 instance;

	public Lession2Manager allLession;

	public GameObject nextButton, backButton, preLessonButton, nextLessonButton;


	void Start(){
		instance = this;
	}

	void Update(){
		allLession.lessions [allLession.currentLession].SetActive (true);

		if (allLession.currentLession == 0) {
			backButton.SetActive (false);
		} else if (allLession.currentLession == allLession.lessions.Count - 1) {
			nextButton.SetActive (false);
		}
/*		if (allLession.sawTest [allLession.currentLession] == true) {
			StartCoroutine (WaitForTestDone ());
		}*/
	}

	public void NextButton(){
		if (allLession.currentLession < allLession.lessions.Count - 1) {
			allLession.currentLession++;
			allLession.lessions [allLession.currentLession - 1].SetActive (false);
			if (allLession.currentLession == allLession.lessions.Count - 1) {
				nextLessonButton.SetActive (true);
			} else {
				backButton.SetActive (true);
				preLessonButton.SetActive (false);
			}
		}
	}

	public void BackButton(){
		if (allLession.currentLession >= 1) {
			allLession.currentLession--;
			allLession.lessions [allLession.currentLession + 1].SetActive (false);
			if (allLession.currentLession == 0) {
				preLessonButton.SetActive (true);
			} else {
				nextButton.SetActive (true);
				nextLessonButton.SetActive (false);
			}
		}
	}

/*	IEnumerator WaitForTestDone(){
		yield return new WaitForSeconds (1.5f);
		allLession.tests [allLession.currentLession].SetActive (false);
	}*/
}
