using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float walkSpd = 3.5f;
    public float runSpd = 9f;
    public float crouchSpd = 2.5f;
    public float slideSpd = 12f;
    public float speed;

    public float maxStam = 300f;
    public float stam;
    public float regenPersec = 25f;
    public float drainPersec = 18.75f;
    public float regenDelay = .5f;
    private float lastsprintTime;

    public bool canSprint = true;
    public bool canCrouch = true;
    public bool canSlide = true;
    public bool canDash = true;
    public bool canJump = true;
    public bool sprinting = false;
    public bool crouching = false;
    public bool sliding = false;
    public bool isMoving = false;

    public float gravity = -9.81f;
    [SerializeField] private float verticalVelocity;
    public float jumpHeight = 2f;

    private bool wasGrounded;
    public bool landed;
    public bool airborne;

    void Start()
    {
        stam = maxStam;
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stam > 0 && canSprint && isMoving)
        {
            sprinting = true;
            lastsprintTime = Time.time;
            stam -= (drainPersec * Time.deltaTime);
        }
        else
        {
            sprinting = false;
            if (Time.time - lastsprintTime >= regenDelay)
            {
                stam += (regenPersec * Time.deltaTime);
            }
        }
            stam = Mathf.Clamp(stam, 0, maxStam);
    }

    void Crouch()
{
    if (Input.GetKey(KeyCode.C) && sprinting && canSlide)
    {
        sliding = true;
        crouching = false;
    }
    else if (Input.GetKey(KeyCode.C) && canCrouch)
    {
        crouching = true;
        sliding = false;
    }
    else
    {
        sliding = false;
        crouching = false;
    }
}

    void Update()
{
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    Vector3 movement = transform.right * x + transform.forward * z;

    isMoving = movement.magnitude > 0f;

    

    Sprint();
    Crouch();
    
   if (sliding)
   {
    speed = slideSpd;
   }
   else if (sprinting)
   {
    speed = runSpd;
   }
   else if (crouching)
   {
    speed = crouchSpd;
   }
   else if (!crouching && !sprinting && !sliding && isMoving)
   {
    speed = walkSpd;
   }
   else
   {
    speed = 0;
   }

    if (controller.isGrounded && verticalVelocity < 0)
    {
        verticalVelocity = -2f;
    }
    
    if (Input.GetButtonDown("Jump") && controller.isGrounded)
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    verticalVelocity += gravity * Time.deltaTime;
    Vector3 velocity = movement * speed;
    velocity.y = verticalVelocity;
    
    controller.Move(velocity * Time.deltaTime);
    
    bool isGrounded = controller.isGrounded;
    landed = !wasGrounded && isGrounded;
    airborne = !isGrounded;
    
    wasGrounded = isGrounded;
}
}
