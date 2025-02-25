using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonsterDetailPanel : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text hpText;
    [SerializeField] Image monsterImage;   
    public void ShowDetail(MonsterData data)
    {
        nameText.text = data.monsterName;
        hpText.text = "HP: " + data.hp;
        attackText.text = "attack: " + data.attack;
        descriptionText.text = data.description;

        //画像がセットされている場合は表示
        if (monsterImage != null)
        {
            if (data.monsterSprite != null)
            {
                monsterImage.sprite = data.monsterSprite;
                monsterImage.gameObject.SetActive(true);
            }
            else
            {
                monsterImage.gameObject.SetActive(false);
            }
        }

        gameObject.SetActive(true);//表示
    }

    public void Hide()
    {
        gameObject.SetActive(false);//非表示
    }
}
