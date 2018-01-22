using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public List<Text> dialogueText = new List<Text> ();
//	public Text dialogueText;
	public List<GameObject> frameText = new List<GameObject> ();
	public int currentText;
	public int currentFrame;

	public GameObject[] nextDialogueButton;
	public GameObject nextButton, backButton, preLessonButton, nextLessonButton;

	public SoundLessionManager sounds;

	public Animator robotMove, testAnimation;

	public Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		currentText = 0;
		currentFrame = 0;
		nextButton.SetActive (false);
		backButton.SetActive (false);
		preLessonButton.SetActive (false);
		nextLessonButton.SetActive (false);
		if (robotMove != null) {
			robotMove.enabled = false;
		}
	}

	void Update(){
		if (sounds.audioSound.isPlaying == false) {
			for (int i = 0; i < nextDialogueButton.Length; i++) {
				nextDialogueButton [i].SetActive (true);
			}
		} else {
			for (int i = 0; i < nextDialogueButton.Length; i++) {
				nextDialogueButton [i].SetActive (false);
			}
		}
	}
	
	public void StartDialogue(Dialogue dialogue){

		frameText [currentFrame].SetActive (true);
		if (robotMove != null) {
			robotMove.enabled = true;
		}

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}
		if (sounds.audioSound.isPlaying == false) {
			sounds.audioSound.PlayOneShot (sounds.sounds [currentText]);
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
			
		frameText [currentFrame].SetActive (true);

		if (currentFrame > 0) {
			frameText [currentFrame - 1].SetActive (false);
		}
	}

	IEnumerator TypeSentence(string sentence){
		dialogueText[currentText].text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText[currentText].text += letter;
			yield return null;
		}

		if (currentFrame < frameText.Count) {
			currentFrame++;
		}

		if (currentText < dialogueText.Count) {
			currentText++;
		}
	}

	void EndDialogue(){
		Debug.Log ("End of conversation.");
		for (int i = 0; i < frameText.Count; i++) {
			frameText [i].SetActive (true);
		}

		if (UIManagerLession2.instance.allLession.sawTest[UIManagerLession2.instance.allLession.currentLession] == false) {
			testAnimation.StartPlayback ();
			testAnimation.enabled = true;
			UIManagerLession2.instance.allLession.tests [UIManagerLession2.instance.allLession.currentLession].SetActive (true);
		}

		if (UIManagerLession2.instance.allLession.currentLession == 0) {
			backButton.SetActive (false);
			nextButton.SetActive (true);
			preLessonButton.SetActive (true);
		} else if (UIManagerLession2.instance.allLession.currentLession == UIManagerLession2.instance.allLession.lessions.Count - 1) {
			nextButton.SetActive (false);
			backButton.SetActive (true);
			nextLessonButton.SetActive (true);
		} else {
			nextButton.SetActive (true);
			backButton.SetActive (true);
			preLessonButton.SetActive (false);
			nextLessonButton.SetActive (false);
		}
	}
}
