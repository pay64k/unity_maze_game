using UnityEngine;
using System.Collections;

public class show_popup : MonoBehaviour {
	public GameObject popup;
	public ball_info ball;
	// Use this for initialization
	void Start () {
		popup.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(){
		popup.SetActive (true);
		StartCoroutine(WinActivity());
	}

	IEnumerator WinActivity() {
		yield return new WaitForSeconds(3);
		popup.SetActive (false);
		ball.transform.position = ball.getStartZonePosition();
		ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
}
