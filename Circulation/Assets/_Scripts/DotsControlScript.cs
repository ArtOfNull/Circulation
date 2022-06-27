using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsControlScript : MonoBehaviour
{
    UIcontrollerScrpit UIC;
    [SerializeField]
    GameObject RedDot;
    [SerializeField]
    GameObject BlueDot;
    public bool state = false;

    [SerializeField]
    public float rotationSpeed = 5f;

    
    public Transform mainDot;
    public Transform subDot;
    float signal;

    [SerializeField]
    float cameraChanger = 1f;
    int camChModifier = 1;
    [SerializeField]
    float cameraSpeed = 0.1f;
    bool isCamMove = false;
    Vector3 offset = new Vector3(0f, -1.5f, 0f);
    [SerializeField]
    List<int> RedWays = new List<int>();
    [SerializeField]
    List<Transform> RedPoints = new List<Transform>();
    [SerializeField]
    List<int> BlueWays = new List<int>();
    [SerializeField]
    List<Transform> BluePoints = new List<Transform>();
    List<int> curWays;
    List<Transform> curPoints;
    int counter = 0;
    bool moving = false;
    float savedSig = 0f;
    [SerializeField]
    Transform lastPoint;
    public bool finished = false;

    public int moves;

    public void swapDotControl()
    {
        if(state)
        {
            BlueDot.transform.SetParent(null);
            RedDot.transform.SetParent(BlueDot.transform);
            mainDot = BlueDot.transform;
            subDot = RedDot.transform;
            curWays = RedWays;
            curPoints = RedPoints;
            state = !state;
            cameraChanger = 0f;
            camChModifier = 1;
            UIC.setPartsActive();
        }
        else
        {
            RedDot.transform.SetParent(null);
            BlueDot.transform.SetParent(RedDot.transform);
            mainDot = RedDot.transform;
            subDot = BlueDot.transform;
            curWays = BlueWays;
            curPoints = BluePoints;
            state = !state;
            cameraChanger = 1f;
            camChModifier = -1;
            UIC.setPartsActive();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        mainDot = BlueDot.transform;
        subDot = RedDot.transform;
        curWays = RedWays;
        curPoints = RedPoints;
        UIC = GetComponent<UIcontrollerScrpit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            //swapDotControl();
        }
        signal = Input.GetAxisRaw("Horizontal");
        if ((signal == curWays[counter] || curWays[counter] == 2) && !moving && !finished && moves>0)
        {
            savedSig = signal;
            moving = true;
            moves--;

        }
        if (moving)
        {
            mainDot.transform.Rotate(Vector3.back * savedSig * rotationSpeed * Time.deltaTime);
            if (Vector2.Distance(subDot.position, curPoints[counter].position)<=0.5f)
            {
                moving = false;
                subDot.position = curPoints[counter].position;
                if(curPoints[counter] != lastPoint)
                {
                    if (mainDot == RedDot.transform) counter++;                    
                    swapDotControl();
                }
                else
                {
                    print("Bababooey");
                    finished = true;
                }
               
            }

        }

        print(signal);
        // mainDot.transform.Rotate(Vector3.back * signal * rotationSpeed * Time.deltaTime);
        cameraChanger += cameraSpeed * camChModifier * Time.deltaTime;
        Vector2 newCamPos = Vector2.Lerp(RedDot.transform.position, BlueDot.transform.position, cameraChanger);
        Camera.main.transform.position = new Vector3(newCamPos.x, newCamPos.y, Camera.main.transform.position.z) + offset;
    }
}
