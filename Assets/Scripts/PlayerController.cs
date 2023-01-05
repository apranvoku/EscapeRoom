using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 turn;
    private GameObject Head;
    public Rigidbody rb;
    public bool gravity_on;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        controller = gameObject.AddComponent<CharacterController>();
        Head = GameObject.Find("XR Origin");
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false;
        gravity_on = true;
    }

    public void Gravity()
    {
        StartCoroutine(TurnOnGravity());
    }
    public IEnumerator TurnOnGravity()
    {
        yield return new WaitForSeconds(2f);
        rb.useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(0f, turn.x, 0f);
        Head.transform.localRotation = Quaternion.Euler(-turn.y, 0f, 0f);

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Vector3 move = new Vector3(transform.right*Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(transform.right * Time.deltaTime * playerSpeed * Input.GetAxis("Horizontal"));
        controller.Move(transform.forward * Time.deltaTime * playerSpeed * Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);
       // Debug.Log("move vector is: " + move);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.G))
        {
            gravity_on = !gravity_on;
            if (gravity_on)
            {
                rb.useGravity = true;
            }
            else
            {
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
        }
        //transform.Rotate(-turn.y, turn.x, 0f);

        //Debug.DrawRay(Head.transform.GetChild(0).position, Head.transform.forward*10f, Color.cyan);
        //Debug.Log(rb.velocity.magnitude);
    }
}
