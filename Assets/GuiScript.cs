using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,25,80,20), "Server")) {
			this.BecomeServer();
		}

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,65,80,20), "Client")) {
			this.BecomeClient();	
		}
		
	}

	private void BecomeServer(){
		Instantiate (Resources.Load ("Prefab/Server"));
		Destroy (GetComponent<GuiScript> ());
	}

	private void BecomeClient(){
		Instantiate(Resources.Load ("Prefab/Client")) ;

		Destroy (GetComponent<GuiScript> ());
	}
}
