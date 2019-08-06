using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Color color;
    private Transform axis;
    private FollowLine line;
    public int id;

    [HideInInspector] public bool activated;

    private float axisSpeed;
    private float lineSpeed;

    private void Start()
    {
        axis = transform.Find("Axis");
        line = GetComponentInChildren<FollowLine>();

        axisSpeed = GameManager.Instance.AxisSpeed;
        lineSpeed = GameManager.Instance.LineSpeed;

        axis.GetComponent<LineRenderer>().startColor = color;
        line.GetComponent<LineRenderer>().startColor = color;

        axis.GetComponent<LineRenderer>().endColor = color;
        line.GetComponent<LineRenderer>().endColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        lineSpeed = GameManager.Instance.LineSpeed; // must be updated, because of increase of speed with higher level

        if (!activated)
        {
            //GameManager.Instance.logText.GetComponent<TextMeshProUGUI>().SetText(axisSpeed.ToString() + lineSpeed.ToString());
            axis.GetComponent<LineRenderer>().startColor = color;
            axis.position = Vector2.MoveTowards(new Vector2(axis.position.x, axis.position.y), new Vector2(-7.2f, axis.position.y), lineSpeed * Time.deltaTime * axisSpeed);

            if(axis.position.x <= 7.2f)
            {
                // game over!
                GameOver.GameOverMethod();
            }
        }
    }
}
