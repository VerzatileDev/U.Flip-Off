using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameOverUIController gameOverUIController;
    [SerializeField] private UnlockContainer container;
    [SerializeField] private GameObject upgradeButton;
    [SerializeField] private GameObject uiContainer;
    [SerializeField] private List<UpgradeButton> buttons = new List<UpgradeButton>();
    [SerializeField] private CumScoreData data;
    [SerializeField] private TextMeshProUGUI totalCoins;
    private void Start()
    {
        GenerateButtons();
    }

    private void GenerateButtons()
    {
        foreach (var x in container.unlocks)
        {
            UpgradeButton but = Instantiate(upgradeButton, uiContainer.transform).GetComponent<UpgradeButton>();
            buttons.Add(but);
            but.Set(this,x);
        }
    }

    private void Update()
    {
        totalCoins.text = "Total Coins = " + (data.hellCoins + data.heavenCoins);
    }

    

    public void OnBackButton()
    {
        AudioController.instance.PlayButtonClick();

        StartCoroutine( MainMenuController.ShowCanvas(gameOverUIController.gameOverScreen, 1f));
        StartCoroutine(MainMenuController.ShowCanvas(gameOverUIController.upgradeScreen, 0f));

    }

    public void OnForwardButton()
    {
        AudioController.instance.PlayButtonClick();

        SceneManager.LoadSceneAsync(0);
    }



    public void Purchase(Unlock unlock)
    {
        AudioController.instance.PlayButtonClick();

        if (unlock.isUnlocked == false)
        {

            switch (unlock.heavenOrHell)
            {
                case Unlock.HeavenOrHell.Heaven:
                    if (unlock.cost <= data.heavenCoins)
                    {
                        unlock.isUnlocked = true;
                        data.heavenCoins -= unlock.cost;

                    }

                    data.heavenCoins -= unlock.cost;
                    break;
                case Unlock.HeavenOrHell.Hell:
                    if (unlock.cost <= data.hellCoins)
                    {
                        unlock.isUnlocked = true;
                        data.heavenCoins -= unlock.cost;
                    }

                    break;
                case Unlock.HeavenOrHell.Both:

                    if (unlock.cost <= (data.hellCoins + data.heavenCoins))
                    {
                        unlock.isUnlocked = true;
                        data.hellCoins -= unlock.cost;
                        if (data.hellCoins < 0)
                        {
                            data.heavenCoins -= Mathf.Abs(data.hellCoins);
                            data.hellCoins = 0;
                        }
                    }

                    break;
            }
        }
    }
}
