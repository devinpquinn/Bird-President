using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Game/Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(3, 10)]
    public string questionText;

    public List<KeywordData> keywords; // Highlighted words with effects

    [System.Serializable]
    public class KeywordData
    {
        public string word;
        public string advisorResponse;
        public bool endsRound;
        public ApprovalEffect approvalEffect;
    }
    
    public enum ApprovalEffectType
    {
        UniversallyNegative, MostlyNegative, Mixed, MostlyPositive, UniversallyPositive
    }

    [System.Serializable]
    public class ApprovalEffect
    {
        public ApprovalEffectType type;
        public int minChange;
        public int maxChange;
    }
}
