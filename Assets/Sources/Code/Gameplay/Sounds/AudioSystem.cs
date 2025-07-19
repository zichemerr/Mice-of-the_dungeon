using UnityEngine;

namespace Sources.Code.Gameplay.Sounds
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourcePrefab;
        
        private AudioSource _audioSource;
        
        public SoundsConfig Sounds { get; private set; }

        public void Init(SoundsConfig sounds)
        {
            Sounds = sounds;
            
            _audioSource = Instantiate(_audioSourcePrefab);
        }
        
        public void PlaySound(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
