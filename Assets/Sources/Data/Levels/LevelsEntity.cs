using System.Collections.Generic;

public class LevelsEntity : CMSEntity
{
    public LevelsEntity()
    {
        Define<TagLevels>().Levels = new List<Level>
        {
            D.Prefabs.Levels.Level_Variant,
            D.Prefabs.Levels.Level_Variant_1
        };
    }
}

public class TagLevels : EntityComponentDefinition
{
    public List<Level> Levels;
}
