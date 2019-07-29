using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public static LineDrawer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float startDelay;

    public float changeCurveSpeed;

    public float curveSize;
    public float curveSizeIncreaseMultiplyer;

    public float rightOffset;

    private Vector2 newPos;

    public Transform cam;

    private float speed;

    private void Start()
    {
        newPos = transform.position;
        InvokeRepeating("SetPos", startDelay, 0.25f); // Change new position dot for constant movement

        speed = GameManager.Instance.LineSpeed;
    }

    private void Update()
    {
        MoveDot();
        //HorizontalMovement();
    }

    void SetPos()
    {
        newPos = new Vector2(cam.position.x + rightOffset, Random.Range(-curveSize, curveSize));
    }

    void MoveDot()
    {
        transform.position = Vector2.Lerp(transform.position, newPos, changeCurveSpeed * Time.deltaTime);
    }
}
