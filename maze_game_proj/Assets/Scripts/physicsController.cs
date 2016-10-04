using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class physicsController : MonoBehaviour {
	public Rigidbody rb;
	public float torque;
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		CharacterController controller = GetComponent<CharacterController>();
//		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
//		Vector3 forward = transform.TransformDirection(Vector3.left);
//		float curSpeed = speed * Input.GetAxis("Mouse Y");
//		controller.SimpleMove(forward * curSpeed);
		float turn = Input.GetAxis("Mouse X");
		rb.AddTorque (transform.right * torque * turn);

		float turn2 = Input.GetAxis ("Mouse Y");
		rb.AddTorque (transform.forward * torque * turn2);

		Quaternion targetRot = transform.rotation;
		targetRot.y = 0f;

	}
}
