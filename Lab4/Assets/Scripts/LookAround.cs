using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform
    public Transform player;

    // Sensitivity for mouse movement
    public float sensitivity = 200f;

    // Maksymalny k�t obrotu kamery w osi X (g�ra-d�)
    private float upperLookLimit = 90f;
    private float lowerLookLimit = -90f;

    // K�t obrotu kamery w osi X
    private float currentXRotation = 0f;

    void Start()
    {
        // Zablokowanie kursora na �rodku ekranu oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Ukrycie kursora
    }

    void Update()
    {
        // Pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Obr�t wok� osi Y (ruch poziomy)
        player.Rotate(Vector3.up * mouseXMove);

        // Obr�t wok� osi X (ruch pionowy) z ograniczeniem
        currentXRotation -= mouseYMove; // U�ywamy -mouseYMove, aby obraca� kamer� w odpowiednim kierunku
        currentXRotation = Mathf.Clamp(currentXRotation, lowerLookLimit, upperLookLimit); // Ograniczamy obr�t kamery

        // Zastosowanie obrotu w osi X do kamery
        transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
}
