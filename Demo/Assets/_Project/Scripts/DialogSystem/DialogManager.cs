using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogSystem {
    public class DialogManager : MonoBehaviour
    {
        #region Singleton
        public static DialogManager instance { get; private set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            Destroy(gameObject);
        }

        #endregion

        [SerializeField] TextMeshProUGUI dialogueTextTMP;
        [SerializeField] Transform choicesParentTR;
        [SerializeField] GameObject choiceButtonPrefab;
        [SerializeField] GameObject dialogGO;
        [HideInInspector] public Animator animator;

        public void SetUpConversationLine(ConversationLine cLine)
        {
            Cursor.lockState = CursorLockMode.None;
            ClearConversation();
            SetDialogUI(cLine);
            if (cLine.animationTrigger != string.Empty && animator != null)
            {
                animator.SetTrigger(cLine.animationTrigger);
            }
        }

        public void EndConversation()
        {
            ClearConversation();
            dialogGO.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void SetDialogUI(ConversationLine cLine)
        {
            dialogGO.SetActive(true);
            dialogueTextTMP.text = cLine.text;
            if (cLine.choices.Length > 0)
            {
                SetChoices(cLine.choices);
            }
        }

        private void SetChoices(Choice[] choices)
        {
            foreach (Choice choice in choices)
            {
                if (choice.conditionName != string.Empty)
                {
                    QuestManager questManager = QuestManager.instance;
                    if (questManager.goalReachedMap.ContainsKey(choice.conditionName) && questManager.goalReachedMap[choice.conditionName])
                    {
                        InstantiateChoice(choice);
                    }
                }
                else
                {
                    InstantiateChoice(choice);
                }
            }
        }

        private void InstantiateChoice(Choice choice)
        {
            GameObject choiceGO = Instantiate(choiceButtonPrefab, choicesParentTR);
            ChoiceUI choiceUI = choiceGO.GetComponent<ChoiceUI>();
            choiceUI.SetOption(choice);
        }

        private void ClearConversation() 
        {
            ClearChoices();
            ClearDialogText();
        }

        private void ClearChoices()
        {
            foreach (Transform choiceTR in choicesParentTR)
            {
                Destroy(choiceTR.gameObject);
            }
        }

        private void ClearDialogText()
        {
            dialogueTextTMP.text = "";
        }
    } 
}
