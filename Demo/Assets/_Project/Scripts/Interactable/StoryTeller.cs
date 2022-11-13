using UnityEngine;

// Предмет, который озвучивает что-то при взаимодействии

namespace InteractionSystem
{
    public class StoryTeller : Interactable
    {
        [SerializeField] AudioClip _storyClip;

        public override void Interact()
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