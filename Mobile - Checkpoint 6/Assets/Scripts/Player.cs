using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -20f;

    [Header("Input Settings")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Knockback Settings")]
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float knockbackDuration = 0.2f;

    [Header("Blink Settings")]
    [SerializeField] private float blinkTime;

    private CharacterController controller;
    private MeshRenderer meshRenderer;
    private float moveInput, knockbackTimer;
    private Vector3 velocity, knockbackVelocity;
    private bool jumpQueued;

    public static bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }
    void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        ReadInput();
        UpdateGroundedState();
        HandleJump();
        ApplyGravity();
        ApplyMovement();
    }

    void ReadInput()
    {
        moveInput = moveAction.action.ReadValue<Vector2>().x;
        
        if (jumpAction.action.WasPressedThisFrame())
        {
            jumpQueued = true;
        }
    }

    void UpdateGroundedState()
    {
        isGrounded = controller.isGrounded;
        
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

    }

    void HandleJump()
    {
        if (!jumpQueued) return;
        
        jumpQueued = false;
        
        if (!isGrounded) return;
        
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void ApplyGravity()
    {
        if (!isGrounded || velocity.y > 0f)
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    public void ApplyKnockback(Vector3 damageSourcePosition)
    {
        Vector3 direction = (transform.position - damageSourcePosition);

        direction.y = 0.2f;

        knockbackVelocity = direction.normalized * knockbackForce;

        knockbackTimer = knockbackDuration;
    }

    void ApplyMovement()
    {
        Vector3 finalMove = Vector3.zero;

        if (knockbackTimer > 0f)
        {
            knockbackTimer -= Time.deltaTime;

            knockbackVelocity = Vector3.Lerp(knockbackVelocity, Vector3.zero, 5f * Time.deltaTime);

            finalMove = knockbackVelocity;
        }

        else
        {
            Vector3 move = transform.right * moveInput;
            Vector3 horizontal = move * moveSpeed;
            finalMove = horizontal + Vector3.up * velocity.y;
        }

        controller.Move(finalMove * Time.deltaTime);
    }

    public void StartBlink()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(blinkTime);
        meshRenderer.enabled = true;
    }
}
