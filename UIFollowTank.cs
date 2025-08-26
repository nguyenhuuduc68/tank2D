using UnityEngine;

public class UIFollowTank : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;
    // tăng khoảng cách với nhân vật
    public Vector2 offset = new Vector2(0, 1);

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {

        // Kiểm tra nếu objectToFollow không null trước khi truy cập localPosition
        if (objectToFollow != null)
        {
            // Cập nhật vị trí của RectTransform theo vị trí của objectToFollow
            rectTransform.anchoredPosition = new Vector2(objectToFollow.localPosition.x, objectToFollow.localPosition.y) + offset;
        }
    }

}
