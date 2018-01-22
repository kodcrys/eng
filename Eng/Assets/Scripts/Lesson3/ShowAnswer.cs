using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnswer : MonoBehaviour {

	[SerializeField]
	Sprite[] listSprites;

	[SerializeField]
	Sprite correct;

	[SerializeField]
	int[] listAnswers;

	[SerializeField]
	GameObject imageAnswer, answer;

	// Use this for initialization
	void Start () {
		// The button to show the answer
		UnityEngine.UI.Button btnclick = transform.GetComponent<UnityEngine.UI.Button> ();
		btnclick.onClick.AddListener (ItemOnClick);
	}

	void OnEnable ()
	{
		imageAnswer.GetComponent<UnityEngine.UI.Image> ().sprite = listSprites [Lesson3Manager.currentQuestion];
		if (listAnswers [Lesson3Manager.currentQuestion] == 1)
			answer.GetComponent<UnityEngine.UI.Image> ().sprite = correct;
	}

	void ItemOnClick()
	{
		answer.SetActive (true);
	}
}
