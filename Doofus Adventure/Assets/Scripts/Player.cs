using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float moveSpeed;
    [SerializeField] float moveSpeedMul = 1.5f; //if the speed feels to slow 
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

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAnim();
        HandleDeath();
    }

    void HandleMovement() {

        Vector2 inputVector = GameInput.Instance.GetMovementInputVector().normalized;

        float moveSpeed = moveSpeedMul * GameData.Instance.GetSpeed(); //can't have it in start coz of download reasons

        float xVel = inputVector.x * moveSpeed;
        float zVel = inputVector.y * moveSpeed;

        float xDir = inputVector.x;
        float zDir = inputVector.y  ;

        //Doofus move
        rb.velocity = new Vector3(xVel, rb.velocity.y, zVel);

        //Doofus smoothly turns.
        Vector3 moveDir = new Vector3(xDir, 0f, zDir);

        if (moveDir == Vector3.zero) { return;  }
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }

    //very primitive grounding check, using physics casts would be too much
    bool IsGrounded() { 
        return rb.position.y - boxCollider.size.y/2 > 0 ;
    }

    void HandleAnim() {

        // if grounded and moving.
        float xSpeed = Mathf.Abs(rb.velocity.x);
        float zSpeed = Mathf.Abs(rb.velocity.z);

        if (IsGrounded() && 
          (xSpeed > 0 || zSpeed > 0)) {
            animator.SetBool(HOPPING_ANIM_BOOL, true);
        }
        else {
            animator.SetBool(HOPPING_ANIM_BOOL, false);
        }
    }

    void HandleDeath() {
        if (!IsGrounded()) {
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(1f); //shouldn't hardcode this, but...
        SessionManager.Instance.PlayerDeath();
    }
}
