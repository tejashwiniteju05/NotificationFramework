using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
  public static NotificationManager Instance;
  public GameObject notificationPanel;
  public NotificationUI notificationUI;

  public Transform topLeft;
  public Transform topCenter;
  public Transform topRight;
  public Transform bottomLeft;
  public Transform bottomCenter;
  public Transform bottomRight;

  private Coroutine hideCoroutine;
  private Queue<NotificationData> notificationQueue = new Queue<NotificationData>();
  private int maxQueueSize = 5;
  private bool isShowing = false;
  private void Awake()
  {
    Instance = this;
  }
  private void Start()
  {
    notificationPanel.SetActive(false);
  }
  public void ShowNotification(NotificationData data)
  {
    if (notificationQueue.Count >= maxQueueSize)
    {
      Debug.Log("Queue is Full");
      return;
    }
    notificationQueue.Enqueue(data);
    if (isShowing)
    {
      return;
    }
    ShowNextNotification();
  }
  void ShowNextNotification()
  {
    if (notificationQueue.Count == 0)
    {
      isShowing = false;
      notificationPanel.SetActive(false);
      return;
    }

    isShowing = true;
    NotificationData data = notificationQueue.Dequeue();
    SetNotificationPosition(data.position);
    notificationPanel.SetActive(true);
    notificationUI.Setup(data);
    if (data.type == NotificationType.Loading || data.type == NotificationType.Progress)
    {
      return;
    }
    if (data.sticky)
    {
      return;
    }
    hideCoroutine = StartCoroutine(AutoHide(data.duration));
  }

  IEnumerator AutoHide(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    HideNotification();
  }
  public void HideNotification()
  {
    notificationPanel.SetActive(false);
    isShowing = false;
    ShowNextNotification();
  }
  public void ClearQueue()
  {
    notificationQueue.Clear();
    Debug.Log("Notification Queue Cleared");
  }
  public void UpdateProgress(float value)
  {
    notificationUI.UpdateProgress(value);
  }
  void SetNotificationPosition(NotificationPosition position)
  {
    switch (position)
    {
      case NotificationPosition.TopLeft:
        notificationPanel.transform.SetParent(topLeft, false);
        break;

      case NotificationPosition.TopCenter:
        notificationPanel.transform.SetParent(topCenter, false);
        break;

      case NotificationPosition.TopRight:
        notificationPanel.transform.SetParent(topRight, false);
        break;

      case NotificationPosition.BottomLeft:
        notificationPanel.transform.SetParent(bottomLeft, false);
        break;

      case NotificationPosition.BottomCenter:
        notificationPanel.transform.SetParent(bottomCenter, false);
        break;

      case NotificationPosition.BottomRight:
        notificationPanel.transform.SetParent(bottomRight, false);
        break;
    }
  }
}
