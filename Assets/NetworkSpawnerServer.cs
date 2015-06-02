using UnityEngine;
using System.Collections;
using uLink;

public class NetworkSpawnerServer : uLink.MonoBehaviour {
	public GameObject _playerPO;
	public GameObject _playerS;
	private Transform _spawnPoitnt;
	private Transform _target;
	private ServerAction _server;

	void Awake(){
		_server = GameObject.FindObjectOfType <ServerAction> ();
		_spawnPoitnt = GameObject.Find("SpawnPoint").transform;
		_target = GameObject.Find("Target").transform;
	}

	[RPC]
	void ServerSpawn(string client_id)
	{
		string name = _server.IdToPlayerTable[client_id] as string;
		GameObject go = uLink.Network.Instantiate(_playerPO,_playerS, _spawnPoitnt.position, Quaternion.identity,0) as GameObject;
		UnitBehavior ub = go.GetComponent<UnitBehavior> ();
		ub.SetTarget (_target);
		Debug.Log ("Player spawns " + name);
	}
}
