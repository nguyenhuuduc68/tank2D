using UnityEngine;
[CreateAssetMenu(fileName = "NewBulletData", menuName = "Data/BulletData")]
public class BulletData : ScriptableObject
{
    public float speed = 10f; // Tốc độ của viên đạn
    public int damage = 5; // Sát thương của viên đạn
    public float maxDistance = 10f; // Khoảng cách tối đa mà viên đạn có thể bay
}
