	using UnityEngine;
	using System.Collections;
	
	public class GUI : MonoBehaviour {
		GameObject selected;//the currently selected game object
		public Camera camera;
		
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}

		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel(2);
		}
	}

		
		public int cameraMoveSpeed = 1;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			handleInput();
		}
				
		void handleInput(){
			if(Input.anyKeyDown){
			camera.GetComponent<CameraController>().disengage();	
			}
			
				Vector3 camPos=camera.transform.position;
			if (Input.GetKey(KeyCode.DownArrow)){
				camera.transform.position=new Vector3(camPos.x,camPos.y,camPos.z-cameraMoveSpeed);
			}else if(Input.GetKey(KeyCode.UpArrow)){
				camera.transform.position=new Vector3(camPos.x,camPos.y,camPos.z+cameraMoveSpeed);
				}
		
			if(Input.GetKey(KeyCode.LeftArrow)){
				camera.transform.position=new Vector3(camPos.x-cameraMoveSpeed,camPos.y,camPos.z);
			}else if(Input.GetKey(KeyCode.RightArrow)){
				camera.transform.position=new Vector3(camPos.x+cameraMoveSpeed,camPos.y,camPos.z);
			}
			
			if(Input.GetKey(KeyCode.KeypadPlus)||Input.GetAxis("Mouse ScrollWheel")>0){
				camera.transform.position=new Vector3(camPos.x,camPos.y-cameraMoveSpeed,camPos.z);
			}else if(Input.GetKey(KeyCode.KeypadMinus)||Input.GetAxis("Mouse ScrollWheel")<0){
				camera.transform.position=new Vector3(camPos.x,camPos.y+cameraMoveSpeed,camPos.z);
			}
		
		
			}//end of handle Input
	}
