	using UnityEngine;
	using System.Collections;
	
	public class GUI : MonoBehaviour {
		GameObject selected;//the currently selected game object
		public Camera camera;
		
		
		
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
