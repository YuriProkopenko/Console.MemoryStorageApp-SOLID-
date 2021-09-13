using System;
using System.Collections.Generic;
using StorageClasses;
using OutputLogs;
using PriceListClass;
using SerializeFormatters;

namespace HW_17
{
	class Interface
	{
		static void Main(string[] args)
		{
			PriceList items = new();
			ConsoleLog consolLog = new();
			FileLog fileLog = new();
			BinarySerialize binarySer = new();
			SoapSerialize soapSer = new();
			XmlSerialize xmlSer = new();
			JSONSerialize jsonSer = new();
			int choiceMenu = 0;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("1.Add the item to the list");
				Console.WriteLine("2.Delete the item");
				Console.WriteLine("3.Edit the item");
				Console.WriteLine("4.Search the items");
				Console.WriteLine("5.Print the list");
				Console.WriteLine("6.Save list");
				Console.WriteLine("7.Load list");
				Console.WriteLine("8.Exit");
				try
				{
					choiceMenu = Convert.ToInt32(Console.ReadLine());
					if (choiceMenu < 1 || choiceMenu > 8)
					{
						Console.Clear();
						Console.WriteLine("Make your choice correct!");
						Console.ReadLine();
					}
					if (choiceMenu == 1)
					{
						int choiceAddItemMenu = 0;
						while (true) {
							Console.Clear();
							Console.WriteLine("Add the item to the list\n");
							Console.WriteLine("1.DVD");
							Console.WriteLine("2.HDD");
							Console.WriteLine("3.Flash");
							Console.WriteLine("4.Cancel");
							try
							{
								choiceAddItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choiceAddItemMenu < 0 || choiceAddItemMenu > 4)
								{
									Console.Clear();
									Console.Beep();
									Console.WriteLine("Make your choice correct!");
									Console.ReadLine();
								}
								else if (choiceAddItemMenu == 4)
									break;
								else
								{
									Console.Clear();
									Console.Write("Manufacturer : ");
									string manufacturer = Console.ReadLine();
									Console.Write("Model : ");
									string model = Console.ReadLine();
									Console.Write("Name : ");
									string name = Console.ReadLine();
									Console.Write("Capacity : ");
									string capacity = Console.ReadLine();
									if (choiceAddItemMenu == 1)
									{
										Console.Write("SpindleSpeed : ");
										string spindleSpeed = Console.ReadLine();
										DVD dvdItem = new();
										dvdItem.Manufacturer = manufacturer;
										dvdItem.Model = model;
										dvdItem.Name = name;
										dvdItem.Capacity = capacity;
										dvdItem.SpindleSpeed = spindleSpeed;
										items.Add(dvdItem);
									}
									else if (choiceAddItemMenu == 2)
									{
										Console.Write("RecordSpeed : ");
										string recordSpeed = Console.ReadLine();
										HDD hddItem = new();
										hddItem.Manufacturer = manufacturer;
										hddItem.Model = model;
										hddItem.Name = name;
										hddItem.Capacity = capacity;
										hddItem.RecordSpeed = recordSpeed;
										items.Add(hddItem);
									}
									else if (choiceAddItemMenu == 3)
									{
										Console.Write("FlashSpeed : ");
										string flashSpeed = Console.ReadLine();
										Flash flashItem = new();
										flashItem.Manufacturer = manufacturer;
										flashItem.Model = model;
										flashItem.Name = name;
										flashItem.Capacity = capacity;
										flashItem.FlashSpeed = flashSpeed;
										items.Add(flashItem);
									}
									Console.Clear();
									Console.WriteLine("Completed!");
									Console.ReadLine();
								}
							}
							catch (Exception Ex)
							{
								Console.Clear();
								Console.Beep();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
							}
						}						
					}
					if (choiceMenu == 2)
					{
						while (true)
						{
							Console.Clear();
							Console.WriteLine("Delete the item from the list\n");
							Console.Write("Input the name : ");
							try
							{
								string itemName = Console.ReadLine();
								int choiceDelItemMenu;
								List<Storage> findItemsList = items.FindByName(itemName);
								Console.Clear();
								if (findItemsList.Count == 0)
								{
									Console.Beep();
									Console.WriteLine("Items not found!");
									Console.ReadLine();
									break;
								}
								int countList = 0;
								foreach (var obj in findItemsList)
								{
									Console.Write("{0}.", ++countList);
									obj.Print(consolLog);
								}
								Console.WriteLine("\nMake your choice : ");
								choiceDelItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choiceDelItemMenu > findItemsList.Count)
									throw new Exception("Make your choice correct!");
								items.Remove(findItemsList[--choiceDelItemMenu]);
							}
							catch (Exception Ex)
							{
								Console.Beep();
								Console.Clear();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
								break;
							}
							Console.Clear();
							Console.WriteLine("Completed!");
							Console.ReadLine();
							break;
						}
					}
                    if (choiceMenu == 3)
                    {
						while (true)
						{
							Console.Clear();
							Console.WriteLine("Edit the item from the list\n");
							Console.Write("Input the name : ");
							try
							{
								string itemName = Console.ReadLine();
								int choiceEditItemMenu;
								List<Storage> findItemsList = items.FindByName(itemName);
								Console.Clear();
								if (findItemsList.Count == 0)
								{
									Console.Beep();
									Console.WriteLine("Items not found!");
									Console.ReadLine();
									break;
								}
								int countList = 0;
								foreach (var obj in findItemsList)
								{
									Console.Write("{0}.", ++countList);
									obj.Print(consolLog);
								}
								Console.WriteLine("\nMake your choice : ");
								choiceEditItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choiceEditItemMenu > findItemsList.Count)
									throw new Exception("Make your choice correct!");
								Console.Clear();
								Console.Write("Manufacturer : ");
								string manufacturer = Console.ReadLine();
								Console.Write("Model : ");
								string model = Console.ReadLine();
								Console.Write("Name : ");
								string name = Console.ReadLine();
								Console.Write("Capacity : ");
								string capacity = Console.ReadLine();
								if (findItemsList[--choiceEditItemMenu] is DVD)
								{
									Console.Write("SpindleSpeed : ");
									string spindleSpeed = Console.ReadLine();
									DVD dvdItem = new();
									dvdItem.Manufacturer = manufacturer;
									dvdItem.Model = model;
									dvdItem.Name = name;
									dvdItem.Capacity = capacity;
									dvdItem.SpindleSpeed = spindleSpeed;
									items.Edit(findItemsList[choiceEditItemMenu], dvdItem);
								}
								else if (findItemsList[choiceEditItemMenu] is HDD)
								{
									Console.Write("RecordSpeed : ");
									string recordSpeed = Console.ReadLine();
									HDD hddItem = new();
									hddItem.Manufacturer = manufacturer;
									hddItem.Model = model;
									hddItem.Name = name;
									hddItem.Capacity = capacity;
									hddItem.RecordSpeed = recordSpeed;
									items.Edit(findItemsList[choiceEditItemMenu], hddItem);
								}
								else if (findItemsList[choiceEditItemMenu] is Flash)
								{
									Console.Write("FlashSpeed : ");
									string flashSpeed = Console.ReadLine();
									Flash flashItem = new();
									flashItem.Manufacturer = manufacturer;
									flashItem.Model = model;
									flashItem.Name = name;
									flashItem.Capacity = capacity;
									flashItem.FlashSpeed = flashSpeed;
									items.Edit(findItemsList[choiceEditItemMenu], flashItem);
								}
							}
							catch (Exception Ex)
							{
								Console.Beep();
								Console.Clear();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
								break;
							}
							Console.Clear();
							Console.WriteLine("Completed!");
							Console.ReadLine();
							break;
						}
					}
					if (choiceMenu == 4)
					{
						while (true)
						{
							Console.Clear();
							Console.WriteLine("Search the items from the list\n");
							Console.Write("Input the name : ");
							try
							{
								string itemName = Console.ReadLine();
								List<Storage> findItemsList = items.FindByName(itemName);
								Console.Clear();
								if (findItemsList.Count == 0)
									Console.WriteLine("Items not found!");
								foreach (var obj in findItemsList)
								{
									obj.Print(consolLog);
								}
								Console.ReadLine();
								break;
							}
							catch (Exception Ex)
							{
								Console.Clear();
								Console.Beep();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
							}
						}
					}
                    if (choiceMenu == 5)
                    {
						while (true)
						{
							int choicePrintItemMenu;
							Console.Clear();
							Console.WriteLine("Print the list\n");
							Console.WriteLine("1.To the console");
							Console.WriteLine("2.To the file");
							Console.WriteLine("3.Cancel");
							try
							{
								choicePrintItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choicePrintItemMenu < 1 || choicePrintItemMenu > 3)
									throw new Exception("Make your choice correct!");
								else if(choicePrintItemMenu == 1)
                                {
									Console.Clear();
									items.Print(consolLog);
									if (items.List.Count == 0)
										Console.WriteLine("Price list is empty!");
									Console.ReadLine();
                                }
								else if(choicePrintItemMenu == 2)
                                {
									Console.Clear();
									items.Print(fileLog);
									if (items.List.Count == 0)
										Console.WriteLine("Price list is empty!");
									else
										Console.WriteLine("Completed!");
									Console.ReadLine();
								}
								else
									break;
							}
							catch(Exception Ex)
                            {
								Console.Clear();
								Console.Beep();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
							}
						}
                    }
                    if (choiceMenu == 6)
                    {
						while (true)
						{
							int choiceSaveItemMenu;
							Console.Clear();
							Console.WriteLine("Save the list\n");
							Console.WriteLine("1.Serialize with binary");
							Console.WriteLine("2.Serialize with soap");
							Console.WriteLine("3.Serialize with xml");
							Console.WriteLine("4.Serialize with JSON");
							Console.WriteLine("5.Cancel");
                            try
                            {
								choiceSaveItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choiceSaveItemMenu < 1 || choiceSaveItemMenu > 5)
									throw new Exception("Make your choice correct!");
								else if (choiceSaveItemMenu == 1)
								{
									items.Save(binarySer);
								}
								else if (choiceSaveItemMenu == 2)
								{
									items.Save(soapSer);
								}
								else if (choiceSaveItemMenu == 3)
								{
									items.Save(xmlSer);
								}
								else if (choiceSaveItemMenu == 4)
								{
									items.Save(jsonSer);
								}
								else
									break;
							}
							catch(Exception Ex)
                            {
								Console.Clear();
								Console.Beep();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
							}
							Console.Clear();
							Console.WriteLine("Completed!");
							Console.ReadLine();
						}
                    }
                    if (choiceMenu == 7)
                    {
						while (true)
						{
							int choiceLoadItemMenu;
							PriceList trialItems = new();
							Console.Clear();
							Console.WriteLine("Load the list\n");
							Console.WriteLine("1.Deserialize with binary");
							Console.WriteLine("2.Deserialize with soap");
							Console.WriteLine("3.Deserialize with xml");
							Console.WriteLine("4.Deserialize with JSON");
							Console.WriteLine("5.Cancel");
							try
							{
								choiceLoadItemMenu = Convert.ToInt32(Console.ReadLine());
								if (choiceLoadItemMenu < 1 || choiceLoadItemMenu > 5)
									throw new Exception("Make your choice correct!");
								else if (choiceLoadItemMenu == 1)
								{
									items.List = trialItems.Load(binarySer);
								}
								else if (choiceLoadItemMenu == 2)
								{
									items.List = trialItems.Load(soapSer);

								}
								else if (choiceLoadItemMenu == 3)
								{
									items.List = trialItems.Load(xmlSer);
									;
								}
								else if (choiceLoadItemMenu == 4)
								{
									items.List = trialItems.Load(jsonSer);
									
								}
								else
									break;
							}
							catch (Exception Ex)
							{
								Console.Clear();
								Console.Beep();
								Console.WriteLine(Ex.Message);
								Console.ReadLine();
							}
							Console.Clear();
							Console.WriteLine("Completed!");
							Console.ReadLine();
						}
					}
                    if (choiceMenu == 8)
                    {
                        break;
                    }
                }
				catch (Exception Ex)
				{
					Console.Clear();
					Console.Beep();
					Console.WriteLine(Ex.Message);
					Console.ReadLine();
				}
			}
		}
	}
}