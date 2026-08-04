using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform model;

    public float walkspd = 3.25f;
    public float runspd = 9f;
    public float crouchspd = 2.5f;
    public float slidespd = 12f;
    public float maxSlidespd = 22.5f;
    public float minSlidespd = 5f;
    public float speed;
    private float currentSlidespd;

    public bool sprinting = false;
    public bool cansprint = true;
    public bool isMoving = false;

    public bool crouching = false;
    public bool sliding = false;

    public float maxStam = 300f;
    public float currentStam = 300f;
    public float stamDrainPersec = 15f;
    public float stamRegenPersec = 25f;
    public float stamRegendelay = 0.5f;
    private float timeSincelastSprint;

    public float gravity = -9.81f;
    private float verticalVelocity;

    void Start()
    {
        currentStam = maxStam;
        speed = walkspd;
    }

void Sprint()
{
    if (Input.GetKey(KeyCode.LeftShift) && currentStam > 0 && cansprint && isMoving && !crouching && !sliding)
    {
        sprinting = true;
        currentStam -= stamDrainPersec * Time.deltaTime;
        timeSincelastSprint = Time.time;
    }
    else
    {
        sprinting = false;
        if (Time.time - timeSincelastSprint >= stamRegendelay)
        {
            currentStam += stamRegenPersec * Time.deltaTime;
        }
    }

    currentStam = Mathf.Clamp(currentStam, 0f, maxStam);
}

void Slide()
{
    RaycastHit hit;

    if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
    {
        Vector3 groundNormal = hit.normal;
        Vector3 downhill = Vector3.ProjectOnPlane(Vector3.down, groundNormal).normalized;

        float slopeAmount = Vector3.Dot(downhill, transform.forward);
        if (slopeAmount > 0)
        {
            currentSlidespd += slopeAmount * 20f * Time.deltaTime;
        }
        else
        {
            currentSlidespd += slopeAmount * 10f * Time.deltaTime;
        }
        currentSlidespd = Mathf.Clamp(currentSlidespd, 0f, maxSlidespd);
        controller.Move(transform.forward * currentSlidespd * Time.deltaTime);
    }
}
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        isMoving = movement.magnitude > 0.1f;

        Sprint();

        if (sliding)
{
    Slide();
}
else
{
    currentSlidespd = slidespd;

    model.localRotation = Quaternion.Slerp(
        model.localRotation,
        Quaternion.identity,
        8f * Time.deltaTime
    );

    if (crouching)
    {
        speed = crouchspd;
    }
    else if (sprinting)
    {
        speed = runspd;
    }
    else
    {
        speed = walkspd;
    }

    stamDrainPersec = 15f;
}
        controller.Move(movement * speed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        verticalVelocity += gravity * Time.deltaTime;
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
}