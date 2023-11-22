using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicManagerUiio : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown _dropdown;

    private void Awake()
    {
        int currentQualityIndex = QualitySettings.GetQualityLevel();

        _dropdown.value = currentQualityIndex;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
