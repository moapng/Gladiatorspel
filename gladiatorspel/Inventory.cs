﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace gladiatorspel
{
    public class Inventory
    {
        public List<Item> inventoryList = new List<Item>();

        public void AddToInventory(Item item)
        {
            inventoryList.Add(item);
        }

        public Item GetFromInventory(int position)
        {
            if(inventoryList.Count > position)
            {
                return inventoryList[position];
            }
            else
            {
                return null;
            }
        }
    }
}
