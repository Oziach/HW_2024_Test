using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotateSpeed = 10f;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    //movement
    void HandleMovement() {

        Vector2 inputVector = GameInput.Instance.GetMovementInputVector().normalized;
        
        float xVel = inputVector.x * moveSpeed;
        float zVel = inputVector.y * moveSpeed;

        float xDir = inputVector.x;
        float zDir = inputVector.y  ;

        //Doofus move
        rb.velocity = new Vector3(xVel, rb.velocity.y, zVel);

        //Doofus smoothly turns.
        Vector3 moveDir = new Vector3(xDir, 0f, zDir);
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }
}
