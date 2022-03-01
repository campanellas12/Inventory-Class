using Xunit;
using System;
using System.Collections.Generic;

namespace Inventory.Tests;

public class UnitTest1
{
    Inventory inventoryTest = new Inventory();
    Item healthpot = new healthPotion(5);
    [Fact]
    public void Test1()
    {
        bool result = false;
        inventoryTest.InventoryBoost();
        if (inventoryTest.inventorySize == 17){//Tests if the inventoryBoost method completed correctly
            result = true;
        }
        Assert.False(result, "The inventory size was not boosted");
    }
    [Fact]
    public void test2(){
        bool result = false;
        inventoryTest.WeaponChange(new Inventory.Weapon(5, "Sword"));
        if (inventoryTest.Weapon.itemName == "Sword"){//Tests if the Weapon was changed
            bool result = true;
        }
        Assert.False(result, "The weapon was not changed");
    }

    [Fact]
    public void test3(){
        bool result = false;
        inventoryTest.ArmorChange(new Inventory.Armor(10, "Chainmail"));
        if (inventoryTest.Armor.itemName == "Chainmail"){//Tests if the armor was changed
            bool result = true;
        }
        Assert.False(result, "The armor was not changed");
    }
    [Fact]
    public void test4(){
        bool result = false;
        inventoryTest.pickup(healthpot);
        if (inventoryTest.items.Contains("healthpot")){//Tests if the healthpot was picked up
            bool result = true;
        }
        Assert.False(result, "The healthpot was not picked up");
    }
    [Fact]
    public void test5(){
        bool result = true;
        inventoryTest.pickup(healthpot);
        inventoryTest.drop(healthpot);
        if (inventoryTest.items.Contains("healthpot")){//Tests if the healthpot was dropped
            bool result = false;
        }
        Assert.False(result, "The armor was not changed");
    }
    
}