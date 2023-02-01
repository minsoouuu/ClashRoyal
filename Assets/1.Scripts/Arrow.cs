using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ArrowData
{
    public float damage;
    public float attackDel;
}

public abstract class Arrow : MonoBehaviour
{
    public ArrowData arrowData = new ArrowData();
    
    private void Update()
    {
        FireArrow();
    }

    public abstract void Initalize();

    public virtual void FireArrow()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
