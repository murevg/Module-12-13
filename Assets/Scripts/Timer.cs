using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeOutsideText;
    [SerializeField] private float _maxTimeOutside = 10f;

    private float _timeOutside = 0f;

    public float TimeLeft => Mathf.Max(0f, _maxTimeOutside - _timeOutside);

    public bool IsTimeUp => TimeLeft <= 0f;

    private void Update()
    {
        _timeOutside += Time.deltaTime;

        if (_timeOutsideText != null)
            _timeOutsideText.text = TimeLeft.ToString("0.0");
    }
}
