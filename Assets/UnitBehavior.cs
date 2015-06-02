using UnityEngine;
using System.Collections;
using Pathfinding;

public class UnitBehavior : MonoBehaviour {

	private Seeker _seeker;
	private Path _path;
	private int _currentWayPoint = 0;
	private CharacterController _controller;
	private float _speed = 5f;

	void Awake(){
		_controller = GetComponent<CharacterController> ();
	}

	public void SetTarget(Transform _target){
		_seeker = GetComponent<Seeker> ();
		_seeker.StartPath (transform.position, _target.position, onPathComplete);
	}

	public void onPathComplete(Path p){
		if (!p.error) {
			_path = p;
			_currentWayPoint = 0;
		}
	}


	void FixedUpdate(){
		if (_path == null) {
			return;
		}
		if (_currentWayPoint >= _path.vectorPath.Count) {
			_path = null;
			uLink.Network.Destroy(gameObject);
			return;
		}
		Vector3 dir = (_path.vectorPath [_currentWayPoint] - transform.position).normalized * _speed;

		_controller.SimpleMove (dir);

		if (Vector3.Distance (this.transform.position, _path.vectorPath [_currentWayPoint]) < 2f) {
			_currentWayPoint++;
		}

	}
}
