using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStageManager : MonoBehaviour
{
    public float currentMoveSpeed;
    public float WalkSpeed = 1, walkBackSpeed = 1;
    public float RunSpeed = 1, RunBackSpeed;
    public float CrouchSpeed = 1, CrouchBackSpeed = 1;
    [HideInInspector] public Vector3 dir;
    float hzInput, vInput;
    [SerializeField] CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkState walk = new WalkState();
    public CrawlState Crawl = new CrawlState();
    public RunState Run = new RunState();

    [HideInInspector] public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwichState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        currentState.UpdateState(this);

        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);
    }

    public void SwichState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right *hzInput;

        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }
    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
            if(Physics.CheckSphere(spherePos, controller.radius -0.05f, groundMask)) return true;
            return false;
    }

    void Gravity()
    {
        if(!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y < 0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(spherePos, controller.radius - 0.05f);
    }
}
