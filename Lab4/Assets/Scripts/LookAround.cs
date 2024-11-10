using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform
    public Transform player;

    // Sensitivity for mouse movement
    public float sensitivity = 200f;

    // Maksymalny k¹t obrotu kamery w osi X (góra-dó³)
    private float upperLookLimit = 90f;
    private float lowerLookLimit = -90f;

    // K¹t obrotu kamery w osi X
    private float currentXRotation = 0f;

    void Start()
    {
        // Zablokowanie kursora na œrodku ekranu oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Obrót wokó³ osi Y (ruch poziomy)
        player.Rotate(Vector3.up * mouseXMove);

        // Obrót wokó³ osi X (ruch pionowy) z ograniczeniem
        currentXRotation -= mouseYMove; // U¿ywamy -mouseYMove, aby obracaæ kamerê w odpowiednim kierunku
        currentXRotation = Mathf.Clamp(currentXRotation, lowerLookLimit, upperLookLimit); // Ograniczamy obrót kamery

        // Zastosowanie obrotu w osi X do kamery
        transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
}
