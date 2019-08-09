using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchPointers : MonoBehaviour
{
    [SerializeField] private GameObject pointer;

    private List<int> activeTouches = new List<int>();

    // Update is called once per frame
    void Update()
    {
        //var log = "";

        //for (var index = 0; index < activeTouches.Count; index++)
        //{
        //    log += activeTouches[index].ToString();
        //}
        //GameManager.Instance.logText.GetComponent<TextMeshProUGUI>().SetText(log + " " + Input.touchCount);

        SetPointers();
        RemovePointers();
        PositionPointers();
        //transform.GetChild(0).position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));  
    }

    void SetPointers()
    {
        GameObject thisPointer;

        // if there are more touches than pointers
        if (transform.childCount < Input.touchCount && Input.touchCount <= GameManager.Instance.PlayerCount)
        {
            thisPointer = Instantiate(pointer);
            thisPointer.transform.parent = transform;

            activeTouches.Add(Input.touchCount - 1);
        }
    }

    void RemovePointers()
    {
        var i = 0;
        foreach(Touch touch in Input.touches)
        {

            // remove a pointer's value and lower all the above with 1 to prevent number 'jumps' (so from 1 to 3 instead of 2, like a normal count)
            if (touch.phase == TouchPhase.Ended)
            {
                //GameManager.Instance.logText.GetComponent<TextMeshProUGUI>().SetText("Remove  object " + i);
                Destroy(transform.GetChild(i).gameObject);
                activeTouches.Remove(i);

                if (i < activeTouches.Count)
                {
                    for (var lowerVal = i; lowerVal < activeTouches.Count; lowerVal++)
                    {
                        activeTouches[lowerVal] -= 1;
                    }
                }
            }

            i++;
        }
    }

    void PositionPointers()
    {
        // position each pointer to finger position, based on index
        for(var i = 0; i < activeTouches.Count; i++)
        {
            transform.GetChild(i).position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, 10));
        }
    }

}
