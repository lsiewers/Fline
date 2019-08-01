using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public bool activated;
    private float axisSpeed;

    // Update is called once per frame
    void Update()
    {
        axisSpeed = GameManager.Instance.AxisSpeed;

        if (activated)
        {
            print("active");
            print(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            // only change axis if your finger is placed more to the right
            if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 540, 10));
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(-7.2f, transform.position.y), GameManager.Instance.LineSpeed * Time.deltaTime * axisSpeed);
        }
    }
}
