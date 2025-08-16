using UnityEngine;

namespace Sources.Code.Gameplay.Sounds
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourcePrefab;
        [SerializeField] private float _globalVolume;
        
        private AudioSource _audioSource;
        
        public SoundsConfig Sounds { get; private set; }
        public static float GlobalVolume { get; private set; }

        public void Init(SoundsConfig sounds)
        {
            Sounds = sounds;
            GlobalVolume = _globalVolume;
            
            _audioSource = Instantiate(_audioSourcePrefab);
        }
        
        public void PlaySound(Sound sound)
        {
            _audioSource.PlayOneShot(sound.AudioClip, sound.Volume);
        }
    }
}
