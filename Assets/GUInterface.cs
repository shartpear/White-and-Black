	using UnityEngine;
	using System.Collections;
	
	public class GUInterface : MonoBehaviour {
		public World world;
		public Object selected;//the currently selected game object
		public GUI gui;
		public Camera myCamera;
	public readonly int numberOfButtons=5;
		
		
	void OnGUI () {
		// Make a background box
	 	string displayed = "White and Black \n";
			if(selected){
			displayed=displayed+selected.ToString();}
		GUI.Box(new Rect(4*Screen.width/5,0,Screen.width/5,Screen.height), displayed);
		
		GUI.Button(new Rect(5,6*Screen.height/7,(((4*Screen.width/5)-5)/numberOfButtons)-5,Screen.height/7),"Raise the Ground");
		GUI.Button(new Rect(10+(Screen.width/5),6*Screen.height/7,(((4*Screen.width/5)-5)/numberOfButtons)-5,Screen.height/7),"Lower The Ground");
		
		
	
		
	}

		
		public int cameraMoveSpeed = 1;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			handleInput();
			//update selected
			
		}
				
		void handleInput(){
			if(Input.anyKeyDown){
			myCamera.GetComponent<CameraController>().disengage();	
			}
			
				Vector3 camPos=myCamera.transform.position;
			if (Input.GetAxis("Vertical")==-1){
				myCamera.transform.position=new Vector3(camPos.x,camPos.y,camPos.z-cameraMoveSpeed);
			}else if(Input.GetAxis("Vertical")==1){
				myCamera.transform.position=new Vector3(camPos.x,camPos.y,camPos.z+cameraMoveSpeed);
				}
		
			if(Input.GetAxis("Horizontal")==-1){
				myCamera.transform.position=new Vector3(camPos.x-cameraMoveSpeed,camPos.y,camPos.z);
			}else if(Input.GetAxis("Horizontal")==1){
				myCamera.transform.position=new Vector3(camPos.x+cameraMoveSpeed,camPos.y,camPos.z);
			}
			
			if(Input.GetKey(KeyCode.KeypadPlus)||Input.GetAxis("Mouse ScrollWheel")>0){
				myCamera.transform.position=new Vector3(camPos.x,camPos.y-cameraMoveSpeed,camPos.z);
			}else if(Input.GetKey(KeyCode.KeypadMinus)||Input.GetAxis("Mouse ScrollWheel")<0){
				myCamera.transform.position=new Vector3(camPos.x,camPos.y+cameraMoveSpeed,camPos.z);
			}
		
			if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray vRay = myCamera.ScreenPointToRay(Input.mousePosition);
			  if (Physics.Raycast (vRay,out hit)) {
                
               GameObject hitObject = hit.collider.gameObject;
				if(hitObject!=null){
				if(hitObject.GetComponent<Being>()!=null){
					selected=hitObject.GetComponent<Being>();
				}else if(hitObject.GetComponent<Spawner>()!=null){
					selected=hitObject.GetComponent<Spawner>();
				}else if(hitObject.GetComponent<Tile>()!=null){
					selected=hitObject.GetComponent<Tile>();
				}}
				
            }
			
			}		
		
			}//end of handle Input
	}
