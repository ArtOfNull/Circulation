using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPointScript : PointScript
{
    [SerializeField] GameObject firstMap;
    [SerializeField] GameObject secondMap;
    [SerializeField] GameObject firstLever;
    [SerializeField] GameObject secondLever;
    bool changer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMap()
    {
        firstMap.SetActive(changer);
        firstLever.SetActive(changer);
        secondMap.SetActive(!changer);
        secondLever.SetActive(!changer);
        changer = !changer;
    }
}
