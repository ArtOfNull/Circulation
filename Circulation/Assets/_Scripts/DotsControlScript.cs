using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsControlScript : MonoBehaviour
{
    [SerializeField]
    GameObject RedDot;
    [SerializeField]
    GameObject BlueDot;
    public bool state = false;

    [SerializeField]
    public float rotationSpeed = 5f;

    
    public Transform curDot;
    float move;

    [SerializeField]
    float cameraChanger = 1f;
    int camChModifier = 1;
    [SerializeField]
    float cameraSpeed = 0.1f;
    bool isCamMove = false;

    public void swapDotControl()
    {
        if(state)
        {
            BlueDot.transform.SetParent(null);
            RedDot.transform.SetParent(BlueDot.transform);
            curDot = BlueDot.transform;
            state = !state;
            cameraChanger = 0f;
            camChModifier = 1;
        }
        else
        {
            RedDot.transform.SetParent(null);
            BlueDot.transform.SetParent(RedDot.transform);
            curDot = RedDot.transform;
            state = !state;
            cameraChanger = 1f;
            camChModifier = -1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        curDot = BlueDot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            swapDotControl();
        }
        move = Input.GetAxisRaw("Horizontal");
        print(move);
        curDot.transform.Rotate(Vector3.back * move * rotationSpeed * Time.deltaTime);
        cameraChanger += cameraSpeed * camChModifier * Time.deltaTime;
        Vector2 newCamPos = Vector2.Lerp(RedDot.transform.position, BlueDot.transform.position, cameraChanger);
        Camera.main.transform.position = new Vector3(newCamPos.x, newCamPos.y, Camera.main.transform.position.z);
    }
}
