using System;
using UnityEngine;

[Serializable]
public class ObjectAniClass {

	[SerializeField]
	GameObject target;

	[SerializeField]
	float speedRun;

	/*
	 * Sprite chuyen frame ani
	 */
	[Header("Sprite to change frame animation")]
	[SerializeField]
	Sprite spriteChangeFrame1;
	[SerializeField]
	Sprite spriteChangeFrame2;

	/*
	 * Position gioi han khi di chuyen doi tuong
	 */
	[Header("Position max when object move")]
	[SerializeField]
	Transform startPos;
	[SerializeField]
	Transform endPos;
	bool changeStateMove = false;

	// Method thuc hien animation chuyen frame
	public void AniChangeFrameSprite1(SpriteRenderer sprTarget) {
		if (sprTarget != null)
			sprTarget.sprite = spriteChangeFrame1;
	}

	public void AniChangeFrameSprite2(SpriteRenderer sprTarget) {
		if (sprTarget != null)
			sprTarget.sprite = spriteChangeFrame2;
	}

	public void Move() {
		if (changeStateMove)
			target.transform.position = Vector3.MoveTowards (target.transform.position, startPos.position, speedRun * Time.deltaTime);
		else
			target.transform.position = Vector3.MoveTowards (target.transform.position, endPos.transform.position, speedRun * Time.deltaTime);

		if (target.transform.position == startPos.position)
			changeStateMove = false;
		if (target.transform.position == endPos.position)
			changeStateMove = true;
	}
}
