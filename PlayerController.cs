using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
   // public float gravity = -9.8f;
    public GameController gameController;

    
    private Rigidbody rb;
   
    public bool hasItem;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasItem = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Jump
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void OnTriggerEnter(Collider other)
    {
            // Collects Amulet and sets bool to true
           if(other.gameObject.CompareTag ("Amulet"))
           {
            other.gameObject.SetActive(false);
            hasItem = true;
           }
    }

    void FixedUpdate()
    {
        //Basic Movement
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = Vector3.ClampMagnitude(movement, speed); //Limits max speed of player
        //movement *= Time.deltaTime;
        //movement.y = gravity;
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement * speed);
    }
}
