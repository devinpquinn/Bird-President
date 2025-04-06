using UnityEngine;
using TMPro;

public class ApprovalRating : MonoBehaviour
{
    public int currentRating = 50;
    public TMP_Text ratingText;

    public void Modify(int amount)
    {
        currentRating = Mathf.Clamp(currentRating + amount, 0, 100);
        ratingText.text = "Approval: " + currentRating + "%";

        if (currentRating <= 0)
            GameManager.Instance.GameOver(false);
        else if (currentRating >= 100)
            GameManager.Instance.GameOver(true);
    }
}
