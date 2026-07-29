using UnityEngine;
using TMPro;

public enum AnimationStyle
{
  Fade,
  Slide,
  Scale
}
[CreateAssetMenu(fileName = "NotificationSettings", menuName = "Notification Framework/Settings")]
public class NotificationSettings : ScriptableObject
{
  //Notification colours...
  public Color successColor = Color.green;
  public Color errorColor = Color.red;
  public Color warningColor = Color.yellow;
  public Color infoColor = Color.blue;
  //Icons..
  public Sprite SuccessIcon;
  public Sprite ErrorIcon;
  public Sprite WarningIcon;
  public Sprite InformationIcon;
  public GameObject LoadingSpinnerprefab;
  public Sprite ProgresIcon;


  [Header("UI Settings")]

  public TMP_FontAsset font;
  public float defaultDuration = 3f;


  [Header("Animation")]
  public AnimationStyle animationStyle;
}
