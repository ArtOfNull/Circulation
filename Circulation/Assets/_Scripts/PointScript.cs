using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct DotState
{
    public string curLeftID;
    public string curRightID;
    public bool isRedMain;

    public DotState (string l, string r, bool isR)
    {
        curLeftID = l;
        curRightID = r;
        isRedMain = isR;
    }
}
public class PointScript : MonoBehaviour
{
    public bool isBlue = false;
    public bool isStop = false;
    public PointScript nextRight;
    public PointScript[] rightNextDots = new PointScript[2];
    public PointScript[] leftNextDots = new PointScript[2];
    public PointScript nextLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public PointScript returnPoint(float signal)
    {
        if (signal == 1)
        {
            if (rightNextDots[0] != null) nextRight.nextLeft = rightNextDots[0];
            if (rightNextDots[1] != null) nextRight.nextRight = rightNextDots[1];
            return nextRight;
        }
        else if (signal == -1)
        {
            if (leftNextDots[0] != null) nextLeft.nextLeft = leftNextDots[0];
            if (leftNextDots[1] != null) nextLeft.nextRight = leftNextDots[1];
            return nextLeft;
        }
        return null;
    }
    public virtual void destroyStop()
    {
        gameObject.SetActive(false);
    }
}
