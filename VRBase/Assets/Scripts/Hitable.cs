using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void IHitableListener(Hitable hitable);
public interface Hitable
{
    public void Remove();
}
