using System;

namespace DndNoteApps.Entities;

public class Npc
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Race { get; set; }
    public string? PlaceFound { get; set; }
    public string? AttitudeTowardsPlayers { get; set; }
    public string? PlayerNote { get; set; }
    public string? DmNote { get; set; }
    public string? Description { get; set; }
    public int CampaignId { get; set; }
    public Campaign? Campaign { get; set; }
    //public int QuestId { get; set; }
    //public Quest? Quest { get; set; } do dodania pozniej

}
