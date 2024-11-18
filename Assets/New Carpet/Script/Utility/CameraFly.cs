using UnityEngine;

public class CameraFly : MonoBehaviour
{
    // Velocidades de movimiento
    public float moveSpeed = 10f;
    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;
    public float minLookAngle = -80f;
    public float maxLookAngle = 80f;

    private float rotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el ratón
        Cursor.visible = false; // Hace invisible el ratón
    }

    void Update()
    {
        // Mover la cámara
        MoveCamera();

        // Girar la cámara con el ratón
        RotateCamera();
    }

    void MoveCamera()
    {
        // Obtener la entrada del teclado para el movimiento
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A/D o las flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // W/S o las flechas arriba/abajo
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Space)) // Subir
        {
            moveY = moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl)) // Bajar
        {
            moveY = -moveSpeed * Time.deltaTime;
        }

        // Aplicar el movimiento en el espacio 3D
        transform.Translate(moveX, moveY, moveZ, Space.Self);
    }

    void RotateCamera()
    {
        // Obtener la entrada del ratón para la rotación
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        // Rotación alrededor del eje Y (izquierda/derecha)
        transform.Rotate(0, mouseX, 0);

        // Limitar la rotación en el eje X (arriba/abajo)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minLookAngle, maxLookAngle);

        // Aplicar la rotación en el eje X (arriba/abajo)
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
