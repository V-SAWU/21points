using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Hand                            //Hand表示在游戏者手中持有的纸牌
    {
        public int numCard;              //持有的纸牌数量
        public Card[] cards;             //一副牌
        static int maxCards = 5;        //游戏中最多只发5张牌
        public int count=0;             //记录持有的纸牌点数

        public Hand()
        {
            numCard = 0;
            cards = new Card[maxCards];
        }              
        public void addCard(Card c)      //新加一张牌 插入Card数组中, 读取新加入的纸牌数值，加到持有纸牌的点数count中 
        {
            cards[numCard] = c;
            count += c.value;
            numCard++;
        }     
        public bool checkBlackJack()        //检测在发完两张牌时，是否有blackjack  
        {
            if (numCard == 2)
            {
                if 
                    ((cards[0].value == 1) && (cards[1].value == 10))
                    return true;
                else if 
                    ((cards[0].value == 10) && (cards[1].value == 1))
                    return true;
                else return false;
            }
            else return false;
        }       
        public bool checkCount()          //在每轮发牌时均要检测庄家的牌点数，若大于18则不再加牌
        {
            if (count > 18) return false;
            else return true;
        }       
        public bool checkOut()              //检测是否大于18
        {
            if (count > 21)
                return true;
            else return false;
        }
    }
}
