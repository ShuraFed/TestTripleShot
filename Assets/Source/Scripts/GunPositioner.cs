using UnityEngine;

public class GunPositioner : MonoBehaviour
{
    private float offsetDividerX = 100;
    private float offsetDividerY = 10;
    private void Awake()
    {
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;
        Vector3 screenPosition = new Vector3(-screenWidth / offsetDividerX, screenHeight / 2 - screenHeight / offsetDividerY, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }
}
