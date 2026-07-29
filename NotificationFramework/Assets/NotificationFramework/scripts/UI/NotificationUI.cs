using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{

  public Image icon;
  public GameObject NotificationPanel;
  public NotificationSettings settings;

  public TMP_Text titleText;
  public TMP_Text messageText;
  public Slider progressBar;

  public Button closeButton;
  public Sprite successIcon;
  public Sprite errorIcon;
  public Sprite warningIcon;
  public Sprite informationIcon;
  public GameObject loadingIcon;
  public Sprite progressIcon;

  public void Setup(NotificationData data)
  {
    progressBar.gameObject.SetActive(false);
    icon.gameObject.SetActive(true);
    loadingIcon.gameObject.SetActive(false);
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
        icon.gameObject.SetActive(false);
        loadingIcon.SetActive(true);
        break;

      case NotificationType.Progress:
        icon.sprite = progressIcon;
        progressBar.gameObject.SetActive(true);
        progressBar.value = 0;
        break;
    }
  }
  public void CloseNotification()
  {
    NotificationManager.Instance.HideNotification();
  }
  public void UpdateProgress(float value)
  {
    progressBar.value = value;
  }

}
