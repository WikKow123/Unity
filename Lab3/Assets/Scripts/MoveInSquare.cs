using UnityEngine;

public class MoveInSquare : MonoBehaviour
{
    public float speed = 2f;
    public float sideLength = 10f;

    private Vector3 startPosition;
    private int currentSide = 0;
    private float distanceMoved = 0;

    void Start()
    {
        startPosition = transform.position;

        void Update()
        {
            MoveAlongSide();
        }

        void MoveAlongSide()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            distanceMoved += speed * Time.deltaTime;

            if (distanceMoved >= sideLength)
            {
                distanceMoved = 0;
                currentSide = (currentSide + 1) % 4;
                transform.Rotate(0, 90, 0);
            }
        }
    }
}
