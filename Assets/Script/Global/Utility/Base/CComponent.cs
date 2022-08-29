using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CComponent : MonoBehaviour
{
    #region
    [HideInInspector] public Transform m_oTransform = null;
    [HideInInspector] public Rigidbody m_oRigidbody = null;
    [HideInInspector] public Rigidbody2D m_oRigidbody2D = null;
    #endregion

    public virtual void Awake()
    {
        m_oTransform = this.transform;
        m_oRigidbody = this.GetComponent<Rigidbody>();
        m_oRigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        
    }

    public virtual void LateUpdate()
    {

    }

    public void StartCorutine(string name)
    {
        StartCoroutine(name);
    }
}
