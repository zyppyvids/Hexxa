using UnityEngine;

public class RowController : MonoBehaviour
{
    public static RowController singleton;

    [SerializeField] float movementSpeed;
    [SerializeField] GameObject[] rows;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        MoveRow(0);
    }

    public void MoveRow(int rowIndex)
    {
        LeanTween.moveX(rows[rowIndex], 0, movementSpeed);

        GameManager.singleton.CurrentRow = rowIndex;
    }

    public int GetRowCount()
    {
        return rows.Length;
    }
}
