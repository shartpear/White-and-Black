using UnityEngine;
using System.Collections;

public class Resource:Object {
	public int amount;
	string name;
	
	public Resource(){
		amount = 0;
		name="";	
	}
	
	public Resource(string s){
		amount = 0;
		name=s;	
	}
	public Resource(string s, int a){
		amount = a;
		name=s;	
	}
	
	public Resource getResource(int request){
		int number;
		if(amount-request<0){
			number=amount-request;
			amount=0;
		}else{
			amount-=request;
			number=request;
		}
		
		return new Resource(this.name,number);
	}
	
	public int getResource(){
		return this.amount;
	}
	
	public void addResource(Resource resource){
		if(resource.name==this.name){
			this.amount+=resource.amount;
		}else{
		Debug.LogError("Cannot add "+resource.name+"to "+this.name);
			//throw new Exception("resourceNameMismatch");
		}
	}
	
}
