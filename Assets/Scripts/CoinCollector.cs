using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            _wallet.Add(coin.Value);
            Debug.Log(_wallet.Value);
            coin.DestroyCoin();
        }
    }
}
