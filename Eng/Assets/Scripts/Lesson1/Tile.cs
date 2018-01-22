using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{

    private Vector2 startingPosition;
    private List<Transform> touchingTiles;
    private Transform myParent;

	public string nameTile;
	public ChooseItemSlice itemSlice;
	public bool isPosTrue;

	public GameObject right, wrong;

	[SerializeField]
	private GameObject nameTileObject;

	[SerializeField]
	ManagerLesson1 managerLesson;

    private void Awake()
    {
		isPosTrue = false;
        startingPosition = transform.position;
        touchingTiles = new List<Transform>();
        myParent = transform.parent;
    }

    public void PickUp()
    {
        transform.localScale = new Vector3(1.4f,1.4f,1f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 20;
    }
    public void Drop()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1f);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        Vector2 newPosition;
		Vector3 rotate = Vector3.zero;
		Vector3 scale = Vector3.zero;
		if (isPosTrue == false) {
			if (touchingTiles.Count == 0) {
				//Debug.Log ("asdasd");
				Vector3 posWrong = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				posWrong.z = 0;
				wrong.transform.position = posWrong;

				transform.position = startingPosition;
				transform.parent = myParent;
				itemSlice.gameObject.SetActive (true);
				gameObject.SetActive (false);
				wrong.SetActive (true);
				nameTileObject.SetActive (true);
				return;
			}

			var currentCell = touchingTiles [0];
			var currentCellValue = currentCell.GetComponent<PosItemDrag> ();

			if (touchingTiles.Count == 1) {
				newPosition = currentCellValue.posNew;//currentCell.position;
				rotate = currentCellValue.rotateNew;
				scale = currentCellValue.scaleNew;
			} else {
				var distance = Vector2.Distance (transform.position, touchingTiles [0].position);
            
				foreach (Transform cell in touchingTiles) {
					if (Vector2.Distance (transform.position, cell.position) < distance) {
						currentCell = cell;
						distance = Vector2.Distance (transform.position, cell.position);
					}
				}
				newPosition = currentCell.position;
			}
			if (currentCell.childCount != 0) {
				transform.position = startingPosition;
				transform.parent = myParent;
				itemSlice.gameObject.SetActive (true);
				itemSlice.isSnapPos = false;

				Vector3 posWrong = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				posWrong.z = 0;
				wrong.transform.position = posWrong;
				wrong.SetActive (true);

				gameObject.SetActive (false);
				nameTileObject.SetActive (true);
				return;
			} else {
				if (currentCell.name == nameTile) {
					isPosTrue = true;
					transform.parent = currentCell;
					right.transform.position = newPosition;
					right.SetActive (true);
					StartCoroutine (SlotIntoPlace (transform.position, newPosition, rotate, scale));
					transform.GetComponent<PolygonCollider2D> ().enabled = false;
					managerLesson.isTrue = true;
				} else {
					transform.position = startingPosition;
					transform.parent = myParent;
					itemSlice.gameObject.SetActive (true);
					itemSlice.isSnapPos = false;

					Vector3 posWrong = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					posWrong.z = 0;
					wrong.transform.position = posWrong;
					wrong.SetActive (true);

					nameTileObject.SetActive (true);
					gameObject.SetActive (false);
				}
			}
		}
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Cell") return;
        if (!touchingTiles.Contains(other.transform))
        {
            touchingTiles.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Cell") return;
        if (touchingTiles.Contains(other.transform))
        {
            touchingTiles.Remove(other.transform);
        }
    }

	IEnumerator SlotIntoPlace(Vector2 startingPos, Vector2 endingPos, Vector3 rotate, Vector3 scale)
    {
        float duration = 0.1f;
        float elapsedTime = 0;

		itemSlice.isSnapPos = true;
        while (elapsedTime < duration)
        {
			transform.position = Vector2.Lerp(startingPos, endingPos, elapsedTime / duration);
			transform.eulerAngles = rotate;
			transform.localScale = scale;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = endingPos;
    }
}
