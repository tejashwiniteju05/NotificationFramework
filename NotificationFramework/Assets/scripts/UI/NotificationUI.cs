using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{

  public Image icon;

  public TMP_Text titleText;
  public TMP_Text messageText;
  public Slider progressBar;

  public Button closeButton;
  public Sprite successIcon;
  public Sprite errorIcon;
  public Sprite warningIcon;
  public Sprite informationIcon;
  public Sprite loadingIcon;
  public Sprite progressIcon;

  public void Setup(NotificationData data)
  {
    progressBar.gameObject.SetActive(false);
    icon.gameObject.SetActive(true);
    titleText.text = data.title;
    messageText.text = data.message;


    switch (data.type)
    {
      case NotificationType.Success:
        icon.sprite = successIcon;
        break;

      case NotificationType.Error:
        icon.sprite = errorIcon;
        break;

      case NotificationType.Warning:
        icon.sprite = warningIcon;

        break;

      case NotificationType.Information:
        icon.sprite = informationIcon;
        break;

      case NotificationType.Loading:
        icon.sprite = loadingIcon;
        break;

      case NotificationType.Progress:
        icon.sprite = progressIcon;
        progressBar.gameObject.SetActive(true);
        progressBar.value = 0;
        break;
    }
  }
}
