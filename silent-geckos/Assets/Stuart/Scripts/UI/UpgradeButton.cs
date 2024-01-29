using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private Unlock unlock;
    [SerializeField] private TextMeshProUGUI buttonName;
    [SerializeField] private TextMeshProUGUI cost;
    private UnityEngine.UI.Image image;
    private UpgradeScreen screen;
    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void Set(UpgradeScreen _screen, Unlock _unlock)
    {
        screen = _screen;
        unlock = _unlock;
        if (unlock == null) return;
        buttonName.text= unlock.unlockName.ToString();
        cost.text= unlock.cost.ToString();

    }

    private void Update()
    {
        if (unlock == null) return;
        image.color = unlock.isUnlocked ? Color.green : Color.white;
        
    }

    public void OnPress()
    {
        screen.Purchase(unlock);
    }
}
