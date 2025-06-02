using UnityEngine;

public class AudioSystem
{
    private AudioSource _audioSource; 
    
    public AudioSystem()
    {
        AudioSorceContainer audioSorceContainer = GameObject.Instantiate(D.Prefabs.AudioContainer);
        _audioSource = audioSorceContainer.AudioSource;
    }
    
    public void Play<T>() where T : CMSEntity
    {
        Play(CMS.Get<T>(E.Id<T>()));
    }

    public void Play(CMSEntity entity)
    {
        if (entity.Is(out TagSound sound))
            _audioSource.PlayOneShot(sound.clip);
        else
        {
            Debug.LogError("CMSEntity not have an TagSound");
        }
    }
}