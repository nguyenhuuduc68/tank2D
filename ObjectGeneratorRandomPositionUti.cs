using UnityEngine;

public class ObjectGeneratorRandomPositionUti : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 0.2f;

    protected Vector2 GetRamdomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }

    protected Quaternion Random2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0f, 360f));
    }

    public void CreteObject()
    {
        Vector2 position = GetRamdomPosition();
        GameObject impactObject = GetObject();
        impactObject.transform.position = position;
        impactObject.transform.rotation = Random2DRotation();
    }

    protected virtual GameObject GetObject()
    {
        return Instantiate(objectPrefab);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}