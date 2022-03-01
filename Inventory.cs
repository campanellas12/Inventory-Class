using System;
using System.Collections.Generic;

    /// <summary>
    /// The Inventory class that has a maximum size, a list for storing items 
    /// and stores the character's armor and weapon items.
    /// </summary>
public class Inventory {              
    int inventorySize;     
    Weapon weapon;
    Armor armor;
    List<Item> items;
    List<String> displayInv;
    Character character;

    /// <summary>
    /// Constructor function that sets the maximum inventory size, generates 
    /// a starter weapon and armor and generates the list to store items
    /// </summary>
    public Inventory(Character character2){
        this.inventorySize = 15;
        this.character = character2;
        this.weapon = new Weapon(5, "starterSword", character, this);
        this.armor = new Armor(10, "starterArmor", character, this);
        this.items = new List<Item>();
        this.displayInv = new List<String>();
        }
    
    /// <summary>
    /// Inventory Array to display when the player opens the Inventory screen
    /// </summary>
    public void display(){
        Console.WriteLine("");
        string printMessage = "Please type the first letter of the item you would like to use/equip ('i' to return to game):";
        char[,] printArray = new char[50, 100];

        for (int fill = 0; fill < 50; fill++){
            for (int fill2 = 0; fill2 < 100; fill2++){
                printArray[fill, fill2] = ' ';
            }
        }
        for (int left = 0; left < 50; left++){
            printArray[left,0] = '#';
        }
        for (int right = 0; right < 50; right++){
            printArray[right,99] = '#';
        }
        for (int top = 0; top < 100; top++){
            printArray[0,top] = '#';
        }
        for (int bottom = 0; bottom < 100; bottom++){
            printArray[49,bottom] = '#';
        }
        for (int print = 0; print < printMessage.Length; print++){
            printArray[1, print+1] = printMessage[print];
        }
        for (int i = 0; i < items.Count; i++){
            for (int b = 0; b < displayInv[i].Length; b++){
                int x = 2 * (i + 1);
                printArray[x, 2+b] = displayInv[i][b];
            }
        }
        for (int row = 0; row < 50; row++){
            for (int col = 0; col < 100; col++){
                Console.Write("{0}", printArray[row, col]);
            }
        }
    }
    
    /// <summary>
    /// Takes an item to be picked up and adds it to the items list
    /// </summary>
    public void pickup(Item pickup){
        if (pickup.itemName == "Satchel"){
            pickup.method();
        }else if (items.Count < inventorySize){
            items.Add(pickup);
            displayInv.Add(pickup.itemName);
        }
    }

    /// <summary>
    /// Takes an item to be dropped and removes it from the items list
    /// </summary>
    public void drop(Item drop){
        items.Remove(drop);
        displayInv.Remove(drop.itemName);
    }
    
    /// <summary>
    /// Boosts the size of the inventory (called when satchel is picked up)
    /// </summary>
    public void InventoryBoost(){
        if (inventorySize < 23){ 
            inventorySize+=2;
        }
    }

    /// <summary>
    /// Method to switch weapons from the inventory screen
    /// </summary>
    public void WeaponChange(Weapon newWeapon){
        weapon = newWeapon;
    }

    /// <summary>
    /// Method to switch armor from the inventory screen
    /// </summary>
    public void ArmorChange(Armor newArmor){
        armor = newArmor;
    }

    /// <summary>
    /// Function consumes an item from the items list and removes it
    /// </summary>
    public void consumeItem(String consume){
        if (displayInv.Contains(consume)){
            for (int d = 0; d < displayInv.Count; d++){
                if (displayInv[d] == consume){
                    items[d].method();
                    items.RemoveAt(d);
                    displayInv.Remove(consume);
                    d = displayInv.Count;
                }
            }
        }
    }
};