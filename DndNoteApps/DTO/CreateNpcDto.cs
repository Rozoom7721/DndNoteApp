using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace DndNoteApps.DTO;

public record class CreateNpcDto(
    [Required][StringLength(50)] string Name,
    string Race,
    string Description,
    string PlaceFound,
    string AttitudeTowardsPlayers,
    string PlayerNote,
    string DmNote,
    [Required]int CampaignId,
    [Required]int QuestId
)
{

}
