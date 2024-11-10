using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 startPosition;
    private float moveDistance = 10f;
    private bool movingRight = true;

    void Start()
    {

        startPosition = transform.position;
    }

    void Update()
    {

        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }

        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= startPosition.x)
            {
                movingRight = true;
            }
        }
    }
}