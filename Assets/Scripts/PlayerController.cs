using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 _xInput;
    private Vector3 _zInput;
    private Rigidbody _rigidBody;
    private float _launchForce = 10.0f;
    private float _maxLaunchForce = 25.0f;
    private float _launchCooldown = 2.0f;
    private float _launchCooldownTimer = 0.0f;
    private bool _isLaunchOnCooldown;
    private bool _isLaunching;
    private bool _isChargingLaunch;
    private PlayerHealth _healthScript;

    public float MovementSpeed;
    public float MaxSpeed;
    public float WeaponRange = 50f;
    public GameObject catAnimator;

    public GameObject succ;
    public GameObject succThree;
    private ParticleSystem _vacuumParticle;

    public int PlayerId;
    private string _horizontalInputName;
    private string _verticalInputName;
    private string _dashInputName;

    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _healthScript = GetComponent<PlayerHealth>();
        _horizontalInputName = "HorizontalJ" + PlayerId.ToString();
        _verticalInputName = "VerticalJ" + PlayerId.ToString();
        _dashInputName = "Dash" + PlayerId.ToString();
        _vacuumParticle = succ.GetComponent<ParticleSystem>();
    }

    protected void Update()
    {
        _xInput.x = Input.GetAxis(_horizontalInputName);
        _zInput.z = Input.GetAxis(_verticalInputName);

        // lookat normalized direction of input
        Vector3 input = new Vector3(_xInput.x, 0, _zInput.z);

        if (!input.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(input), Time.deltaTime * 2.0f);
        }

        if (_isLaunchOnCooldown)
        {
            if (_launchCooldownTimer < _launchCooldown)
                _launchCooldownTimer += Time.deltaTime;
            else
                _isLaunchOnCooldown = false;
        }
        else
        {
            if (Input.GetButtonDown(_dashInputName))
            {
                succ.SetActive(true);
                if (_healthScript.catPowerEnabled)
                {
                    var cat = catAnimator.GetComponent<CatAnimator>();
                    cat.CatAttack();
                }
            }

            if (Input.GetButton(_dashInputName))
            {
                if (!_isChargingLaunch)
                {
                    succ.SetActive(true);
                    _isChargingLaunch = true;
                }

                if (_launchForce < _maxLaunchForce)
                    _launchForce += 6.0f * Time.deltaTime;
            }

            if (Input.GetButtonUp(_dashInputName))
            {
                _isLaunching = true;

                if (_healthScript.catPowerEnabled)
                    succThree.SetActive(true);

                succ.SetActive(false);
            }
        }
    }

    protected void FixedUpdate()
    {

        // Left and down are negative velocities, so absolute value
        if (Mathf.Abs(_rigidBody.velocity.x) < MaxSpeed)
            _rigidBody.AddForce(_xInput * MovementSpeed);

        if (Mathf.Abs(_rigidBody.velocity.z) < MaxSpeed)
            _rigidBody.AddForce(_zInput * MovementSpeed);


        if (_isLaunching)
        {
            _isChargingLaunch = false;

            if (_healthScript.catPowerEnabled)
                CatAttack();
            else
                DashAttack();

            _launchForce = 10.0f;
            _isLaunching = false;
            _isLaunchOnCooldown = true;
            _launchCooldownTimer = 0.0f;
        }
    }

    private void CatAttack()
    {
        RaycastHit[] hits;
        LayerMask noBumpers = new LayerMask();
        noBumpers = Physics.AllLayers ^ (1 << 9);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, transform.forward * WeaponRange, Color.green, 10.0f);
        hits = Physics.SphereCastAll(transform.position, 1, transform.forward, WeaponRange, noBumpers);
        for(int i = 0; i < hits.Length; i++) {
            var hit = hits[i];
            if (hit.rigidbody != null && 
                hit.transform.gameObject.tag == "CatPushable" &&
                hit.transform.name != transform.name)
            {
                if (hit.transform.name.Contains("Box"))
                    hit.rigidbody.AddForce(-hit.normal * _launchForce * 100);
                else 
                    hit.rigidbody.AddForce(-hit.normal * _launchForce * 4000);
            }
        }
    }

    private void DashAttack()
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(transform.forward * _launchForce * 100, ForceMode.Impulse);
    }
}
