using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))] // does need a Line Renderer component to work
public class FollowLine : MonoBehaviour
{
    public float pointSpacing;

    public int maxVertices;

    private float rightOffset;

    List<Vector2> points;

    LineRenderer line;

    Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        points = new List<Vector2>(); // instantiate list

        newPosition = LineDrawer.Instance.transform.position;

        rightOffset = LineDrawer.Instance.rightOffset;

        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = LineDrawer.Instance.transform.position;

        if (Vector2.Distance(points.Last(), newPosition) > pointSpacing)
            SetPoint();
    }

    void SetPoint()
    {
        points.Add(newPosition); // new vector point each frame

        if (points.Count > maxVertices)
        {
            points.Remove(points[0]); // remove points for optimization
            for(int i = 0; i < maxVertices - 1; i++)
            {
                line.SetPosition(i, line.GetPosition(i + 1)); // set all previous vertices to the next so the line will stay the same
            }
        }

        line.positionCount = points.Count; // line position count must be equal to list count
        line.SetPosition(points.Count - 1, newPosition); // set position of new point
    }
}
