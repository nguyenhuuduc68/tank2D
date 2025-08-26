using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AIPatrolPathBehaviour : AIBehaviour
{
    public PatrolPath patrolPath;
    [Range(0.1f, 1)]
    public float arriveDistance = 1;
    public float waittime = 0.5f;
    [SerializeField] private bool isWaiting = false;
    [SerializeField] Vector2 currentPatrolTarget = Vector2.zero;
    bool isInitialized = false;

    private int currentIndex = -1;

    private void Awake()
    {
        if (patrolPath == null)
        {
            patrolPath = GetComponentInChildren<PatrolPath>();
        }
    }

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (!isWaiting)
        {
            // Kiểm tra xem có đủ điểm để tuần tra không
            if (patrolPath.Length < 2)
            {
                return;
            }
            // Nếu chưa khởi tạo, lấy điểm gần nhất và lưu index
            // và vị trí của điểm đó
            if (!isInitialized)
            {
                var currentPathPoint = patrolPath.GetClosestPathPoint(tank.transform.position);// lấy điểm gần nhất
                currentIndex = currentPathPoint.Index;// lưu index của điểm gần nhất
                currentPatrolTarget = currentPathPoint.Position;// lưu vị trí của điểm gần nhất
                isInitialized = true;// đánh dấu đã khởi tạo
            }
            // Kiểm tra xem có đến điểm đích chưa
            if (Vector2.Distance(tank.transform.position, currentPatrolTarget) < arriveDistance)
            {
                isWaiting = true;
                StartCoroutine(WaitCoroutine());
                return;
            }
            Vector2 directionTOGO = currentPatrolTarget - (Vector2)tank.tankMover.transform.position;
            var dotProduct = Vector2.Dot(tank.tankMover.transform.up, directionTOGO.normalized);

            // Nếu chưa đến điểm đích, di chuyển về phía điểm đích
            if (dotProduct < 0.98f)
            {
                var crossProducts = Vector3.Cross(tank.tankMover.transform.up, directionTOGO.normalized);
                int rotationResult = crossProducts.z >= 0 ? -1 : 1;
                tank.HandleqaMoveBody(new Vector2(rotationResult, 1));
            }
            else
            {
                tank.HandleqaMoveBody(Vector2.up);
            }
        }
        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waittime);
            var newPathPoint = patrolPath.GetNextPathPoint(currentIndex);
            currentPatrolTarget = newPathPoint.Position;
            currentIndex = newPathPoint.Index;
            isWaiting = false;
        }
    }
}
