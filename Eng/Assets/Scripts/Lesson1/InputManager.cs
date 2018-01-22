using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedObject;
	private Tile draggedObjectTile;
    private Vector2 touchOffset;
	public Tile[] tiles;
	int countTileTrue;

	[SerializeField]
	GameObject Congratulation;
	float timeShowWin;

	void Start(){
		countTileTrue = 0;
		if (Congratulation != null)
			Congratulation.SetActive (false);
	}

    void Update() {
		if (HasInput)
		{
			//Debug.Log ("dsada");
			DragOrPickUp();
		}
		else
		{
			if (draggingItem)
				DropItem();
		}

		//Debug.Log ("countTileTrue: " + countTileTrue + " tiles.Length: " + tiles.Length);
		if (countTileTrue == tiles.Length) {
			if (timeShowWin < 1f)
				timeShowWin += Time.deltaTime;
			else
				Congratulation.SetActive (true);
		}
    }
    Vector2 CurrentTouchPosition
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;
        if (draggingItem)
        {
			if (draggedObjectTile != null)
				if (draggedObjectTile.isPosTrue == false) 
					draggedObject.transform.position = inputPosition + touchOffset;
        }
        else
        {
            var layerMask = 1 << 0;
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f, layerMask);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null && hit.transform.tag == "Tile")
                {
                    draggingItem = true;
                    draggedObject = hit.transform.gameObject;
					if (draggedObject.GetComponent<Tile> () != null) {
						draggedObjectTile = draggedObject.GetComponent<Tile> ();
						if (draggedObjectTile.isPosTrue == false) {
							touchOffset = (Vector2)hit.transform.position - inputPosition;
							draggedObjectTile.PickUp ();
						}
					}
                }
            }
        }
    }
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }



    void DropItem()
    {
		countTileTrue = 0;
        draggingItem = false;
        draggedObject.transform.localScale = new Vector3(1, 1, 1);
		if(draggedObjectTile != null)
			draggedObjectTile.Drop();
		for (int i = 0; i < tiles.Length; i++)
			if (tiles [i].isPosTrue)
				countTileTrue++;
    }
}
