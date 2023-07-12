using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    private MenuManager MM;
    private InfoPanelManager IPM;
    private Transform card;

    [Header("Информация о карте")]
    public string nameCard; //название карты
    public string typeCard; //тип редкости карты
    public int number; //основной порядковый номер карты
    public string description;

    [Header("Вывод данных")]
    public Text nameText;
    public Text quantityText;
    public Sprite imageCard;
    public GameObject buttonInfo;
    public GameObject panelInfo;

    void Start()
    {
        MM = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
        nameText.text = "" + nameCard; //вывод имени
        if (MM.isInfoCard == false){ //если выключена возможность открытия панели, то:
            buttonInfo.SetActive(false); //не будет кнопки, для того чтобы открыть
        }
    }

    public void Update()
    {
        for (int i = 0; i < MM.Items.Count; i++){ //назначение карте количества
            if (GameObject.FindGameObjectWithTag("Case") != null){ //если открывается кейс, то тогда:
                if (typeCard == MM.Items[i].typeCard){
                    if (MM.Items[i].quantity[number] <= 1){ //если он открывется первый раз, то выводится надпись нью (новая карта)
                        quantityText.text = "новая";
                    }else if (MM.Items[i].quantity[number] > 1){ //если больше одного то выводится в текст +1
                        quantityText.text = "+1";
                    }
                }
                if (MM.isInfoCard == true){ //при открытии кейса, кнопка посмотреть панель информации непоявляется
                    buttonInfo.SetActive(false);
                }
            }else{
                if (typeCard == MM.Items[i].typeCard){
                    quantityText.text = "x" + MM.Items[i].quantity[number]; //в коллекции выводется текст, количество карт имеющихся в наличии

                    if (MM.Items[i].quantity[number] == 0){ //если количество карты равно нулю, то она удаляется
                        MM.SaveGame(); //сохранение карт
                        Destroy(gameObject);
                    }
                }
                if (MM.isInfoCard == true){ //если можно открывать панель информации, то она открывается
                    buttonInfo.SetActive(true);
                }
            }
        }
    }

    public void ButtonPanel() //при нажатии на кнопку, будет:
    {
        Instantiate(panelInfo, MM.pointSpawnCase.transform.position, Quaternion.identity, MM.pointSpawnCase.transform); //создаваться панель
        IPM = GameObject.FindGameObjectWithTag("Panel Info").GetComponent<InfoPanelManager>(); //определятся панель, чтобы с ней позже работать
        IPM.namePanelText.text = nameText.text; //отображение имени в панели
        IPM.quantityPanelText.text = quantityText.text; //отображение количества карт в панели
        IPM.descriptionPanelText.text = "Описание: " + description; //отображение описания в панели
        IPM.imagePanelCard.sprite = imageCard; //отображение заданной картинки
        IPM.imagePanelCard.SetNativeSize(); //картинка расягивается в весь свой размер
        IPM.number = number; //номер карты присваивается панели, для корректной работы
        IPM.typeCard = typeCard; //тоже самое, тип карты присваивается панеле
        IPM.typePanelText.text = typeCard; //отображение типа карты на панели
    }
}
