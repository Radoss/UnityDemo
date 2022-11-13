using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogSystem;

// Предмет/НПС, который начинает диалог при взаимодействии

namespace InteractionSystem
{
    public class DialogStarter : Interactable
    {
        [SerializeField] private ConversationLine firstConversationLine;

        DialogManager _dialogManager;
        Animator animator;

        private void Start()
        {
            _dialogManager = DialogManager.instance;
            animator = GetComponent<Animator>();
        }

        public override void Interact()
        {
            StartCoroutine("rotateTowardsMe");
        }

        private void StartDialog(ConversationLine line)
        {
            if (animator != null)
            {
                _dialogManager.animator = animator;
            }
            _dialogManager.SetUpConversationLine(line);
        }


        IEnumerator rotateTowardsMe()
        {
            bool isTargetreached = false;
            while (!isTargetreached)
            {
                // Determine which direction to rotate towards
                Vector3 targetDirection = Player.instance.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float singleStep = 2.0f * Time.deltaTime;

                Vector3 forwardNoY = new Vector3(transform.forward.x, 0, transform.forward.z);
                Vector3 targetDirectionNoY = new Vector3(targetDirection.x, 0, targetDirection.z);

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(forwardNoY, targetDirectionNoY, singleStep, 0.0f);

                // Calculate a rotation a step closer to the target and applies rotation to this object
                transform.rotation = Quaternion.LookRotation(newDirection);

                isTargetreached = forwardNoY == newDirection;

                yield return null;
            }
            StartDialog(firstConversationLine);
        }

    }
}
