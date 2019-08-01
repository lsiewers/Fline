using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color color;
    public GameObject axis;
    public GameObject line;

    private void Start()
    {
        axis.GetComponent<LineRenderer>().startColor = color;
        line.GetComponent<LineRenderer>().startColor = color;

        axis.GetComponent<LineRenderer>().endColor = color;
        line.GetComponent<LineRenderer>().endColor = color;
    }
}
