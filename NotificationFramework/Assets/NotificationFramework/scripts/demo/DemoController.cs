using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class DemoController : MonoBehaviour
{
  public void ShowSuccess()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Success;
    data.title = "SUCCESS";
    data.message = "Profile Saved Successfully";
    data.position = NotificationPosition.TopLeft;
    data.sticky = false;
    data.duration = 2f;
    NotificationManager.Instance.ShowNotification(data);
  }
  public void ShowError()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Error;
    data.title = "ERROR";
    data.message = "Network Error";
    data.position = NotificationPosition.TopCenter;
    data.sticky = false;
    data.duration = 3f;
    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowWarning()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Warning;
    data.title = "WARNING";
    data.message = "Low Battery";
    data.position = NotificationPosition.TopRight;
    data.sticky = false;
    data.duration = 1f;
    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowInformation()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Information;
    data.title = "INFORMATION";
    data.message = "New Update Available";
    data.position = NotificationPosition.BottomLeft;
    data.sticky = true;
    data.duration = 1f;
    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowLoading()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Loading;
    data.title = "LOADING";
    data.message = "Downloading Assets...";
    data.position = NotificationPosition.BottomCenter;
    data.sticky = false;
    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowProgress()
  {
    NotificationData data = new NotificationData();
    data.type = NotificationType.Progress;
    data.title = "PROGRESS";
    data.position = NotificationPosition.BottomRight;
    data.sticky = false;
    NotificationManager.Instance.ShowNotification(data);
    StartCoroutine(ProgressBar());
  }
  public void ClearQueue()
  {
    NotificationManager.Instance.ClearQueue();
  }
  public void CancelNotification()
  {
    NotificationManager.Instance.HideNotification();
  }
  IEnumerator ProgressBar()
  {
    float progress = 0;
    while (progress <= 1)
    {
      NotificationManager.Instance.UpdateProgress(progress);
      progress += 0.1f;
      yield return new WaitForSeconds(1f);
    }
    NotificationManager.Instance.UpdateProgress(1f);
    yield return new WaitForSeconds(1f);
    NotificationManager.Instance.HideNotification();
  }
}
