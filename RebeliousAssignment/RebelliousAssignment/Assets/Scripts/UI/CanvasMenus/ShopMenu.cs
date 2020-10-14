using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public void OnHPUPButtonPressed()
    {
        PlayerData.singleton.MaxHealth = Mathf.RoundToInt(1.2f * PlayerData.singleton.MaxHealth);
    }

    public void OnHPRESTOREButtonPressed()
    {
        PlayerController.singleton.HealthPoints = PlayerData.singleton.MaxHealth * 1; // Multiplication by 1 is used only to differentiate the two values and not assign them to the same IntPointer
    }

    public void OnPOWERUPButtonPressed()
    {
        PlayerData.singleton.MaxPower = Mathf.RoundToInt(1.2f * PlayerData.singleton.MaxPower);
    }

    public void FadeOutBG(CanvasGroup background)
    {
        background.interactable = false;
        background.blocksRaycasts = false;

        LeanTween.alphaCanvas(background, 0f, 2f);
    }
}
