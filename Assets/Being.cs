using UnityEngine;
using System.Collections;

public class Being : MonoBehaviour {
	
	public Tile[,] map;
	
	//resources it is worth if killed 
	public Resource food;
	public Resource water;
	
	//resources it has in its possession
	public Resource carriedFood;
	public Resource carriedWater;
	
	//spawner
	public Spawner spawner;
	
	//goal
	BeingAction goal; //current goal
	
	//genetic traits
	public int aggression; //determines threshold distance for attacking
	public int strength; //determines how much damage an attack does
	public int courage; 
	public int intelligence;//Intelligence and courage are two traits that affect goal choice
	//how these two traits affect it is to be decided.
	public int hardiness;//how much health they have
	public int longevity;//how long they live
	public int mobility;//how fast they move or how many resources they use to move
	public int reproductiveAppeal;//would affect the genetic algo somehow
	public int loyalty;//affects how much resource advantadge another village has to have to switch
	
	//attributes
	int age;//turns since created
	int currentHealth;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {//will need some way to access the tiles matrix, maybe pass in the world variable
	
		//check to see if dead, then call kill
		
		//goal assessment
		
		
		
		//action
			//attack
			//move resource
			//building?
		
		
		
	}
	
	//when the being dies, add the resources to the tile it died on
	void kill(){
		Vector3 pos = this.gameObject.transform.position;
		Tile location = map[(int)pos.x/Tile.tileWidth,(int)pos.z/Tile.tileHeight];
		
	}
	
	public void addResource(Resource r){
		if(r.name==carriedFood.name){
			carriedFood.addResource(r);
		}else{
			if(r.name==carriedWater.name){
				carriedWater.addResource(r);
			}
		}
	}
	
	
	
	
}
