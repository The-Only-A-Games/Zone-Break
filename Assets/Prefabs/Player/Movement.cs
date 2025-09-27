using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 15f;
    public float jump = 5f;
    public float gravity = 9.81f;
    public float rotationSpeed = 10f;

    public Vector3 MousePosDir { get; private set; }


    public CharacterController ch;
    public PlayerInputActions controls;
    public Camera mainCam;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform muzzelTransform;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ch = GetComponent<CharacterController>();
        controls = GetComponent<PlayerInputActions>();
        mainCam = FindFirstObjectByType<Camera>();
        // muzzelTransform = FindFirstObjectByType<Muz>
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 input = new(controls.Move.x, controls.Move.y);
        Vector3 move_direction = new(input.x, 0f, input.y);

        if (!ch.isGrounded)
        {
            move_direction.y -= gravity * Time.deltaTime;
        }



        Vector3 lookTarget = LookTowardCusor();
        MousePosDir = (lookTarget - muzzelTransform.position).normalized;
        if (lookTarget != Vector3.zero && controls.Shoot) // Only move if raycast collided with something
        {
            Vector3 lookDir = (lookTarget - transform.position);
            lookDir.y = 0; // ignore vertical
            Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = targetRotation;
        }

        ch.Move(move_direction * speed * Time.deltaTime);


        Vector3 flatVelocity = new Vector3(ch.velocity.x, 0, ch.velocity.z); // ignore vertical
        float currentSpeed = flatVelocity.magnitude; // how fast the player is moving
        animator.SetFloat("speed", currentSpeed); // send value to Animator

        move_direction.y = 0;
        if (move_direction.sqrMagnitude > 0.01f && !controls.Shoot)
        {
            // Smooth rotation toward movement direction
            Quaternion targetRotation = Quaternion.LookRotation(move_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        ch.Move(move_direction * speed * Time.deltaTime);

    }

    private Vector3 LookTowardCusor()
    {
        // Getting the mouse position
        Vector3 mousePosition = Input.mousePosition;

        // Cast a ray to the mouse cusor position
        Ray ray = mainCam.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
