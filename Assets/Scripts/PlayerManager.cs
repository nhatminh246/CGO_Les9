using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float verticalInput;
    [SerializeField] private float horizontalInput;
    CharacterController cha;
    Vector3 move_speed;
    [SerializeField] private Animator animator;

    void Start()
    {
        cha = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direc = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 100f, 0);

        WalkAndRunAnimation(direc);
        JumpAnimation();
        CrouchAnimation();








    }

    void RunAnimation()
    {
        if (Input.GetKey(KeyCode.L))
        {
            animator.SetBool("IsRun", true);

        }
        else animator.SetBool("IsRun", false);
    }
    void WalkAndRunAnimation(Vector3 direc)
    {
        if (direc != Vector3.zero)
        {
            animator.SetBool("IsWalk", true);

            RunAnimation();
        }
        else
        {
            animator.SetBool("IsWalk", false);


        }
    }
    void JumpAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsRun", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HumanoidJumpForwardRight"))
        {
            // Avoid any reload.
            animator.SetBool("IsJump", false);
        }
    }
    void CrouchAnimation()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsCrouch", true);

        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HumanoidCrouchIdle"))
        {
            // Avoid any reload.
            animator.SetBool("IsCrouch", false);
        }
    }
}
