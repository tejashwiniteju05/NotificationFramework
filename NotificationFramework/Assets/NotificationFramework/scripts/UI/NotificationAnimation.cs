using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationAnimation : MonoBehaviour
{

  public CanvasGroup canvasGroup;
  public GameObject NotificationPanel;
  public NotificationSettings settings;
  RectTransform panelRect;
  Vector2 panelPosition;
  void Start()
  {
    panelRect = NotificationPanel.GetComponent<RectTransform>();
    panelPosition = panelRect.anchoredPosition;
  }
  //fade animation...
  IEnumerator FadeIn()
  {
    canvasGroup.alpha = 0;
    while (canvasGroup.alpha < 1)
    {
      canvasGroup.alpha += 0.05f;
      yield return new WaitForSeconds(0.02f);
    }
    canvasGroup.alpha = 1;
  }
  IEnumerator FadeOut()
  {
    canvasGroup.alpha = 1;
    while (canvasGroup.alpha > 0)
    {
      canvasGroup.alpha -= 0.05f;
      yield return new WaitForSeconds(0.02f);
    }

    canvasGroup.alpha = 0;
  }
  //slide animation...
  IEnumerator SlideIn()
  {
    panelRect.anchoredPosition = new Vector2(panelPosition.x, panelPosition.y + 200);
    while (panelRect.anchoredPosition.y > panelPosition.y)
    {
      panelRect.anchoredPosition -= new Vector2(0, 10);
      yield return new WaitForSeconds(0.01f);
    }
    panelRect.anchoredPosition = panelPosition;
  }
  IEnumerator SlideOut()
  {
    while (panelRect.anchoredPosition.y < panelPosition.y + 200)
    {
      panelRect.anchoredPosition += new Vector2(0, 10);
      yield return new WaitForSeconds(0.01f);
    }
  }
  //scale animation...
  IEnumerator ScaleIn()
  {
    NotificationPanel.transform.localScale = Vector3.zero;
    while (NotificationPanel.transform.localScale.x < 1)
    {
      NotificationPanel.transform.localScale += new Vector3(0.05f, 0.05f, 0);
      yield return new WaitForSeconds(0.02f);
    }
    NotificationPanel.transform.localScale = Vector3.one;
  }
  IEnumerator ScaleOut()
  {
    while (NotificationPanel.transform.localScale.x > 0)
    {
      NotificationPanel.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
      yield return new WaitForSeconds(0.02f);
    }
    NotificationPanel.transform.localScale = Vector3.zero;
  }
  public void PlayShowAnimation()
  {

    switch (settings.animationStyle)
    {
      case AnimationStyle.Fade:
        StartCoroutine(FadeIn());
        break;

      case AnimationStyle.Slide:
        StartCoroutine(SlideIn());
        break;

      case AnimationStyle.Scale:
        StartCoroutine(ScaleIn());
        break;
    }
  }
  public void PlayHideAnimation()
  {
    switch (settings.animationStyle)
    {
      case AnimationStyle.Fade:
        StartCoroutine(FadeOut());
        break;

      case AnimationStyle.Slide:
        StartCoroutine(SlideOut());
        break;

      case AnimationStyle.Scale:
        StartCoroutine(ScaleOut());
        break;
    }
  }
}
