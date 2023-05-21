using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D _coll;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] public LayerMask jumpableGround;

    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpSpeed = 14f;

    private enum MovementState { Idle, Running, Jumping, Falling }

    private MovementState _state = MovementState.Idle;

    [SerializeField]
    private AudioSource _jumpSoundEffect;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _coll = GetComponent<BoxCollider2D>();
    }

    protected void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _jumpSoundEffect.Play();
            rb.velocity = new Vector3(0, jumpSpeed, 0);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        if (rb.velocity.x < 0f)
        {
            _state = MovementState.Running;
            _spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0f)
        {
            _state = MovementState.Running;
            _spriteRenderer.flipX = false;
        }
        else
        {
            _state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            _state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            _state = MovementState.Falling;
        }

        _animator.SetInteger("state", (int)_state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_coll.bounds.center, _coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
