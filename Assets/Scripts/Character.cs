using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)] public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.81f;
    public Animator animator;
    public Weapon weapon;

    bool onGround = false;
    CharacterController characterController;
    Vector3 inputDirection = Vector3.zero;
    Vector3 velocity;
    Health health;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();
    }

    void Update()
    {

        onGround = characterController.isGrounded;
        if (onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion rotation = Quaternion.AngleAxis(cameraRotation.eulerAngles.y, Vector3.up);
        Vector3 direction = rotation * inputDirection;

        if(inputDirection.magnitude > 0.1f)
        {
            //transform.forward = inputDirection.normalized;
            Quaternion target = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, target, 5 * Time.deltaTime);

        }

        //animator
        animator.SetFloat("speed", inputDirection.magnitude);
        animator.SetBool("OnGround", onGround);
        animator.SetFloat("VelocityY", velocity.y);

        
        characterController.Move(direction * speed * Time.deltaTime);

        // gravity movement
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if(health.CurrentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    public void OnJump()
    {
        if (onGround)
        {
            velocity.y += jump;
        }
    }

    public void OnFire()
    {
        weapon.Fire(transform.forward);
    }

    public void OnPunch()
    {
        animator.SetTrigger("Punch");
    }

    public void OnThrow()
    {
        animator.SetTrigger("Throw");
    }

    public void OnMove(InputValue input)
    {
        Vector2 v2 = input.Get<Vector2>();
        inputDirection.x = v2.x;
        inputDirection.z = v2.y;
    }

    public void OnDoorOpen()
    {
        animator.SetTrigger("Open");
    }

    public void OnDoorClost()
    {
        animator.SetTrigger("Close");
    }

    public Health GetHealth()
    {
        return health;
    }
}
