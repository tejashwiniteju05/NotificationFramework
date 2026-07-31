using UnityEngine;

public class HistoryManager : MonoBehaviour
{
  public static HistoryManager Instance;
  public GameObject historyPanel;
  public GameObject historyItemPrefab;
  public Transform content;
  public void Awake()
  {
    Instance = this;
  }
  void Start()
  {
    historyPanel.SetActive(false);
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

  public void AddHistory(NotificationData data)
  {
    GameObject item = Instantiate(historyItemPrefab, content);
    HistoryUI historyUI = item.GetComponent<HistoryUI>();
    historyUI.Setup(data);
  }
}
