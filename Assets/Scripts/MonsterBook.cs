using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class MonsterBook : MonoBehaviour
{
    [SerializeField] private List<MonsterData> monsterList = new List<MonsterData>();
    [SerializeField] private Transform content;
    [SerializeField] private GameObject monsterItemPrefab;
    [SerializeField] private MonsterDetailPanel monsterDetailPanel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopulateMonsterList();
        monsterDetailPanel.Hide();
    }

    private void PopulateMonsterList()
    {
        foreach (var monster in monsterList)
        {
            //プレハブから1個生成
            GameObject item = Instantiate(monsterItemPrefab, content);
            //テキストをセット
            TMP_Text itemText = item.GetComponentInChildren<TMP_Text>();

            if (itemText != null)
            {
                itemText.text = monster.monsterName;
            }

            //ボタンをセット
            Button itemButton = item.GetComponent<Button>();
            if (itemButton != null)
            {
                itemButton.onClick.AddListener(() => 
                {
                    monsterDetailPanel.ShowDetail(monster);
                });
            }            
            
        }
    }
}
