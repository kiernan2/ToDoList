using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace ToDoList.TestTools
{
  [TestClass]
  public class ItemTests : IDisposable
  {
    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      List<Item> newList = new List<Item>();

      List<Item> result = Item.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      Item testItem = new Item("Mow the lawn");
      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item> { testItem };
      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void ItemConstructor_CreatesInstanceOfItem_Item()
    // {
    //   Item newItem = new Item("test");
    //   Assert.AreEqual(typeof(Item), newItem.GetType());
    // }
    // [TestMethod]
    // public void GetDescription_ReturnsDescrption_String()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //   string result = newItem.Description;
    //   Assert.AreEqual(description, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_ItemList()
    // {
    //   List<Item> newList = new List<Item>();
    //   List<Item> result = Item.GetAll();
    //   foreach (Item thisItem in result)
    //   {
    //     Console.WriteLine("Output from empty list GetAll test: " + thisItem.Description);
    //   }
    // CollectionAssert.AreEqual(newList, result);
    // }
    
    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      newItem.Save();
      Item foundItem = Item.Find(newItem.Id);
      Assert.AreEqual(foundItem.Id, newItem.Id);
    }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //   string updatedDescription = "Do the dishes";
    //   newItem.Description = updatedDescription;
    //   string result = newItem.Description;
    //   Assert.AreEqual(updatedDescription, result);
    // }
    // [TestMethod]
    // public void Find_ReturnsCorrectItem_Item()
    // {
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01);
    //   Item newItem2 = new Item(description02);
    //   Item result = Item.Find(2);
    //   Assert.AreEqual(newItem2, result);
    // }

    [TestMethod]
    public void GetAll_Returns_ItemList()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      List<Item> result = Item.GetAll();
      // foreach (Item thisItem in result)
      // {
      //   Console.WriteLine("Output from second GetAll test: " + thisItem.Description);
      // }
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Item()
    {
      Item newItem1 = new Item("Mow the lawn");
      newItem1.Save();
      Item newItem2 = new Item("Wash dishes");
      newItem2.Save();

      Item foundItem = Item.Find(newItem1.Id);
      Assert.AreEqual(newItem1, foundItem);
    }


  }
}