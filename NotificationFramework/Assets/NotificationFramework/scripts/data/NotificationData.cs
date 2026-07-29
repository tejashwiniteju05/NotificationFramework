using UnityEngine;
public class NotificationData
{
  public NotificationType type;
  public string title;
  public string message;
  public float duration = 2f;
  public bool sticky = false;
  public NotificationPosition position;
}
