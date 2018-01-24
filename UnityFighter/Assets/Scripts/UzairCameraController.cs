using UnityEngine;
using System.Collections;

/**
 * Mouse controlled camera controller.
 * This isn't in use because the fixed camera works better, 
 * but i kept it because it uses late update.
 **/

public class UzairCameraController : MonoBehaviour
{
    //Get the optimal turn speed, height, and distance from player
    public float turnSpeed = 4f;
    public float height = 3f;
    public float distance = -4f;

    //the target object
    public GameObject player;

    //the x and y offsets
    Vector3 offsetX;
    Vector3 offsetY;

    //the mouse x and y inputs
    float mx;
    float my;

    private void Start()
    {
        //gets the offset with the height, distance and target position
        offsetX = new Vector3(player.transform.position.x, player.transform.position.y + height,
            player.transform.position.z - distance);

        offsetY = new Vector3(player.transform.position.x, player.transform.position.y,
            player.transform.position.z - distance);
    }

    private void LateUpdate()
    {
        //updates mouse pos
        mx = Input.GetAxisRaw("Mouse X");
        my = Input.GetAxisRaw("Mouse Y");

        //uses the mousepos to rotate the camera around the player
        offsetX = Quaternion.AngleAxis(mx * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(my * turnSpeed, Vector3.right) * offsetY;

        //sets the cameras position to the players position plus the offset
        transform.position = player.transform.position + offsetX + offsetY;

        //aims the camera on the player
        transform.LookAt(player.transform.position);
    }
}