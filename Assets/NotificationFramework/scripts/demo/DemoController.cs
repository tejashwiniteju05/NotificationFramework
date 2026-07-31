using System.Collections;
using UnityEngine;
using NotificationFramework;

public class DemoController : MonoBehaviour
{
  public GameObject historyPanel;
  public Transform content;
  void Start()
  {
    historyPanel.SetActive(false);
  }
  public void ShowSuccess()
  {
    Notification.ShowSuccess("Profile Saved Succesfully");
  }

  public void ShowError()
  {
    Notification.ShowError("Network Error");
  }

  public void ShowWarning()
  {
    Notification.ShowWarning("Low Battery");
  }

  public void ShowInformation()
  {
    Notification.ShowInformation("New Update Available");
  }

  public void ShowLoading()
  {
    Notification.ShowLoading("Downloading Assets...");
  }

  public void ShowProgress()
  {
    Notification.ShowProgress();
    StartCoroutine(ProgressBar());
  }

  public void ClearQueue()
  {
    Notification.ClearAll();
  }

  public void CancelNotification()
  {
    Notification.HideCurrent();
  }
  public void OpenHistory()
  {
    historyPanel.SetActive(true);
  }

  public void CloseHistory()
  {
    historyPanel.SetActive(false);
  }

  public void ClearHistory()
  {
    foreach (Transform child in content)
    {
      Destroy(child.gameObject);
    }
  }

  IEnumerator ProgressBar()
  {
    float progress = 0;
    while (progress <= 1)
    {
      NotificationManager.Instance.UpdateProgress(progress);
      progress += 0.1f;
      yield return new WaitForSeconds(1);
    }
    Notification.HideCurrent();
  }
}

