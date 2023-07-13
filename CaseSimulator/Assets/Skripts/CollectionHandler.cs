//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CollectionHandler : MonoBehaviour
//{
//    private MenuManager MM;
//    // Start is called before the first frame update
//    void Start()
//    {
//        MM = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void UpdateScoreCard()
//    {
//        for (int i = 0; i < MM.Items.Count; i++)
//        { //назначение карте количества
//            if (GameObject.FindGameObjectWithTag("Case") != null)
//            { //если открываетс€ кейс, то тогда:
//                if (typeCard == MM.Items[i].typeCard)
//                {
//                    if (MM.Items[i].quantity[number] <= 1)
//                    { //если он открыветс€ первый раз, то выводитс€ надпись нью (нова€ карта)
//                        quantityText.text = "нова€";
//                        if (typeCard == "ќбычна€")
//                        {
//                            cardLeve1++;
//                            if (time <= 0)
//                            {
//                                cardLeve1++;
//                                cardAll++;
//                                MM.UpdateCard(0, cardLeve1);
//                                PlayerPrefs.SetInt("cardLevel1", cardLeve1);
//                                time = 0.1f;
//                            }
//                        }
//                        else if (typeCard == "–едка€")
//                        {
//                            if (time <= 0)
//                            {
//                                cardLeve1++;
//                                cardAll++;
//                                MM.UpdateCard(1, cardLeve2);
//                                PlayerPrefs.SetInt("cardLevel2", cardLeve2);
//                                time = 2f;
//                            }
//                        }
//                        else
//                        {
//                            if (time <= 0)
//                            {
//                                cardLeve1++;
//                                cardAll++;
//                                MM.UpdateCard(2, cardLeve3);
//                                PlayerPrefs.SetInt("cardLevel3", cardLeve3);
//                                time = 2f;
//                            }
//                        }
//                        if (time <= 0)
//                        {
//                            MM.UpdateCard(4, cardAll);
//                            PlayerPrefs.SetInt("cardAll", cardAll);
//                            time = 2f;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
