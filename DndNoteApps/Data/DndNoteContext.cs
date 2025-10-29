using System;
using DndNoteApps.Entities;
using Microsoft.EntityFrameworkCore;

namespace DndNoteApps.Data;

public class DndNoteContext(DbContextOptions<DndNoteContext> options) 
: DbContext(options)
{
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Npc> Npcs => Set<Npc>();
    public DbSet<SesionNote> SesionNotes => Set<SesionNote>();
}