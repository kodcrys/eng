using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIAni {

	[SerializeField]
	float speedRun;

	[Header("Target run ani")]
	public GameObject target;
	[SerializeField]
	SpriteRenderer sprOfTarget;

	[Header("Animation scale object")]
	[SerializeField]
	Vector3 originScale;
	[SerializeField]
	Vector3 maxScale;
	[SerializeField]
	Vector3 minScale;

	[Header("Change sprite button listen")]
	[SerializeField]
	Sprite soundPlay;
	[SerializeField]
	Sprite soundOff;

	[Header("Change color Ani")]
	[SerializeField]
	Color32 color1;
	[SerializeField]
	Color32 color2;
	float timeChangeColor;
	public bool isRunFinish;

	// Bien doi de chuyen mau
	float timeWaitChangeColor;
	[SerializeField]
	float timeMaxChangeColor;

	/*
	 * State ani intro lesson
	 */
	enum IntroLesson { none, moveDes1, moveDes2, moveDes3 }
	IntroLesson introLesson = IntroLesson.none;
	[Header("Destination of intro object when run animation")]
	[SerializeField]
	GameObject des0;
	[SerializeField]
	GameObject des1;
	[SerializeField]
	GameObject des2;
	[SerializeField]
	GameObject des3;
	[SerializeField]
	GameObject canvasOfIntro;
	float timeWaitIntro = 0;

	[Header("Change state ani")]
	[SerializeField]
	bool isChangeState;

	[Header("List object runAni star")]
	[SerializeField]
	GameObject[] lstStar;
	[SerializeField]
	float timeWaitChangeFrame;

	[Header("List button ui of canvasWin")]
	[SerializeField]
	GameObject[] lstButtonCanvasWin;
	/*
	 * thuc hien animation cho cac button nhu home, listen, replay,...
	 */
	public void MaximizeObject() {
		target.transform.localScale = maxScale;	
	}

	public void OriginObject() {
		target.transform.localScale = originScale;
	}

	public void MinimizeObject() {
		target.transform.localScale = minScale;
	}

	/*
	 * thay doi sprite cua button listen khi click vao nghe
	 * khi click vao play chuyen thanh off
	 * khi nghe xong het thi chuyen thanh on
	 */
	public void WhenSoundPlay() {
		target.GetComponent<Image> ().sprite = soundOff;
	}

	public void WhenSoundOff(){
		target.GetComponent<Image> ().sprite = soundPlay;
	}
		
	/*
	 * Di chuyen intro less theo 1 trinh tu tu des0 den des1, den des2 cuoi cung la des3
	 */
	public void RunIntroLesson(){
		switch (introLesson) {
			case IntroLesson.none:
				target.transform.position = des0.transform.position;
				introLesson = IntroLesson.moveDes1;
				break;
			case IntroLesson.moveDes1:
				target.transform.position = Vector3.MoveTowards (target.transform.position, des1.transform.position, speedRun * Time.deltaTime);
				if (target.transform.position == des1.transform.position)
					introLesson = IntroLesson.moveDes2;
				break;
			case IntroLesson.moveDes2:
				target.transform.position = Vector3.MoveTowards (target.transform.position, des2.transform.position, speedRun * Time.deltaTime);
				if (target.transform.position == des2.transform.position)
					timeWaitIntro += Time.deltaTime;
				if(timeWaitIntro > 1f)
					introLesson = IntroLesson.moveDes3;
				break;
			case IntroLesson.moveDes3:
				target.transform.position = Vector3.MoveTowards (target.transform.position, des3.transform.position, speedRun * Time.deltaTime);
				if (target.transform.position == des3.transform.position)
					canvasOfIntro.SetActive (false);
				break;
		}
	}

	/*
	 * Run ani symbol right wrong when drop object
	 */
	public void RightWrongAni() {
		target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, maxScale, speedRun * Time.deltaTime);
		Color32 color = Color32.Lerp (color1, color2, timeChangeColor);
		timeChangeColor += Time.deltaTime;
		sprOfTarget.color = color;
		if (target.transform.localScale == maxScale)
			isRunFinish = true;
	}

	public void ResetAniRightWrong(){
		isRunFinish = false;
		timeChangeColor = 0;
		target.transform.localScale = minScale;
	}

	public void ChangeColor() {
		timeWaitChangeColor += Time.deltaTime;
		if (timeWaitChangeColor < timeMaxChangeColor)
			sprOfTarget.color = color1;
		else
			sprOfTarget.color = color2;

		if (timeWaitChangeColor > 2 * timeMaxChangeColor)
			timeWaitChangeColor = 0;
	}

	public void ScaleImage() {
		if (isChangeState) {
			target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, maxScale, speedRun * Time.deltaTime);
			if (target.transform.localScale == maxScale)
				isChangeState = false;
		}
		else {
			target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, minScale, speedRun * Time.deltaTime);
			if (target.transform.localScale == minScale)
				isChangeState = true;
		}
	}

	public void ScaleToMax(){
		if(target.transform.localScale != maxScale)
			target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, maxScale, speedRun * Time.deltaTime);
	}

	float timeWait;
	public void RotateAni() {
		if (isChangeState) {
			timeWait += Time.deltaTime;
			target.transform.Rotate (Vector3.forward * Time.deltaTime * speedRun);
			//target.transform.eulerAngles = Vector3.MoveTowards (target.transform.eulerAngles, angle1, speedRun * Time.deltaTime);
			if (timeWait >= 0.3f) {
				isChangeState = false;
				timeWait = 0;
			}
		} else {
			timeWait += Time.deltaTime;
			target.transform.Rotate (-Vector3.forward * Time.deltaTime * speedRun);
			//target.transform.eulerAngles = Vector3.MoveTowards (target.transform.eulerAngles, angle2, speedRun * Time.deltaTime);
			if (timeWait >= 0.3f) {
				isChangeState = true;
				timeWait = 0;
			}
		}
	}

	int indexStar = 0;
	bool isPlayPre;
	public void StarsAni(){
		if (isPlayPre == false) {
			timeWait += Time.deltaTime;
			if (timeWait >= timeWaitChangeFrame && indexStar < lstStar.Length) {
				for (int i = 0; i < lstStar.Length; i++)
					if (i == indexStar)
						lstStar [i].SetActive (true);
					else
						lstStar [i].SetActive (false);
				indexStar++;
				timeWait = 0;
			}
			if (indexStar >= lstStar.Length) {
				indexStar = lstStar.Length - 1;
				isPlayPre = true;
				timeWait = 0;
			}
		}
		if (isPlayPre) {
			timeWait += Time.deltaTime;
			if (timeWait >= timeWaitChangeFrame && indexStar > 0) {
				for (int i = 0; i < lstStar.Length; i++)
					if (i == indexStar)
						lstStar [i].SetActive (true);
					else
						lstStar [i].SetActive (false);
				indexStar--;
				timeWait = 0;
			}
			if (indexStar <= 0) {
				indexStar = 0;
				isPlayPre = false;
				timeWait = 0;
			}
		}
	}

	bool isToMax, isToOrigin;
	public void RunAniBtnWinCanvas() {
		if (isToMax == false) {
			target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, maxScale, speedRun * Time.deltaTime);
			if (target.transform.localScale == maxScale)
				isToMax = true;
		} else if (isToMax) {
			if (isToOrigin == false) {
				target.transform.localScale = Vector3.MoveTowards (target.transform.localScale, originScale, speedRun * Time.deltaTime);
				if (target.transform.localScale == originScale)
					isToOrigin = true;
			}
		}
	}
}