using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CRotateButton : CComponent
{
    [SerializeField]
    private int targetRotationState;
    [SerializeField]
    private COctahedron octahedron;

    [Header("showNhideArrows")]
    [SerializeField]
    private GameObject[] showArrows;
    [SerializeField]
    private GameObject[] hideArrows;

    private CPlaySoundEvent soundEvent;

    public override void Start()
    {
        soundEvent = CPlaySoundEvent.Instance;
    }

    public void OnMouseOver()
    {
        if (CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyPointerCursorImg();
        }
    }

    public void OnMouseExit()
    {
        if (CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyNormalCursor();
        }
    }

    private void OnMouseDown()
    {
        if (CUIManager.Instance.uiCanInteract && !EventSystem.current.IsPointerOverGameObject())
        {
            soundEvent.PlayRotateSoundEffect();
            RotateStateSetting();
        }
    }

    public void RotateStateSetting()
    {
        octahedron.RotateCamera(targetRotationState);

        for (int i = 0; i < showArrows.Length; i++)
        {
            showArrows[i].SetActive(true);
        }

        for (int i = 0; i < hideArrows.Length; i++)
        {
            hideArrows[i].SetActive(false);
        }
    }
}
