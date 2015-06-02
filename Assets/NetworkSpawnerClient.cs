using UnityEngine;
using System.Collections;
using uLink;

public class NetworkSpawnerClient : uLink.MonoBehaviour {

	void OnGUI () {
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width - 100,50,80,20), "Spawn")) {
			uLink.NetworkView.Get(this).RPC("ServerSpawn", uLink.RPCMode.Server, uLink.Network.player.id.ToString());
		}

	}
}
