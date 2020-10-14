using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void FadeOutBG(CanvasGroup background)
    {
        LeanTween.alphaCanvas(background, 0f, 2f);

        background.interactable = false;
        background.blocksRaycasts = false;
    }

    public void QuitApplication()
    {
        Application.Quit(0);
    }
}
