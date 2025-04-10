using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GroundDetector _groundDetector;

    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";
    private KeyCode _jumpKey = KeyCode.Space;

    private Rigidbody _rigidBody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveForce;

    private float _deadZone = 0.1f;
    private float xInput;
    private float yInput;
    private bool _isJumpKeyPressed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw(_horizontalAxisName);
        yInput = Input.GetAxisRaw(_verticalAxisName);

        if (Input.GetKeyDown(_jumpKey) && _groundDetector.IsGrounded)
        {
            _isJumpKeyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward * yInput + cameraRight * xInput).normalized;

        Move(moveDirection);
        Jump();
    }

    private void Move (Vector3 direction)
    {
        if (direction.magnitude > _deadZone)
        {
            _rigidBody.AddForce(direction * _moveForce);
        }
    }

    private void Jump ()
    {
        if (_isJumpKeyPressed)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpKeyPressed = false;
            _groundDetector.ForceUnground();
        }
    }
}