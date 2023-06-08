using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 << layer) & layerMask) != 0;
    }

    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeInHierarchy;
    }

    public static bool IsValid(this Component component)
    {
        return component != null && component.gameObject.activeInHierarchy;
    }
}
