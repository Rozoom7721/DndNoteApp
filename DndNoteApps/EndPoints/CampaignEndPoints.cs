using System;
using DndNoteApps.Data;
using DndNoteApps.DTO;
using DndNoteApps.Entities;
using DndNoteApps.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.EndPoints;

public static class CampaignEndPoints
{
    const string GetGameEndpointName = "GetCampaign";
    
    public static RouteGroupBuilder MapCampaignEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/campaigns");

        //GET /api/campaigns
        group.MapGet("/", async (DndNoteContext dbContext) =>
            await dbContext.Campaigns
            .AsNoTracking()
            .ToListAsync());

        //GET /api/campaigns/{id}
        group.MapGet("/{id}", async (int id, DndNoteContext dbContext) =>
        {
            Campaign? campaign = await dbContext.Campaigns.FindAsync(id);

            return campaign is null ? Results.NotFound() : Results.Ok(campaign);
        })
        .WithName(GetGameEndpointName);

        //POST /api/campaigns
        group.MapPost("/", async (CreateCampaignDto newCampaign, DndNoteContext dbContext) =>
        {
            try
            {
                Campaign campaignToAdd = newCampaign.ToEntity();

                dbContext.Campaigns.Add(campaignToAdd);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGameEndpointName,
                    new { id = campaignToAdd.Id },
                    campaignToAdd
                );
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });

        //PUT /api/campaigns/{id}
        group.MapPut("/{id}", async (int id, UpdateCampaignDto updatedCampaign, DndNoteContext dbContext) =>
        {
            var existingCampaign = await dbContext.Campaigns.FindAsync(id);

            if (existingCampaign is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingCampaign).CurrentValues.SetValues(updatedCampaign.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //Delete /api/campaigns/{id}
        group.MapDelete("/{id}", async (int id, DndNoteContext dbContext) =>
        {
            await dbContext.Campaigns
                .Where(campaign => campaign.Id == id)
                .ExecuteDeleteAsync();
            return Results.NoContent();
        });
        return group;
    }
}
