using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3Manager : MonoBehaviour {

	public static int currentQuestion;

	[SerializeField]
	private GameObject A, B, C, info, title, cript;

	/// <summary>
	/// The Button for next, previous and refresh button.
	/// It will close the answer, the info and the title of the question.
	/// </summary>
	public void QuestionAction (int valueQuestion)
	{
		Debug.Log (transform.name);
		A.SetActive (false);
		B.SetActive (false);
		C.SetActive (false);
		info.SetActive (false);
		title.SetActive (false);
		currentQuestion += valueQuestion;
	}

	/// <summary>
	/// Load the scene on the button previous lesson, next lesson, main menu.
	/// </summary>
	/// <param name="valueLesson">Value lesson.</param>
	public void LessonAction (string valueLesson)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Lesson"+valueLesson);
	}

	/// <summary>
	/// Button Information to show the script on the quiestion .
	/// </summary>
	public void InfoButton ()
	{
		cript.SetActive (true);
	}

	/// <summary>
	/// Closes the cripts on the scene.
	/// </summary>
	public void CloseButton ()
	{
		cript.SetActive (false);
	}
}
