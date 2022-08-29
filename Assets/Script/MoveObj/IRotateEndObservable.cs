using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotateEndObservable
{
    public void SubscribeEvent(IRotateObserver observer);

    public void UnSubscribeEvent(IRotateObserver observer);

    public void Notify();
}
