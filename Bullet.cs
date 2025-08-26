using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rb2d;

    public UnityEvent OnHit = new UnityEvent();

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void Initialized(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.linearVelocity = transform.up * bulletData.speed;
    }

    private void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);// Tính khoảng cách từ vị trí ban đầu
        if (conquareDistance > bulletData.maxDistance)
        {
            DisableOject();// Nếu khoảng cách vượt quá giới hạn xóa đạn.
            Debug.Log("Bullet disabled due to max distance exceeded.");
        }
    }
    private void DisableOject()
    {
        rb2d.linearVelocity = Vector2.zero;// Dừng chuyển động của viên đạn
        gameObject.SetActive(false);// Vô hiệu hóa đối tượng viên đạn
    }

    // Hàm này sẽ được gọi khi viên đạn va chạm với một đối tượng khác
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        Debug.Log("Collider  " + collision.name);
        OnHit?.Invoke(); // Gọi sự kiện OnHit khi va chạm xảy ra
        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(bulletData.damage);
            Debug.Log("Hit " + damagable.name + " with damage: " + bulletData.damage);
        }
        DisableOject();
    }

}
