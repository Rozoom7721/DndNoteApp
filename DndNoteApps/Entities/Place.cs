using System;

namespace DndNoteApps.Entities;

public class Place
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Fraction { get; set; }
    public string? PlayerNote { get; set; }
    public string? DmNote { get; set; }
    public string? Description { get; set; }
    public int CampaignId { get; set; }
    public Campaign? Campaign { get; set; }
    public int QuestId { get; set; }
    public ICollection<Quest>? Quest { get; set; }
    public int NpcId { get; set; }
    public ICollection<Npc>? Npc { get; set; }
}
