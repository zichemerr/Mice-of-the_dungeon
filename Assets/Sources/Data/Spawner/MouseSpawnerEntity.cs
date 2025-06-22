using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MouseSpawnerEntity : CMSEntity
{
    public MouseSpawnerEntity()
    {
        Define<TagSpawnerCount>().Count = 10;
    }
}

public class TagSpawnerCount : EntityComponentDefinition
{
    public float Count;
}
