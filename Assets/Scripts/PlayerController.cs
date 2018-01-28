using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Vector3 _xInput;
	private Vector3 _zInput;
	private Rigidbody _rigidBody;
	private float _launchForce = 10.0f;
	private float _maxLaunchForce = 15.0f;
	private float _launchCooldown = 2.0f;
	private float _launchCooldownTimer = 0.0f;
	private bool _isLaunchOnCooldown;
	private bool _isLaunching;
	private bool _isChargingLaunch;


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
        _xInput.x = Input.GetAxis(_horizontalInputName);
        _zInput.z = Input.GetAxis(_verticalInputName);
        //_xInput.x = Input.GetAxis(_horizontalInputName) * MovementSpeed;
        //_zInput.z = Input.GetAxis(_verticalInputName) * MovementSpeed;

        // lookat normalized direction of input
        Vector3 input = new Vector3(_xInput.x, 0, _zInput.z);

		if(!input.Equals(Vector3.zero)){
			//transform.LookAt(transform.position + input.normalized, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(input), Time.deltaTime * 2.0f);
		}

		if(_isLaunchOnCooldown)
		{
			if(_launchCooldownTimer < _launchCooldown)
				_launchCooldownTimer += Time.deltaTime;
			else 
				_isLaunchOnCooldown = false;
		} 
		else 
		{
			if(Input.GetButton("Fire1"))
			{
				_isChargingLaunch = true;
				_rigidBody.drag = 0.5f;
				if(_launchForce < _maxLaunchForce)
					_launchForce += 3.0f * Time.deltaTime;
			}

			if(Input.GetButtonUp("Fire1"))
			{
				_isLaunching = true;
			}
		}

	}

	protected void FixedUpdate() 
	{

		if(!_isChargingLaunch)
		{
			// Left and down are negative velocities, so absolute value
			if(Mathf.Abs(_rigidBody.velocity.x) < MaxSpeed)
				_rigidBody.AddForce(_xInput * MovementSpeed);

			if(Mathf.Abs(_rigidBody.velocity.z) < MaxSpeed)
				_rigidBody.AddForce(_zInput * MovementSpeed);

			Debug.Log("Input: " + _rigidBody.velocity);
		}

		//Debug.Log("Vel: " + _rigidBody.velocity);

		if(_isLaunching) 
		{
			_isChargingLaunch = false;
			_rigidBody.drag = 1.0f;
			_rigidBody.velocity = Vector3.zero;
			_rigidBody.AddForce(transform.forward * _launchForce, ForceMode.Impulse);
			_launchForce = 10.0f;
			_isLaunching = false;
			_isLaunchOnCooldown = true;
			_launchCooldownTimer = 0.0f;
		}
	}
}
