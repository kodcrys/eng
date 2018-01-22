using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimations : MonoBehaviour {

	[SerializeField]
	enum UI { none, btnUIGeneral, introLesson, rightWrongSymbol, clampAni, scaleUIAni, rotateUIAni, starWinAni, scaleToMaxCanvasWin }

	[SerializeField]
	UI uiAnimations = UI.none;

	[SerializeField]
	UIAni uiAniClass;

	void Start(){
		uiAniClass.isRunFinish = false;
	}

	void Update(){
		switch (uiAnimations) {
			case UI.introLesson:
				uiAniClass.RunIntroLesson ();
				break;
			case UI.rightWrongSymbol:
				if (uiAniClass.isRunFinish == false)
					uiAniClass.RightWrongAni ();
				else {
					uiAniClass.ResetAniRightWrong ();
					gameObject.SetActive (false);
				}
				break;
			case UI.clampAni:
				uiAniClass.ChangeColor ();
				break;
			case UI.scaleUIAni:
				uiAniClass.ScaleImage ();
				break;
			case UI.rotateUIAni:
				uiAniClass.RotateAni ();
				break;
			case UI.starWinAni:
				uiAniClass.StarsAni ();
				break;
			case UI.scaleToMaxCanvasWin:
				uiAniClass.ScaleToMax ();
				break;
			
		}
	}

	// Max scale button
	public void MaxScale() {
		Button targetButton = transform.GetComponent<Button> ();
		if(targetButton != null && targetButton.interactable)
			uiAniClass.MaximizeObject ();
	}

	// Origin scale button
	public void OriginScale() {
		Button targetButton = transform.GetComponent<Button> ();
		if(targetButton != null && targetButton.interactable)
			uiAniClass.OriginObject ();
	}

	public void SoundOn() {
		transform.GetComponent<Button> ().interactable = false;
		uiAniClass.WhenSoundPlay ();
	}
		
	public void SoundOff() {
		transform.GetComponent<Button> ().interactable = true;
		uiAniClass.WhenSoundOff ();
	}
}


