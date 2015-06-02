using UnityEngine;
using System.Collections;
using uLink;

public class ServerAction : uLink.MonoBehaviour {

	public GameObject Spawner;
	public GameObject SpawnerServer;

	public Hashtable PlayerTable = new Hashtable();
	public Hashtable IdToPlayerTable = new Hashtable();
	
	void uLink_OnServerInitialized()
	{

	}
	
	void uLink_OnPlayerDisconnected(uLink.NetworkPlayer player)
	{
		string name = IdToPlayerTable[player.id.ToString()] as string;
		PlayerTable.Remove (name);
		IdToPlayerTable.Remove (player.id);
		Debug.Log("Disconnected player: "+player.id+ " "+name);
	}
	

	void uLink_OnPlayerConnected(uLink.NetworkPlayer player)
	{

		string playername = player.loginData.Read<string> ();
		PlayerTable.Add (playername, player);
		IdToPlayerTable.Add (player.id.ToString(), playername);
		uLink.Network.Instantiate(player, Spawner, Spawner, SpawnerServer, Vector3.zero, Quaternion.identity,0);
		Debug.Log("Network aware game object is now created on server for player: "+ player.id+" "+playername);
	}




}
