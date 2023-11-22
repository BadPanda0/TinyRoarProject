using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISpeedAdjustable, IStunnable
{
    private PlayerInput _input;
    private Rigidbody _rb;
    private Transform _cam;

    [Header("Movement")]
    [SerializeField] public float MaxSpeed;

    [Header("Rotation")]
    [SerializeField] private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    [Header("Animation")]
    [SerializeField] private PlayerAnimationController _animController;

    private bool _isStunned;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        _input = GetComponent<PlayerInput>();

        _cam = Camera.main.transform;
    }

    private void Update()
    {
        SpeedControl();
        SetAnimationSpeed();
    }

    private void FixedUpdate()
    {
        if  (!_isStunned)
        {
            Vector3 direction = new Vector3(_input.Horizontal, 0, _input.Vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
                _rb.AddForce(moveDir.normalized * MaxSpeed * 5, ForceMode.Force);
            }
        }
        else
        {
            //stunned
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        if(flatVelocity.magnitude > MaxSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * MaxSpeed;
            _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
        }
    }

    private void SetAnimationSpeed()
    {
        Vector3 flatVelocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        _animController.SetFloat(PlayerAnimationController.Parameter.SpeedF, Mathf.Clamp(flatVelocity.magnitude/5, 0, 1));
    }

    public void TriggerManipulateSpeed(float amount, float duration)
    {
        StartCoroutine(ManipulateSpeed(amount, duration));
    }

    public IEnumerator ManipulateSpeed(float amount, float duration)
    {
        MaxSpeed += amount;
        yield return new WaitForSeconds(duration);
        MaxSpeed -= amount;
    }

    public void TriggerStun(float duration)
    {
        StopCoroutine("Stun");
        StartCoroutine(Stun(duration));
    }

    public IEnumerator Stun(float duration)
    {
        _isStunned = true;
        _animController.SetBool(PlayerAnimationController.Parameter.StunnedT, true);
        yield return new WaitForSeconds(duration);
        _isStunned = false;
        _animController.SetBool(PlayerAnimationController.Parameter.StunnedT, false);
    }
}
