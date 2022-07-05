using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPointScript : PointScript
{
    [SerializeField]
    PointScript afterStopRightPoint;
    [SerializeField]
    PointScript afterStopLeftPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void destroyStop()
    {      
        base.destroyStop();
    }

    public void changePoints(PointScript curP)
    {
        if (afterStopRightPoint != null) curP.nextRight = afterStopRightPoint;
        if (afterStopLeftPoint != null) curP.nextLeft = afterStopLeftPoint;
    }
}
