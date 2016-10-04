using UnityEngine;
using System.Collections;

public class ball_info : MonoBehaviour {

	public Vector3 startingZonePosition;
	public GameObject startingZone;
	// Use this for initialization
	void Start () {
		startingZonePosition = startingZone.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 getStartZonePosition(){
		return startingZone.transform.position;
	}
}
