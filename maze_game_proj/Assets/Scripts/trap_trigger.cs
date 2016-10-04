using UnityEngine;
using System.Collections;

public class trap_trigger : MonoBehaviour {
	public ball_info ball;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(){
		ball.transform.position = ball.getStartZonePosition();
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

}
