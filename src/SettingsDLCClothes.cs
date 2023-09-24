using ModSettings;
using UnityEngine;

namespace ClothingTweaker
{

    internal class ClothingTweakerDLCSettings : JsonModSettings
    {
        public ClothingTweakerDLCSettings(string relativeJsonFilePath) : base(relativeJsonFilePath)
        {
        }

        // Flight Jacket
        [Section("Flight Jacket")]
        [Name("Warmth")]
        [Description("Default is 3°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float flightJacketWarmth = 3.0f;

        [Name("Warmth When Wet")]
        [Description("Default is 0.75°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float flightJacketWetWarmth = 0.75f;

        [Name("Windproof")]
        [Description("Default is 5°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float flightJacketWindproof = 5.0f;

        [Name("Waterproof")]
        [Description("Default is 50%")]
        [Slider(0f, 1f, 101, NumberFormat = "{0:P0}")]
        public float flightJacketWaterproof = 0.5f;

        [Name("Protection")]
        [Description("Default is 10%")]
        [Slider(0f, 50f, 51, NumberFormat = "{0:F0}%")]
        public float flightJacketProtection = 10.0f;

        [Name("Mobility")]
        [Description("Default is 5%")]
        [Slider(0f, 25f, 26, NumberFormat = "{0:F0}%")]
        public float flightJacketMobility = 5.0f;

        [Name("Weight")]
        [Description("Default is 2.5 kg")]
        [Slider(0f, 5f, 101, NumberFormat = "{0:0.##} kg")]
        public float flightJacketWeight = 2.5f;


        // Hockey Jersey
        [Section("Hockey Jersey")]
        [Name("Warmth")]
        [Description("Default is 1°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float hockeyJerseyWarmth = 1.0f;

        [Name("Warmth When Wet")]
        [Description("Default is 0.75°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float hockeyJerseyWetWarmth = 0.75f;

        [Name("Windproof")]
        [Description("Default is 3.0°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float hockeyJerseyWindproof = 3.0f;

        [Name("Waterproof")]
        [Description("Default is 15%")]
        [Slider(0f, 1f, 101, NumberFormat = "{0:P0}")]
        public float hockeyJerseyWaterproof = 0.15f;

        [Name("Protection")]
        [Description("Default is 3%")]
        [Slider(0f, 50f, 51, NumberFormat = "{0:F0}%")]
        public float hockeyJerseyProtection = 3.0f;

        [Name("Mobility")]
        [Description("Default is 0%")]
        [Slider(0f, 25f, 26, NumberFormat = "{0:F0}%")]
        public float hockeyJerseyMobility = 0.0f;

        [Name("Weight")]
        [Description("Default is 0.3 kg")]
        [Slider(0f, 1f, 21, NumberFormat = "{0:0.##} kg")]
        public float hockeyJerseyWeight = 0.3f;


        // Aviator Cap
        [Section("Aviator Cap")]
        [Name("Warmth")]
        [Description("Default is 2°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float aviatorCapWarmth = 2.0f;

        [Name("Warmth When Wet")]
        [Description("Default is 1°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float aviatorCapWetWarmth = 1f;

        [Name("Windproof")]
        [Description("Default is 2°C")]
        [Slider(0f, 10f, 41, NumberFormat = "{0:0.##}°C")]
        public float aviatorCapWindproof = 2.0f;

        [Name("Waterproof")]
        [Description("Default is 30%")]
        [Slider(0f, 1f, 101, NumberFormat = "{0:P0}")]
        public float aviatorCapWaterproof = 0.3f;

        [Name("Protection")]
        [Description("Default is 4%")]
        [Slider(0f, 50f, 51, NumberFormat = "{0:F0}%")]
        public float aviatorCapProtection = 4.0f;

        [Name("Mobility")]
        [Description("Default is 0%")]
        [Slider(0f, 25f, 26, NumberFormat = "{0:F0}%")]
        public float aviatorCapMobility = 0.0f;

        [Name("Weight")]
        [Description("Default is 0.3 kg")]
        [Slider(0f, 0.5f, 11, NumberFormat = "{0:0.##} kg")]
        public float aviatorCapWeight = 0.3f;


        protected override void OnConfirm()
        {
            base.OnConfirm();
        }
    }

    internal static class SettingsDLC
    {
        public static ClothingTweakerDLCSettings dlcSettings;

        public static void OnLoad()
        {
            if (SettingsMain.mainSettings.showDLCClothes != ShowHideDisable.Disable)
            {
                dlcSettings = new ClothingTweakerDLCSettings("ClothingTweakerDLC");
                if (SettingsMain.mainSettings.showDLCClothes == ShowHideDisable.Show) dlcSettings.AddToModSettings("Clothing Tweaker: DLC");
            }
        }
    }
}