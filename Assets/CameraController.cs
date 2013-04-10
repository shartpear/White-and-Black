using UnityEngine;
using System.Collections;

//for controlling the camera
//I tried to move all input handling to gui
public class CameraController : MonoBehaviour {
    bool centeredCamera;//whether or not the camera is following("Centered on") a agent or is being moved by arrows
	public GameObject target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (centeredCamera){
			this.transform.position=new Vector3(target.transform.position.x,this.transform.position.y,target.transform.position.z);
		}
	}
	
	//tells camera to center on game object every frame
	public void follow(GameObject t){
		if(t!=null){
		centeredCamera=true;
		target=t;
		}
	}
	
	public void disengage(){
		centeredCamera=false;
		target=null;
	}
	
}
