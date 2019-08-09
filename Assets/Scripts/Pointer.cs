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
        OnActive();
    }

    private void OnActive()
    {
        // if both axis and line collision with pointer
        if (activeAxis != null && activeLine != null)
        {
            // and if both of the same player, then this player is active and line can be dragged to the right
            if (activeAxis.GetComponentInParent<Player>().id == activeLine.GetComponentInParent<Player>().id)
            {
                activeAxis.GetComponentInParent<Player>().activated = true;

                // set positive feedback color
                activeLine.endColor = new Color(0, 255, 155);
                activeAxis.GetComponent<LineRenderer>().startColor = new Color(0, 255, 155);

                // if axis left position is higher than pointer left, then move axis following the pointer
                if (activeAxis.transform.position.x < transform.position.x)
                {
                    AudioManager.Instance.Play("Rise");
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
            if (AudioManager.Instance.IsPlaying("Rise")) { AudioManager.Instance.Stop("Rise"); }
        }
        if (collision.gameObject.name == "Line")
        {
            activeLine = null;
            Deactivate(collision.transform.parent.GetComponent<Player>());
            if (AudioManager.Instance.IsPlaying("Rise")) { AudioManager.Instance.Stop("Rise"); }
        }
    }
}
