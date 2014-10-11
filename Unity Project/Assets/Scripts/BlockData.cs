using UnityEngine;
using System.Collections;

public class BlockData : MonoBehaviour {

	public int id, xTile, yTile;

	void OnMouseDown(){
		GameManager.gm.SetSelected(xTile, yTile);
	}

	void Update(){
		//The swiping gensutre
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			Vector2 touchPos = Input.GetTouch(0).deltaPosition;
			if(touchPos.x > 1){
				GameManager.gm.SetSelected(xTile, yTile);
				GameManager.gm.SetSelected(xTile + 1, yTile);
			}
		}
	}
}
