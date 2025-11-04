using System;
using System.Data;
using DndNoteApps.Data;
using DndNoteApps.DTO;
using DndNoteApps.Entities;
using DndNoteApps.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.EndPoints;

public static class QuestEndPoint
{
    const string GetQuestEndPointName = "GetQuest";

    public static RouteGroupBuilder MapQuestEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/quests");

        //GET /api/quests
        group.MapGet("/", async (DndNoteContext dbContext) =>
        {
            await dbContext.Quests
                .AsNoTracking()
                .ToListAsync();
        });

        //GET /api/quests/{id}
        group.MapGet("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            Quest? quest = await dbContext.Quests.FindAsync(id);

            return quest is null ? Results.NotFound() : Results.Ok(quest);
        })
        .WithName(GetQuestEndPointName);

        //POST /api/quests
        group.MapPost("/", async (CreateQuestDto newQuest, DndNoteContext dbContext) =>
        {
            Quest questToAdd = newQuest.ToEntity();

            dbContext.Quests.Add(questToAdd);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetQuestEndPointName,
                new { id = questToAdd.Id },
                questToAdd
            );
        });

        //PUT /api/quests/{id}
        group.MapPut("/{id}", async (UpdateQuestDto updateQuest, DndNoteContext dbContext, int id) =>
        {
            var existingQuest = await dbContext.Quests.FindAsync(id);

            if (existingQuest is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingQuest).CurrentValues.SetValues(updateQuest.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /api/quests/{id}
        group.MapDelete("/{id}", async (DndNoteContext dbContext, int id) =>
        {
            await dbContext.Quests
                .Where(quest => quest.Id == id)
                .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
