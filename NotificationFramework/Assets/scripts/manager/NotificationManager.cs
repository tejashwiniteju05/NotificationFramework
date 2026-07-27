using UnityEngine;


public class NotificationManager : MonoBehaviour
{
  public static NotificationManager Instance;
  public NotificationUI notificationUI;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }
  public void ShowNotification(NotificationData data)
  {
    notificationUI.gameObject.SetActive(true);

    notificationUI.Setup(data);
  }

}
