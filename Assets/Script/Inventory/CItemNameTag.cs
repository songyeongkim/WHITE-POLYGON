using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CItemNameTag : CComponent
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    private Vector2 mousePos;
    private CUIManager uIManager;

    public override void Start()
    {
        uIManager = CUIManager.Instance;
        uIManager.itemNameTag = gameObject;
        uIManager.itemNameTagText = nameText;

        gameObject.SetActive(false);
    }

    public override void Update()
    {
        mousePos = Input.mousePosition;
        gameObject.transform.position = mousePos;
    }
}
