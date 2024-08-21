using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float shiftSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    bool isGrounded = true;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
