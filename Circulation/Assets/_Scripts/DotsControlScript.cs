using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DotsControlScript : MonoBehaviour
{
    [SerializeField]
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
    public Vector3 offset = new Vector3(0f, -1.5f, 0f);
    [SerializeField]
    public GameObject curPoint;
    public int counter = 0;
    bool moving = false;
    float savedSig = 0f;
    [SerializeField]
    PointScript lastPoint;
    public bool finished = false;
    public DotScript curDotS;
    public int moves;
    [SerializeField]
    float tempRot;
    [SerializeField]
    string blueTag;
    [SerializeField]
    string redTag;
    [SerializeField]
    string curTag;
    int checker = 0;

    AudioSource source;

    [SerializeField] string ThisLevelName;
    [SerializeField] string NextLevelName;

    [SerializeField] GameObject Menu;

    public void swapDotControl()
    {
        if (state)
        {
            BlueDot.transform.SetParent(null);
            RedDot.transform.SetParent(BlueDot.transform);
            mainDot = BlueDot.transform;
            subDot = RedDot.transform;
            curTag = redTag;
            curDotS = subDot.GetComponent<DotScript>();
            Collider2D overCall = Physics2D.OverlapPoint(curDotS.edgePoints[0] + subDot.position, 1 << 6);
            if (overCall != null) curPoint = overCall.gameObject;
            state = !state;
            cameraChanger = 0f;
            camChModifier = 1;
        }
        else
        {
            RedDot.transform.SetParent(null);
            BlueDot.transform.SetParent(RedDot.transform);
            mainDot = RedDot.transform;
            subDot = BlueDot.transform;
            curTag = blueTag;
            curDotS = subDot.GetComponent<DotScript>();
            Collider2D overCall = Physics2D.OverlapPoint(curDotS.edgePoints[0] + subDot.position, 1 << 6);
            if (overCall != null) curPoint = overCall.gameObject;
            state = !state;
            cameraChanger = 1f;
            camChModifier = -1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        mainDot = BlueDot.transform;
        subDot = RedDot.transform;
        curTag = redTag;
        curDotS = subDot.GetComponent<DotScript>();
        Collider2D overCall = Physics2D.OverlapPoint(curDotS.edgePoints[0] + subDot.position, 1 << 6);
        if(overCall!=null) curPoint = overCall.gameObject;
        UIC = GetComponent<UIcontrollerScrpit>();
        source = GetComponent<AudioSource>();  
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
        if (Menu.activeSelf) return;
        signal = Input.GetAxisRaw("Horizontal");
        if (signal != 0 && !moving && !finished && moves > 0)
        {
            savedSig = signal;
            moving = true;
            tempRot = mainDot.transform.rotation.eulerAngles.z;
        }
        if (moving)
        {
            mainDot.transform.Rotate(Vector3.back * savedSig * rotationSpeed * Time.deltaTime);
            Collider2D overCall = Physics2D.OverlapPoint(curDotS.edgePoints[0]+subDot.position, 1 << 6);
            if (!curDotS.isOnLevel)
            {
                checker++;
                
            }
            else
            {
                checker = 0;
            }
            if(checker == 3)
            {
                mainDot.gameObject.transform.eulerAngles = new Vector3(mainDot.transform.rotation.eulerAngles.x, mainDot.transform.rotation.eulerAngles.y, tempRot);
                moving = false;
                UIC.invalidMoveUIset();
                checker = 0;
            }
            if (overCall!=null && overCall.gameObject.tag == curTag && overCall.gameObject != curPoint)
            {
                PointScript temp = overCall.gameObject.GetComponent<PointScript>();
                moving = false;
                moves--;
                subDot.position = temp.gameObject.transform.position;
                if (temp.isStop)
                {
                    StopPointScript SP = temp.GetComponent<StopPointScript>();
                    SP.destroyStop();
                }
                if (temp != lastPoint)
                {
                    if (mainDot == RedDot.transform) counter++;
                    swapDotControl();
                }
                else
                {
                    print("Bababooey");
                    source.Play();
                    UIC.FinishLevel();
                    finished = true;
                }
                AudioSource Clicksource = subDot.GetComponent<AudioSource>();
                Clicksource.Play();

            }

        }

        // mainDot.transform.Rotate(Vector3.back * signal * rotationSpeed * Time.deltaTime);
        //cameraChanger += cameraSpeed * camChModifier * Time.deltaTime;
        //Vector2 newCamPos = Vector2.Lerp(RedDot.transform.position, BlueDot.transform.position, cameraChanger);
        //Camera.main.transform.position = new Vector3(newCamPos.x, newCamPos.y, Camera.main.transform.position.z) + offset;
    }

    public void Retry()
    {
        SceneManager.LoadScene(ThisLevelName);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(NextLevelName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void PauseMenu()
    {
        Menu.SetActive(!Menu.activeSelf);
    }

    
}
