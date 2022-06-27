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
    GameObject RedPart;
    [SerializeField]
    GameObject BluePart;
    // Start is called before the first frame update
    void Start()
    {
        //BluePart.SetActive(false);
        //RedPart.SetActive(true);
        DC = GetComponent<DotsControlScript>();
    }

    // Update is called once per frame
    void Update()
    {

        movesLeftTxT.text = "Moves left: " + DC.moves.ToString();
        /*if(DC.finished)
        {
            BluePart.SetActive(true);
            RedPart.SetActive(true);
        }*/
        
    }

    public void setPartsActive()
    {
        /*if (DC.state)
        {
            BluePart.SetActive(true);
            RedPart.SetActive(false);
        }
        else
        {
            BluePart.SetActive(false);
            RedPart.SetActive(true);
        }*/
    }
}
