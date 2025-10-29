using System;

namespace DndNoteApps.Entities;

public class SesionNote
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign? Campaign { get; set; }
    public DateOnly SessionDate { get; set; }
    public string? NoteContent { get; set; }
    //public int PlayerId { get; set; }
}
