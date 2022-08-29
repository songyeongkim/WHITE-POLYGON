using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraChange : CComponent
{
    [SerializeField]
    private Camera changedCamera;

    [SerializeField]
    private CCameraMove cameraMove;

    public override void Start()
    {
        cameraMove.endTransformEvent += TurnOnCamera;
    }

    private void OnMouseDown()
    {
        TurnOnCamera();
    }

    public void TurnOnCamera()
    {
        if (Camera.main.depth > changedCamera.depth)
        {
            changedCamera.depth = Camera.main.depth + 1;
        }

        changedCamera.gameObject.SetActive(true);
    }

    public void TurnOffCamera()
    {
        changedCamera.gameObject.SetActive(false);
    }
}
