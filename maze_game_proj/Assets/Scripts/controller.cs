using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	public bool KeyboardEnabled;
	public float rotateSpeedKeyboard = 1f;
	public float rotateSpeedMouse = 1f;
	public float fastRotateSpeed = 30f;
	public float MinimumX = -15F;
	public float MaximumX = 15F;
	public GameObject ControllText;


	private Quaternion targetRot;

	void Start () {
		ControllText.SetActive (false);
	}

	void Update () {

		if (KeyboardEnabled) {
			RotateWithKeyboard ();
		} else {
			RotateWithMouse ();
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			ToggleControlls ();
		}
	}

	void RotateWithMouse(){
		
		float xRot = Input.GetAxis ("Mouse X") * rotateSpeedMouse;
		float zRot = Input.GetAxis ("Mouse Y") * rotateSpeedMouse;
		Rotate (xRot, zRot);

	}

	void RotateWithKeyboard(){
		
		if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
		{
			Rotate(-rotateSpeedKeyboard,0);
		}

		if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			Rotate(rotateSpeedKeyboard,0);
		}

		if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
		{
			Rotate(0,-rotateSpeedKeyboard);
		}

		if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
		{
			Rotate(0,rotateSpeedKeyboard);
		}
	}

	void Rotate(float xRot, float zRot){
		
		targetRot = transform.rotation * Quaternion.Euler (xRot, 0f, zRot);

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (targetRot.x);
		angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);
		targetRot.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

		float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan (targetRot.z);
		angleZ = Mathf.Clamp (angleZ, MinimumX, MaximumX);
		targetRot.z = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleZ);

		targetRot.y = 0f;

		transform.rotation = targetRot;
	}

	void ToggleControlls(){
		ControllText.SetActive (true);
		if (KeyboardEnabled) {
			KeyboardEnabled = false;
			ControllText.GetComponent<TextMesh> ().text = "Mouse Controled";
		} else {
			KeyboardEnabled = true;
			ControllText.GetComponent<TextMesh> ().text = "Keyboard Controled";
		}
		StartCoroutine(ToggleActivity());
	}

	IEnumerator ToggleActivity() {
		yield return new WaitForSeconds(1f);
		ControllText.SetActive (false);
	}
}

