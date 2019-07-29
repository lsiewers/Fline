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
        transform.Translate(speed, 0, 0);
    }
}
