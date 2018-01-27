using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _xInput;
	private Vector3 _zInput;
	private Rigidbody _rigidBody;

	public float MovementSpeed;
	public float MaxSpeed;

    public int PlayerId = 1;
    private string _horizontalInputName;
    private string _verticalInputName;

    protected void Awake() 
	{
		_rigidBody = GetComponent<Rigidbody> ();

        _horizontalInputName = "HorizontalJ" + PlayerId.ToString();
        _verticalInputName = "VerticalJ" + PlayerId.ToString();
        //_horizontalInputName = "Horizontal";
        //_verticalInputName = "Vertical";
    }

    protected void Start () 
	{
		
	}
	
	protected void Update () 
	{
        _xInput.x = Input.GetAxisRaw(_horizontalInputName) * MovementSpeed;
        _zInput.z = Input.GetAxisRaw(_verticalInputName) * MovementSpeed;
        //_xInput.x = Input.GetAxis(_horizontalInputName) * MovementSpeed;
        //_zInput.z = Input.GetAxis(_verticalInputName) * MovementSpeed;

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
