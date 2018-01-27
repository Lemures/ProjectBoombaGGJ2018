using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _xInput;
	private Vector3 _zInput;
	private Rigidbody _rigidBody;
	private float _launchForce;

	public float MovementSpeed;
	public float MaxSpeed;

	protected void Awake() 
	{
		_rigidBody = GetComponent<Rigidbody> ();
	}

	protected void Start () 
	{
		
	}
	
	protected void Update () 
	{
		_xInput.x = Input.GetAxisRaw ("Horizontal") * MovementSpeed;
		_zInput.z = Input.GetAxisRaw ("Vertical") * MovementSpeed;

		if(Input.GetButtonDown("Jump")){
			Debug.Log("JUMP");
		}


		// lookat normalized direction of input
		Vector3 input = new Vector3(_xInput.x, 0, _zInput.z);

		if(!input.Equals(Vector3.zero))
			transform.LookAt(transform.position + input.normalized, Vector3.up);
	}

	protected void FixedUpdate() 
	{
		// Left and down are negative velocities, so absolute value
		if(Mathf.Abs(_rigidBody.velocity.x) < MaxSpeed)
			_rigidBody.AddForce(_xInput, ForceMode.Acceleration);

		if(Mathf.Abs(_rigidBody.velocity.z) < MaxSpeed)
			_rigidBody.AddForce(_zInput, ForceMode.Acceleration);

	}
}
