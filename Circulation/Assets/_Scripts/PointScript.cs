using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PointScript : MonoBehaviour
{
    public bool isBlue = false;
    public bool isStop = false;
    public bool isSwitch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void destroyStop()
    {
        gameObject.SetActive(false);
    }
}
