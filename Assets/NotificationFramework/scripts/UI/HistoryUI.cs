
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;

public class HistoryUI : MonoBehaviour
{
  public Image icon;
  public TMP_Text titleText;
  public TMP_Text messageText;
  public TMP_Text timeText;
  public void Setup(NotificationData data)
  {
    icon.sprite = data.Icon;
    titleText.text = data.title;
    messageText.text = data.message;
    timeText.text = data.time;
  }
}
