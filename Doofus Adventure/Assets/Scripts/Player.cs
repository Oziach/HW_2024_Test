using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveSpeed;
    [SerializeField] private float rotateSpeed = 10f;

    private Rigidbody rb;
    private BoxCollider boxCollider;
    
    private Animator animator;

    const string HOPPING_ANIM_BOOL = "Hopping";
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        boxCollider = rb.GetComponent<BoxCollider>();
        animator= rb.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAnim();
    }

    //movement
    void HandleMovement() {

        Vector2 inputVector = GameInput.Instance.GetMovementInputVector().normalized;

        float moveSpeed = GameData.Instance.GetSpeed(); //can't have it in start coz of download reasons

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
    
    bool IsGrounded() { //very primitive grounding check, using physics casts would be too much
        return rb.position.y - boxCollider.size.y/2 > 0 ;
    }

    void HandleAnim() {

        // if grounded and moving.
        if (IsGrounded() && 
          (Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.z) > 0)) {
            animator.SetBool(HOPPING_ANIM_BOOL, true);
        }
        else {
            animator.SetBool(HOPPING_ANIM_BOOL, false);
        }
    }
}
