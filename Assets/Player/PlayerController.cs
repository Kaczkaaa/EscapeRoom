using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject CameraHolder;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 move, look;
    private float lookRotation;
    public bool grounded;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        Vector3 jumpForces = Vector3.zero;

        if (grounded)
        {
            jumpForces = Vector3.up * jumpForce;
            grounded = false;
        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }

    void Move()
    {
        //Find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        //Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);
        Vector3 velocityChange = (targetVelocity - currentVelocity);

        //Calculate forces
        Vector3.ClampMagnitude(velocityChange, maxForce);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z); //falling

        //Limit Force
        rb.AddForce(velocityChange * Time.fixedDeltaTime, ForceMode.VelocityChange);

    }

    void Look()
    {
        //Turn
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Look
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90); //so you can't look up past 90 and -90 degrees
        CameraHolder.transform.eulerAngles = new Vector3(lookRotation, CameraHolder.transform.eulerAngles.y, CameraHolder.transform.eulerAngles.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //hide and lock cursor to the center of the screen
    }

    // Update is called once per frame
    void Update() //late Update? bu�a!! doesn't work???._.
    {
       Look();
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }
    private void OnTriggerEnter(Collider other)
    {
        grounded = true;
    }
}
