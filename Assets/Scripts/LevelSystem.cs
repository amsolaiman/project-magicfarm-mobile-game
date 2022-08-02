using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject levelPanelPrefab;
    private int level;
    private int XPCurrent;
    private int XPNext;

    private Slider slider;
    private TextMeshProUGUI XPText;
    private TextMeshProUGUI levelText;
    private Image starImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
