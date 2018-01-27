using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _xInput;
	private Vector3 _zInput;
	private Rigidbody _rigidBody;

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
	}

	protected void FixedUpdate() 
	{
		// Left and down are negative velocities, so absolute value
		if(Mathf.Abs(_rigidBody.velocity.x) < MaxSpeed)
			_rigidBody.AddForce(_xInput, ForceMode.Acceleration);

		if(Mathf.Abs(_rigidBody.velocity.z) < MaxSpeed)
			_rigidBody.AddForce(_zInput, ForceMode.Acceleration);

		//Debug.Log("velocity: " + _rigidBody.velocity);
	}
}
