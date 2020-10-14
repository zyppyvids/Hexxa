using UnityEngine;

public class EightRow : MonoBehaviour
{
    public void EnableEnd(Clickable endClickable)
    {
        foreach (Clickable clicky in gameObject.transform.GetComponentsInChildren<Clickable>())
        {
            clicky.isEnabled = false;
        }

        endClickable.isEnabled = true;
    }
}
