﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    public class HexType
    {

        public HexType(string name)
        {
            this.Name = name;
            Actions = new List<HexAction>();
            SetMaterial("default");
            SetModel("Default");
        }

        public static HexType Void;
        public static HexType Cell;
        public static HexType Expansion;
        public static HexType Workshop;

        public string Name;
        public Material Material;
        public GameObject Model;

        public List<HexAction> Actions;

        public HexUpgrade Upgrade;

        public static void Init()
        {
            Void = new HexType("Void").SetMaterial("Void");

            Cell = new HexType("Cell");
            Cell.AddAction(HexAction.CreateRuneBasicBlank);
            Cell.AddAction(HexAction.CreateRuneBasicSpace);
            Cell.AddAction(HexAction.CreateRuneBasicStability);
            Cell.AddAction(HexAction.CreateClusterBasicExpansion);
            Cell.AddAction(HexAction.CreateClusterBasicWorkshop);
            Cell.SetModel("Cell");
            Cell.SetMaterial("Cell");

            Expansion = new HexType("Expansion");
            Expansion.SetMaterial("Expansion");

            Workshop = new HexType("Workshop");
            Workshop.SetMaterial("Workshop");
            Workshop.SetModel("Workshop");
            Workshop.AddAction(HexAction.CreateRuneBasicBlank);
            Workshop.AddAction(HexAction.CreateRuneBasicSpace);
            Workshop.AddAction(HexAction.CreateRuneBasicStability);
            Workshop.AddAction(HexAction.CreateRuneBasicOre);
            Workshop.AddAction(HexAction.CreateClusterBasicExpansion);
            Workshop.AddAction(HexAction.CreateClusterBasicWorkshop);


            Void.SetUpgrade(new HexUpgrade(HexType.Expansion).SetInput(new Item(ItemData.ClusterBasicExpansion).SetAmount(1)));
            Expansion.SetUpgrade(new HexUpgrade(HexType.Workshop).SetInput(new Item(ItemData.ClusterBasicWorkshop).SetAmount(1)));
        }

        public HexType SetMaterial(string matName)
        {
            Material = Resources.Load<Material>("Materials/Hexes/" + matName);
            return this;
        }

        public HexType SetModel(string modelName)
        {
            Model = Resources.Load<GameObject>("Models/Hexes/" + modelName);
            return this;
        }

        public HexType AddAction(HexAction action)
        {
            Actions.Add(action);
            return this;
        }

        public HexType SetUpgrade(HexUpgrade upgrade)
        {
            this.Upgrade = upgrade;
            return this;
        }
    }
}