using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementListingComponent : MonoBehaviour
{
    AchievementManager manager;

    [SerializeField]
    GameObject AchievementPanelPrefab;

    List<GameObject> AchievementPanels; // Liste des panneaux des succès

    GameObject ListPanel; // Panel parent des AchievementPanels

    Sprite starUnlocked, starLocked;

    private void ShowAchievements() {
        foreach (Achievement acv in manager.achievements) {
            GameObject panel = Instantiate(AchievementPanelPrefab);

            Text title = panel.transform.Find("Title").GetComponent<Text>();
            Text description = panel.transform.Find("Description").GetComponent<Text>();
            Image image = panel.transform.Find("Image").GetComponent<Image>();

            title.text = acv.Name;
            description.text = acv.Description;
            image.sprite = acv.Unlocked ? starUnlocked : starLocked;

            AchievementPanels.Add(panel);
            panel.transform.SetParent(ListPanel.transform, false);
            panel.SetActive(true);
        }

    }

    public void TogglePanel()
    {
        if (gameObject.activeInHierarchy)
            CloseAchievementsPanel();
        else
            ShowAchievementPanel();
    }

    public void ShowAchievementPanel()
    {
        gameObject.SetActive(true);
        ShowAchievements();
    }

    private void CloseAchievementsPanel() {
        gameObject.SetActive(false);

        foreach(GameObject g in AchievementPanels)
        {
            Destroy(g);
        }

        AchievementPanels.Clear();
    }

    // Start is called before the first frame update
    void Awake()
    {
        manager = FindObjectOfType<AchievementManager>();
        Debug.Assert(manager != null);

        ListPanel = GetComponentInChildren<VerticalLayoutGroup>().gameObject;
        Debug.Assert(ListPanel != null);

        starLocked = Resources.Load<Sprite>("Sprite/star");
        starUnlocked = Resources.Load<Sprite>("Sprite/starLock");
        AchievementPanels = new List<GameObject>();
    }
}
