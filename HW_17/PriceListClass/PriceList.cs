using System;
using System.Collections.Generic;
using StorageClasses;
using ILogInterface;
using ISerializeInterface;

namespace PriceListClass
{
    public class PriceList
    {
        public List<Storage> List = new();
        public PriceList() { }
        public void Add(object _item)
        {
            if (_item != null)
            {
                if (_item is DVD)
                {
                    List.Add((DVD)_item);
                    return;
                }
                else if (_item is HDD)
                {
                    List.Add((HDD)_item);
                    return;
                }
                else if (_item is Flash)
                {
                    List.Add((Flash)_item);
                    return;
                }
                throw new Exception("Error object!");
            }
            else throw new Exception("Error object!");
        }
        private int FindIndex(object _item)
        {
            if (_item is Storage)
                return List.IndexOf((Storage)_item);
            else
                throw new Exception("Object not found!");
        }
        public void Remove(object _item)
        {
            int index = FindIndex(_item);
            List.RemoveAt(index);
        }
        public List<Storage> FindByName(string _name)
        {
            List<Storage> items = new();
            foreach (var obj in List)
            {
                if (_name == obj.Name)
                    items.Add(obj);
            }
            return items;
        }
        public void Edit(object _item, object _newItem)
        {
            int index = FindIndex(_item);
            if (_item is DVD)
                List[index] = (DVD)_newItem;
            else if (_item is HDD)
                List[index] = (HDD)_newItem;
            else if (_item is Flash)
                List[index] = (Flash)_newItem;
        }
        public void Print(ILog log)
        {
            foreach (var obj in List)
            {
                obj.Print(log);
            }
        }
        public void Save(ISerialize ser)
        {
            ser.Save(List);
        }
        public List<Storage> Load(ISerialize ser)
        {
            return ser.Load();
        }
    }
}