using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoRotate : CComponent
{
    [SerializeField]
    private Vector3 rotateDir;

    [SerializeField]
    private float rotateSpeed;


    public override void Update()
    {
        gameObject.transform.Rotate(rotateDir * rotateSpeed * Time.deltaTime);
    }
}
