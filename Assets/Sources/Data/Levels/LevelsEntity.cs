using System.Collections.Generic;

public class LevelsEntity : CMSEntity
{
    public LevelsEntity()
    {
        Define<TagLevels>().Levels = new List<LevelObject>
        {
            D.Prefabs.Levels.Level_Variant,
            D.Prefabs.Levels.Level_Variant_1,
            D.Prefabs.Levels.Level_Variant_2
        };
    }
}

public class TagLevels : EntityComponentDefinition
{
    public List<LevelObject> Levels;
}
