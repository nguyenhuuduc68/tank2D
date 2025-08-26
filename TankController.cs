using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public AimTuret aimTuret;
    public Turret[] turrets;
    private void Awake()
    {
        if (tankMover == null)
        {
            tankMover = GetComponentInChildren<TankMover>();
        }
        if (aimTuret == null)
        {
            aimTuret = GetComponentInChildren<AimTuret>();
        }
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    public void HanleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
            Debug.Log("Shoot from turret: " + turret.name);
        }
    }

    public void HandleqaMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);

    }
    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTuret.Aim(pointerPosition);
    }

}
