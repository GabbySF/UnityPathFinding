using UnityEngine;
using System.Collections;
using uLink;

public class ClientAction : uLink.MonoBehaviour {

	void uLink_OnConnectedToServer()
	{
		Debug.Log("Network aware game object is now created on client");
	}


	public void uLink_OnPlayerDisconnected(uLink.NetworkPlayer player)
	{
		// Removing player from network and scene
		uLink.Network.RemoveRPCs(player, 0);
		uLink.Network.DestroyPlayerObjects(player);
	}

}
