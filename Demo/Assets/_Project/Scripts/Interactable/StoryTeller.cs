using UnityEngine;

// Предмет, который озвучивает что-то при взаимодействии

namespace InteractionSystem
{
    public class StoryTeller : MonoBehaviour, Iinteractable
    {
        [SerializeField] AudioClip _storyClip;
        [SerializeField] private float _radius = 5;
        public float radius { get { return _radius; } }

        public void Interact()
        {
            PlayStory();
        }

        private void PlayStory()
        {
            AudioSource audioSource = Player.instance.audioSource;
            audioSource.clip = _storyClip;
            audioSource.Play();
        }
    }
}