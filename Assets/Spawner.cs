using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
	Tile tile;
	List<Being> citizens;
	
	public void init(Tile t){
		tile=t;
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*removes corpse from the list of citizens
	 * called from the being when it determines itself is dead
	 * */
	public void removeCitizen(Being corpse){
		if(citizens.Contains(corpse)){
			citizens.Remove(corpse);
		}else{
			Debug.LogError("Tried to remove corpse from wrong village");
		}
	}
}
