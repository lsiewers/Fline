using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject activeAxis;
    private LineRenderer activeLine;

    public int pointerId;

    // Update is called once per frame
    void Update()
    {
        if (activeAxis != null && activeLine != null)
        {
            if (activeAxis.GetComponentInParent<Player>().id == activeLine.GetComponentInParent<Player>().id)
            {
                activeAxis.GetComponentInParent<Player>().activated = true;
                activeLine.endColor = GameManager.Instance.ColorGreen;

                if (activeAxis.transform.position.x < transform.position.x)
                {
                    activeAxis.transform.position = new Vector3(transform.position.x, 0, 10);
                }
            }
        }
    }

    void Deactivate(Player player) 
    {
        if(player.activated)
        {
            player.activated = false;
            player.GetComponentInChildren<FollowLine>().GetComponent<LineRenderer>().endColor = player.color;
            player.transform.Find("Axis").GetComponent<LineRenderer>().startColor = player.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Axis")
        {
            activeAxis = collision.gameObject;
        }
        if (collision.gameObject.name == "Line")
        {
            activeLine = collision.gameObject.GetComponent<LineRenderer>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Axis")
        {
            activeAxis = null;
            Deactivate(collision.transform.parent.GetComponent<Player>());
        }
        if (collision.gameObject.name == "Line")
        {
            activeLine = null;
            Deactivate(collision.transform.parent.GetComponent<Player>());
        }
    }
}
