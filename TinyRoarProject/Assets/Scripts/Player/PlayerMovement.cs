using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISpeedAdjustable, IStunnable
{
    private CharacterController characterController;
    public Transform cam;
    private PlayerInput input;

    [SerializeField] public float speed = 6.0f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private bool _isStunned = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if  (!_isStunned)
        {
            Vector3 direction = new Vector3(input.Horizontal, 0, input.Vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDir * speed * Time.deltaTime);
            }
        }
        else
        {
            //stunned
        }
    }

    public void TriggerManipulateSpeed(float amount, float duration)
    {
        StartCoroutine(ManipulateSpeed(amount, duration));
    }

    public IEnumerator ManipulateSpeed(float amount, float duration)
    {
        speed += amount;
        yield return new WaitForSeconds(duration);
        speed -= amount;
    }

    public void TriggerStun(float duration)
    {
        StopCoroutine("Stun");
        StartCoroutine(Stun(duration));
    }

    public IEnumerator Stun(float duration)
    {
        _isStunned = true;
        yield return new WaitForSeconds(duration);
        _isStunned = false;
    }
}
