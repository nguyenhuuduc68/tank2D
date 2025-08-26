using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb;// Rigidbody2D của xe tăng
    private Vector2 movementVector;// vector di chuyển của xe tăng
    public TankMovementData movementData;// dữ liệu di chuyển của xe tăng
    private float currentSpeed = 0; // tốc độ hiện tại của xe tăng
    private float currentForewardDirection = 1f; // tốc độ xoay hiện tại của xe tăng

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();// Sự kiện để thông báo tốc độ thay đổi
    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();//
    }
    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
        if (movementVector.y > 0)
        {
            if (currentForewardDirection == -1f)
            {
                currentSpeed = 0; // Reset speed if changing direction
                currentForewardDirection = 1f; // Change direction to forward
            }
        }
        else if (movementVector.y < 0)
        {
            if (currentForewardDirection == 1f)
            {
                currentSpeed = 0; // Reset speed if changing direction
                currentForewardDirection = -1f; // Change direction to backward
            }
        }

    }
    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));
    }
}
