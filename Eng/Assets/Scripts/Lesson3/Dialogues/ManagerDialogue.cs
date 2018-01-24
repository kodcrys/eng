using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDialogue : MonoBehaviour {
	[SerializeField]
	private UnityEngine.UI.Text dialogueText, dialogueNumber;

	[TextArea (1,3)]
	public string[] listTitle;

	[SerializeField]
	private AudioClip[] dialogueAudio;

	private AudioSource audio;

	[SerializeField]
	GameObject A, B, C, next, previous;

	void Update()
	{
		if (audio.isPlaying == true) {
			A.transform.GetComponent<UnityEngine.UI.Button> ().enabled = false;
			B.transform.GetComponent<UnityEngine.UI.Button> ().enabled = false;
			C.transform.GetComponent<UnityEngine.UI.Button> ().enabled = false;
			next.SetActive (false);
			previous.SetActive (false);
		} 
		else 
		{
			A.transform.GetComponent<UnityEngine.UI.Button> ().enabled = true;
			B.transform.GetComponent<UnityEngine.UI.Button> ().enabled = true;
			C.transform.GetComponent<UnityEngine.UI.Button> ().enabled = true;
		}
	}

	public void DisplayNextSentence()
	{
		if (audio.isPlaying == false) 
		{
			audio.PlayOneShot (dialogueAudio[Lesson3Manager.currentQuestion]);
		}

		string sentence = listTitle[Lesson3Manager.currentQuestion];

		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";

		dialogueNumber.text = "";
		dialogueNumber.text = (Lesson3Manager.currentQuestion + 1).ToString ();

		foreach (char letter in sentence.ToCharArray()) 
		{
			dialogueText.text += letter;
			yield return null;
		}

	}
}
