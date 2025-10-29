using System;
using DndNoteApps.DTO;
using DndNoteApps.Entities;

namespace DndNoteApps.Mapping;

public static class CampainMapping
{
    public static Campaign ToEntity(this CreateCampaignDto dto)
    {
        return new Campaign
        {
            Name = dto.Name,
            StartDate = dto.StartDate
        };
    }
    public static Campaign ToEntity(this UpdateCampaignDto campaign, int id)
    {
        return new Campaign
        {
            Id = id,
            Name = campaign.Name,
            StartDate = campaign.StartDate
        };
    }
}
