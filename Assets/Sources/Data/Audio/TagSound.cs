using UnityEngine;

public class ClickSound : CMSEntity
{
    public ClickSound()
    {
        Define<TagSound>().clip = D.Audio.Click;
    }
}

public class WriteSound : CMSEntity
{
    public WriteSound()
    {
        Define<TagSound>().clip = D.Audio.Write;
    }
}

public class TagSound : EntityComponentDefinition
{
    public AudioClip clip;
}
