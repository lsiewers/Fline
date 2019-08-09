using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(LineRenderer))] // this script must be assigned to an object with these components
public class FollowLine : MonoBehaviour
{
    private float[] lineVertices;

    private float speed;
    private float curveSize;

    private void Start()
    {
        speed = GameManager.Instance.LineSpeed;
        curveSize = GameManager.Instance.CurveSize;

        InvokeRepeating("UpdateLine", 0, speed * 10f); // move line up/down based on speed
        System.Array.Resize(ref lineVertices, transform.childCount); // dynamically chance array size on given child objects (in case I want more or less vertices)
    }

    private void FixedUpdate()
    {
        speed = GameManager.Instance.LineSpeed;

        for (var i = 0; i < lineVertices.Length; i++)
        {   
            // move each vertice object to its new position from the UpdateLine function.
            transform.GetChild(i).position = Vector2.MoveTowards(transform.GetChild(i).position, new Vector2(transform.GetChild(i).position.x, lineVertices[i]), speed * Time.deltaTime);
        }
    }

    private void UpdateLine()
    {
        // for each child (- 1, because index starts with 0 instead of 1)
        for (var i = 0; i < (transform.childCount - 1); i++)
        {
            // vertice of i (reverse counting), gets position of previous vertice. The line will look like it goes from right to left
            lineVertices[transform.childCount - i - 1] = lineVertices[transform.childCount - i - 2];
        }

        // first vertice gets a random y position
        lineVertices[0] = Random.Range(-curveSize, curveSize);
    }
}
