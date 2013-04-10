using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {
	public Terrain terrain;

	// public so we can see them in the Inspector and double-check:
	public Vector3 TS; // terrain grid-space size
	public Vector2 AS; // control texture size
	// Use this for initialization
	void Start () {
	TS = Terrain.activeTerrain.terrainData.size;
	AS.x = Terrain.activeTerrain.terrainData.alphamapWidth;
	AS.y = Terrain.activeTerrain.terrainData.alphamapHeight;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
		//	increaseTerrainUpdate();
		}
	
	}
	
	
	/*void increaseTerrainUpdate(){
		float[, ,] alphas = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
		int AX = (int)((worldPos.x/TS.x)*AS.x+0.5f);
		int AY = (int)((worldPos.z/TS.z)*AS.y+0.5f);

		
	
	}*/
}
