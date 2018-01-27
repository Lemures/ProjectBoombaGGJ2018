using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _xInput;
	private Vector3 _zInput;
	private Rigidbody _rigidBody;
	private float _launchForce = 10.0f;
	private float _maxLaunchForce = 35.0f;
	private float _launchCooldown = 2.0f;
	private float _launchCooldownTimer = 0.0f;
	private bool _isLaunchOnCooldown;
	private bool _isLaunching;


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

		if(_isLaunchOnCooldown)
		{
			if(_launchCooldownTimer < _launchCooldown)
				_launchCooldownTimer += Time.deltaTime;
			else 
				_isLaunchOnCooldown = false;
		} 
		else 
		{
			if(Input.GetButton("Submit"))
			{
				if(_launchForce < _maxLaunchForce)
					_launchForce += 18.0f * Time.deltaTime;
			}

			if(Input.GetButtonUp("Submit"))
			{
				Debug.Log("LAUNCHEDING: " + _launchForce);
				_isLaunching = true;

			}
		}

	}

	protected void FixedUpdate() 
	{
		// Left and down are negative velocities, so absolute value
		if(Mathf.Abs(_rigidBody.velocity.x) < MaxSpeed)
			_rigidBody.AddForce(_xInput, ForceMode.Acceleration);

		if(Mathf.Abs(_rigidBody.velocity.z) < MaxSpeed)
			_rigidBody.AddForce(_zInput, ForceMode.Acceleration);

		if(_isLaunching) 
		{
			_rigidBody.AddForce(transform.forward * _launchForce, ForceMode.Impulse);
			_launchForce = 10.0f;
			_isLaunching = false;
			_isLaunchOnCooldown = true;
			_launchCooldownTimer = 0.0f;
		}
	}
}
