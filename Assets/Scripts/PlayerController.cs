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
//		Vector3 inputMovement = new Vector3 ();
		_xInput.x = Input.GetAxisRaw ("Horizontal") * MovementSpeed;
		_zInput.z = Input.GetAxisRaw ("Vertical") * MovementSpeed;
		// _input.y, = 0.0f;
	}

	protected void FixedUpdate() 
	{

		if(_rigidBody.velocity.x < MaxSpeed)
			_rigidBody.AddForce(_xInput, ForceMode.Acceleration);

		if(_rigidBody.velocity.z < MaxSpeed)
			_rigidBody.AddForce(_zInput, ForceMode.Acceleration);

		Debug.Log("velocity: " + _rigidBody.velocity);
	}
}
