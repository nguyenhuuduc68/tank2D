using UnityEngine;

public class DestroyIfDisabled : MonoBehaviour

{
    public bool SelDestructionEnabled { get; set; } = false;
    private void OnDisable()
    {
        if (SelDestructionEnabled)
        {
            Destroy(gameObject);
        }
    }
}
