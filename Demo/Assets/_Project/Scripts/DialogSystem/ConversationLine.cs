using UnityEngine;

// Текст реплики с последующим выбором

namespace DialogSystem
{
    [CreateAssetMenu(fileName = "New Dialog Line", menuName = "Dialog/New Line")]
    public class ConversationLine : ScriptableObject
    {

        [TextArea(2, 5)]
        public string text;

        public string animationTrigger; //если есть анимация, триггерим её
        public Choice[] choices;
    }
}