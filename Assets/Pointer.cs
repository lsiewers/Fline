using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private GameObject axis;
    [SerializeField] private GameObject line;

    private bool verticalActive;
    private bool horizontalActive;

    // Update is called once per frame
    void Update()
    {
        // convert mouse position to world position 
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(FingerCount()).rawPosition.x, Input.GetTouch(FingerCount()).rawPosition.y, 10));  

        if(verticalActive && horizontalActive)
        {
            axis.GetComponent<Axis>().activated = true;
            GetComponent<SpriteRenderer>().color = GameManager.Instance.ColorGreen;
            line.GetComponent<LineRenderer>().endColor = GameManager.Instance.ColorGreen;
        }
        else
        {
            axis.GetComponent<Axis>().activated = false;
            line.GetComponent<LineRenderer>().endColor = GetComponentInParent<Player>().color;
        }
    }

    private int FingerCount()
    {
        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        return fingerCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        verticalActive |= collision.gameObject == axis;
        horizontalActive |= collision.gameObject == line;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        verticalActive &= collision.gameObject != axis;
        horizontalActive &= collision.gameObject != line;
    }
}
