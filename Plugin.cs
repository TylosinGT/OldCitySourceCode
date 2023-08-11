using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace OldCity
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToBasement/Uncover DungeonEntrance").SetActive(false);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToBasement/DungeonEntrance").SetActive(false);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/cosmetics room OLD").SetActive(true);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/cosmetics room new").SetActive(false);
        }

        void Update()
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToBasement/Uncover DungeonEntrance").SetActive(false);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/CityToBasement/DungeonEntrance").SetActive(false);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/cosmetics room OLD").SetActive(true);
            GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/cosmetics room new").SetActive(false);
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
