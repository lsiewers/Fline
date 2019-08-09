using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // inspector
    public Color color;
    public int id;

    // not inspector
    private bool isActive = true;

    private Transform axis;
    private FollowLine line;

    [HideInInspector] public bool activated;

    private float axisSpeed;
    private float lineSpeed;

    private void Start()
    {
        axis = transform.Find("Axis");
        line = GetComponentInChildren<FollowLine>();

        axisSpeed = GameManager.Instance.AxisSpeed;
        lineSpeed = GameManager.Instance.LineSpeed;

        SetColors();
    }

    // Update is called once per frame
    void Update()
    {
        lineSpeed = GameManager.Instance.LineSpeed; // must be updated, because of increase of speed with higher level

        if (!activated)
        {
            //GameManager.Instance.logText.GetComponent<TextMeshProUGUI>().SetText(axisSpeed.ToString() + lineSpeed.ToString());
            axis.GetComponent<LineRenderer>().startColor = color;
            axis.position = Vector2.MoveTowards(new Vector2(axis.position.x, axis.position.y), new Vector2(-7.5f, axis.position.y), lineSpeed * Time.deltaTime * axisSpeed); // move y-axis to left

            // if player is out of range (game over)
            if (axis.localPosition.x <= 0 && isActive)
            {
                isActive = false;
                GameManager.Instance.PlayerCount -= 1; // Remove one player. If PlayerCount == 0, game ends
            }
        }
    }

    private void SetColors()
    {
        axis.GetComponent<LineRenderer>().startColor = color;
        line.GetComponent<LineRenderer>().startColor = color;

        axis.GetComponent<LineRenderer>().endColor = color;
        line.GetComponent<LineRenderer>().endColor = color;
    }
}
