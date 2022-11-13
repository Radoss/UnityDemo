using UnityEngine;

// Структура опции (кнопки выбора) во время диалога

namespace DialogSystem
{
    [System.Serializable]
    public struct Choice
    {
        public string text; //что отображаем на кнопке выбора

        public string conditionName; // если есть условие показа данной опции, то проверяем наличие его выполнения её отображении

        public ConversationLine nextConversationLine; // если ничего нет, то это конец диалога. Если есть, ответвляем диалог в nextConversationLine.
    }
}
