using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData singleton;

    [SerializeField] Slider healthSlider;
    [SerializeField] Slider powerSlider;

    private int maxHealth;
    private int maxPower;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;

            OnMaxHealthChanged(value);
        }
    }

    public int MaxPower
    {
        get
        {
            return maxPower;
        }
        set
        {
            maxPower = value;

            OnMaxPowerChanged(value);
        }
    }

    private System.Random RNG; // Random Number Generator - System class

    private void Awake()
    {
        singleton = this;    
    }

    private void Start()
    {
        RNG = new System.Random();

        int currentHealthPoints = RNG.Next(50, 200);
        int currentPowerPoints = RNG.Next(0, 50);

        MaxHealth = currentHealthPoints;
        MaxPower = currentPowerPoints;

        PlayerController.singleton.HealthPoints = MaxHealth;
        PlayerController.singleton.PowerPoints = MaxPower;
    }

    private void OnMaxHealthChanged(int value)
    {
        healthSlider.maxValue = value;
    }

    private void OnMaxPowerChanged(int value)
    {
        powerSlider.maxValue = value;
    }
}
