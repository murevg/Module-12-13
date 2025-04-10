using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _maxGroundAngle = 45f;

    private float _minDotProduct;
    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _minDotProduct = Mathf.Cos(_maxGroundAngle * Mathf.Deg2Rad);
    }

    public void ForceUnground()
    {
        _isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) >= _minDotProduct)
            {
                _isGrounded = true;
                return;
            }
        }
        _isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}

