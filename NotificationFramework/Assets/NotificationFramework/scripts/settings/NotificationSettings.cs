using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

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
  public Color loadingColor = Color.cyan;
  public Color progressColor = Color.magenta;
  //Icons..
  public Sprite SuccessIcon;
  public Sprite ErrorIcon;
  public Sprite WarningIcon;
  public Sprite InformationIcon;
  public Sprite ProgressIcon;


  [Header("UI Settings")]

  public TMP_FontAsset titlefont;
  public TMP_FontAsset messagefont;
  public float defaultDuration = 3f;


  [Header("Animation")]
  public AnimationStyle animationStyle;
}
