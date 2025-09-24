using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 15f;
    public float jump = 5f;
    public float gravity = 9.81f;


    public CharacterController ch;
    public PlayerInputActions controls;
    public Camera mainCam;
    public LayerMask groundLayer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ch = GetComponent<CharacterController>();
        controls = GetComponent<PlayerInputActions>();
        mainCam = FindFirstObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 input = new(controls.Move.x, controls.Move.y);
        Vector3 move_direction = transform.forward * input.y + transform.right * input.x;

        if (!ch.isGrounded)
        {
            move_direction.y -= gravity * Time.deltaTime;
        }

        // if (controls.Jump && ch.isGrounded)
        // {
        //     move_direction.y = jump;
        // }

        Vector3 lookTarget = LookTowardCusor();
        if (lookTarget != Vector3.zero) // Only move if raycast collided with something
        {
            Vector3 lookDir = (lookTarget - transform.position);
            lookDir.y = 0; // ignore vertical
            Quaternion targetRotation = Quaternion.LookRotation(lookDir);
            transform.rotation = targetRotation;
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
