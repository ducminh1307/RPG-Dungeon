using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public Stats stats { get; private set; }

    [Header("Collision Details")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform attackCheck;
    [SerializeField] protected float attackCheckRadius;
    [SerializeField] protected LayerMask whatIsGround;

    protected virtual void Awake()
    {
        stats = GetComponent<Stats>();
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual bool IsGroundDetected() => Physics.CheckSphere(groundCheck.position, groundCheckDistance, whatIsGround);

    public virtual void Death() { }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
}
