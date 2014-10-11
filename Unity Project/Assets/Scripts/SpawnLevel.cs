using UnityEngine;
using System.Collections;

public class SpawnLevel : MonoBehaviour {

	[SerializeField] GameObject hexagon;
	[SerializeField] float tileWidth = 1;
	[SerializeField] float tileHeight = 1;
	//Num of Tiles accross and down
	[SerializeField] int tilesAcross;
	[SerializeField] int tilesDown;

	void Start(){
		GameManager.gm.SetLevelSize(tilesAcross, tilesDown);

		for(int i = 0; i < tilesDown; i++){
			for(int j = 0; j < tilesAcross; j++){
				float indent = 0;
				if(i % 2 != 0)
					indent = tileWidth / 2 + 0.23f;
				GameObject go = Instantiate(hexagon, new Vector3(transform.position.x + (j + indent) * tileWidth, transform.position.y + i * -tileHeight, 0f), Quaternion.identity) as GameObject;
				go.transform.parent = transform;
			}
		}
	}

}
