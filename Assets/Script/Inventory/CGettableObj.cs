using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CGettableObj : CComponent
{
    public string itemName;
    public CItem itemPrefab;

    public bool gettableItem;

    public delegate void AddItemOption();
    public AddItemOption additionalItemMethod;

    [SerializeField]
    protected CInventory inventory;

    protected CPlaySoundEvent soundEvent;

    public override void Start()
    {
        base.Start();
        inventory = CInventory.Instance;
    }

    public void OnMouseEnter()
    {
        if (gettableItem && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyPointerCursorImg();
        }
    }

    public void OnMouseExit()
    {
        if (gettableItem && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyNormalCursor();
        }
    }

    public virtual void AddItemEvent()
    {
        if (gettableItem)
        {
            inventory = CInventory.Instance;
            soundEvent = CPlaySoundEvent.Instance;
            inventory.inventoryCells[inventory.m_nEmptyCellNum].AddItem(this);

            soundEvent.PlayItemGetSoundEffect();
            CUIManager.Instance.ApplyNormalCursor();

            inventory.m_nEmptyCellNum++;

            if(additionalItemMethod != null)
                additionalItemMethod();
        }
    }
}
