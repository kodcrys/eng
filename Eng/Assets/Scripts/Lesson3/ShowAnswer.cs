	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnswer : MonoBehaviour {
	// list sprite for A, B, or C.
	[SerializeField]
	Sprite[] listSprites;

	// the sprite right image.
	[SerializeField]
	Sprite correct;

	// the list answer right or wrong for A, B, or C.
	[SerializeField]
	int[] listAnswers;

	// imageAnswer is the image is showed on the button, answer is right or wrong of the question.
	[SerializeField]
	GameObject imageAnswer, answer;

	[SerializeField]
	GameObject[] otherAnswer;

	bool checkEnable, checkClicked;
	float scale;
	int countScale;
	// Use this for initialization
	void Start () 
	{
		// The button to show the answer
		UnityEngine.UI.Button btnclick = transform.GetComponent<UnityEngine.UI.Button> ();
		btnclick.onClick.AddListener (ItemOnClick);
		scale = 0f;
	}

	void Update ()
	{
		if (checkEnable) 
		{
			if (countScale == 0)
				ZoomIn (1, 1.95f);
			else 
				if (countScale == 1)
					ZoomOut (2, 1.85f, gameObject);
				else 
					if (countScale == 2)
						ZoomIn (3, 1.95f);
					else
						checkEnable = false;
		}

		if (checkClicked)
			for (int i = 0; i < 2; i++)
				ZoomOut (3, 0f, otherAnswer [i]);
	}

	void ZoomIn (int valueCount, float valueScale)
	{
		if (scale <= valueScale)
		{
			scale += Time.deltaTime;
			transform.localScale = new Vector3 (scale, scale, 1f);
		}
		else
			countScale = valueCount;
	}

	void ZoomOut (int valueCount, float valueScale, GameObject obj)
	{
		if (scale >= valueScale) 
		{
			scale -= Time.deltaTime;
			obj.transform.localScale = new Vector3 (scale, scale, 1f);
		}
		else
			countScale = valueCount;
	}

	void OnEnable ()
	{
		// Change the sprite when the question is showed.
		imageAnswer.GetComponent<UnityEngine.UI.Image> ().sprite = listSprites [Lesson3Manager.currentQuestion];
		if (listAnswers [Lesson3Manager.currentQuestion] == 1)
			answer.GetComponent<UnityEngine.UI.Image> ().sprite = correct;
		checkEnable = true;
		checkClicked = false;
		countScale = 0;
	}

	void ItemOnClick()
	{
		answer.SetActive (true);
		checkClicked = true;
	}
}
