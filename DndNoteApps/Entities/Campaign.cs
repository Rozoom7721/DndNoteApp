using System;

namespace DndNoteApps.Entities;

public class Campaign
{
    public int Id {get; set; }
    public required string Name { get; set; }
    public DateOnly StartDate { get; set; }
    //public int DungeonMasterId { get; set; }
}
