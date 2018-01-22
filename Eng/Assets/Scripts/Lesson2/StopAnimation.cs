using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour {


	public void StopAni(){
		gameObject.GetComponent<Animator> ().enabled = false;
	}
}
