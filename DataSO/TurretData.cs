using UnityEngine;
[CreateAssetMenu(fileName = "NewTurretData", menuName = "Data/TurretData", order = 1)]
public class TurretData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float reloadDelay = 4f;
    public BulletData bulletData;
}

