using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public enum TileType
{
    Default,

    Start,

    StrongOponent,
    Oponent,
    Shop,
    Fountain,

    End
}

public class TypeController : MonoBehaviour
{
    public static TypeController singleton;

    [SerializeField] GameObject startTile;
    [SerializeField] GameObject endTile;

    [SerializeField] CanvasGroup shopGroup;

    [SerializeField] Slider oponentPower;
    [SerializeField] Text oponentPowerText;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        OnChangeTileType(startTile, TileType.Start);
        OnChangeTileType(endTile, TileType.End);
    }

    public void OnChangeTileType(GameObject typeHolder, TileType newType)
    {
        if (newType == TileType.Default)
        {
            Debug.LogWarning("You are trying to change tile type to Default. Perhaps there is an error somewhere?");
        }

        else if (newType == TileType.Start)
        {
            // r: 255 | g: 255 | b: 255 - White color
            typeHolder.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }

        else if (newType == TileType.StrongOponent)
        {
            // r: 255 | g: 0 | b: 0 - Red color
            typeHolder.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);

            typeHolder.AddComponent<Hoverable>();
            typeHolder.AddComponent<Oponent>();

            typeHolder.GetComponent<Hoverable>().onHoverEvent = new UnityEvent();
            typeHolder.GetComponent<Hoverable>().onExitEvent = new UnityEvent();

            typeHolder.GetComponent<Clickable>().onClickEvent.AddListener(() =>
            {
                PlayerController.singleton.PowerPoints -= Mathf.RoundToInt(typeHolder.GetComponent<Oponent>().PowerPoints * 0.1f);
                PlayerController.singleton.HealthPoints -= typeHolder.GetComponent<Oponent>().PowerPoints;
            });

            typeHolder.GetComponent<Hoverable>().onHoverEvent.AddListener(() =>
            {
                oponentPower.gameObject.SetActive(true);

                oponentPower.value = typeHolder.GetComponent<Oponent>().PowerPoints;
                oponentPowerText.text = typeHolder.GetComponent<Oponent>().PowerPoints.ToString();
            });
            typeHolder.GetComponent<Hoverable>().onExitEvent.AddListener(() =>
            {
                oponentPower.value = 0;
                oponentPowerText.text = 0.ToString();

                oponentPower.gameObject.SetActive(false);
            });
        }
        else if (newType == TileType.Oponent)
        {
            // r: 255 | g: 0 | b: 255 - Purple color
            typeHolder.GetComponent<Renderer>().material.color = new Color(1, 0, 1, 1);

            typeHolder.AddComponent<Hoverable>();
            typeHolder.AddComponent<Oponent>();

            typeHolder.GetComponent<Hoverable>().onHoverEvent = new UnityEvent();
            typeHolder.GetComponent<Hoverable>().onExitEvent = new UnityEvent();

            typeHolder.GetComponent<Clickable>().onClickEvent.AddListener(() =>
            {
                PlayerController.singleton.PowerPoints -= Mathf.RoundToInt(typeHolder.GetComponent<Oponent>().PowerPoints * 0.1f);
                PlayerController.singleton.HealthPoints -= typeHolder.GetComponent<Oponent>().PowerPoints;
            });

            typeHolder.GetComponent<Hoverable>().onHoverEvent.AddListener(() =>
            {
                oponentPower.gameObject.SetActive(true);

                oponentPower.value = typeHolder.GetComponent<Oponent>().PowerPoints;
                oponentPowerText.text = typeHolder.GetComponent<Oponent>().PowerPoints.ToString();
            });
            typeHolder.GetComponent<Hoverable>().onExitEvent.AddListener(() =>
            {
                oponentPower.value = 0;
                oponentPowerText.text = 0.ToString();

                oponentPower.gameObject.SetActive(false);
            });
        }
        else if (newType == TileType.Shop)
        {
            // r: 0 | g: 0 | b: 255 - Blue color
            typeHolder.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);

            typeHolder.GetComponent<Clickable>().onClickEvent.AddListener(() =>
            {
                shopGroup.interactable = true;
                shopGroup.blocksRaycasts = true;

                LeanTween.alphaCanvas(shopGroup, 1f, 2f);
            });
        }
        else if (newType == TileType.Fountain)
        {
            // r: 255 | g: 255 | b: 0 - Yellow color
            typeHolder.GetComponent<Renderer>().material.color = new Color(1, 1, 0, 1);

            typeHolder.GetComponent<Clickable>().onClickEvent.AddListener(() =>
            {
                int modifiedHP = Mathf.RoundToInt(PlayerController.singleton.HealthPoints * 1.3f);
                int modifiedPower = Mathf.RoundToInt(PlayerController.singleton.PowerPoints * 1.3f);

                PlayerController.singleton.HealthPoints = PlayerData.singleton.MaxHealth < modifiedHP ? PlayerData.singleton.MaxHealth : modifiedHP;
                PlayerController.singleton.PowerPoints = PlayerData.singleton.MaxPower < modifiedPower ? PlayerData.singleton.MaxPower : modifiedPower;
            });
        }

        else if (newType == TileType.End)
        {
            // r: 255 | g: 125.5 | b: 0 - Orange color
            typeHolder.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0, 1);
        }
    }
}
