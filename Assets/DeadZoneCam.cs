using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float deadZoneX = 3f;
    public float deadZoneY = 2f;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        float offsetX = player.position.x - transform.position.x;
        float offsetY = player.position.y - transform.position.y;

        Vector3 desiredPosition = transform.position;

        if (Mathf.Abs(offsetX) > deadZoneX)
        {
            desiredPosition.x = player.position.x - Mathf.Sign(offsetX) * deadZoneX;
        }

        if (Mathf.Abs(offsetY) > deadZoneY)
        {
            desiredPosition.y = player.position.y - Mathf.Sign(offsetY) * deadZoneY;
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}