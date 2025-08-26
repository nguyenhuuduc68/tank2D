using UnityEngine;
[CreateAssetMenu(fileName = "NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeed = 10f;
    public float rotationSpeed = 100f;
    public float acceleration = 70f;
    public float deceleration = 50f;
}
