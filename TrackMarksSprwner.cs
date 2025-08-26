using UnityEngine;

public class TrackMarksSprwner : MonoBehaviour
{
    private Vector2 lastPosition;
    public float trackMarkDistance = 0.2f; // Khoảng cách giữa các dấu vết
    public GameObject trackMarkPrefab; // prefab dấu vết

    public int objectPoolSize = 50; // Kích thước pool cho dấu vết
    private ObjectPool objectPool; // Pool để quản lý dấu vết

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        lastPosition = transform.position;
        objectPool.Initialize(trackMarkPrefab, objectPoolSize); // Khởi tạo pool với prefab dấu vết và kích thước pool
    }
    private void Update()
    {
        var distanceDriver = Vector2.Distance(lastPosition, transform.position);
        if (distanceDriver >= trackMarkDistance)
        {
            lastPosition = transform.position;
            var trackMark = objectPool.CreateOject(); // Tạo dấu vết từ pool
            trackMark.transform.position = transform.position; // Đặt vị trí dấu vết
            trackMark.transform.rotation = transform.rotation; // Đặt góc quay dấu vết
        }
    }
}
