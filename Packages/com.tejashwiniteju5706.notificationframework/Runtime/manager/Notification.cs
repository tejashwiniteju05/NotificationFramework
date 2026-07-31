
namespace NotificationFramework
{
  public static class Notification
  {
    public static void ShowSuccess(string message)
    {
      Show("SUCCESS", message, NotificationType.Success, NotificationPosition.TopLeft, false, 2f);
    }

    public static void ShowError(string message)
    {
      Show("ERROR", message, NotificationType.Error, NotificationPosition.TopCenter, false, 3f);
    }

    public static void ShowWarning(string message)
    {
      Show("WARNING", message, NotificationType.Warning, NotificationPosition.TopRight, false, 2f);
    }

    public static void ShowInformation(string message)
    {
      Show("INFORMATION", message, NotificationType.Information, NotificationPosition.BottomLeft, true, 3f);
    }

    public static void ShowLoading(string message)
    {
      Show("LOADING", message, NotificationType.Loading, NotificationPosition.BottomCenter, false, 5f);
    }

    public static void ShowProgress()
    {
      Show("PROGRESS", "", NotificationType.Progress, NotificationPosition.BottomRight, true, 0);
    }

    private static void Show(string title, string message, NotificationType type, NotificationPosition position, bool sticky, float duration)
    {
      NotificationData data = new NotificationData();
      data.title = title;
      data.message = message;
      data.type = type;
      data.position = position;
      data.sticky = sticky;
      data.duration = duration;
      data.time = System.DateTime.Now.ToString("hh:mm tt");

      NotificationManager.Instance.ShowNotification(data);
    }
    public static void HideCurrent()
    {
      NotificationManager.Instance.HideNotification();
    }
    public static void ClearAll()
    {
      NotificationManager.Instance.ClearQueue();
    }
  }
}
