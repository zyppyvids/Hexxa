using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour
{
    [SerializeField] int tileRow;

    public bool isEnabled = true;

    public UnityEvent onClickEvent;

    private void OnMouseUp()
    {
        if (isEnabled && !EventSystem.current.IsPointerOverGameObject())
        {
            onClickEvent.Invoke();

            foreach (Clickable clickableElement in FindObjectsOfType<Clickable>()
                .Where(x => x.tileRow < GameManager.singleton.CurrentRow + 2 && x.isEnabled == true))
            {
                clickableElement.isEnabled = false;
            }
        }
    }
}
