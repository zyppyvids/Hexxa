using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Hoverable : MonoBehaviour
{
    [SerializeField] int tileRow;

    public bool isEnabled = true;

    public UnityEvent onHoverEvent;
    public UnityEvent onExitEvent;

    private void OnMouseOver()
    {
        if (isEnabled && !EventSystem.current.IsPointerOverGameObject())
        {
            onHoverEvent.Invoke();
        }
    }

    private void OnMouseExit()
    {
        if (isEnabled && !EventSystem.current.IsPointerOverGameObject())
        {
            onExitEvent.Invoke();
        }
    }
}
