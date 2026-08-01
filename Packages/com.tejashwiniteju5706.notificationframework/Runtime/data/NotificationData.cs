using UnityEngine;
namespace NotificationFramework
{
  public class NotificationData
  {
    public NotificationType type;
    public string title;
    public string message;
    public Sprite Icon;
    public string time;
    public float duration = 2f;
    public bool sticky = false;
    public NotificationPosition position;
    public NotificationPriority priority;
  }
}
