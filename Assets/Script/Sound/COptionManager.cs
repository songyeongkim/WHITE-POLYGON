using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COptionManager : CComponent
{
    private bool optionShow = false;

    [SerializeField]
    private GameObject optionUI;

    public override void Start()
    {
        
    }

    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            if (!optionShow)
            {
                Time.timeScale = 0;
                optionUI.SetActive(true);
                optionShow = true;
            }
            else
            {
                Time.timeScale = 1;
                optionUI.SetActive(false);
                optionShow = false;
            }
        }
        
    }

}
