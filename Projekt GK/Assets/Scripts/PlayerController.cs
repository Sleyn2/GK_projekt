using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    public float knockBackForce;
    public float knockbackTime;
    private float knockBackCounter;

    //double jump
    private bool doubleJump = true;

    //jiterring
    public float slopeRayLength;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            float oldMoveDirectionY = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = oldMoveDirectionY;
            if (controller.isGrounded || OnSlope())
            {
                doubleJump = true;
                if (controller.isGrounded)
                {
                    moveDirection.y = 0f;
                }
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
            else if (doubleJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetBool("doubleJump", true);

                    moveDirection.y = jumpForce;
                    doubleJump = false;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //move the player in different directions based on camera look direction
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);

        if (OnSlope() || controller.isGrounded)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("doubleJump", false);
        }
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockbackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

    private bool OnSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeRayLength))
            if (hit.normal != Vector3.up)
                return true;
        return false;
    }
}
