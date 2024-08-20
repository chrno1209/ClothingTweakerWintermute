﻿using System;
using HarmonyLib;
using UnityEngine;
using MelonLoader;
using Il2Cpp;
using ModSettings;

namespace ClothingTweaker
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
        private static class ChangeClothingParameters
        {
            internal static void Postfix(GearItem __instance)
            {
                if (SettingsMain.mainSettings.modFunction && __instance.m_ClothingItem)
                {
                    
                    if (SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        SettingsModClothes.modClothesSettings.ChangePrefabs();
                    }

                    if (SettingsMain.mainSettings.clothingDecay == Choice.Custom) 
                    {
                        updateDecayRates(__instance);
                    }

                    string properName = __instance.name.Contains("Clone") ? __instance.name.Replace("(Clone)", "") : __instance.name;

                    
                    if (properName == "GEAR_Balaclava" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.balaclavaWarmth,
                                                            SettingsHead.headSettings.balaclavaWetWarmth,
                                                            SettingsHead.headSettings.balaclavaWindproof,
                                                            SettingsHead.headSettings.balaclavaWaterproof,
                                                            SettingsHead.headSettings.balaclavaProtection,
                                                            SettingsHead.headSettings.balaclavaMobility,
                                                            SettingsHead.headSettings.balaclavaWeight);
                    }
                    else if (properName == "GEAR_BallisticVest" && SettingsMain.mainSettings.showAccessories != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsAccessories.accessorySettings.ballisticVestWarmth,
                                                            SettingsAccessories.accessorySettings.ballisticVestWetWarmth,
                                                            SettingsAccessories.accessorySettings.ballisticVestWindproof,
                                                            SettingsAccessories.accessorySettings.ballisticVestWaterproof,
                                                            SettingsAccessories.accessorySettings.ballisticVestProtection,
                                                            SettingsAccessories.accessorySettings.ballisticVestMobility,
                                                            SettingsAccessories.accessorySettings.ballisticVestWeight);
                    }
                    else if (properName == "GEAR_BaseballCap" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.baseballCapWarmth,
                                                            SettingsHead.headSettings.baseballCapWetWarmth,
                                                            SettingsHead.headSettings.baseballCapWindproof,
                                                            SettingsHead.headSettings.baseballCapWaterproof,
                                                            SettingsHead.headSettings.baseballCapProtection,
                                                            SettingsHead.headSettings.baseballCapMobility,
                                                            SettingsHead.headSettings.baseballCapWeight);
                    }
                    else if (properName == "GEAR_BasicBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.trailBootsWarmth,
                                                            SettingsFeet.feetSettings.trailBootsWetWarmth,
                                                            SettingsFeet.feetSettings.trailBootsWindproof,
                                                            SettingsFeet.feetSettings.trailBootsWaterproof,
                                                            SettingsFeet.feetSettings.trailBootsProtection,
                                                            SettingsFeet.feetSettings.trailBootsMobility,
                                                            SettingsFeet.feetSettings.trailBootsWeight);
                    }
                    else if (properName == "GEAR_BasicGloves" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.drivingGlovesWarmth,
                                                            SettingsHands.handsSettings.drivingGlovesWetWarmth,
                                                            SettingsHands.handsSettings.drivingGlovesWindproof,
                                                            SettingsHands.handsSettings.drivingGlovesWaterproof,
                                                            SettingsHands.handsSettings.drivingGlovesProtection,
                                                            SettingsHands.handsSettings.drivingGlovesMobility,
                                                            SettingsHands.handsSettings.drivingGlovesWeight);
                    }
                    else if (properName == "GEAR_BasicShoes" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.runningShoesWarmth,
                                                            SettingsFeet.feetSettings.runningShoesWetWarmth,
                                                            SettingsFeet.feetSettings.runningShoesWindproof,
                                                            SettingsFeet.feetSettings.runningShoesWaterproof,
                                                            SettingsFeet.feetSettings.runningShoesProtection,
                                                            SettingsFeet.feetSettings.runningShoesMobility,
                                                            SettingsFeet.feetSettings.runningShoesWeight);
                    }
                    else if (properName == "GEAR_BasicWinterCoat" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.windbreakerWeight);
                    }
                    else if (properName == "GEAR_BasicWoolHat" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.cottonToqueWarmth,
                                                            SettingsHead.headSettings.cottonToqueWetWarmth,
                                                            SettingsHead.headSettings.cottonToqueWindproof,
                                                            SettingsHead.headSettings.cottonToqueWaterproof,
                                                            SettingsHead.headSettings.cottonToqueProtection,
                                                            SettingsHead.headSettings.cottonToqueMobility,
                                                            SettingsHead.headSettings.cottonToqueWeight);
                    }
                    else if (properName == "GEAR_BasicWoolScarf" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.woolScarfWarmth,
                                                            SettingsHead.headSettings.woolScarfWetWarmth,
                                                            SettingsHead.headSettings.woolScarfWindproof,
                                                            SettingsHead.headSettings.woolScarfWaterproof,
                                                            SettingsHead.headSettings.woolScarfProtection,
                                                            SettingsHead.headSettings.woolScarfMobility,
                                                            SettingsHead.headSettings.woolScarfWeight);
                    }
                    else if (properName == "GEAR_BearSkinCoat" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.bearskinCoatWeight);
                    }
                    else if (properName == "GEAR_CargoPants" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.cargoPantsWarmth,
                                                            SettingsLegs.legsSettings.cargoPantsWetWarmth,
                                                            SettingsLegs.legsSettings.cargoPantsWindproof,
                                                            SettingsLegs.legsSettings.cargoPantsWaterproof,
                                                            SettingsLegs.legsSettings.cargoPantsProtection,
                                                            SettingsLegs.legsSettings.cargoPantsMobility,
                                                            SettingsLegs.legsSettings.cargoPantsWeight);
                    }
                    else if (properName == "GEAR_ClimbingSocks" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.climbingSocksWarmth,
                                                            SettingsFeet.feetSettings.climbingSocksWetWarmth,
                                                            SettingsFeet.feetSettings.climbingSocksWindproof,
                                                            SettingsFeet.feetSettings.climbingSocksWaterproof,
                                                            SettingsFeet.feetSettings.climbingSocksProtection,
                                                            SettingsFeet.feetSettings.climbingSocksMobility,
                                                            SettingsFeet.feetSettings.climbingSocksWeight);
                    }
                    else if (properName == "GEAR_CombatBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.combatBootsWarmth,
                                                            SettingsFeet.feetSettings.combatBootsWetWarmth,
                                                            SettingsFeet.feetSettings.combatBootsWindproof,
                                                            SettingsFeet.feetSettings.combatBootsWaterproof,
                                                            SettingsFeet.feetSettings.combatBootsProtection,
                                                            SettingsFeet.feetSettings.combatBootsMobility,
                                                            SettingsFeet.feetSettings.combatBootsWeight);
                    }
                    else if (properName == "GEAR_CombatPants" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.combatPantsWarmth,
                                                            SettingsLegs.legsSettings.combatPantsWetWarmth,
                                                            SettingsLegs.legsSettings.combatPantsWindproof,
                                                            SettingsLegs.legsSettings.combatPantsWaterproof,
                                                            SettingsLegs.legsSettings.combatPantsProtection,
                                                            SettingsLegs.legsSettings.combatPantsMobility,
                                                            SettingsLegs.legsSettings.combatPantsWeight);
                    }
                    else if (properName == "GEAR_CottonHoodie" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.hoodieWeight);
                    }
                    else if (properName == "GEAR_CottonScarf" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.cottonScarfWarmth,
                                                            SettingsHead.headSettings.cottonScarfWetWarmth,
                                                            SettingsHead.headSettings.cottonScarfWindproof,
                                                            SettingsHead.headSettings.cottonScarfWaterproof,
                                                            SettingsHead.headSettings.cottonScarfProtection,
                                                            SettingsHead.headSettings.cottonScarfMobility,
                                                            SettingsHead.headSettings.cottonScarfWeight);
                    }
                    else if (properName == "GEAR_CottonShirt" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.dressShirtWeight);
                    }
                    else if (properName == "GEAR_CottonSocks" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.sportsSocksWarmth,
                                                            SettingsFeet.feetSettings.sportsSocksWetWarmth,
                                                            SettingsFeet.feetSettings.sportsSocksWindproof,
                                                            SettingsFeet.feetSettings.sportsSocksWaterproof,
                                                            SettingsFeet.feetSettings.sportsSocksProtection,
                                                            SettingsFeet.feetSettings.sportsSocksMobility,
                                                            SettingsFeet.feetSettings.sportsSocksWeight);
                    }
                    else if (properName == "GEAR_CowichanSweater" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.cowichanSweaterWeight);
                    }
                    else if (properName == "GEAR_Crampons" && SettingsMain.mainSettings.showAccessories != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsAccessories.accessorySettings.cramponsWarmth,
                                                            SettingsAccessories.accessorySettings.cramponsWetWarmth,
                                                            SettingsAccessories.accessorySettings.cramponsWindproof,
                                                            SettingsAccessories.accessorySettings.cramponsWaterproof,
                                                            SettingsAccessories.accessorySettings.cramponsProtection,
                                                            SettingsAccessories.accessorySettings.cramponsMobility,
                                                            SettingsAccessories.accessorySettings.cramponsWeight);
                    }
                    else if (properName == "GEAR_DeerSkinBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.deerskinBootsWarmth,
                                                            SettingsFeet.feetSettings.deerskinBootsWetWarmth,
                                                            SettingsFeet.feetSettings.deerskinBootsWindproof,
                                                            SettingsFeet.feetSettings.deerskinBootsWaterproof,
                                                            SettingsFeet.feetSettings.deerskinBootsProtection,
                                                            SettingsFeet.feetSettings.deerskinBootsMobility,
                                                            SettingsFeet.feetSettings.deerskinBootsWeight);
                    }
                    else if (properName == "GEAR_DeerSkinPants" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.deerskinPantsWarmth,
                                                            SettingsLegs.legsSettings.deerskinPantsWetWarmth,
                                                            SettingsLegs.legsSettings.deerskinPantsWindproof,
                                                            SettingsLegs.legsSettings.deerskinPantsWaterproof,
                                                            SettingsLegs.legsSettings.deerskinPantsProtection,
                                                            SettingsLegs.legsSettings.deerskinPantsMobility,
                                                            SettingsLegs.legsSettings.deerskinPantsWeight);
                    }
                    else if (properName == "GEAR_DownParka" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.urbanParkaWeight);
                    }
                    else if (properName == "GEAR_DownSkiJacket" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.skiJacketWeight);
                    }
                    else if (properName == "GEAR_DownVest" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.downVestWeight);
                    }
                    else if (properName == "GEAR_EarMuffs" && SettingsMain.mainSettings.showAccessories != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsAccessories.accessorySettings.woolEarWrapWarmth,
                                                            SettingsAccessories.accessorySettings.woolEarWrapWetWarmth,
                                                            SettingsAccessories.accessorySettings.woolEarWrapWindproof,
                                                            SettingsAccessories.accessorySettings.woolEarWrapWaterproof,
                                                            SettingsAccessories.accessorySettings.woolEarWrapProtection,
                                                            SettingsAccessories.accessorySettings.woolEarWrapMobility,
                                                            SettingsAccessories.accessorySettings.woolEarWrapWeight);
                    }
                    else if (properName == "GEAR_FishermanSweater" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.fishermansSweaterWeight);
                    }
                    else if (properName == "GEAR_FleeceMittens" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.fleeceMittensWarmth,
                                                            SettingsHands.handsSettings.fleeceMittensWetWarmth,
                                                            SettingsHands.handsSettings.fleeceMittensWindproof,
                                                            SettingsHands.handsSettings.fleeceMittensWaterproof,
                                                            SettingsHands.handsSettings.fleeceMittensProtection,
                                                            SettingsHands.handsSettings.fleeceMittensMobility,
                                                            SettingsHands.handsSettings.fleeceMittensWeight);
                    }
                    else if (properName == "GEAR_FleeceSweater" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.sweatshirtWeight);
                    }
                    else if (properName == "GEAR_Gauntlets" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.gauntletsWarmth,
                                                            SettingsHands.handsSettings.gauntletsWetWarmth,
                                                            SettingsHands.handsSettings.gauntletsWindproof,
                                                            SettingsHands.handsSettings.gauntletsWaterproof,
                                                            SettingsHands.handsSettings.gauntletsProtection,
                                                            SettingsHands.handsSettings.gauntletsMobility,
                                                            SettingsHands.handsSettings.gauntletsWeight);
                    }
                    else if (properName == "GEAR_GreyMotherBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.mountaineeringBootsWarmth,
                                                            SettingsFeet.feetSettings.mountaineeringBootsWetWarmth,
                                                            SettingsFeet.feetSettings.mountaineeringBootsWindproof,
                                                            SettingsFeet.feetSettings.mountaineeringBootsWaterproof,
                                                            SettingsFeet.feetSettings.mountaineeringBootsProtection,
                                                            SettingsFeet.feetSettings.mountaineeringBootsMobility,
                                                            SettingsFeet.feetSettings.mountaineeringBootsWeight);
                    }
                    else if (properName == "GEAR_HeavyParka" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.oldFashionedParkaWeight);
                    }
                    else if (properName == "GEAR_HeavyWoolSweater" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.thickWoolSweaterWeight);
                    }
                    else if (properName == "GEAR_InsulatedBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.insulatedBootsWarmth,
                                                            SettingsFeet.feetSettings.insulatedBootsWetWarmth,
                                                            SettingsFeet.feetSettings.insulatedBootsWindproof,
                                                            SettingsFeet.feetSettings.insulatedBootsWaterproof,
                                                            SettingsFeet.feetSettings.insulatedBootsProtection,
                                                            SettingsFeet.feetSettings.insulatedBootsMobility,
                                                            SettingsFeet.feetSettings.insulatedBootsWeight);
                    }
                    else if (properName == "GEAR_InsulatedPants" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.snowPantsWarmth,
                                                            SettingsLegs.legsSettings.snowPantsWetWarmth,
                                                            SettingsLegs.legsSettings.snowPantsWindproof,
                                                            SettingsLegs.legsSettings.snowPantsWaterproof,
                                                            SettingsLegs.legsSettings.snowPantsProtection,
                                                            SettingsLegs.legsSettings.snowPantsMobility,
                                                            SettingsLegs.legsSettings.snowPantsWeight);
                    }
                    else if (properName == "GEAR_InsulatedVest" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.sportVestWeight);
                    }
                    else if (properName == "GEAR_Jeans" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.jeansWarmth,
                                                            SettingsLegs.legsSettings.jeansWetWarmth,
                                                            SettingsLegs.legsSettings.jeansWindproof,
                                                            SettingsLegs.legsSettings.jeansWaterproof,
                                                            SettingsLegs.legsSettings.jeansProtection,
                                                            SettingsLegs.legsSettings.jeansMobility,
                                                            SettingsLegs.legsSettings.jeansWeight);
                    }
                    else if (properName == "GEAR_LeatherShoes" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.leatherShoesWarmth,
                                                            SettingsFeet.feetSettings.leatherShoesWetWarmth,
                                                            SettingsFeet.feetSettings.leatherShoesWindproof,
                                                            SettingsFeet.feetSettings.leatherShoesWaterproof,
                                                            SettingsFeet.feetSettings.leatherShoesProtection,
                                                            SettingsFeet.feetSettings.leatherShoesMobility,
                                                            SettingsFeet.feetSettings.leatherShoesWeight);
                    }
                    else if (properName == "GEAR_LightParka" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.simpleParkaWeight);
                    }
                    else if (properName == "GEAR_LongUnderwear" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.thermalUnderwearWarmth,
                                                            SettingsLegs.legsSettings.thermalUnderwearWetWarmth,
                                                            SettingsLegs.legsSettings.thermalUnderwearWindproof,
                                                            SettingsLegs.legsSettings.thermalUnderwearWaterproof,
                                                            SettingsLegs.legsSettings.thermalUnderwearProtection,
                                                            SettingsLegs.legsSettings.thermalUnderwearMobility,
                                                            SettingsLegs.legsSettings.thermalUnderwearWeight);
                    }
                    else if (properName == "GEAR_LongUnderwearWool" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.woolLongjohnsWarmth,
                                                            SettingsLegs.legsSettings.woolLongjohnsWetWarmth,
                                                            SettingsLegs.legsSettings.woolLongjohnsWindproof,
                                                            SettingsLegs.legsSettings.woolLongjohnsWaterproof,
                                                            SettingsLegs.legsSettings.woolLongjohnsProtection,
                                                            SettingsLegs.legsSettings.woolLongjohnsMobility,
                                                            SettingsLegs.legsSettings.woolLongjohnsWeight);
                    }
                    else if (properName == "GEAR_MackinawJacket" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.mackinawJacketWeight);
                    }
                    else if (properName == "GEAR_MilitaryParka" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.militaryCoatWeight);
                    }
                    else if (properName == "GEAR_Mittens" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.woolMittensWarmth,
                                                            SettingsHands.handsSettings.woolMittensWetWarmth,
                                                            SettingsHands.handsSettings.woolMittensWindproof,
                                                            SettingsHands.handsSettings.woolMittensWaterproof,
                                                            SettingsHands.handsSettings.woolMittensProtection,
                                                            SettingsHands.handsSettings.woolMittensMobility,
                                                            SettingsHands.handsSettings.woolMittensWeight);
                    }
                    else if (properName == "GEAR_MooseHideBag" && SettingsMain.mainSettings.showAccessories != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelWarmth,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelWetWarmth,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelWindproof,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelWaterproof,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelProtection,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelMobility,
                                                            SettingsAccessories.accessorySettings.moosehideSatchelWeight);
                    }
                    else if (properName == "GEAR_MooseHideCloak" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.moosehideCloakWeight);
                    }
                    else if (properName == "GEAR_MuklukBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.mukluksWarmth,
                                                            SettingsFeet.feetSettings.mukluksWetWarmth,
                                                            SettingsFeet.feetSettings.mukluksWindproof,
                                                            SettingsFeet.feetSettings.mukluksWaterproof,
                                                            SettingsFeet.feetSettings.mukluksProtection,
                                                            SettingsFeet.feetSettings.mukluksMobility,
                                                            SettingsFeet.feetSettings.mukluksWeight);
                    }
                    else if (properName == "GEAR_PlaidShirt" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.plaidShirtWeight);
                    }
                    else if (properName == "GEAR_PremiumWinterCoat" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.expeditionParkaWeight);
                    }
                    else if (properName == "GEAR_QualityWinterCoat" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.marinersPeaCoatWeight);
                    }
                    else if (properName == "GEAR_RabbitskinHat" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.rabbitskinHatWarmth,
                                                            SettingsHead.headSettings.rabbitskinHatWetWarmth,
                                                            SettingsHead.headSettings.rabbitskinHatWindproof,
                                                            SettingsHead.headSettings.rabbitskinHatWaterproof,
                                                            SettingsHead.headSettings.rabbitskinHatProtection,
                                                            SettingsHead.headSettings.rabbitskinHatMobility,
                                                            SettingsHead.headSettings.rabbitskinHatWeight);
                    }
                    else if (properName == "GEAR_RabbitSkinMittens" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.rabbitskinMittsWarmth,
                                                            SettingsHands.handsSettings.rabbitskinMittsWarmth,
                                                            SettingsHands.handsSettings.rabbitskinMittsWindproof,
                                                            SettingsHands.handsSettings.rabbitskinMittsWaterproof,
                                                            SettingsHands.handsSettings.rabbitskinMittsProtection,
                                                            SettingsHands.handsSettings.rabbitskinMittsMobility,
                                                            SettingsHands.handsSettings.rabbitskinMittsWeight);
                    }
                    else if (properName == "GEAR_SkiBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.skiBootsWarmth,
                                                            SettingsFeet.feetSettings.skiBootsWetWarmth,
                                                            SettingsFeet.feetSettings.skiBootsWindproof,
                                                            SettingsFeet.feetSettings.skiBootsWaterproof,
                                                            SettingsFeet.feetSettings.skiBootsProtection,
                                                            SettingsFeet.feetSettings.skiBootsMobility,
                                                            SettingsFeet.feetSettings.skiBootsWeight);
                    }
                    else if (properName == "GEAR_SkiGloves" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.skiGlovesWarmth,
                                                            SettingsHands.handsSettings.skiGlovesWetWarmth,
                                                            SettingsHands.handsSettings.skiGlovesWindproof,
                                                            SettingsHands.handsSettings.skiGlovesWaterproof,
                                                            SettingsHands.handsSettings.skiGlovesProtection,
                                                            SettingsHands.handsSettings.skiGlovesMobility,
                                                            SettingsHands.handsSettings.skiGlovesWeight);
                    }
                    else if (properName == "GEAR_SkiJacket" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.lightShellWeight);
                    }
                    else if (properName == "GEAR_TeeShirt" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.tshirtWeight);
                    }
                    else if (properName == "GEAR_Toque" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.woolToqueWarmth,
                                                            SettingsHead.headSettings.woolToqueWetWarmth,
                                                            SettingsHead.headSettings.woolToqueWindproof,
                                                            SettingsHead.headSettings.woolToqueWaterproof,
                                                            SettingsHead.headSettings.woolToqueProtection,
                                                            SettingsHead.headSettings.woolToqueMobility,
                                                            SettingsHead.headSettings.woolToqueWeight);
                    }
                    else if (properName == "GEAR_WolfSkinCape" && SettingsMain.mainSettings.showTorsoOuter != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatWetWarmth,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatWindproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatWaterproof,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatProtection,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatMobility,
                                                            SettingsTorsoOuter.torsoOuterSettings.wolfskinCoatWeight);
                    }
                    else if (properName == "GEAR_WoolShirt" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.woolShirtWeight);
                    }
                    else if (properName == "GEAR_WoolSocks" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.woolSocksWarmth,
                                                            SettingsFeet.feetSettings.woolSocksWetWarmth,
                                                            SettingsFeet.feetSettings.woolSocksWindproof,
                                                            SettingsFeet.feetSettings.woolSocksWaterproof,
                                                            SettingsFeet.feetSettings.woolSocksProtection,
                                                            SettingsFeet.feetSettings.woolSocksMobility,
                                                            SettingsFeet.feetSettings.woolSocksWeight);
                    }
                    else if (properName == "GEAR_WoolSweater" && SettingsMain.mainSettings.showTorsoInner != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterWetWarmth,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterWindproof,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterWaterproof,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterProtection,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterMobility,
                                                            SettingsTorsoInner.torsoInnerSettings.thinWoolSweaterWeight);
                    }
                    else if (properName == "GEAR_WoolWrap" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.longWoolScarfWarmth,
                                                            SettingsHead.headSettings.longWoolScarfWetWarmth,
                                                            SettingsHead.headSettings.longWoolScarfWindproof,
                                                            SettingsHead.headSettings.longWoolScarfWaterproof,
                                                            SettingsHead.headSettings.longWoolScarfProtection,
                                                            SettingsHead.headSettings.longWoolScarfMobility,
                                                            SettingsHead.headSettings.longWoolScarfWeight);
                    }
                    else if (properName == "GEAR_WoolWrapCap" && SettingsMain.mainSettings.showHead != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHead.headSettings.fleeceCowlWarmth,
                                                            SettingsHead.headSettings.fleeceCowlWetWarmth,
                                                            SettingsHead.headSettings.fleeceCowlWindproof,
                                                            SettingsHead.headSettings.fleeceCowlWaterproof,
                                                            SettingsHead.headSettings.fleeceCowlProtection,
                                                            SettingsHead.headSettings.fleeceCowlMobility,
                                                            SettingsHead.headSettings.fleeceCowlWeight);
                    }
                    else if (properName == "GEAR_WorkBoots" && SettingsMain.mainSettings.showFeet != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsFeet.feetSettings.workBootsWarmth,
                                                            SettingsFeet.feetSettings.workBootsWetWarmth,
                                                            SettingsFeet.feetSettings.workBootsWindproof,
                                                            SettingsFeet.feetSettings.workBootsWaterproof,
                                                            SettingsFeet.feetSettings.workBootsProtection,
                                                            SettingsFeet.feetSettings.workBootsMobility,
                                                            SettingsFeet.feetSettings.workBootsWeight);
                    }
                    else if (properName == "GEAR_WorkGloves" && SettingsMain.mainSettings.showHands != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsHands.handsSettings.workGlovesWarmth,
                                                            SettingsHands.handsSettings.workGlovesWetWarmth,
                                                            SettingsHands.handsSettings.workGlovesWindproof,
                                                            SettingsHands.handsSettings.workGlovesWaterproof,
                                                            SettingsHands.handsSettings.workGlovesProtection,
                                                            SettingsHands.handsSettings.workGlovesMobility,
                                                            SettingsHands.handsSettings.workGlovesWeight);
                    }
                    else if (properName == "GEAR_WorkPants" && SettingsMain.mainSettings.showLegs != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsLegs.legsSettings.workPantsWarmth,
                                                            SettingsLegs.legsSettings.workPantsWetWarmth,
                                                            SettingsLegs.legsSettings.workPantsWindproof,
                                                            SettingsLegs.legsSettings.workPantsWaterproof,
                                                            SettingsLegs.legsSettings.workPantsProtection,
                                                            SettingsLegs.legsSettings.workPantsMobility,
                                                            SettingsLegs.legsSettings.workPantsWeight);
                    }
                    else if (properName == "GEAR_BeanieCap" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.beanieCapWarmth,
                                                            SettingsModClothes.modClothesSettings.beanieCapWetWarmth,
                                                            SettingsModClothes.modClothesSettings.beanieCapWindproof,
                                                            SettingsModClothes.modClothesSettings.beanieCapWaterproof,
                                                            SettingsModClothes.modClothesSettings.beanieCapProtection,
                                                            SettingsModClothes.modClothesSettings.beanieCapMobility,
                                                            SettingsModClothes.modClothesSettings.beanieCapWeight);
                    }
                    else if (properName == "GEAR_SkiGoggles" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.skiGogglesWarmth,
                                                            SettingsModClothes.modClothesSettings.skiGogglesWetWarmth,
                                                            SettingsModClothes.modClothesSettings.skiGogglesWindproof,
                                                            SettingsModClothes.modClothesSettings.skiGogglesWaterproof,
                                                            SettingsModClothes.modClothesSettings.skiGogglesProtection,
                                                            SettingsModClothes.modClothesSettings.skiGogglesMobility,
                                                            SettingsModClothes.modClothesSettings.skiGogglesWeight);
                    }
                    else if (properName == "GEAR_SkiMask" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.skiMaskWarmth,
                                                            SettingsModClothes.modClothesSettings.skiMaskWetWarmth,
                                                            SettingsModClothes.modClothesSettings.skiMaskWindproof,
                                                            SettingsModClothes.modClothesSettings.skiMaskWaterproof,
                                                            SettingsModClothes.modClothesSettings.skiMaskProtection,
                                                            SettingsModClothes.modClothesSettings.skiMaskMobility,
                                                            SettingsModClothes.modClothesSettings.skiMaskWeight);
                    }
                    else if (properName == "GEAR_PrisonCoat" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.prisonCoatWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonCoatWetWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonCoatWindproof,
                                                            SettingsModClothes.modClothesSettings.prisonCoatWaterproof,
                                                            SettingsModClothes.modClothesSettings.prisonCoatProtection,
                                                            SettingsModClothes.modClothesSettings.prisonCoatMobility,
                                                            SettingsModClothes.modClothesSettings.prisonCoatWeight);
                    }
                    else if (properName == "GEAR_PrisonPants" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.prisonPantsWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonPantsWetWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonPantsWindproof,
                                                            SettingsModClothes.modClothesSettings.prisonPantsWaterproof,
                                                            SettingsModClothes.modClothesSettings.prisonPantsProtection,
                                                            SettingsModClothes.modClothesSettings.prisonPantsMobility,
                                                            SettingsModClothes.modClothesSettings.prisonPantsWeight);
                    }
                    else if (properName == "GEAR_PrisonShirt" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.prisonShirtWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonShirtWetWarmth,
                                                            SettingsModClothes.modClothesSettings.prisonShirtWindproof,
                                                            SettingsModClothes.modClothesSettings.prisonShirtWaterproof,
                                                            SettingsModClothes.modClothesSettings.prisonShirtProtection,
                                                            SettingsModClothes.modClothesSettings.prisonShirtMobility,
                                                            SettingsModClothes.modClothesSettings.prisonShirtWeight);
                    }
                    else if (properName == "GEAR_BearskinLeggings" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsWarmth,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsWetWarmth,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsWindproof,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsWaterproof,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsProtection,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsMobility,
                                                            SettingsModClothes.modClothesSettings.bearskinLeggingsWeight);
                    }
                    else if (properName == "GEAR_DeerskinCoat" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatWarmth,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatWetWarmth,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatWindproof,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatWaterproof,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatProtection,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatMobility,
                                                            SettingsModClothes.modClothesSettings.deerskinCoatWeight);
                    }
                    else if (properName == "GEAR_DeerskinGloves" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesWarmth,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesWetWarmth,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesWindproof,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesWaterproof,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesProtection,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesMobility,
                                                            SettingsModClothes.modClothesSettings.deerskinGlovesWeight);
                    }
                    else if (properName == "GEAR_WolfskinBoots" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsWetWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsWindproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsWaterproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsProtection,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsMobility,
                                                            SettingsModClothes.modClothesSettings.wolfskinBootsWeight);
                    }
                    else if (properName == "GEAR_WolfskinHat" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatWetWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatWindproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatWaterproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatProtection,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatMobility,
                                                            SettingsModClothes.modClothesSettings.wolfskinHatWeight);
                    }
                    else if (properName == "GEAR_wolfscarf" && SettingsMain.mainSettings.showModClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfWetWarmth,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfWindproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfWaterproof,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfProtection,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfMobility,
                                                            SettingsModClothes.modClothesSettings.wolfskinScarfWeight);
                    }
                    else if (properName == "GEAR_ImprovisedCrampons" && SettingsMain.mainSettings.showAccessories != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsAccessories.accessorySettings.improvCramponsWarmth,
                                                            SettingsAccessories.accessorySettings.improvCramponsWetWarmth,
                                                            SettingsAccessories.accessorySettings.improvCramponsWindproof,
                                                            SettingsAccessories.accessorySettings.improvCramponsWaterproof,
                                                            SettingsAccessories.accessorySettings.improvCramponsProtection,
                                                            SettingsAccessories.accessorySettings.improvCramponsMobility,
                                                            SettingsAccessories.accessorySettings.improvCramponsWeight);
                    }
                    else if (properName == "GEAR_JacketLeatherFlightA" && SettingsMain.mainSettings.showDLCClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsDLC.dlcSettings.flightJacketWarmth,
                                                            SettingsDLC.dlcSettings.flightJacketWetWarmth,
                                                            SettingsDLC.dlcSettings.flightJacketWindproof,
                                                            SettingsDLC.dlcSettings.flightJacketWaterproof,
                                                            SettingsDLC.dlcSettings.flightJacketProtection,
                                                            SettingsDLC.dlcSettings.flightJacketMobility,
                                                            SettingsDLC.dlcSettings.flightJacketWeight);
                    }
                    else if (properName == "GEAR_JerseyHockeyA" && SettingsMain.mainSettings.showDLCClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsDLC.dlcSettings.hockeyJerseyWarmth,
                                                            SettingsDLC.dlcSettings.hockeyJerseyWetWarmth,
                                                            SettingsDLC.dlcSettings.hockeyJerseyWindproof,
                                                            SettingsDLC.dlcSettings.hockeyJerseyWaterproof,
                                                            SettingsDLC.dlcSettings.hockeyJerseyProtection,
                                                            SettingsDLC.dlcSettings.hockeyJerseyMobility,
                                                            SettingsDLC.dlcSettings.hockeyJerseyWeight);
                    }
                    else if (properName == "GEAR_HatLeatherAviatorA" && SettingsMain.mainSettings.showDLCClothes != ShowHideDisable.Disable)
                    {
                        Patches.changePostfabParameters(__instance,
                                                            SettingsDLC.dlcSettings.aviatorCapWarmth,
                                                            SettingsDLC.dlcSettings.aviatorCapWetWarmth,
                                                            SettingsDLC.dlcSettings.aviatorCapWindproof,
                                                            SettingsDLC.dlcSettings.aviatorCapWaterproof,
                                                            SettingsDLC.dlcSettings.aviatorCapProtection,
                                                            SettingsDLC.dlcSettings.aviatorCapMobility,
                                                            SettingsDLC.dlcSettings.aviatorCapWeight);
                    }

                    


                }
            }
        }
        public static void updateDecayRates(GearItem __instance)
        {
            //MelonLogger.Msg(__instance.name.ToString() + " ORIGINAL DailyHPDecay: " + __instance.m_DailyHPDecay.ToString());
            //MelonLogger.Msg(__instance.name.ToString() + " ORIGINAL DailyHPDecayWhenWornInside: " + __instance.m_ClothingItem.m_DailyHPDecayWhenWornInside.ToString());
            //MelonLogger.Msg(__instance.name.ToString() + " ORIGINAL DailyHPDecayWhenWornOutside: " + __instance.m_ClothingItem.m_DailyHPDecayWhenWornOutside.ToString());
            __instance.m_DailyHPDecay *= SettingsMain.mainSettings.clothingDecayDaily;
            __instance.m_ClothingItem.m_DailyHPDecayWhenWornInside *= SettingsMain.mainSettings.clothingDecayIndoors;
            __instance.m_ClothingItem.m_DailyHPDecayWhenWornOutside *= SettingsMain.mainSettings.clothingDecayOutdoors;
            //MelonLogger.Msg(__instance.name.ToString() + " NEW DailyHPDecay: " + __instance.m_DailyHPDecay.ToString());
            //MelonLogger.Msg(__instance.name.ToString() + " NEW DailyHPDecayWhenWornInside: " + __instance.m_ClothingItem.m_DailyHPDecayWhenWornInside.ToString());
            //MelonLogger.Msg(__instance.name.ToString() + " NEW DailyHPDecayWhenWornOutside: " + __instance.m_ClothingItem.m_DailyHPDecayWhenWornOutside.ToString());
        }

        public static void changePostfabParameters(GearItem __instance, float warmth, float wetwarmth, float windproof, float waterproof, float protection, float mobility, float weight)
        {
            __instance.m_ClothingItem.m_Warmth = warmth;
            __instance.m_ClothingItem.m_WarmthWhenWet = wetwarmth;
            __instance.m_ClothingItem.m_Windproof = windproof;
            __instance.m_ClothingItem.m_Waterproofness = waterproof;
            __instance.m_ClothingItem.m_Toughness = protection;
            __instance.m_ClothingItem.m_SprintBarReductionPercent = mobility;
            __instance.m_WeightKG = weight;
        }

        //public static void ChangePrefabParameters(string name, float warmth, float wetwarmth, float windproof, float waterproof, float protection, float mobility, float weight)
        //{
        //    GearItem item = GearItem.LoadGearItemPrefab(name);
        //    if (item == null) return;
        //    item.m_ClothingItem.m_Warmth = warmth;
        //    item.m_ClothingItem.m_WarmthWhenWet = wetwarmth;
        //    item.m_ClothingItem.m_Windproof = windproof;
        //    item.m_ClothingItem.m_Waterproofness = waterproof;
        //    item.m_ClothingItem.m_Toughness = protection;
        //    item.m_ClothingItem.m_SprintBarReductionPercent = mobility;
        //    item.m_WeightKG = weight;
        //    if (SettingsMain.mainSettings.clothingDecay == Choice.Custom)
        //    {
        //        updateDecayRates(item);
        //    }
        //}
    }
}