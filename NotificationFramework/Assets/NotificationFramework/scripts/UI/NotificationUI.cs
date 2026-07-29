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
  public GameObject LoadingIcon;
  public CanvasGroup canvasGroup;


  public void Setup(NotificationData data)
  {
    progressBar.gameObject.SetActive(false);
    icon.gameObject.SetActive(true);
    LoadingIcon.gameObject.SetActive(false);
    titleText.text = data.title;
    messageText.text = data.message;
    if (settings.titlefont != null)
    {
      titleText.font = settings.titlefont;
    }

    if (settings.messagefont != null)
    {
      messageText.font = settings.messagefont;
    }


    switch (data.type)
    {
      case NotificationType.Success:
        icon.sprite = settings.SuccessIcon;
        ApplyColor(settings.successColor);
        break;

      case NotificationType.Error:
        icon.sprite = settings.ErrorIcon;
        ApplyColor(settings.errorColor);
        break;

      case NotificationType.Warning:
        icon.sprite = settings.WarningIcon;
        ApplyColor(settings.warningColor);

        break;

      case NotificationType.Information:
        icon.sprite = settings.InformationIcon;
        ApplyColor(settings.infoColor);
        break;

      case NotificationType.Loading:
        icon.gameObject.SetActive(false);
        ApplyColor(settings.loadingColor);
        LoadingIcon.SetActive(true);
        break;

      case NotificationType.Progress:
        icon.sprite = settings.ProgressIcon;
        ApplyColor(settings.progressColor);
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
  void ApplyColor(Color color)
  {
    titleText.color = color;
  }

}
