using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public bool allowMovement = false;

	public GameObject[,] list;
	private int selectedX = -1;
	private int selectedY = -1;

	private int levelWidth;
	private int levelHeight;

	//Colours
	[SerializeField] private Color green = new Color(0f, 1f, 0f, 0.5f);
	[SerializeField] private Color white = new Color(1f, 1f, 1f, 1f);

	void Start () {
		gm = this;
	}

	public void AddTile(GameObject go, int x, int y){
		list[x, y] = go;
	}

	public void SetSelected(int x, int y){
		if(allowMovement){
			if(selectedX != -1 && selectedY != -1){

				//Check Left, Right, Up, Down
				if(CheckSwap(x, y)){
					//Swap the two around
					SwapInList(x, y);
					list[x, y].GetComponent<SpriteRenderer>().color = white;
				}

				list[selectedX, selectedY].GetComponent<SpriteRenderer>().color = white;
				selectedX = -1;
				selectedY = -1;
			}else{
				selectedX = x;
				selectedY = y;
				list[selectedX, selectedY].GetComponent<SpriteRenderer>().color = green;
			}
		}
	}

	// Checks if the two tiles are able to be swapped, and if so,
	// returns true
	private bool CheckSwap(int x, int y){
		int tempX = selectedX;
		int tempY = selectedY;
		int thisID = list[selectedX, selectedY].GetComponent<BlockData>().id;

		// Swapping Left
		if((selectedX - 1) == x && selectedY == y)
		{
			tempX --;
		}
		// Swapping Right
		if((selectedX + 1) == x && selectedY == y)
		{
			tempX ++;
		}
		// Swapping Up
		if(selectedX == x && (selectedY + 1) == y)
		{
			tempY ++;
		}
		// Swapping Down
		if(selectedX == x && (selectedY - 1) == y)
		{
			tempY --;
		}

		// Checks if swapping would make a match
		if(tempX != selectedX || tempY != selectedY)
		{
			// Check Bounds
			if(tempX > 1){
				if(list[tempX - 1, tempY].GetComponent<BlockData>().id == thisID
				   && list[tempX - 2, tempY].GetComponent<BlockData>().id == thisID)
				{
					return true;
				}
			}

			if(tempX < levelWidth - 2){
				if(list[tempX + 1, tempY].GetComponent<BlockData>().id == thisID
				   && list[tempX + 2, tempY].GetComponent<BlockData>().id == thisID)
				{
					return true;
				}
			}
		}

		return false;
	}

	// Swaps two items around in the list
	// Swaps with current selected 
	// Parameters: Give it second object to swap with currently selected
	private void SwapInList(int x, int y){
		//Move the two objects
		GameObject g = list[selectedX, selectedY];
		Vector3 currentPos = g.transform.position;
//		g.AddComponent<Block>().finalPosition = list[x, y].transform.position;
//		list[x, y].AddComponent<Block>().finalPosition = currentPos;
		g.transform.position = list[x, y].transform.position;
		list[x, y].transform.position = currentPos;

		//Update blockData xTile, yTile
		g.GetComponent<BlockData>().xTile = x;
		g.GetComponent<BlockData>().yTile = y;
		list[x, y].GetComponent<BlockData>().xTile = selectedX;
		list[x, y].GetComponent<BlockData>().yTile = selectedY;

		//Update the array
		list[selectedX, selectedY] = list[x, y];
		list[x, y] = g;
	}

	public void SetLevelSize(int width, int height){
		levelWidth = width;
		levelHeight = height;
	}

}
