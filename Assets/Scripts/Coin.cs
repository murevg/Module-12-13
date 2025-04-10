using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _value = 1;
    public int Value => _value;

    [SerializeField] private ParticleSystem _collectParticles;

    public void DestroyCoin()
    {
        if (_collectParticles != null)
        {
            _collectParticles.transform.parent = null;
            _collectParticles.Play();
            Destroy(_collectParticles.gameObject, _collectParticles.main.duration + _collectParticles.main.startLifetime.constantMax);
        }

        gameObject.SetActive(false);
    }
}
