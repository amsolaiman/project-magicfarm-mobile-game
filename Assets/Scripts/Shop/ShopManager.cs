using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager current;
    public static Dictionary<CurrencyType, Sprite> currencySprites = new Dictionary<CurrencyType, Sprite>();

    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private GameObject button;
    private RectTransform rt;
    private RectTransform prt;
    private bool opened;

    [SerializeField] private GameObject itemPrefab;
    private Dictionary<ObjectType, List<ShopItem>> shopItems = new Dictionary<ObjectType, List<ShopItem>>(2);

     void Awake()
    {
        current = this;
        rt = GetComponent<RectTransform>();
        prt = transform.parent.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currencySprites.Add(CurrencyType.Coins, sprites[0]);
        currencySprites.Add(CurrencyType.Bucks, sprites[1]);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopButtonClicked()
    {
        float time = 0.2f;
        if (!opened)
        {
            LeanTween.moveX(prt, prt.anchoredPosition.x + rt.sizeDelta.x, time);
            opened = true;
            gameObject.SetActive(true);
            button.SetActive(false);
        }
        else
        {
            LeanTween.moveX(prt, prt.anchoredPosition.x - rt.sizeDelta.x, time)
                .setOnComplete(delegate ()
                {
                    gameObject.SetActive(false);
                    button.SetActive(true);
                });
            opened = false;
        }
    }

    private bool dragging;

    public void OnBeginDrag()
    {
        dragging = true;
    }

    public void OnEndDrad()
    {
        dragging = false;
    }

    public void OnPointerClick()
    {
        if (!dragging)
        {
            ShopButtonClicked();
        }
    }
}
