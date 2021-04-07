using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    public float sprintModifier;
    //public float jumpForce;
    //public Transform groundDetector;
    //public LayerMask ground;
    public Camera normalCam;
    private float baseFOV;
    private float sprintFOVModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        //bool jump = Input.GetKeyDown(KeyCode.Space);

        //bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        //bool isJumping = jump && isGrounded;
        bool isSprinting = sprint && verticalMove > 0/* && !isJumping && isGrounded*/;

        //if (isJumping)
        //{
        //    rb.AddForce(Vector3.up * jumpForce);
        //}

        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);
        direction.Normalize();

        float adjustSpeed = moveSpeed;
        if (isSprinting)
        {
            adjustSpeed *= sprintModifier;
        }

        rb.velocity = transform.TransformDirection(direction) * adjustSpeed * Time.deltaTime;

        if (isSprinting)
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
        }
        else
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }

        //t_targetVelocity.y = rb.velocity.y;
        //rb.velocity = t_targetVelocity;
    }
}
