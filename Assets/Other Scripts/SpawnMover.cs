using UnityEngine;

public class SpawnMover : MonoBehaviour
{
    private bool _goRight;

    private void Update()
    {
        if (transform.position.x >= 9)
            _goRight = false;

        if (transform.position.x <= -9)
            _goRight = true;

        if(_goRight)
            transform.Translate(2 * 1 * Time.deltaTime, 0, 0);
        else
            transform.Translate(2 * -1 * Time.deltaTime, 0, 0);
    }
}
