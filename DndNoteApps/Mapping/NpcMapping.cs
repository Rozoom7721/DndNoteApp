using System;
using DndNoteApps.DTO;
using DndNoteApps.Entities;

namespace DndNoteApps.Mapping;

public static class NpcMapping
{
    public static Npc ToEntity(this CreateNpcDto npc)
    {
        return new Npc
        {
            Name = npc.Name,
            Race = npc.Race,
            PlaceFound = npc.PlaceFound,
            AttitudeTowardsPlayers = npc.AttitudeTowardsPlayers,
            PlayerNote = npc.PlayerNote,
            DmNote = npc.DmNote,
            CampaignId = npc.CampaignId
        };
    }
    public static Npc ToEntity(this UpdateNpcDto npc, int id)
    {
        return new Npc
        {
            Id = id,
            Name = npc.Name,
            Race = npc.Race,
            PlaceFound = npc.PlaceFound,
            AttitudeTowardsPlayers = npc.AttitudeTowardsPlayers,
            PlayerNote = npc.PlayerNote,
            DmNote = npc.DmNote,
            CampaignId = npc.CampaignId
        };
    }

}
