namespace DndNoteApps.DTO;

public record class CreateSesionNoteDto(
    int CampaignId,
    DateOnly SessionDate,
    string NoteContent,
    int PlayerId
);
