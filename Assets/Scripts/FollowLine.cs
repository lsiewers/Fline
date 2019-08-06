using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class FollowLine : MonoBehaviour
{
    private float[] lineVertices;

    private float speed;
    private float curveSize;

    private void Start()
    {
        speed = GameManager.Instance.LineSpeed;
        curveSize = GameManager.Instance.CurveSize;

        InvokeRepeating("UpdateLine", 0, speed * 10f);
        System.Array.Resize(ref lineVertices, transform.childCount);
    }

    private void FixedUpdate()
    {
        speed = GameManager.Instance.LineSpeed;

        for (var i = 0; i < lineVertices.Length; i++)
        {   
            transform.GetChild(i).position = Vector2.MoveTowards(transform.GetChild(i).position, new Vector2(transform.GetChild(i).position.x, lineVertices[i]), speed * Time.deltaTime);
        }
    }

    private void UpdateLine()
    {
        for (var i = 0; i < (transform.childCount - 1); i++)
        {
            lineVertices[transform.childCount - i - 1] = lineVertices[transform.childCount - i - 2];
        }

        lineVertices[0] = Random.Range(-curveSize, curveSize);
    }
}
