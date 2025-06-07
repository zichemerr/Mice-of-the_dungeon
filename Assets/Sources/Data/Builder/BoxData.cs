using UnityEngine;

public class BoxData : CMSEntity
{
    public BoxData()
    {
        Define<TagPrefab>().Prefab = D.Prefabs.Box.gameObject;
    }
}

public class TagPrefab : EntityComponentDefinition
{
    public GameObject Prefab;
}
