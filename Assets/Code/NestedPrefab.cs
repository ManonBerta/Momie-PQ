using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestedPrefab : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    protected GameObject prefabTarget;

    [ContextMenu("Apply nested Prefab")]
    public virtual void ApplyNestedPrefab()
    {
        UnityEditor.PrefabUtility.ReplacePrefab(this.gameObject, this.prefabTarget, UnityEditor.ReplacePrefabOptions.ReplaceNameBased);

        Component nestedPrefabComponent = this.prefabTarget.GetComponentInChildren<NestedPrefab>();
        GameObject.DestroyImmediate(nestedPrefabComponent, true);
    }
#endif
}
