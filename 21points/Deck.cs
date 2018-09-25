using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Deck                              //Deck表示一副牌 共52张 card是int数组 存储1-52的数字 
    {                      
        public int[] card;
        Random rd = new Random();       
        public Deck()                       //构造函数 生成一副纸牌并打乱
        {
            card = new int[52];
            for (int i = 0; i < 52; i++)
            {
                card[i] = i + 1;
            }
            shuffle();
        }                                                                                     
        private void  shuffle()            //洗牌 随意两张牌对换500次  
        {
            for(int i=0;i<500;i++)
            {
                int j = rd.Next(0, 51);
                int k = rd.Next(0, 51);
                int temp = card[j];
                card[j] = card[k];
                card[k] = temp;
            }
        }
    }
}
