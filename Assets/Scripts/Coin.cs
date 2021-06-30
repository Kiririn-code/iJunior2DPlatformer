using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerMover playerMoower))
        {
            Destroy(gameObject);
        }
    }
}
