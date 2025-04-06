using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeywordClickHandler : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI tmpText;

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmpText, Input.mousePosition, null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = tmpText.textInfo.linkInfo[linkIndex];
            string keyword = linkInfo.GetLinkID();

            if (eventData.button == PointerEventData.InputButton.Left)
                GameManager.Instance.SpeakKeyword(keyword);
            else if (eventData.button == PointerEventData.InputButton.Right)
                GameManager.Instance.ToggleMemory(keyword);
        }
    }
}
