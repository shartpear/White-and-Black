using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	public static readonly int tileWidth=10;//the width of a tile in unity units
	public static readonly int tileHeight=10;//the height "    "		"
	
	public readonly float heightMinDelta=0.25f;//minimum percent change in distance from maximum
	public readonly float tempMinDelta=0.25f;
	public readonly float humidMinDelta=0.25f;
	
	public readonly int heightMax=100;
	public readonly int tempMax=100;
	public readonly int humidMax=100;
	
	
	
	public int x; //its position on the grid of tiles
	public int y;
	public GameObject parent;
	//Tile Attributes
	//the first three are interrelated
	public int height; // the altitude of the tile from 0-100
	public int temperature;// the heat of the tile from 0-100
	public int humidity; //the humidity of the tile from 0-100
	
	public bool waterSource; // whether or not this tile has a water source
	public bool lavaSource;	//whether or not this tile has a lava source
	
	public int hallowedness;//how lucky the tile is
	public Spawner spawner;//if the tile has a spawner, this is it.
	
	//resources
	public Resource food; //amount of food on the tile currently
	public Resource water; //amount of drinking water on tile currently
	public int fGenRate;//amount of food tile generates a frame
	public int wGenRate;//amount of drinking water tile generates a frame
	
	
	//used to set position
	public void init(int xVal,int yVal){
		parent=this.gameObject;
		this.x=xVal;
		this.y=yVal;
		Color c = new Color(temperature/100f,humidity/100f,height/100f);
		renderer.material.color=c;
		//	Debug.Log("Color for"+x+", "+y+" is"+renderer.material.color.ToString());
		parent.transform.position=new Vector3(x*tileWidth,.2f,y*tileHeight);
	}
	// Use this for initialization
	void Start () {
		food=new Resource("food", 5);
		water=new Resource("water", 5);
	height=Random.Range(0,101);
		temperature=Random.Range(0,101);
		humidity=Random.Range(0,101);
		waterSource=false;
		lavaSource=false;
		
		fGenRate=1;
		wGenRate=1;
		
	}
	
	// Update is called once per frame
	void Update () {
	Color c = new Color(temperature/100f,humidity/100f,height/100f);
		renderer.material.color=c;
		food.addResource(new Resource("food",fGenRate));
		water.addResource(new Resource("water",wGenRate));
	}
	
	//changes an attribute by given amount
	void changeAttribute(string attributeName, bool positive){
		switch(attributeName){
		case "height":
				changeHeight(positive);
			break;
		case "temperature":
			changeTemperature(positive);
			break;
		case "humidity":
			changeHumidity(positive);
			break;
		case "waterSource":
			waterSource=positive;
			break;
		case "lavaSource":
			lavaSource=positive;
			break;
		case "hallowedness":
			changeHallowedness(positive);
			break;
		}	
}
	
	//changes the height a random percentage of the remaining distance in given given direction 
	//with the percentage between minDelta and 1-minDelta, or just equal to minDelta when minDelta >=.5
	void changeHeight(bool positive){
		if(positive){
		int diff=heightMax-height;
		height+= (int)Mathf.Round(Mathf.Max(Random.value-heightMinDelta, heightMinDelta)*diff);
		}else{
			
			height-= (int)Mathf.Round(Mathf.Max(Random.value-heightMinDelta, heightMinDelta)*height);
		}
	}
	
	//changes the temperature a random percentage of the remaining value
	void changeTemperature(bool positive){
		if(positive){
		int diff=tempMax-temperature;
			temperature+= (int)Mathf.Round(Mathf.Max(Random.value-tempMinDelta, tempMinDelta)*diff);
		}else{
			
			temperature-= (int)Mathf.Round(Mathf.Max(Random.value-tempMinDelta, tempMinDelta)*temperature);
		}
	}
	
	//changes the humidity a random percentage of the remaining value
	void changeHumidity(bool positive){
		if(positive){
		int diff=humidMax-humidity;
			humidity+= (int)Mathf.Round(Mathf.Max(Random.value-humidMinDelta, humidMinDelta)*diff);
		}else{
			
			humidity-= (int)Mathf.Round(Mathf.Max(Random.value-humidMinDelta, humidMinDelta)*humidity);
		}
	}
	
	//to be done
	void changeHallowedness(bool positive){
		
		
	}
	
	
	public Spawner getSpawner(){
		return spawner;
	}
	
	
	//tests to see if the vector parameter is contained within this tile
	public bool contains(Vector3 location){
		bool b = false;
		if(location.x>(this.x-1)*tileWidth&&location.x<(this.x)*tileWidth){
			if(location.z>(this.y-1)*tileHeight&&location.z<(this.y)*tileHeight){
				b=true;
			}
		}
	return b;		
	}
	
	public Resource collectResource(Resource r){
		if(r.name==food.name){
			return food.getResource(r.amount);
		}else{ 
			if(r.name==water.name){
			return water.getResource(r.amount);
			}else{
				return null;
			}
		}
	}
}