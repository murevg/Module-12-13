using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _amplitude = 0.2f;
    [SerializeField] private float _frequency = 2f;
    [SerializeField] private float _rotationSpeed = 50f;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * _frequency) * _amplitude;
        transform.position = _currentPosition + new Vector3(0, offsetY, 0);

        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }
}
