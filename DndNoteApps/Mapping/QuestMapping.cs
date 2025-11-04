using System;
using DndNoteApps.DTO;
using DndNoteApps.Entities;

namespace DndNoteApps.Mapping;

public static class QuestMapping
{
    public static Quest ToEntity(this CreateQuestDto quest)
    {
        return new Quest
        {
            Name = quest.Name,
            Objective = quest.Objective,
            Reward = quest.Reward,
            Description = quest.Description,
            NpcId = quest.NpcId,
            CampaignId = quest.CampaignId
        };
    }
    public static Quest ToEntity(this UpdateQuestDto quest, int id)
    {
        return new Quest
        {
            Id = id,
            Name = quest.Name,
            Objective = quest.Objective,
            Reward = quest.Reward,
            Description = quest.Description,
            NpcId = quest.NpcId,
            CampaignId = quest.CampaignId
        };
    }
}
