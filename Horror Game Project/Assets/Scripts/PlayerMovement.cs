using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    private Vector3 rotate;//Stores x + y vector to rotate by

/*
Player Fields 
*/
    [SerializeField]
    private float moveSpeed, rotationSpeed, groundDrag;//floats representing speed to move by

    [SerializeField]
    private InputAction forwardMovement, sideMovement;

    private Vector3 movementForce;//A force to move by


    [SerializeField]
    private Rigidbody rb;

//Enables Input Actions
     void OnEnable(){
        forwardMovement.Enable();
        sideMovement.Enable();
    }

//Disables Input Actions
     void OnDisable(){
        forwardMovement.Disable();
        sideMovement.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Gets value of key presses for side and forward movement
        float sideInput = sideMovement.ReadValue<float>();
        float forwardInput = forwardMovement.ReadValue<float>();

        animator.SetFloat("WalkValue", forwardInput);
        animator.SetFloat("TurnValue", sideInput);

//Allows the player to move forward and backward with W and S, regardless of rotation
        Vector3 moveDirection = transform.forward * forwardInput + transform.right * sideInput; 
        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        
//Rotates the player left and right
        if(sideInput != 0f)
             transform.Rotate(new Vector3(0, sideInput * 1, 0) * Time.fixedDeltaTime * rotationSpeed, Space.World);

        SpeedControl();
         rb.linearDamping = groundDrag; 
    }

    void Update(){
        
    }

//Helps reduce slippery movement
    private void SpeedControl(){
    Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

    if(flatVelocity.magnitude > moveSpeed){
        Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
        rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
    }
}
}
