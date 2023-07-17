using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class InfoPanelManager : MonoBehaviour
{
    private MenuManager MM;

    [Header("Панель информации")]
    public Text namePanelText;
    public Text quantityPanelText;
    public Text descriptionPanelText;
    public Text typePanelText;
    public Image imagePanelCard;
    public GameObject panelQuantity;
    public int number;
    public string typeCard;

    [Header("Панель продать карту")]
    public bool isCardSales; //бул переменная отвечающая за то, будет ли в игре возможность продавать карты
    public List<CardSales> CardSales;

    void Start()
    {
        MM = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
        if (isCardSales == true){ //проверка, есть ли возможность продавать
            panelQuantity.SetActive(true); //если есть возможность, то панель появляется при старте
            for (int i = 0; i < CardSales.Count; i++){ //нормальное отображение текста для продажи карт
                if (i != 0)
                    CardSales[i].nameText.text = CardSales[i].name + " карт";
                for (int a = 0; a < CardSales[i].payment.Length; a++){
                    if (typeCard == MM.Items[a].typeCard){
                        CardSales[i].salesNameText.text = "Вам выплятят: " + CardSales[i].payment[a] + "$";
                    }
                }
            }
        }else{
            panelQuantity.SetActive(false);
        }
    }

    public void CardSalesChanged0(){ //функция отвечает за продажу одной карты
        for (int i = 0; i < MM.Items.Count; i++){
            if (typeCard == MM.Items[i].typeCard){
                if (MM.Items[i].quantity[number] >= CardSales[0].name){
                    MM.money += CardSales[0].payment[i];
                    PlayerPrefs.SetInt("money", MM.money);
                    MM.Items[i].quantity[number] -= CardSales[0].name;
                    ExitPanelInfo();
                    MM.SaveGame();
                    YandexGame.NewLeaderboardScores("LeaderBoard", MM.money);
                }
            }
        }
        MM.UpdateCardText();
        
    }

    public void CardSalesChanged1(){ //функция отвечает за продажу десяти карт
        for (int i = 0; i < MM.Items.Count; i++){
            if (typeCard == MM.Items[i].typeCard){
                if (MM.Items[i].quantity[number] >= CardSales[1].name){
                    MM.money += CardSales[1].payment[i];
                    PlayerPrefs.SetInt("money", MM.money);
                    MM.Items[i].quantity[number] -= CardSales[1].name;
                    ExitPanelInfo();
                    MM.SaveGame();
                    YandexGame.NewLeaderboardScores("LeaderBoard", MM.money);
                }
            }
        }
        MM.UpdateCardText();
    }

    public void CardSalesChanged2(){
        for (int i = 0; i < MM.Items.Count; i++){ //функция отвечает за продажу пятьдесят карт
            if (typeCard == MM.Items[i].typeCard){
                if (MM.Items[i].quantity[number] >= CardSales[2].name){
                    MM.money += CardSales[2].payment[i];
                    PlayerPrefs.SetInt("money", MM.money);
                    MM.Items[i].quantity[number] -= CardSales[2].name;
                    ExitPanelInfo();
                    MM.SaveGame();
                    YandexGame.NewLeaderboardScores("LeaderBoard", MM.money);
                }
            }
        }
        MM.UpdateCardText();
    }

    public void ExitPanelInfo(){ //закрытие панели с информацией карты
        Destroy(gameObject);
    }
}

[System.Serializable]
public class CardSales //общая информация панели
{
    public Text nameText;
    public int name;
    public Text salesNameText;
    public int[] payment;
}
