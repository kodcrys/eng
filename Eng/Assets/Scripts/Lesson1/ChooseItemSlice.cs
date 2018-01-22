using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItemSlice : MonoBehaviour {
	[SerializeField]
	GameObject des;

	[SerializeField]
	GameObject nameItemSlice;

	public bool isSnapPos;

	void OnEnable() {
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	public void ChooseFood(GameObject item){
		item.transform.position = des.transform.position;
		gameObject.SetActive (false);
		nameItemSlice.SetActive (false);
		item.SetActive (true);
	}

	public void UnChooseFood(GameObject item){
		if (isSnapPos == false)
			item.SetActive (false);
		else
			item.SetActive (true);
	}
}
