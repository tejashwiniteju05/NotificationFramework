using UnityEngine;

public class DemoController : MonoBehaviour
{
  public void ShowSuccess()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Success;
    data.title = "SUCCESS";
    data.message = "Profile Saved Successfully";

    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowError()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Error;
    data.title = "ERROR";
    data.message = "Network Error";

    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowWarning()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Warning;
    data.title = "WARNING";
    data.message = "Low Battery";

    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowInformation()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Information;
    data.title = "INFORMATION";
    data.message = "New Update Available";

    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowLoading()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Loading;
    data.title = "LOADING";
    data.message = "Downloading Assets...";

    NotificationManager.Instance.ShowNotification(data);
  }

  public void ShowProgress()
  {
    NotificationData data = new NotificationData();

    data.type = NotificationType.Progress;
    data.title = "PROGRESS";
    NotificationManager.Instance.ShowNotification(data);
  }
}
