using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace WastedEncounters;

public class Settings
{
    [MaintainOrder]
    [Tooltip("If enabled, patch base difficulty modifiers for encounter zones, making them slightly more challenging.")]
    public bool PatchBaseDifficulty { get; set; } = false;
    
    [MaintainOrder]
    [SettingName("Customize Base Difficulty Game Settings")]
    [Tooltip("Set the new difficulty multipliers for leveled NPCs. Defaults are slightly more challenging than vanilla.")]
    public Dictionary<string, float> NewGameSettings { get; set; } = new()
    {
        ["fLeveledActorMultEasy"] = 0.75f,
        ["fLeveledActorMultMedium"] = 1,
        ["fLeveledActorMultHard"] = 1.25f,
        ["fLeveledActorMultVeryHard"] = 1.5f,
    };
    
    [MaintainOrder]
    [SettingName("Encounter Zones Never Reset")]
    [Tooltip("If enabled, all encounter zones will be set to Never Reset. Use with caution.")]
    public bool NeverResets { get; set; } = false;
    
    [MaintainOrder]
    [SettingName("Encounter Zone Disable Combat Boundary")]
    [Tooltip("If enabled, all encounter zones will have Combat Boundaries disabled. Use with caution.")]
    public bool DisableCombatBoundary { get; set; } = false;
    
    [MaintainOrder]
    [SettingName("Minimum Level To 1")]
    [Tooltip("If enabled, all encounter zones will have a minimum level of 1. Overrides manual Encounter Zone settings.")]
    public bool MinLevelOne { get; set; } = false;
    
    [MaintainOrder]
    [SettingName("Custom Minimum Levels for Encounter Zones")]
    [Tooltip("Set the new Encounter Zone Minimum Levels manually. If an Encounter Zone is missing from the list, the Vanilla minimum level is used.")]
    public List<EncounterZoneEntry> EncounterZonesEntries { get; set; } = [];
    
    [MaintainOrder]
    [SettingName("Maximum Level")]
    [Tooltip("By default, all Encounter Zones will now have uncapped max levels. Set this to greater than 0 to limit the max level based on the min level.")]
    public int MaxLevel { get; set; } = 0;
}

public class EncounterZoneEntry
{
    public List<IFormLinkGetter<IEncounterZoneGetter>> EncounterZones { get; set; } = [];
    
    public int NewMinLevel { get; set; } = -1;
}