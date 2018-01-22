using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lession2Manager {
	
	public List<GameObject> lessions = new List<GameObject>();
	public List<GameObject> tests = new List<GameObject>();
	public List<bool> sawTest = new List<bool> ();

	public int currentLession;
	public int currentTest;
}
