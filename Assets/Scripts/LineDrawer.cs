using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public List<Vector2> points;
    [SerializeField] private float pointSpacing;

    private LineRenderer line;

    private void Start()
    {
        points = new List<Vector2>();

        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Vector3.Distance(points.Last(), transform.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        points.Add(transform.position);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, transform.position);
    }
}
