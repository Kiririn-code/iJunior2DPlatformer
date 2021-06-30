using UnityEngine;

public class SpawnMover : MonoBehaviour
{
    private bool _doChangeSide;

    private void Update()
    {
        if (transform.position.x >= 9)
            _doChangeSide = false;

        if (transform.position.x <= -9)
            _doChangeSide = true;

        if(_doChangeSide)
            transform.Translate(2 * 1 * Time.deltaTime, 0, 0);
        else
            transform.Translate(2 * -1 * Time.deltaTime, 0, 0);
    }
}
