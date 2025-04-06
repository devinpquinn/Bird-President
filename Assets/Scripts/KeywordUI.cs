using UnityEngine;
using TMPro;

public class KeywordUI : MonoBehaviour
{
    public TextMeshProUGUI questionText;

    // Highlights keywords using TMP <link> tags
    public void DisplayQuestion(QuestionSO question)
    {
        string processedText = question.questionText;

        foreach (var keyword in question.keywords)
        {
            // Wrap keyword in TMP link tag
            processedText = processedText.Replace(keyword.word,
                $"<link={keyword.word}><color=#FFD700><u>{keyword.word}</u></color></link>");
        }

        questionText.text = processedText;
    }
}
