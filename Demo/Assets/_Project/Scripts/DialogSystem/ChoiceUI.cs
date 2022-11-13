using UnityEngine;
using TMPro;

namespace DialogSystem
{
    public class ChoiceUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _optionTextTMP;
        ConversationLine _nextConversationLine;
        DialogManager _dialogManager;

        public void SetOption(Choice choice)
        {
            _dialogManager = DialogManager.instance;
            _optionTextTMP.text = choice.text;
            _nextConversationLine = choice.nextConversationLine;
        }

        public void onChoiceClicked()
        {
            if (_nextConversationLine != null)
            {
                _dialogManager.SetUpConversationLine(_nextConversationLine);
            }
            else
            {
                _dialogManager.EndConversation();
            }
        }
    }
}
