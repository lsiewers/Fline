using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = GameManager.Instance.LineSpeed;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        // Move the object upward in world space 1 unit/second.
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }
}
