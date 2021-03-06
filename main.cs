using System;
using System.IO;
using System.Collections.Generic;
//Item class - handles finer attributes like if an item has been checked off or not
class item{
	private bool complete;
	private string toDo;

	//Items aren't done by default for obvious reasons;
	public item(string details){
		complete = false;
		toDo = details;
	}

	public item(){
		complete = false;
		toDo = "null";
	}

	//I'm going to group the set and get methods
	public string getItem(){
		return toDo;
	}

	public bool isComplete(){
		return complete;
	}
	
	//Mutators
	public void setItem(string changes){
		toDo = changes;
	}

	public void nowComplete(){
		complete = true;
	}
}

//Todo List class - handles the adding, removing, and checking off of items
class toDoList {
	//I decided that the todo list would literally be a list.
	// Doesn't make sense to make it more complex than it needs to be
	List<item> toDo = new List<item>();

	//Adds an item with it's details
	public void addItem(string details){
		item current = new item(details);
		toDo.Add(current);
	}
	//A default add item method
	public void addItem(){
		item current = new item();
		toDo.Add(current);
	}
	//Simple display method
	public void Display(){
		foreach(item quest in toDo){
			Console.WriteLine(quest.getItem() + "\n");
		}
	}

	//the remove method might give me trouble, maybe a hashmap would've been easier?
	//Or a linkedlist
	public void removeItem(string name){
		foreach(item current in toDo){
			if(current.getItem() == name){
				toDo.Remove(current);
				Console.WriteLine("\nDone.");
				return;
			}
		}
		Console.WriteLine("\nNot found.");
	}
}

class MainClass {
  public static void Main (string[] args) {
		toDoList missions = new toDoList();

    Console.WriteLine ("Hello World");
		Console.WriteLine ("Samuel Adetunji To-Do List app!\n\n");

		//Switch case based menu
		int selection = 1;
		while(selection > 0){
			Console.WriteLine("0 - Exit your list app\n1 - Add an item\n2 - Remove an item\n3 - Display to-do list\n");
			Console.Write("Please make a selection - ");
			//@stackoverflow - (user) CodeCaster
			selection = int.Parse(Console.ReadLine());
			switch(selection){
				case 0: Console.WriteLine("0 - Exiting\n");
					break;
				case 1: Console.Write("\nWhat is the item - ");
					string details = Console.ReadLine();
					missions.addItem(details);
					Console.WriteLine("\nDone!");
					break;
				case 2: missions.removeItem(Console.ReadLine());
					break;
				case 3: missions.Display();
					break;
			}
		}
  }
}