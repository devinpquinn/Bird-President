using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake() => Instance = this;

    public List<QuestionSO> allQuestions;
    private List<QuestionSO> unusedQuestions = new();
    private QuestionSO currentQuestion;

    [Header("References")]
    public KeywordUI keywordUI;
    public MemorySystem memorySystem;
    public ApprovalRating approval;

    void Start()
    {
        unusedQuestions = new List<QuestionSO>(allQuestions);
        NextRound();
    }

    public void NextRound()
    {
        if (unusedQuestions.Count == 0)
        {
            Debug.Log("No more questions!");
            return;
        }

        currentQuestion = unusedQuestions[Random.Range(0, unusedQuestions.Count)];
        unusedQuestions.Remove(currentQuestion);

        keywordUI.DisplayQuestion(currentQuestion); // Parses and highlights keywords
    }

    public void SpeakKeyword(string keyword)
    {
        var keywordData = currentQuestion.keywords.Find(k => k.word == keyword);
        if (keywordData == null) return;

        ShowAdvisorResponse(keywordData.advisorResponse);

        if (keywordData.endsRound)
        {
            int change = Random.Range(keywordData.approvalEffect.minChange, keywordData.approvalEffect.maxChange + 1);
            approval.Modify(change);
            Invoke(nameof(NextRound), 2f);
        }
    }

    public void ToggleMemory(string keyword)
    {
        memorySystem.ToggleMemory(keyword);
        // Possibly refresh UI here
    }

    public void ShowAdvisorResponse(string text)
    {
        Debug.Log("Advisor: " + text);
        // Hook up to your dialog UI here
    }

    public void GameOver(bool goodEnding)
    {
        Debug.Log("Game Over: " + (goodEnding ? "You were loved." : "You were impeached."));
        // Load end scene or display message
    }
}
