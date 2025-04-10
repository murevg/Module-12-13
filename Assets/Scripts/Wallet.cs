using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Value { get; private set; }

    public void Add (int coin)
    {
        Value = Mathf.Max(0, Value + coin);
    }
}
