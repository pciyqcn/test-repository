using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float walkSpeed = 5.0f;
	public float nodAngleLimit = 60.0f;
	public float mouseSensitivity = 2.5f;

	float charNod = 0;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;	
	}
	
	// Update is called once per frame
	void Update () {

		/*control for aiming and moving*/

		//get input from mouse for horizontal aiming
		float charRotate = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, charRotate, 0);

		//get input from mouse for vertial rotation
		charNod -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		charNod = Mathf.Clamp (charNod, -nodAngleLimit, nodAngleLimit);
		Camera.main.transform.localRotation = Quaternion.Euler( charNod, 0, 0 );

		//get input from keyboard for movement
		float forwardSpeed = Input.GetAxis ("Vertical") * walkSpeed;
		float strafeSpeed = Input.GetAxis ("Horizontal") * walkSpeed;

		Vector3 movementSpeed = new Vector3 (strafeSpeed, 0, forwardSpeed );

		movementSpeed = transform.rotation * movementSpeed;

		CharacterController player = GetComponent <CharacterController>();

		player.SimpleMove( movementSpeed );
	}
}
