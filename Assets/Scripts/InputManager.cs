using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int selectedCell;

    public void SetCellValue(int cel)
    {
        selectedCell = cel;
        GameManager.Instance().selected = cel;
    }
    
    public void UnsetCellValue()
    {
        selectedCell = -1;
        GameManager.Instance().selected = -1;
    }
}
