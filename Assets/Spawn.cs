using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public Transform _spawnpoint;
	public Transform _target;
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Spawn")) {
			GameObject seeker = Instantiate(Resources.Load("Prefab/Unit"),_spawnpoint.position,Quaternion.identity) as GameObject;
			UnitBehavior seekerBehavior = seeker.GetComponent<UnitBehavior>();
			seekerBehavior.SetTarget(_target);
		}
		
	}
}
