/*using System;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float fielOfVisionForShooting = 60f;
    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleqaMoveBody(Vector2.zero);
            tank.HanleShoot();
        }
        tank.HandleTurretMovement(detector.Target.position);
    }
    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        var diretion = detector.Target.position - tank.aimTuret.transform.position;
        if (Vector2.Angle(tank.aimTuret.transform.right, diretion) < fielOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
*/
using System;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float fielOfVisionForShooting = 60f;
    public float shootCooldown = 2f; // Thời gian chờ giữa mỗi lần bắn
    private float shootTimer = 0f;   // Bộ đếm thời gian

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        // Cập nhật bộ đếm thời gian
        shootTimer -= Time.deltaTime;

        // Kiểm tra xem có mục tiêu không
        if (detector.Target == null)
        {
            return; // Không có mục tiêu, không làm gì cả
        }

        if (TargetInFOV(tank, detector))
        {
            tank.HandleqaMoveBody(Vector2.zero);

            // Chỉ bắn khi hết thời gian chờ
            if (shootTimer <= 0f)
            {
                tank.HanleShoot();
                shootTimer = shootCooldown; // Reset thời gian chờ
            }
        }

        // Xoay nòng pháo về phía mục tiêu
        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.aimTuret.transform.position;
        return Vector2.Angle(tank.aimTuret.transform.right, direction) < fielOfVisionForShooting / 2;
    }
}
