using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectTest : MonoBehaviour {

	public GameObject test;

	void CorrectDoneTest(){
		test.SetActive (false);
		gameObject.GetComponent<Animator> ().enabled = false;
	}
}
