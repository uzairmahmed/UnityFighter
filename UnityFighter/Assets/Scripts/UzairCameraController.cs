using UnityEngine;
using System.Collections;

public class UzairCameraController : MonoBehaviour
{
    public float turnSpeed = 4f;
    public float height = 3f;
    public float distance = -4f;
    public GameObject player;

    Vector3 offsetX;
    Vector3 offsetY;

    float mx;
    float my;

    private void Start()
    {
        offsetX = new Vector3(player.transform.position.x, player.transform.position.y + height,
            player.transform.position.z - distance);

        offsetY = new Vector3(player.transform.position.x, player.transform.position.y,
            player.transform.position.z - distance);
    }

    private void LateUpdate()
    {
        mx = Input.GetAxisRaw("Mouse X");
        my = Input.GetAxisRaw("Mouse Y");

        offsetX = Quaternion.AngleAxis(mx * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(my * turnSpeed, Vector3.right) * offsetY;

        transform.position = player.transform.position + offsetX + offsetY;
        transform.LookAt(player.transform.position);
    }
}