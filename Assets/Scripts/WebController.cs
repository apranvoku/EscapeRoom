using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebController : MonoBehaviour
{
    public Vector2 turn;
    public float speed = 80;
    private GameObject Head;
    public Rigidbody rb;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        Cursor.lockState = CursorLockMode.Locked;
        Head = GameObject.Find("Head");
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        //transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position += speed * Time.deltaTime*transform.forward/10f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(transform.position -= speed * Time.deltaTime*transform.right / 10f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position -= speed * Time.deltaTime*transform.forward / 10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(transform.position += speed * Time.deltaTime*transform.right / 10f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * 300);
            canJump = false;
            StartCoroutine(JumpCooldown());
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        //transform.Rotate(-turn.y, turn.x, 0f);
        transform.localRotation = Quaternion.Euler(0f, turn.x, 0f);
        Head.transform.localRotation = Quaternion.Euler(-turn.y, 0f, 0f);
        //Debug.DrawRay(Head.transform.GetChild(0).position, Head.transform.forward*10f, Color.cyan);
        //Debug.Log(rb.velocity.magnitude);
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null) {
                    Debug.Log(hit.transform.name);
                }
            }

        }*/
    }

    public IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(2f);
        canJump = true;
    }
}
