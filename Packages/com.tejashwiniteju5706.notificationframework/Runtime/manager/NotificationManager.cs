using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NotificationFramework
{
  public class NotificationManager : MonoBehaviour
  {
    public static NotificationManager Instance;
    public GameObject notificationpanel;
    public NotificationUI notificationUI;
    public NotificationSettings settings;

    public Transform topLeft;
    public Transform topCenter;
    public Transform topRight;
    public Transform bottomLeft;
    public Transform bottomCenter;
    public Transform bottomRight;
    public GameObject historyItemPrefab;
    public Transform content;
    private List<NotificationData> notificationHistory = new List<NotificationData>();
    private List<NotificationData> notificationQueue = new List<NotificationData>();
    private bool isShowing = false;
    private int maxQueueSize = 5;
    private void Awake()
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
      notificationpanel = Instantiate(notificationpanel);
      notificationUI = notificationpanel.GetComponent<NotificationUI>();
    }
    public void ShowNotification(NotificationData data)
    {
      if (notificationQueue.Count >= maxQueueSize)
      {
        Debug.Log("Queue is Full");
        return;
      }
      notificationQueue.Add(data);
      if (settings.queueMode == Queuemode.Priority)
      {
        notificationQueue.Sort((a, b) => b.priority.CompareTo(a.priority));
      }
      if (!isShowing)
      {
        ShowNextNotification();
      }
    }
    public void AddHistory(NotificationData data)
    {
      GameObject item = Instantiate(historyItemPrefab, content);
      HistoryUI historyUI = item.GetComponent<HistoryUI>();
      historyUI.Setup(data);
    }
    void ShowNextNotification()
    {
      if (notificationQueue.Count == 0)
      {
        isShowing = false;
        return;
      }
      isShowing = true;
      NotificationData data = notificationQueue[0];
      notificationQueue.RemoveAt(0);
      SetNotificationPosition(data.position);
      notificationpanel.SetActive(true);
      notificationUI.Setup(data);
      if (data.type != NotificationType.Loading && data.type != NotificationType.Progress)
      {
        NotificationManager.Instance.AddHistory(data);
      }
      notificationUI.notificationAnimation.PlayShowAnimation();

      if (data.sticky)
      {
        return;
      }
      StartCoroutine(AutoHide(data.duration));
    }
    public List<NotificationData> GetHistory()
    {
      return notificationHistory;
    }
    IEnumerator AutoHide(float seconds)
    {
      yield return new WaitForSeconds(seconds);
      HideNotification();
    }
    public void HideNotification()
    {
      notificationUI.notificationAnimation.PlayHideAnimation();
      StartCoroutine(HideAfterAnimation());
    }
    IEnumerator HideAfterAnimation()
    {
      yield return new WaitForSeconds(0.5f);
      notificationpanel.SetActive(false);
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
          notificationpanel.transform.SetParent(topLeft, false);
          // notificationPanel = Instantiate(notificationPanel, topLeft);
          break;

        case NotificationPosition.TopCenter:
          notificationpanel.transform.SetParent(topCenter, false);
          break;

        case NotificationPosition.TopRight:
          notificationpanel.transform.SetParent(topRight, false);
          break;

        case NotificationPosition.BottomLeft:
          notificationpanel.transform.SetParent(bottomLeft, false);
          break;

        case NotificationPosition.BottomCenter:
          notificationpanel.transform.SetParent(bottomCenter, false);
          break;

        case NotificationPosition.BottomRight:
          notificationpanel.transform.SetParent(bottomRight, false);
          break;
      }
    }
  }
}

