using UnityEngine;
using System.Collections;

public class BlockLevel : MonoBehaviour {

	[SerializeField] GameObject[] cube;
	[SerializeField] float width;
	[SerializeField] float height;
	[SerializeField] int levelWidth;
	[SerializeField] int levelHeight;

	void Start () {
		GameManager.gm.list = new GameObject[levelWidth,levelHeight];
		GameManager.gm.SetLevelSize(levelWidth, levelHeight);

		for(int i = 0; i < levelWidth; i++){
			for(int j = 0; j < levelHeight; j++){
				int rand = Random.Range(0, cube.Length);
				GameObject go = Instantiate(cube[rand], new Vector3(transform.position.x + i * width, transform.position.y + j * height, 0f), Quaternion.identity) as GameObject;
				GameManager.gm.AddTile(go, i, j);
				BlockData bd = go.GetComponent<BlockData>();
				bd.id = rand;
				bd.xTile = i;
				bd.yTile = j;
				go.GetComponent<Block>().finalPosition = new Vector3(go.transform.position.x, go.transform.position.y - 5f, 0f);
				go.transform.parent = transform;
			}
		}

	}
}
