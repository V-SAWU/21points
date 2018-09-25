using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Game
    {
        public string Box1;
        public string Box2;
        public string Box3;
        public string Box4;
        public string Box5;
        public string Box6;
        public string Box7;
        public string Box8;
        public string Box9;
        public string Box10;                        //以上放置纸牌      
        public string lab_zhuangjia;                //显示庄家目前的点数
        public string lab_wanjia;                   //显示玩家目前的点数
        public Hand hand_zj;                        //保存庄家手中的牌
        public Hand hand_wj;                        //保存玩家手中的牌
        public Deck deck;                           //新创建一副牌
        public int i;                               //一副牌的第几张,用于记录发牌过程中发到一副牌的第几张
        public int score;                           //玩家在一轮游戏中赢得或输掉的金额
        public string k = "";

        bool result = false;

        public Game()
        {
            hand_wj = new Hand();
            hand_zj = new Hand();
            deck = new Deck();
            i = 0;
            setnew();
        }

        public void setnew()
        {
            Box1="";
            Box2="";
            Box3="";
            Box4="";
            Box5="";
            Box6="";
            Box7="";
            Box8="";
            Box9="";
            Box10 = "";
        }              
        public bool firstCicle(out string message)      //第一轮发牌 庄家和玩家均发到两张牌-从庄家开始拿牌
        {
            message = "";
            fapai(Box1, hand_zj,out message);
            fapai(Box1, hand_wj,out message);
            fapai(Box2, hand_zj,out message);
            fapai(Box2, hand_wj,out message);
           
            

            //判断是否有黑杰克 
            if (hand_zj.checkBlackJack() && hand_wj.checkBlackJack())
            { showCard(); result = true; message= "banker and player are blackjack! It ends in a draw ";
                score = 0; lab_wanjia = "21"; lab_zhuangjia = "21"; }
            else if (hand_wj.checkBlackJack())
            { showCard(); result = true; message="blackjack! you win!";
                score = getScore(k) * 2; lab_wanjia = "21"; }
            else if (hand_zj.checkBlackJack())
            { showCard(); result = true; message="banker win! ";
                score = 0 - getScore(k) * 2; lab_zhuangjia = "21"; }
            else
            {
                result = false;                     //游戏时 庄家只显示一张手牌的点数
                lab_zhuangjia = hand_zj.cards[0].value.ToString();
                lab_wanjia = hand_wj.count.ToString();
            }
            return result;
        }

        public bool hitEvent(out string message)
        {
            message = "";
            fapai(checkPicture_wj(), hand_wj,out message);
            lab_wanjia = hand_wj.count.ToString();
            if (hand_wj.checkOut())                 //玩家爆牌
            {
                showCard();
                result = true;
                message = "Player burst the card ,banker win!";
                score = 0 - getScore(k);
            }
            return result;
        }

        public bool standEvent(out string message)
        {
            while (hand_zj.checkCount()) { fapai(checkPicture_zj(), hand_zj,out message); }
            if (hand_zj.count > 21)
            {
                showCard();
                result = true;
                message = "bankerer burst the card ,player win!";
                score = getScore(k);
            }
            else
            {
                if (hand_wj.count > hand_zj.count)
                {
                    showCard();
                    result = true;
                    if (hand_wj.count == 21) { message = "21points! you win!"; }
                    else message = "you win!";
                    score = getScore(k);
                }
                else if (hand_zj.count > hand_wj.count)
                {
                    showCard();
                    result = true;
                    if (hand_zj.count == 21) { message = "banker 21points! banker win"; }
                    else message = "you lose";
                    score = 0 - getScore(k);
                }
                else
                {
                    showCard();
                    result = true;
                    message = "It ends in a draw ";
                    score = 0;
                }

            }

            return result;

        }

        //发牌
        private void fapai(string picture, Hand hand,out string message)
        {
            message = "";
            int num = deck.card[i];
            i++;
            Card card = new Card(num);
            if (hand.numCard < 5)
            {
                hand.addCard(card);
            }
            else
                message = "The number of cards has reached the upper limit. ";
        }
        private void showCard()
        {
        }       
        private string checkPicture_wj()
        {
            if (Box8 == "") { return Box8; }
            else if ((Box9 == "")) { return Box9; }
            else if ((Box10 == "")) { return Box10; }
            else return "";
        }
        private string checkPicture_zj()
        {
            if (Box3 == "") { return Box3; }
            else if ((Box4 == "")) { return Box4; }
            else if ((Box5 == "")) { return Box5; }
            else return "";
        }

        public int getScore(string a)
        {
            int num = 0;
            if (a=="1") num = 50;
            else if (a=="2") num = 100;
            else if (a=="3") num = 200;
            else num = 50;
            return num=50;
        }
              
    }
}
