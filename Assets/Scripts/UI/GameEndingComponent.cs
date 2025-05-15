using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndingComponent : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel, _losePanel;
    [SerializeField] private TextMeshProUGUI _resultText;

    public void DrawEndingResults()
    {

    }

    private void ShowLoseScreen()
    {
        _losePanel.SetActive(true);
    }

    private void ShowWinScreen()
    {
        _winPanel.SetActive(true);
    }

    private void HideAll()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
    }
}
