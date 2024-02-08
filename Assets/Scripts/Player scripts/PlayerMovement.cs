using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeed;
    
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public bool isSprinting;

    public Transform orientation;
    private StaminaController controller;


    float horiontalIn;
    float verticalIn;

    Vector3 moveDirection;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<StaminaController>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        horiontalIn = Input.GetAxisRaw("Horizontal");
        verticalIn = Input.GetAxisRaw("Vertical");
        SpeedControl();
        Sprint();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalIn + orientation.right * horiontalIn;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }
    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && CanSprint())
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;

            cameraForward.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = new Vector3(horiontalIn, 0, verticalIn).normalized;
            Vector3 sprintDirection = Camera.main.transform.TransformDirection(moveDirection);

            rb.velocity = new Vector3(sprintDirection.x * sprintSpeed,
                                      rb.velocity.y, sprintDirection.z * sprintSpeed);

            controller.currentStamina -= Time.deltaTime * 20;
            isSprinting = true;


        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = false;

            if (controller.currentStamina < controller.maxStamina)
                StartCoroutine(controller.StaminaRecharge());
            else
                StopAllCoroutines();

        }
        if (controller.currentStamina <= 0.2)
            isSprinting = false;

    }
    private bool CanSprint()
    {
        return controller.currentStamina > 0;
    }

}
