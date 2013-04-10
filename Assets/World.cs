using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	
	public readonly int worldWidth = 25; //in tiles
	public readonly int worldHeight = 25;//in tiles
	public readonly int waterFlowRate =30; //number of frames it takes water to flow to a downhill terrain
	
	public Tile[,] tiles;// the tiles on the map
	public GameObject Tile;
	
	public Village playerVillage;//the village the player is trying to maximize;
	public Village enemyVillage;//the other village;
	
	public ArrayList caves;//the monster spawners
	
	// Use this for initialization
	void Start () {
		tiles = new Tile[worldWidth,worldHeight];
		for (int i=0; i<worldWidth;i++){
			for(int j=0; j<worldHeight;j++){
				GameObject tile = (GameObject)Instantiate(Tile);
				tiles[i,j]=(Tile)tile.GetComponent("Tile");
				tiles[i,j].init(i,j);
			}
		}//end of tile initialization
		
		playerVillage = new Village();
		playerVillage.init(tiles[Random.Range(0,worldWidth/2),Random.Range(0,worldHeight/2)]);
		enemyVillage = new Village();		
		enemyVillage.init(tiles[Random.Range(0,worldWidth/2),Random.Range(0,worldHeight/2)]);
		caves=new ArrayList();
	
	}
	
	// Update is called once per frame
	//update intertile behaviors, i.e. lava and water
	void Update () {
	
	}
}
