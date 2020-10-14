using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void FadeInBG(CanvasGroup background)
    {
        LeanTween.alphaCanvas(background, 1f, 2f);

        background.blocksRaycasts = true;
    }
}
