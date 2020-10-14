using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider powerSlider;

    [SerializeField] Text healthText;
    [SerializeField] Text powerText;

    private int healthPoints;
    private int powerPoints;

    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            if (value <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                healthPoints = value;

                OnHealthPointsChanged(value);
            }
        }
    }

    public int PowerPoints
    {
        get
        {
            return powerPoints;
        }
        set
        {
            if (value <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                powerPoints = value;

                OnPowerPointsChanged(value);
            }
        }
    }

    private void Start()
    {
        singleton = this;
    }

    private void OnHealthPointsChanged(int value)
    {
        healthSlider.value = value;
        healthText.text = value.ToString();
    }

    private void OnPowerPointsChanged(int value)
    {
        powerSlider.value = value;
        powerText.text = value.ToString();
    }
}
