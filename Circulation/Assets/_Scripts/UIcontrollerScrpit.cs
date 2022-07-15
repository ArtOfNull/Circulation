using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrollerScrpit : MonoBehaviour
{
    DotsControlScript DC;
    [SerializeField]
    Text movesLeftTxT;

    [SerializeField]
    Image invalidMoveImg;
    [SerializeField]
    Text invalidMoveTxt;
    [SerializeField]
    float invMoveStayDur = 2f;
    [SerializeField]
    float fadingSpeed = 0.5f;
    Color invMoveImgCol;
    Color invMoveTxtCol;
    int InvMoveState;
    float invMoveStayTemp;
    public GameObject TutorPal;

    [SerializeField]
    GameObject LevelFinishPanel;

    public GameObject RedText;
    public GameObject BlueText;
    // Start is called before the first frame update
    void Start()
    {

        DC = GetComponent<DotsControlScript>();
        invMoveImgCol = invalidMoveImg.color; 
        invMoveTxtCol = invalidMoveTxt.color;
    }

    // Update is called once per frame
    void Update()
    {

        movesLeftTxT.text = "Moves left: " + DC.moves.ToString();
        invalidMoveImgFading();


    }

    public void invalidMoveUIset()
    {
        invalidMoveImg.gameObject.SetActive(true);
        invMoveImgCol.a = 0.9f;
        invalidMoveImg.color = invMoveImgCol;
        invMoveTxtCol.a = 1f;
        invalidMoveTxt.color = invMoveTxtCol;
        InvMoveState = 1;

    }

    void invalidMoveImgFading()
    {
        switch(InvMoveState)
        {
            case 0:
                {

                }break;

            case 1:
                {
                    invMoveStayTemp = invMoveStayDur;
                    InvMoveState = 2;
                }break;

            case 2:
                {
                    if(invMoveStayTemp>0)
                    {
                        invMoveStayTemp -= Time.deltaTime;
                    }
                    else
                    {
                        InvMoveState = 3;
                    }
                }break;

            case 3:
                {
                    if(invMoveTxtCol.a>0)
                    {
                        invMoveTxtCol.a -= fadingSpeed * Time.deltaTime;
                        invalidMoveTxt.color = invMoveTxtCol;
                        invMoveImgCol.a -= fadingSpeed * Time.deltaTime;
                        invalidMoveImg.color = invMoveImgCol;
                    }
                    else
                    {
                        invalidMoveImg.gameObject.SetActive(false);
                        InvMoveState = 0;
                    }
                }break;
        }

    }   
    
    public void FinishLevel()
    {
        LevelFinishPanel.SetActive(true);
    }

    public void offTutor()
    {
        if (TutorPal != null) TutorPal.SetActive(false);
    }
}
