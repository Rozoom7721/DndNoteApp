using System;

namespace DndNoteApps.Entities;

public class Quest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Objective { get; set; }
    public string? Reward { get; set; } 
    public string? Description { get; set; }
    public Npc? Npc { get; set; }
    public int NpcId { get; set; }
    public Campaign? Campaign { get; set; } 
    public int CampaignId { get; set; }
    //public Place? Place { get; set; }
    //public int PlaceId { get; set; }
    //public Loot? Loot { get; set; }
    //public int LootId { get; set; }
}