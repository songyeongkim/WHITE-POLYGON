using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRandomPosMaker : CComponent
{
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private float xRange;

    [SerializeField]
    private float yRange;

    [SerializeField]
    private float zRange;

    [SerializeField]
    private int makeNum;

    public override void Start()
    {
        PosPlace();
    }

    public void PosPlace()
    {
        float xRandom;
        float yRandom;
        float zRandom;

        for(int i = 0; i<makeNum;i++)
        {
            GameObject copyObj = Instantiate(targetPrefab, transform);
            xRandom = Random.Range(-xRange/2, xRange/2);
            yRandom = Random.Range(-yRange/2, yRange/2);
            zRandom = Random.Range(-zRange/2, zRange/2);

            copyObj.transform.localPosition = new Vector3(xRandom, yRandom, zRandom);
        }
    }
}
