using System;
using DndNoteApps.DTO;
using DndNoteApps.Entities;

namespace DndNoteApps.Mapping;

public static class PlaceMapping
{
    public static Place ToEntity(this CreatePlaceDto place)
    {
        return new Place
        {
            Name = place.Name,
            Fraction = place.Fraction,
            PlayerNote = place.PlayerNote,
            DmNote = place.DmNote,
            Description = place.Description,
            CampaignId = place.CampaignId
        };
    }
    public static Place ToEntity(this UpdatePlaceDto place, int id)
    {
        return new Place
        {
            Id = id,
            Name = place.Name,
            Fraction = place.Fraction,
            PlayerNote = place.PlayerNote,
            DmNote = place.DmNote,
            Description = place.Description,
            CampaignId = place.CampaignId
        };
    }
}
