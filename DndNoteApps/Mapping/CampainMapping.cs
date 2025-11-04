using System;
using DndNoteApps.DTO;
using DndNoteApps.Entities;

namespace DndNoteApps.Mapping;

public static class CampainMapping
{
    public static Campaign ToEntity(this CreateCampaignDto campaign)
    {
        return new Campaign
        {
            Name = campaign.Name,
            StartDate = campaign.StartDate
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
