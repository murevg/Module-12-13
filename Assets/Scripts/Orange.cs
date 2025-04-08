using UnityEngine;

public class Orange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            ball.AddOranges(1);
            gameObject.SetActive(false);
        }
    }
}
